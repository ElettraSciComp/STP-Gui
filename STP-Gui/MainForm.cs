/***************************************************************************/
/* (C) 2016 Elettra - Sincrotrone Trieste S.C.p.A.. All rights reserved.   */
/*                                                                         */
/*                                                                         */
/* This file is part of STP-Gui, the .NET Graphical User Interface of      */
/* SYRMEP Tomo Project, a software tool for the reconstruction of          */
/* experimental CT datasets.                                               */
/*                                                                         */
/* STP-Gui is free software: you can redistribute it and/or modify it      */
/* under the terms of the GNU General Public License as published by the   */
/* Free Software Foundation, either version 3 of the License, or (at your  */
/* option) any later version.                                              */
/*                                                                         */
/* STP-Gui is distributed in the hope that it will be useful, but WITHOUT  */
/* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or   */
/* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License    */
/* for more details.                                                       */
/*                                                                         */
/* You should have received a copy of the GNU General Public License       */
/* along with STP-Gui. If not, see <http://www.gnu.org/licenses/>.         */
/*                                                                         */
/***************************************************************************/

//
// Author: Francesco Brun
// Last modified: July, 8th 2016
//


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Globalization;
using System.Xml;

using SYRMEPTomoProject.Jobs;

namespace SYRMEPTomoProject
{
    public partial class MainForm : Form
    {
        private HourGlass mGlass;
        private bool m_bLayoutCalled = false;
        private DateTime mDt;

        private JobMonitor mJobMonitor;
        private bool mFirstRun = false;

        PerformanceCounter mCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter mRAMCounter = new PerformanceCounter("Memory", "Available MBytes");

        public MainForm()
        {
            InitializeComponent();

            // Settings for the JobMonitor instance:
            mJobMonitor = new JobMonitor();
            mJobMonitor.JobStarted += new JobStartedEventHandler(mJobMonitor_JobStarted);
            mJobMonitor.JobCompleted += new JobCompletedEventHandler(mJobMonitor_JobCompleted);
            mJobMonitor.JobError += new JobErrorEventHandler(mJobMonitor_JobError);
            mJobMonitor.JobStep += new JobStepEventHandler(mJobMonitor_JobStep);

            // Start the JobMonitor with the background worker:
            mJobMonitorBgw.RunWorkerAsync();
        }

        #region Monitoring

        void mJobMonitor_JobStep(object sender, JobEventArgs e)
        {
            try
            {
                IMonitoredJob zJob = ((JobMonitor)sender).MonitoredJob;
                TimeSpan zElapsedTime, zRemainingTime;
                ulong zFreeSpace;               

                // Thread safe (it runs on UI thread):
                if (!e.Line.Equals(Environment.NewLine))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        try
                        {
                            // Append line to log textbox:
                            zLogTxb.AppendText(e.Line);// runs on UI thread

                            // Update status bar:
                            zElapsedTime = DateTime.Now - mDt;
                            if (e.Step > 0.0)
                            {
                                zRemainingTime = TimeSpan.FromSeconds(zElapsedTime.TotalSeconds * (1.0 - e.Step) / e.Step);
                                if (e.Step > Properties.Settings.Default.EstimatedRemaingTimeThresh)
                                    zTiming_ToolStripLbl.Text = "Elapsed time: " + zElapsedTime.ToString(@"hh\:mm\:ss") + ". Estimated remaining time: " + zRemainingTime.ToString(@"hh\:mm\:ss") + ".";
                                else
                                    zTiming_ToolStripLbl.Text = "Elapsed time: " + zElapsedTime.ToString(@"hh\:mm\:ss") + ".";
                            }

                            mStatusBarProgressBar.Value = Math.Min((int)(Math.Round(e.Step * 100.0)), 100);
                            toolStripStatusLabel1.Text = "Busy (Available RAM: " + (mRAMCounter.NextValue() / 1000).ToString("0.00") + " GB";

                            if ((zJob.GetType() == typeof(PreProcessingJob)) || (zJob.GetType() == typeof(PhaseRetrievalJob)))
                            {
                                // Add memory usage and free space on temporary folder:
                                if (FreeSpaceHelper.DriveFreeBytes(Properties.Settings.Default.FormSettings_WorkingPath, out zFreeSpace))
                                {
                                    double zVal = ((double)(zFreeSpace) / (1024.0 * 1024.0 * 1024.0));
                                    if (zVal > 1024.0)
                                    {
                                        toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + " - Free space on working path: " +
                                            (zVal / (1024.0)).ToString("0.0") + " TB)";
                                    }
                                    else
                                    {
                                        toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + " - Free space on working path: " +
                                            zVal.ToString("0.0") + " GB)";
                                    }
                                }
                                else
                                {
                                    toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + ")";
                                }
                            }
                            else if ((zJob.GetType() == typeof(ReconstructionJob)) || (zJob.GetType() == typeof(PostProcessingJob)))
                            {
                                // Add memory usage and free space on temporary folder:
                                if (FreeSpaceHelper.DriveFreeBytes(Properties.Settings.Default.FormSettings_OutputPath, out zFreeSpace))
                                {
                                    double zVal = ((double)(zFreeSpace) / (1024.0 * 1024.0 * 1024.0));
                                    if (zVal > 1024.0)
                                    {
                                        toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + " - Free space on output path: " +
                                            (zVal / (1024.0)).ToString("0.0") + " TB)";
                                    }
                                    else
                                    {
                                        toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + " - Free space on output path: " +
                                            zVal.ToString("0.0") + " GB)";
                                    }
                                }
                                else
                                {
                                    toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + ")";
                                }
                            }
                            else
                            {
                                toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + ")";
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    });
                }
            }
            catch (Exception ex)
            {
            }
        }

        void mJobMonitor_JobError(object sender, JobEventArgs e)
        {
            try
            {
                // Thread safe (it runs on UI thread):
                this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        zLogTxb.AppendText(e.Line);// runs on UI thread           

                        // Update status bar:
                        zTiming_ToolStripLbl.Text = String.Empty;

                        // Update progress bar:
                        mStatusBarProgressBar.Value = 0;

                        // Change status bar label:
                        toolStripStatusLabel1.Text = "Ready";

                        // Enable all the "Run" buttons:
                        btnPreProcessing_ExecuteRun.Enabled = true;
                        btnPhaseRetrieval_ExecuteRun.Enabled = true;
                        btnReconstructionTab_ExecuteRunSubset.Enabled = true;
                        btnReconstructionTab_ExecuteRunAll.Enabled = true;
                        btnPostProcessingTab_RunSubset.Enabled = true;
                        btnPostProcessingTab_RunAll.Enabled = true;
                       
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
            catch (Exception ex)
            {
            }
        }

        void mJobMonitor_JobCompleted(object sender, JobEventArgs e)
        {
            try
            {
                // Thread safe (it runs on UI thread):           
                this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        zLogTxb.AppendText(e.Line);

                        // Update status bar:
                        zTiming_ToolStripLbl.Text = String.Empty;

                        // Update progress bar:
                        mStatusBarProgressBar.Value = 0;

                        // Change status bar label:
                        toolStripStatusLabel1.Text = "Ready";

                        // Enable all the "Run" buttons:
                        btnPreProcessing_ExecuteRun.Enabled = true;
                        btnPhaseRetrieval_ExecuteRun.Enabled = true;
                        btnReconstructionTab_ExecuteRunSubset.Enabled = true;
                        btnReconstructionTab_ExecuteRunAll.Enabled = true;
                        btnPostProcessingTab_RunSubset.Enabled = true;
                        btnPostProcessingTab_RunAll.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
            catch (Exception ex)
            {
            }
        }

        void mJobMonitor_JobStarted(object sender, JobEventArgs e)
        {
            try
            {
                string zString;

                if (!mFirstRun)
                {
                    zString = e.Line.TrimStart('\r', '\n');
                    mFirstRun = true;
                }
                else
                    zString = e.Line;

                // Thread safe (it runs on UI thread):
                mDt = DateTime.Now;
                this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        zLogTxb.AppendText(zString);

                        // Change status bar label:
                        toolStripStatusLabel1.Text = "Busy";

                        // Disable all the "Run" buttons:
                        btnPreProcessing_ExecuteRun.Enabled = false;
                        btnPhaseRetrieval_ExecuteRun.Enabled = false;
                        btnReconstructionTab_ExecuteRunSubset.Enabled = false;
                        btnReconstructionTab_ExecuteRunAll.Enabled = false;
                        btnPostProcessingTab_RunSubset.Enabled = false;
                        btnPostProcessingTab_RunAll.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                    }
                });
            }
            catch (Exception ex)
            {

            }
        }

        private void mJobMonitorBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            mJobMonitor.Start();
        }

        #endregion

        #region On Form Load

        private void InitializeReconstructionAlgorithmsDropDown(bool includeGPUAlgorithms)
        {
            int ct = 0;
            string zFile;

            zFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + Properties.Settings.Default.RecAlgsXmlFile;
            if (File.Exists(zFile))
            {
                XmlDocument zDoc = new XmlDocument();
                zDoc.Load(zFile);

                XmlNodeList zKeys = zDoc.SelectNodes("algorithms/algorithm/key");
                XmlNodeList zValues = zDoc.SelectNodes("algorithms/algorithm/value");

                Dictionary<string, string> zDict = new Dictionary<string, string>();
                foreach (XmlNode zValue in zValues)
                {
                    if (zKeys[ct++].InnerText.ToUpperInvariant().Contains("CUDA"))
                    {
                        if (includeGPUAlgorithms)
                        {
                            zDict.Add(zKeys[ct - 1].InnerText, zValue.InnerText);
                        }
                    }
                    else
                    {
                        zDict.Add(zKeys[ct - 1].InnerText, zValue.InnerText);
                    }

                }

                cbxAlgorithm.DataSource = new BindingSource(zDict, null);
                cbxAlgorithm.DisplayMember = "Value";
                cbxAlgorithm.ValueMember = "Key";

                if (cbxAlgorithm.Items.Count > 0)
                {
                    cbxAlgorithm.SelectedIndex = 0;
                }
            }

            // Filters:

            ct = 0;

            zFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + Properties.Settings.Default.FbpFiltersXmlFile;
            if (File.Exists(zFile))
            {
                XmlDocument zDoc = new XmlDocument();
                zDoc.Load(zFile);

                XmlNodeList zKeys = zDoc.SelectNodes("filters/filter/key");
                XmlNodeList zValues = zDoc.SelectNodes("filters/filter/value");

                Dictionary<string, string> zDict = new Dictionary<string, string>();
                foreach (XmlNode zValue in zValues)
                {
                    zDict.Add(zKeys[ct++].InnerText, zValue.InnerText);
                }

                cbxAlgorithmParameterFilter.DataSource = new BindingSource(zDict, null);
                cbxAlgorithmParameterFilter.DisplayMember = "Value";
                cbxAlgorithmParameterFilter.ValueMember = "Key";

                if (cbxAlgorithmParameterFilter.Items.Count > 0)
                {
                    cbxAlgorithmParameterFilter.SelectedIndex = 1;
                }
            }
        }

        private void InitializeDegradationMethodsDropDown()
        {
            int ct = 0;
            string zFile;

            zFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + Properties.Settings.Default.DegradationMethodsXmlFile;
            if (File.Exists(zFile))
            {
                XmlDocument zDoc = new XmlDocument();
                zDoc.Load(zFile);

                XmlNodeList zKeys = zDoc.SelectNodes("algorithms/algorithm/key");
                XmlNodeList zValues = zDoc.SelectNodes("algorithms/algorithm/value");

                Dictionary<string, string> zDict = new Dictionary<string, string>();
                foreach (XmlNode zValue in zValues)
                {
                    zDict.Add(zKeys[ct++].InnerText, zValue.InnerText);
                }

                cbxDegradationMethods.DataSource = new BindingSource(zDict, null);
                cbxDegradationMethods.DisplayMember = "Value";
                cbxDegradationMethods.ValueMember = "Key";

                if (cbxDegradationMethods.Items.Count > 0)
                {
                    cbxDegradationMethods.SelectedIndex = 1;
                }
            }
        }

        private void InitializePhaseRetrievalAlgorithmsDropDown()
        {
            int ct = 0;
            string zFile;

            zFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + Properties.Settings.Default.PhrtAlgsXmlFile;
            if (File.Exists(zFile))
            {
                XmlDocument zDoc = new XmlDocument();
                zDoc.Load(zFile);

                XmlNodeList zKeys = zDoc.SelectNodes("algorithms/algorithm/key");
                XmlNodeList zValues = zDoc.SelectNodes("algorithms/algorithm/value");

                Dictionary<string, string> zDict = new Dictionary<string, string>();
                foreach (XmlNode zValue in zValues)
                {
                    zDict.Add(zKeys[ct++].InnerText, zValue.InnerText);
                }

                cbxPhaseRetrievalTab_Algorithms.DataSource = new BindingSource(zDict, null);
                cbxPhaseRetrievalTab_Algorithms.DisplayMember = "Value";
                cbxPhaseRetrievalTab_Algorithms.ValueMember = "Key";

                if (cbxPhaseRetrievalTab_Algorithms.Items.Count > 0)
                {
                    cbxPhaseRetrievalTab_Algorithms.SelectedIndex = 0;
                }
            }
        }

        private void InitializeNormalizationMethodsDropDown()
        {
            int ct = 0;
            string zFile;
            
            zFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + Properties.Settings.Default.FlatFieldAlgsXmlFile;
            if (File.Exists(zFile))
            {
                XmlDocument zDoc = new XmlDocument();
                zDoc.Load(zFile);

                XmlNodeList zKeys = zDoc.SelectNodes("algorithms/algorithm/key");
                XmlNodeList zValues = zDoc.SelectNodes("algorithms/algorithm/value");

                Dictionary<string, string> zDict = new Dictionary<string, string>();
                foreach (XmlNode zValue in zValues)
                {
                    zDict.Add(zKeys[ct++].InnerText, zValue.InnerText);
                }

                cbxFlatField.DataSource = new BindingSource(zDict, null);
                cbxFlatField.DisplayMember = "Value";
                cbxFlatField.ValueMember = "Key";

                if (cbxFlatField.Items.Count > 0)
                {
                    cbxFlatField.SelectedIndex = 0;
                }
            }
        }

        private void InitializeRingRemovalMethodsDropDown()
        {
            int ct = 0;
            string zFile;

            zFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + Properties.Settings.Default.RingRemAlgsXmlFile;
            if (File.Exists(zFile))
            {
                XmlDocument zDoc = new XmlDocument();
                zDoc.Load(zFile);

                XmlNodeList zKeys = zDoc.SelectNodes("algorithms/algorithm/pyname");
                XmlNodeList zValues = zDoc.SelectNodes("algorithms/algorithm/displayname");

                Dictionary<string, string> zDict = new Dictionary<string, string>();
                foreach (XmlNode zValue in zValues)
                {
                    zDict.Add(zKeys[ct++].InnerText, zValue.InnerText);
                }

                cbxRingRem.DataSource = new BindingSource(zDict, null);
                cbxRingRem.DisplayMember = "Value";
                cbxRingRem.ValueMember = "Key";

                if (cbxRingRem.Items.Count > 0)
                {
                    cbxRingRem.SelectedIndex = 1;
                }
            }
        }

        private void LoadPreviousValues()
        {
            // Phase Retrieval Tab:
            this.nudPhaseRetrievalTab_Beta.Value = Properties.Settings.Default.PhaseRetrievalTab_Beta;
            this.nudPhaseRetrievalTab_BetaExp.Value = Properties.Settings.Default.PhaseRetrievalTab_BetaExp;
            this.nudPhaseRetrievalTab_Delta.Value = Properties.Settings.Default.PhaseRetrievalTab_Delta;
            this.nudPhaseRetrievalTab_DeltaExp.Value = Properties.Settings.Default.PhaseRetrievalTab_DeltaExp;
            this.nudPhaseRetrievalTab_Distance.Value = Properties.Settings.Default.PhaseRetrievalTab_Distance;
            this.nudPhaseRetrievalTab_PixelSize.Value = Properties.Settings.Default.PhaseRetrievalTab_PixelSize;
            this.nudPhaseRetrievalTab_Energy.Value = Properties.Settings.Default.PhaseRetrievalTab_Energy;
            this.chkPhaseRetrievalTab_OverPadding.Checked = Properties.Settings.Default.PhaseRetrievalTab_OverpadChecked;

            if (Properties.Settings.Default.PhaseRetrievalTab_MethodIndex < cbxPhaseRetrievalTab_Algorithms.Items.Count)
            {
                this.cbxPhaseRetrievalTab_Algorithms.SelectedIndex = Properties.Settings.Default.PhaseRetrievalTab_MethodIndex;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Settings.Default.ProgramName + " v. " + Properties.Settings.Default.Version;

            InitializePhaseRetrievalAlgorithmsDropDown();
            InitializeNormalizationMethodsDropDown();
            InitializeRingRemovalMethodsDropDown();
            InitializeDegradationMethodsDropDown();

            // Load previously available values:
            LoadPreviousValues();

            UpdateDeltaBetaLbl();

            // Load settings:


            // Check Settings:
            while ((Program.CheckDirectoryAccess(Properties.Settings.Default.FormSettings_WorkingPath) == false) ||
                 (Program.CheckDirectoryAccess(Properties.Settings.Default.FormSettings_TemporaryPath) == false) ||
                 (Program.CheckDirectoryAccess(Properties.Settings.Default.FormSettings_OutputPath) == false))
            //|| (Program.IsDirectoryEmpty(Properties.Settings.Default.FormSettings_TemporaryPath) == false ))
            {
                //MessageBox.Show("Unexisting or not empty path(s) specified. Settings form will be opened.", 
                MessageBox.Show("Unexisting path(s) specified. Settings form will be opened.",
                                Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormSettings zFormSettings = new FormSettings();
                zFormSettings.ShowDialog(this);
            }

            // Create temporary folder:
            if (!Directory.Exists(Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar +
                Properties.Settings.Default.SessionID))
            {
                Directory.CreateDirectory(Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar +
                Properties.Settings.Default.SessionID);
            }



            // Check the presence of a GPU:
            if (Properties.Settings.Default.PerformGPUCheck)
            {
                if (Program.CheckGPU() == false)
                {
                    InitializeReconstructionAlgorithmsDropDown(false);
                    MessageBox.Show("NVIDIA GPU card not detected. Some features won't be available.",
                        Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    InitializeReconstructionAlgorithmsDropDown(true);
                }
            }
            else
            {
                InitializeReconstructionAlgorithmsDropDown(true);
            }           
        }

        #endregion

        private void btnPreProcessingExecution_RunAll_Click(object sender, EventArgs e)
        {
            IJob zJob;
            string zRingRemString;
            bool zDynamicFlatFielding;

            zDynamicFlatFielding = !(this.cbxFlatField.SelectedIndex == 0);

            zRingRemString = ((KeyValuePair<string, string>)this.cbxRingRem.SelectedItem).Key + ":" +
                Convert.ToInt32(nudRingRemParam1.Value).ToString() + ";" + (Convert.ToDouble(nudRingRemParam2.Value)).ToString(CultureInfo.InvariantCulture);

            // Execute with conventional flat fielding:
            zJob = new PreProcessingJob(
                // Get combobox selection (in handler)
                   ((KeyValuePair<string, string>)this.cbxPreProcessing_Input.SelectedItem).Key,
                   this.lblPreProcessing_Output.Text,
                   0,
                   TDFReader.GetNumberOfSlices(((KeyValuePair<string, string>)this.cbxPreProcessing_Input.SelectedItem).Key) - 1,
                   Convert.ToInt32(this.nudNormSx.Value),
                   Convert.ToInt32(this.nudNormDx.Value),
                   chkDarkFlatEnd.Checked, // use flat at the end
                   chkHalfHalfMode.Checked,
                   Convert.ToInt32(this.nudHalfHalfMode.Value),
                   chkExtendedFOV.Checked,
                   chkExtFOV_AirRight.Checked,                   
                   Convert.ToInt32(nudExtendedFOVOverlap.Value),
                   chkExtFOVNormalize.Checked,
                   chkExtFOVAverage.Checked,
                   zRingRemString,
                   zDynamicFlatFielding,
                   Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses),
                   false,
                   "-"
            );


            // Create an instance of JobExecuter with the pre processing job:
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, "sino");
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                mDt = DateTime.Now;
                this.Activate();
                SplashScreen.CloseForm();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings zFormSettings = new FormSettings();
            zFormSettings.ShowDialog(this);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Start the task
            var thread = new Thread(DoTask)
            {
                IsBackground = false,
                Name = "Closing thread.",
            };
            thread.Start();

            base.OnFormClosed(e);
        }

        private void DoTask()
        {
            // Closing MATLAB...
            //Program.StartProcess("\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + Properties.Settings.Default.MatlabPath
            //    + Path.DirectorySeparatorChar + Properties.Settings.Default.MatlabClose + "\"", String.Empty);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If it wasn't the user who asked for the closing, we just close
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            // If it was the user, we want to make sure he didn't do it by accident
            DialogResult r = MessageBox.Show("This will close the application. Are you sure?",
                                             Properties.Settings.Default.ProgramName,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (r != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                // Delete everything from temp folder:
                System.IO.DirectoryInfo zDi = new DirectoryInfo(Properties.Settings.Default.FormSettings_TemporaryPath
                    + Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID);

                foreach (FileInfo zFile in zDi.GetFiles())
                {
                    zFile.Delete();
                }
                foreach (DirectoryInfo zDir in zDi.GetDirectories())
                {
                    zDir.Delete(true);
                }

                // Delete the temp folder
                Directory.Delete(Properties.Settings.Default.FormSettings_TemporaryPath
                    + Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID);

                // Serialize settings:
                Properties.Settings.Default["PhaseRetrievalTab_Beta"] = this.nudPhaseRetrievalTab_Beta.Value;
                Properties.Settings.Default["PhaseRetrievalTab_BetaExp"] = this.nudPhaseRetrievalTab_BetaExp.Value;
                Properties.Settings.Default["PhaseRetrievalTab_Delta"] = this.nudPhaseRetrievalTab_Delta.Value;
                Properties.Settings.Default["PhaseRetrievalTab_DeltaExp"] = this.nudPhaseRetrievalTab_DeltaExp.Value;
                Properties.Settings.Default["PhaseRetrievalTab_Distance"] = this.nudPhaseRetrievalTab_Distance.Value;
                Properties.Settings.Default["PhaseRetrievalTab_Energy"] = this.nudPhaseRetrievalTab_Energy.Value;
                Properties.Settings.Default["PhaseRetrievalTab_PixelSize"] = this.nudPhaseRetrievalTab_PixelSize.Value;
                Properties.Settings.Default["PhaseRetrievalTab_OverpadChecked"] = this.chkPhaseRetrievalTab_OverPadding.Checked;
                Properties.Settings.Default["PhaseRetrievalTab_MethodIndex"] = this.cbxPhaseRetrievalTab_Algorithms.SelectedIndex;

                Properties.Settings.Default.Save();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            IJob zJob;
            double zScale = 1.0;
            string zRingRemString;
            string zConvertTo8String;
            string zCropString;
            double zCorrectionOffset = 0.0;
            string zParam1 = "-";
            bool zDynamicFlatFielding;

            zDynamicFlatFielding = !(this.cbxFlatField.SelectedIndex == 0);

            zRingRemString = ((KeyValuePair<string, string>)this.cbxRingRem.SelectedItem).Key + ":" +
                Convert.ToInt32(nudRingRemParam1.Value).ToString() + ";" + (Convert.ToDouble(nudRingRemParam2.Value)).ToString(CultureInfo.InvariantCulture);

            zConvertTo8String = ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key + ":" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMin.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture) + ";" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMax.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);

            zCropString = Convert.ToInt32(nudConvertToTDF_CropTop.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropBottom.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropLeft.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropRight.Value).ToString();

            if (this.chkCorrectionOffset.Checked)
                zCorrectionOffset = Convert.ToDouble(this.nudCorrectionOffset.Value);

            double zVal = Convert.ToDouble(this.nudCenter_Middle.Value);
            if ((Math.Abs(zVal - Math.Floor(zVal))) > Double.Epsilon)
                zScale = 2.0;

            // Get algorithm-specific parameters:
            if ((((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FBP_CUDA") ||
                 (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "SCIKIT-FBP"))
            {
                zParam1 = ((KeyValuePair<string, string>)this.cbxAlgorithmParameterFilter.SelectedItem).Key.ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "GRIDREC")
            {
                zParam1 = Convert.ToDouble(this.nudGridRec.Value).ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FISTA-TV_CUDA")
            {
                zParam1 = Convert.ToDouble(this.txbReconstructionLambda.Text).ToString();
            }
            else
            {
                // Iterative algorithms:
                zParam1 = Convert.ToInt32(this.nudAlgorithmParameterIterations.Value).ToString();
            }


            // Create an instance for the reconstruction job:
            zJob = new ReconstructionJob(
                // Get combobox selection (in handler)
                ((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key,
                lblReconstructionOutputPath.Text,
                this.chkApplyPreProcessing.Checked,
                Convert.ToInt32(this.nudNormSx.Value),
                Convert.ToInt32(this.nudNormDx.Value),
                chkDarkFlatEnd.Checked, // use flat at the end
                chkHalfHalfMode.Checked,
                Convert.ToInt32(this.nudHalfHalfMode.Value),
                chkExtendedFOV.Checked,
                chkExtFOV_AirRight.Checked,
                Convert.ToInt32(nudExtendedFOVOverlap.Value),
                chkExtFOVNormalize.Checked,
                chkExtFOVAverage.Checked,
                zRingRemString,
                Convert.ToDouble(this.nudAngles.Value) * Math.PI / 180.0,
                Convert.ToInt32(this.nudAnglesProjFrom.Value),
                Convert.ToInt32(this.nudAnglesProjTo.Value),
                Convert.ToDouble(this.nudCenter_Middle.Value),
                ((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key,
                zParam1,
                zScale,
                chkOverPadding.Checked,
                chkLogTransform.Checked,
                chkCircleMask.Checked,
                (chkZeroneMode.Checked) && (!chkApplyPreProcessing.Checked),
                zCorrectionOffset,
                Convert.ToInt32(this.nudReconstructionTab_ExecuteFrom.Value),
                Convert.ToInt32(this.nudReconstructionTab_ExecuteTo.Value),
                Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses),
                Convert.ToInt32(this.nudReconstructionTab_Decimate.Value),
                Convert.ToInt32(this.nudReconstructionTab_Downscale.Value),
                chkReconstructionTab_PostProcess.Checked,
                zConvertTo8String,
                zCropString,
                zDynamicFlatFielding,
                this.gbxRolling.Enabled,
                Convert.ToInt32(this.nudRollShift.Value)            
                );



            // Create an instance of JobExecuter with the reconstruction job:
            // splitting it into several processes (if specified):
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job: 
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, Properties.Settings.Default.FormSettings_OutputPrefix);
        }


        private void tbxDatasetName_Click(object sender, EventArgs e)
        {
            // Populate the list:
            this.SuspendLayout();

            string zFilter = "*" + Properties.Settings.Default.TomoDataFormatExtension;
            string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.FormSettings_WorkingPath, zFilter, SearchOption.TopDirectoryOnly);
            Dictionary<string, string> zDict = new Dictionary<string, string>();
            if (fileEntries.Length == 0)
                zDict.Add("<none>", "<none>");
            else
            {
                foreach (string fileName in fileEntries)
                    zDict.Add(fileName, Path.GetFileName(fileName));
            }

            tbxDatasetName.DataSource = new BindingSource(zDict, null);
            tbxDatasetName.DisplayMember = "Value";
            tbxDatasetName.ValueMember = "Key";

            this.ResumeLayout();
        }

        private void btnReconstruction_RunAll_Click(object sender, EventArgs e)
        {
            IJob zJob;
            double zScale = 1.0;
            string zRingRemString;
            string zConvertTo8String;
            string zCropString;
            double zCorrectionOffset = 0.0;
            string zParam1 = "-";
            bool zDynamicFlatFielding;

            zDynamicFlatFielding = !(this.cbxFlatField.SelectedIndex == 0);

            zRingRemString = ((KeyValuePair<string, string>)this.cbxRingRem.SelectedItem).Key + ":" +
                nudRingRemParam1.Value.ToString() + ";" + nudRingRemParam2.Value.ToString();

            zConvertTo8String = ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key + ":" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMin.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture) + ";" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMax.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);

            zCropString = Convert.ToInt32(nudConvertToTDF_CropTop.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropBottom.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropLeft.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropRight.Value).ToString();

            if (this.chkCorrectionOffset.Checked)
                zCorrectionOffset = Convert.ToDouble(this.nudCorrectionOffset.Value);

            double zVal = Convert.ToDouble(this.nudCenter_Middle.Value);
            if ((Math.Abs(zVal - Math.Floor(zVal))) > Double.Epsilon)
                zScale = 2.0;

            // Get algorithm-specific parameters:
            if ((((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FBP_CUDA") ||
                 (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "SCIKIT-FBP"))
            {
                zParam1 = ((KeyValuePair<string, string>)this.cbxAlgorithmParameterFilter.SelectedItem).Key.ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "GRIDREC")
            {
                zParam1 = Convert.ToDouble(this.nudGridRec.Value).ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FISTA-TV_CUDA")
            {
                zParam1 = Convert.ToDouble(this.txbReconstructionLambda.Text).ToString();
            }
            else
            {
                // Iterative algorithms:
                zParam1 = Convert.ToInt32(this.nudAlgorithmParameterIterations.Value).ToString();
            }

            // Create an instance for the reconstruction job:
            zJob = new ReconstructionJob(
                // Get combobox selection (in handler)
                ((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key,
                lblReconstructionOutputPath.Text,
                this.chkApplyPreProcessing.Checked,
                Convert.ToInt32(this.nudNormSx.Value),
                Convert.ToInt32(this.nudNormDx.Value),
                chkDarkFlatEnd.Checked, // use flat at the end
                chkHalfHalfMode.Checked,
                Convert.ToInt32(this.nudHalfHalfMode.Value),
                chkExtendedFOV.Checked,
                chkExtFOV_AirRight.Checked,
                Convert.ToInt32(nudExtendedFOVOverlap.Value),
                chkExtFOVNormalize.Checked,
                chkExtFOVAverage.Checked,
                zRingRemString,
                Convert.ToDouble(this.nudAngles.Value) * Math.PI / 180.0,
                Convert.ToInt32(this.nudAnglesProjFrom.Value),
                Convert.ToInt32(this.nudAnglesProjTo.Value),
                Convert.ToDouble(this.nudCenter_Middle.Value),
                ((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key,
                zParam1,
                zScale,
                chkOverPadding.Checked,
                chkLogTransform.Checked,
                chkCircleMask.Checked,
                (chkZeroneMode.Checked) && (!chkApplyPreProcessing.Checked),
                zCorrectionOffset,
                0,
                TDFReader.GetNumberOfSlices(((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key) - 1,
                Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses),
                Convert.ToInt32(this.nudReconstructionTab_Decimate.Value),
                Convert.ToInt32(this.nudReconstructionTab_Downscale.Value),
                chkReconstructionTab_PostProcess.Checked,
                zConvertTo8String,
                zCropString,
                zDynamicFlatFielding,
                this.gbxRolling.Enabled,
                Convert.ToInt32(this.nudRollShift.Value)  
                );

            // Create an instance of JobExecuter with the reconstruction job 
            // splitting it into several processes (if specified):
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job: 
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, Properties.Settings.Default.FormSettings_OutputPrefix);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If it was the user, we want to make sure he didn't do it by accident
            DialogResult r = MessageBox.Show("This will close the application. Are you sure?",
                                             Properties.Settings.Default.ProgramName,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cbxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FBP_CUDA") ||
                  (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "SCIKIT-FBP"))
            {
                this.lblAlgorithmParameter.Text = "Filter:";
                this.lblAlgorithmParameter.Visible = true;
                this.lblAlgorithmParameter.Location = new Point(24, 25);

                this.cbxAlgorithmParameterFilter.Visible = true;
                this.nudAlgorithmParameterIterations.Visible = false;
                this.txbReconstructionLambda.Visible = false;
                this.nudGridRec.Visible = false;
                this.chkOverPadding.Enabled = true;
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "GRIDREC")
            {
                this.lblAlgorithmParameter.Text = "Oversampling:";
                this.lblAlgorithmParameter.Visible = true;
                this.lblAlgorithmParameter.Location = new Point(7, 25);

                this.cbxAlgorithmParameterFilter.Visible = false;
                this.nudAlgorithmParameterIterations.Visible = false;
                this.txbReconstructionLambda.Visible = false;
                this.nudGridRec.Visible = true;
                this.chkOverPadding.Enabled = false;
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "MR-FBP_CUDA")
            {
                this.lblAlgorithmParameter.Visible = false;

                this.nudAlgorithmParameterIterations.Visible = false;
                this.cbxAlgorithmParameterFilter.Visible = false;
                this.txbReconstructionLambda.Visible = false;
                this.nudGridRec.Visible = false;
                this.chkOverPadding.Enabled = true;
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FISTA-TV_CUDA")
            {
                this.lblAlgorithmParameter.Text = "Lambda:";
                this.lblAlgorithmParameter.Visible = true;
                this.lblAlgorithmParameter.Location = new Point(8, 25);

                this.nudAlgorithmParameterIterations.Visible = false;
                this.cbxAlgorithmParameterFilter.Visible = false;
                this.txbReconstructionLambda.Visible = true;
                this.nudGridRec.Visible = false;
                this.chkOverPadding.Enabled = true;
            }
            else
            {
                // Iterative algorithms:
                this.lblAlgorithmParameter.Text = "Iterations:";
                this.lblAlgorithmParameter.Visible = true;
                this.lblAlgorithmParameter.Location = new Point(7, 25);

                this.nudAlgorithmParameterIterations.Visible = true;
                this.cbxAlgorithmParameterFilter.Visible = false;
                this.txbReconstructionLambda.Visible = false;
                this.nudGridRec.Visible = false;
                this.chkOverPadding.Enabled = true;
            }
        }

        private void btnAlgorithmSettings_Click(object sender, EventArgs e)
        {
            string zString;

            zString = ((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key;
            //zString = zString.Remove(0, 6);
            zString = zString.ToUpper();
            zString = "BrunTomoProject.AlgorithmSettings." + zString + "_Settings";

            Form zForm = (Form)Activator.CreateInstance(Type.GetType(zString));
            zForm.ShowDialog(this);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            IJob zJob;
            double zScale = 1.0;

            mGlass = new HourGlass();

            // Create an instance for the guess center job:
            zJob = new GuessCenterJob(
                // Get combobox selection (in handler)
                ((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key,
                zScale,
                Convert.ToDouble(this.nudAngles.Value) * Math.PI / 180.0,
                Convert.ToInt32(this.nudAnglesProjFrom.Value),
                Convert.ToInt32(this.nudAnglesProjTo.Value)
            );

            // Create an instance of JobExecuter with the guess center job:
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:            
            bgwGuessOffset.RunWorkerAsync(zJob.LogFile);
            //mJobMonitor.Run(zExecuter, BTPSettings.TomoPrefix);
        }

        private void bgwGuessOffset_DoWork(object sender, DoWorkEventArgs e)
        {
            string zLogFile = (string)e.Argument;

            // Wait 'till file exists:
            while (!(File.Exists(zLogFile)))
            {
                System.Threading.Thread.Sleep(100);
            }

            // Read the file:
            string zValue = System.IO.File.ReadAllText(zLogFile);

            // Modify the UI:
            this.Invoke((MethodInvoker)delegate
            {
                this.nudCenter_Middle.Value = System.Convert.ToDecimal(zValue);
            });


            // Delete the file:
            File.Delete(zLogFile);

        }

        private void bgwGuessOffset_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mGlass.Dispose();
        }

        private void cbxRingRem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int zIndex = this.cbxRingRem.SelectedIndex + 1;
                XmlDocument zDoc = new XmlDocument();

                // Load the XML configuration file for ring removal filters:
                zDoc.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                    Path.DirectorySeparatorChar + Properties.Settings.Default.RingRemAlgsXmlFile);

                // Hide UI elements:
                this.lblRingRemParam1.Visible = false;
                this.nudRingRemParam1.Visible = false;

                this.lblRingRemParam2.Visible = false;
                this.nudRingRemParam2.Visible = false;

                // Configure parameter 1:                
                XmlNode zParameterNode = zDoc.SelectSingleNode("/algorithms/algorithm[" + zIndex.ToString() + "]/parameters/parameter[1]");
                this.lblRingRemParam1.Text = zParameterNode.InnerText + ":";
                this.nudRingRemParam1.Minimum = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("min").Value);
                this.nudRingRemParam1.Maximum = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("max").Value);
                this.nudRingRemParam1.DecimalPlaces = Convert.ToInt32(zParameterNode.Attributes.GetNamedItem("decimalplaces").Value);
                this.nudRingRemParam1.Increment = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("increment").Value);
                this.nudRingRemParam1.Value = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("default").Value);

                this.lblRingRemParam1.Visible = true;
                this.nudRingRemParam1.Visible = true;

                // Configure parameter 1:                
                zParameterNode = zDoc.SelectSingleNode("/algorithms/algorithm[" + zIndex.ToString() + "]/parameters/parameter[2]");
                this.lblRingRemParam2.Text = zParameterNode.InnerText + ":";
                this.nudRingRemParam2.Minimum = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("min").Value);
                this.nudRingRemParam2.Maximum = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("max").Value);
                this.nudRingRemParam2.DecimalPlaces = Convert.ToInt32(zParameterNode.Attributes.GetNamedItem("decimalplaces").Value);
                this.nudRingRemParam2.Increment = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("increment").Value);
                this.nudRingRemParam2.Value = Convert.ToDecimal(zParameterNode.Attributes.GetNamedItem("default").Value);

                this.lblRingRemParam2.Visible = true;
                this.nudRingRemParam2.Visible = true;

            }
            catch (Exception ex)
            {

            }



            /*if ((this.cbxRingRem.SelectedIndex > 0) && (this.cbxRingRem.SelectedIndex < 4))
            {
                // Rivers + Boin/Haibel + Raven:                
                this.lblRingRemParam1.Text = "Width:";
                this.lblRingRemParam1.Visible = true;
                this.nudRingRemParam1.Minimum = 3;
                this.nudRingRemParam1.Maximum = 99;
                this.nudRingRemParam1.DecimalPlaces = 0;
                this.nudRingRemParam1.Increment = 2;
                this.nudRingRemParam1.Value = 3;
                this.nudRingRemParam1.Visible = true;


                this.lblRingRemParam2.Visible = false;
                this.nudRingRemParam2.Visible = false;
            }
            else if (this.cbxRingRem.SelectedIndex == 4)
            {
                // Munch et al.:
                this.lblRingRemParam1.Text = "Levels:";
                this.lblRingRemParam1.Visible = true;
                this.nudRingRemParam1.Minimum = 2;
                this.nudRingRemParam1.Maximum = 8;
                this.nudRingRemParam1.DecimalPlaces = 0;
                this.nudRingRemParam1.Increment = 1;
                this.nudRingRemParam1.Value = 4;
                this.nudRingRemParam1.Visible = true;

                this.lblRingRemParam2.Text = "Sigma:";
                this.lblRingRemParam2.Visible = true;
                this.nudRingRemParam2.Minimum = (decimal)0.0;
                this.nudRingRemParam2.Maximum = (decimal)9.9;
                this.nudRingRemParam2.DecimalPlaces = 1;
                this.nudRingRemParam2.Increment = (decimal)0.1;
                this.nudRingRemParam2.Value = 1;
                this.nudRingRemParam2.Visible = true;
            }
            else if (this.cbxRingRem.SelectedIndex == 5)
            {
                // Oimoen:
                this.lblRingRemParam1.Text = "Horizontal:";
                this.lblRingRemParam1.Visible = true;
                this.nudRingRemParam1.Minimum = 3;
                this.nudRingRemParam1.Maximum = 999;
                this.nudRingRemParam1.DecimalPlaces = 0;
                this.nudRingRemParam1.Increment = 1;
                this.nudRingRemParam1.Value = 31;
                this.nudRingRemParam1.Visible = true;

                this.lblRingRemParam2.Text = "Vertical:";
                this.lblRingRemParam2.Visible = true;
                this.nudRingRemParam2.Minimum = 3;
                this.nudRingRemParam2.Maximum = 999;
                this.nudRingRemParam2.DecimalPlaces = 0;
                this.nudRingRemParam2.Increment = 1;
                this.nudRingRemParam2.Value = 31;
                this.nudRingRemParam2.Visible = true;
            }
            else if (this.cbxRingRem.SelectedIndex == 6)
            {
                // Sijbers and Postnov:
                this.lblRingRemParam1.Text = "Winsize:";
                this.lblRingRemParam1.Visible = true;
                this.nudRingRemParam1.Minimum = 3;
                this.nudRingRemParam1.Maximum = 999;
                this.nudRingRemParam1.DecimalPlaces = 0;
                this.nudRingRemParam1.Increment = 1;
                this.nudRingRemParam1.Value = 51;
                this.nudRingRemParam1.Visible = true;

                this.lblRingRemParam2.Text = "Thresh:";
                this.lblRingRemParam2.Visible = true;
                this.nudRingRemParam2.Minimum = 0;
                this.nudRingRemParam2.Maximum = (decimal) 99.9;
                this.nudRingRemParam2.DecimalPlaces = 2;
                this.nudRingRemParam2.Increment = 1;
                this.nudRingRemParam2.Value = (decimal) 1.0;
                this.nudRingRemParam2.Visible = true;
            }
            else
            {
                this.lblRingRemParam1.Visible = false;
                this.nudRingRemParam1.Visible = false;

                this.lblRingRemParam2.Visible = false;
                this.nudRingRemParam2.Visible = false;
            }*/
        }

        private void cbxPreProcessing_Input_Click(object sender, EventArgs e)
        {
            // Populate the list:
            this.SuspendLayout();

            string zFilter = "*" + Properties.Settings.Default.TomoDataFormatExtension;
            string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.FormSettings_WorkingPath, zFilter, SearchOption.TopDirectoryOnly);
            Dictionary<string, string> zDict = new Dictionary<string, string>();
            if (fileEntries.Length == 0)
                zDict.Add("<none>", "<none>");
            else
            {
                foreach (string fileName in fileEntries)
                    zDict.Add(fileName, Path.GetFileName(fileName));
            }

            cbxDatasetInfo_Input.DataSource = new BindingSource(zDict, null);
            cbxDatasetInfo_Input.DisplayMember = "Value";
            cbxDatasetInfo_Input.ValueMember = "Key";

            this.ResumeLayout();
        }

        private void cbxPhaseRetrieval_Input_Click(object sender, EventArgs e)
        {
            // Populate the list:
            this.SuspendLayout();

            string zFilter = "*" + Properties.Settings.Default.TomoDataFormatExtension;
            string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.FormSettings_WorkingPath, zFilter, SearchOption.TopDirectoryOnly);
            Dictionary<string, string> zDict = new Dictionary<string, string>();
            if (fileEntries.Length == 0)
                zDict.Add("<none>", "<none>");
            else
            {
                foreach (string fileName in fileEntries)
                    zDict.Add(fileName, Path.GetFileName(fileName));
            }

            cbxPhaseRetrieval_Input.DataSource = new BindingSource(zDict, null);
            cbxPhaseRetrieval_Input.DisplayMember = "Value";
            cbxPhaseRetrieval_Input.ValueMember = "Key";

            this.ResumeLayout();
        }

        private void btnPhaseRetrievalRunAll_Click(object sender, EventArgs e)
        {
            IJob zJob;
            JobExecuter zExecuter;

            // Create an instance for the phase retrieval job:
            zJob = new PhaseRetrievalJob(
                // Get combobox selection (in handler)
                   ((KeyValuePair<string, string>)this.cbxPhaseRetrieval_Input.SelectedItem).Key,
                   this.lblPhaseRetrieval_Output.Text,
                   Convert.ToInt32(((KeyValuePair<string, string>)this.cbxPhaseRetrievalTab_Algorithms.SelectedItem).Key),
                   0,
                   TDFReader.GetNumberOfProjections(((KeyValuePair<string, string>)this.cbxPhaseRetrieval_Input.SelectedItem).Key) - 1,
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Beta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_BetaExp.Value)),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Delta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_DeltaExp.Value)),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Distance.Value),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Energy.Value),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_PixelSize.Value),
                   this.chkPhaseRetrievalTab_OverPadding.Checked,
                   Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses)
            );

            // Create an instance of JobExecuter with the Phase Retrieval job:
            zExecuter = new JobExecuter(zJob);


            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, "tomo");
        }

        private void chkDarkFlatEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDarkFlatEnd.Checked)
            {
                chkHalfHalfMode.Enabled = true;
                nudHalfHalfMode.Enabled = true;
            }
            else
            {
                chkHalfHalfMode.Enabled = false;
                nudHalfHalfMode.Enabled = false;
            }
        }

        private void chkExtendedFOV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtendedFOV.Checked)
            {
                btnPreProcess_GuessOverlap.Enabled = true;
                nudExtendedFOVOverlap.Enabled = true;
                chkExtFOV_AirRight.Enabled = true;
                chkExtFOVNormalize.Enabled = true;
                chkExtFOVAverage.Enabled = true;
                chkExtFOV_AirRight_CheckedChanged(null, null);
            }
            else
            {
                btnPreProcess_GuessOverlap.Enabled = false;
                nudExtendedFOVOverlap.Enabled = false;
                chkExtFOV_AirRight.Enabled = false;
                chkExtFOVNormalize.Enabled = false;
                chkExtFOVAverage.Enabled = false;
                nudNormSx.Enabled = true;
                nudNormDx.Enabled = true;
            }
        }

        private void chkExtFOV_AirRight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtFOV_AirRight.Checked)
            {
                nudNormSx.Enabled = false;
                nudNormDx.Enabled = true;
            }
            else
            {
                nudNormSx.Enabled = true;
                nudNormDx.Enabled = false;
            }
        }

        private void bgwGuessOverlap_DoWork(object sender, DoWorkEventArgs e)
        {
            string zLogFile = (string)e.Argument;

            // Wait 'till file exists:
            while (!(File.Exists(zLogFile)))
            {
                System.Threading.Thread.Sleep(100);
            }

            // Read the file:
            string zValue = System.IO.File.ReadAllText(zLogFile);

            // Modify the UI:
            this.Invoke((MethodInvoker)delegate
            {
                this.nudExtendedFOVOverlap.Value = System.Convert.ToDecimal(zValue);
            });


            // Delete the file:
            File.Delete(zLogFile);
        }

        private void bgwGuessOverlap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mGlass.Dispose();
        }

        private void btnPreProcess_GuessOverlap_Click(object sender, EventArgs e)
        {
            IJob zJob;
            double zScale = 1.0;

            mGlass = new HourGlass();

            // Create an instance for the guess overlap job:
            zJob = new GuessOverlapJob(
                // Get combobox selection (in handler)
                ((KeyValuePair<string, string>)this.cbxPreProcessing_Input.SelectedItem).Key,
                zScale
            );

            // Create an instance of JobExecuter with the guess overlap job:
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:            
            bgwGuessOverlap.RunWorkerAsync(zJob.LogFile);
            //mJobMonitor.Run(zExecuter, BTPSettings.TomoPrefix);
        }

        private void menuTIFF2TDF_Click(object sender, EventArgs e)
        {
            TIFFToTDF zForm = new TIFFToTDF();
            zForm.Show(this);
        }

        private void menuTDF2TIFF_Click(object sender, EventArgs e)
        {
            TDFToTIFF zForm = new TDFToTIFF();
            zForm.Show(this);
        }

        private void chkApplyPreProcessing_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyPreProcessing.Checked)
            {
                this.chkZeroneMode.Enabled = false;
            }
            else
            {
                this.chkZeroneMode.Enabled = true;
            }
        }

        #region Preview Section



        /// <summary>
        /// In-place swap the sequence of float32 bytes in a float array.
        /// </summary>
        /// <param name="data">The float array to swap.</param>
        private unsafe void SwapSingles(byte[] data)
        {
            int cnt = data.Length / 4;
            fixed (byte* d = data)
            {
                byte* p = d;
                while (cnt-- > 0)
                {
                    byte a = *p;
                    p++;
                    byte b = *p;
                    *p = *(p + 1);
                    p++;
                    *p = b;
                    p++;
                    *(p - 3) = *p;
                    *p = a;
                    p++;
                }
            }
        }

        /// <summary>
        /// The float32 RAW image saved in the specified file will be loaded into the preview panel.
        /// </summary>
        /// <param name="tempFile">File name of the temporary RAW image to load.</param>
        private void PreviewImageFromTemporaryFile(string tempFile)
        {
            int zWidth, zHeight;
            float zMin, zMax;
            string zString;
            string[] zStrings;

            // Get details from file name:
            zString = Path.GetFileName(tempFile);
            zString = zString.Substring(18);
            zStrings = zString.Split('x');
            zWidth = int.Parse(zStrings[0]);
            zStrings = zStrings[1].Split('_');
            zHeight = int.Parse(zStrings[0]);
            zStrings = zStrings[1].Split('$');

            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            zMin = float.Parse(zStrings[0], NumberStyles.Any, ci);
            zMax = float.Parse(zStrings[1], NumberStyles.Any, ci);

            // Load the image from temporary folder and create a Bitmap:            
            // (In case of memory concerns this should be done in chunks)

            //Equivalent line: byte[] zRawData = File.ReadAllBytes(tempFile);
            FileStream zFs = Program.WaitForFile(tempFile);
            BinaryReader zBr = new BinaryReader(zFs);
            long numBytes = new FileInfo(tempFile).Length;
            byte[] zRawData = zBr.ReadBytes((int)numBytes);
            zBr.Close();
            zFs.Close();
            //SwapSingles(zRawData);          
            this.kpImageViewer1.Pix32.Clear();
            this.kpImageViewer1.Pix8.Clear();

            Bitmap zBitmap = new Bitmap(zWidth, zHeight, PixelFormat.Format32bppArgb);

            BitmapData zBitmapData = zBitmap.LockBits(new Rectangle(0, 0, zWidth, zHeight),
               System.Drawing.Imaging.ImageLockMode.WriteOnly, zBitmap.PixelFormat);

            unsafe
            {
                int pixelSize = 4;
                int i, j, j1, ct = 0;

                fixed (byte* buffer = zRawData)
                {
                    // Convert to float array:
                    float* pixels = (float*)buffer;

                    for (i = 0; i < zBitmapData.Height; ++i)
                    {
                        byte* row = (byte*)zBitmapData.Scan0 + (i * zBitmapData.Stride);

                        for (j = 0; j < zBitmapData.Width; ++j)
                        {
                            float f = ((pixels[ct] - zMin) / (zMax - zMin)) * 255.0f;

                            if (f < 0.0f) f = 0.0f;
                            if (f > 255.0f) f = 255.0f;
                            byte b = (byte)f;

                            this.kpImageViewer1.Pix32.Add(pixels[ct++]);
                            this.kpImageViewer1.Pix8.Add(b);

                            j1 = j * pixelSize;
                            row[j1] = b;            // Red
                            row[j1 + 1] = b;        // Green
                            row[j1 + 2] = b;        // Blue
                            row[j1 + 3] = 255;         // Alpha
                        }
                    }
                }
            }
            zBitmap.UnlockBits(zBitmapData);

            // Add the Bitmap to the image viewer:
            this.kpImageViewer1.ResetValues();
            this.kpImageViewer1.Image = zBitmap;            


            // Delete temporary file:
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }

        /// <summary>
        /// The 2D image (projection or sinogram) at the specified index within the specified TDF file will be loaded
        /// into the preview panel.
        /// </summary>
        /// <param name="TDFToLoad">File name of the TDF to read.</param>
        /// <param name="index">Offset for the 2D image to extract within the 3D dataset.</param>
        /// <param name="imtype">True for projection, false for sinogram.</param>
        private void PreviewImageFromTDF(string TDFToLoad, int index, string imtype)
        {
            string zProcess;
            string zArgs;
            string zTempFile;

            // Prepare the temporary file name:
            zTempFile = Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar
                + Properties.Settings.Default.SessionID + Path.DirectorySeparatorChar +
                Program.GetTimestamp(DateTime.Now);

            // Prepare the process:
            zProcess = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + Properties.Settings.Default.PythonExe;

            // Prepare the args:
            zArgs = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.ExtractImage + "\" "
                + TDFToLoad + " " + index.ToString() + " " + imtype + " "
                + zTempFile;

            // Get projection by calling the python process:
            Program.StartProcess(zProcess, zArgs);

            // Get the modified file name:
            string[] files = Directory.GetFiles(Path.GetDirectoryName(zTempFile), Path.GetFileNameWithoutExtension(zTempFile) + "*");
            zTempFile = files[0];

            // Call subprogram:
            this.PreviewImageFromTemporaryFile(zTempFile);

        }

        /// <summary>
        /// Event handler when the drop down menu for the selection of a TDF is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDatasetInfo_Input_DropDownClosed(object sender, EventArgs e)
        {
            string zString;

            zString = ((KeyValuePair<string, string>)this.cbxDatasetInfo_Input.SelectedItem).Key;

            // Modify the cursor:
            mGlass = new HourGlass();

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                // Modify UI in dataset tab:
                this.gbxDatasetInfo_Preview.Enabled = false;
                this.gbxDatasetInfo_Metadata.Enabled = false;

                // Modify UI:
                this.lblDatasetTab_Projection.Enabled = true;
                this.nudDatasetTab_Projection.Enabled = true;
                this.btnDatasetTabPreviewProjection.Enabled = true;
                this.nudDatasetTab_Projection.Minimum = 0;
                this.nudDatasetTab_Projection.Maximum = TDFReader.GetNumberOfProjections(zString) - 1;
                this.nudDatasetTab_Projection.Value = Convert.ToDecimal(TDFReader.GetNumberOfProjections(zString) / 2);

                this.lblDatasetTab_Sinogram.Enabled = true;
                this.nudDatasetTab_Sinogram.Enabled = true;
                this.btnDatasetTabPreviewSinogram.Enabled = true;
                this.nudDatasetTab_Sinogram.Minimum = 0;
                this.nudDatasetTab_Sinogram.Maximum = TDFReader.GetNumberOfSlices(zString) - 1;
                this.nudDatasetTab_Sinogram.Value = Convert.ToDecimal(TDFReader.GetNumberOfSlices(zString) / 2);

                if ((TDFReader.HasDarks(zString)) && (TDFReader.GetNumberOfDarks(zString) > 0))
                {
                    this.lblDatasetTab_Dark.Enabled = true;
                    this.nudDatasetTab_Dark.Enabled = true;
                    this.btnDatasetTabPreviewDark.Enabled = true;
                    this.nudDatasetTab_Dark.Minimum = 0;
                    this.nudDatasetTab_Dark.Maximum = TDFReader.GetNumberOfDarks(zString) - 1;
                    this.nudDatasetTab_Dark.Value = 0;
                }
                else
                {
                    this.lblDatasetTab_Dark.Enabled = false;
                    this.nudDatasetTab_Dark.Enabled = false;
                    this.btnDatasetTabPreviewDark.Enabled = false;
                }

                if ((TDFReader.HasFlats(zString)) && (TDFReader.GetNumberOfFlats(zString) > 0))
                {
                    this.lblDatasetTab_Flat.Enabled = true;
                    this.nudDatasetTab_Flat.Enabled = true;
                    this.btnDatasetTabPreviewFlat.Enabled = true;
                    this.nudDatasetTab_Flat.Minimum = 0;
                    this.nudDatasetTab_Flat.Maximum = TDFReader.GetNumberOfFlats(zString) - 1;
                    this.nudDatasetTab_Flat.Value = 0;
                }
                else
                {
                    this.lblDatasetTab_Flat.Enabled = false;
                    this.nudDatasetTab_Flat.Enabled = false;
                    this.btnDatasetTabPreviewFlat.Enabled = false;
                }

                // Preview by default the central projection:
                //PreviewImageFromTDF(zString, (int)(this.nudDatasetTab_Projection.Value), true);
                //PreviewImageFromTDF(zString, (int) (this.nudDatasetTab_Sinogram.Value), false);
                this.lblMetadata_FOV.Text = "FOV: " + TDFReader.GetDetectorSize(zString).ToString() + " x " + TDFReader.GetNumberOfSlices(zString).ToString();
                this.lblMetadata_NrProjections.Text = "Nr. of projections: " + TDFReader.GetNumberOfProjections(zString).ToString();
                try
                {
                    this.lblMetadata_Energy.Text = "Energy: " + (TDFReader.GetMetadata<float>(zString, "/measurement/instrument/monochromator/energy")) + " keV";
                    this.lblMetadata_Distance.Text = "Distance: " + (TDFReader.GetMetadata<float>(zString, "/measurement/instrument/detector/distance")) + " mm";
                    this.lblMetadata_PixelSize.Text = "Pixel size: " + (TDFReader.GetMetadata<float>(zString, "/measurement/instrument/detector/pixel_size")) + " μm";
                    //this.lblMetadata_Experiment.Text = "Experiment: " + (TDFReader.GetMetadata<string>(zString, "/measurement/instrument/name"));
                }
                catch (Exception ex)
                {

                }
                // Modify UI in dataset tab:
                this.gbxDatasetInfo_Preview.Enabled = true;
                this.gbxDatasetInfo_Metadata.Enabled = true;
            }
            else
            {
                // Modify UI in dataset tab:
                this.gbxDatasetInfo_Preview.Enabled = false;
                this.gbxDatasetInfo_Metadata.Enabled = false;
            }

            mGlass.Dispose();
        }

        /// <summary>
        /// Event handler for the preview projection button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatasetTabPreviewProjection_Click(object sender, EventArgs e)
        {
            string zString;

            mGlass = new HourGlass();

            zString = ((KeyValuePair<string, string>)this.cbxDatasetInfo_Input.SelectedItem).Key;

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                PreviewImageFromTDF(zString, (int)(this.nudDatasetTab_Projection.Value), "tomo");
            }

            mGlass.Dispose();
        }

        /// <summary>
        /// Event handler for the preview sinogram button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatasetTabPreviewSinogram_Click(object sender, EventArgs e)
        {
            string zString;

            mGlass = new HourGlass();

            zString = ((KeyValuePair<string, string>)this.cbxDatasetInfo_Input.SelectedItem).Key;

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                PreviewImageFromTDF(zString, (int)(this.nudDatasetTab_Sinogram.Value), "sino");
            }

            mGlass.Dispose();
        }


        /// <summary>
        /// Event handler for the preview flat button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatasetTabPreviewFlat_Click(object sender, EventArgs e)
        {
            string zString;

            mGlass = new HourGlass();

            zString = ((KeyValuePair<string, string>)this.cbxDatasetInfo_Input.SelectedItem).Key;

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                PreviewImageFromTDF(zString, (int)(this.nudDatasetTab_Flat.Value), "flat");
            }

            mGlass.Dispose();
        }

        /// <summary>
        /// Event handler for the preview dark button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatasetTabPreviewDark_Click(object sender, EventArgs e)
        {
            string zString;

            mGlass = new HourGlass();

            zString = ((KeyValuePair<string, string>)this.cbxDatasetInfo_Input.SelectedItem).Key;

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                PreviewImageFromTDF(zString, (int)(this.nudDatasetTab_Dark.Value), "dark");
            }

            mGlass.Dispose();
        }



        private void cbxPhaseRetrieval_Input_DropDownClosed(object sender, EventArgs e)
        {
            string zString;

            zString = ((KeyValuePair<string, string>)this.cbxPhaseRetrieval_Input.SelectedItem).Key;

            mGlass = new HourGlass();

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                // Modify UI:
                this.gbxPhaseRetrieval_Execution.Enabled = true;
                this.gbxPhaseRetrieval_Preview.Enabled = true;

                lblPhaseRetrieval_Output.Text = zString.Remove(zString.Length - 4) + "_phrt.tdf";

                this.nudPhaseretrievalTab_ProjectionPreview.Minimum = 0;
                this.nudPhaseretrievalTab_ProjectionPreview.Maximum = TDFReader.GetNumberOfProjections(zString) - 1;
                this.nudPhaseretrievalTab_ProjectionPreview.Value = Convert.ToDecimal(TDFReader.GetNumberOfProjections(zString) / 2);
            }

            mGlass.Dispose();
        }

        private void tbxDatasetName_DropDownClosed(object sender, EventArgs e)
        {
            string zString;
            //string[] zSplit;

            /*string zExperiment;
            string zDataset;  */

            mGlass = new HourGlass();

            zString = ((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key;
            //zSplit = Path.GetFileNameWithoutExtension(zString).Split('_');
            //zExperiment = zSplit[0];
            //zDataset = zSplit[1];          

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                lblReconstructionOutputPath.Text = Properties.Settings.Default.FormSettings_OutputPath + Path.DirectorySeparatorChar +
                    //zExperiment + Path.DirectorySeparatorChar + zDataset +
                        Path.GetFileNameWithoutExtension(zString) +
                        Path.DirectorySeparatorChar + @"slices" + Path.DirectorySeparatorChar;

                this.nudCenter_Middle.Maximum = (TDFReader.GetDetectorSize(zString) - 1) / 2;
                this.nudCenter_Middle.Minimum = -(TDFReader.GetDetectorSize(zString) - 1) / 2;

                this.btnReconstructionGuess.Enabled = true;
                this.btnMultipleCenters.Enabled = true;
                this.btnMultipleAngles.Enabled = true;

                this.lblExecutionOutput.Enabled = true;
                this.lblReconstructionOutputPath.Enabled = true;

                this.lblReconstructionTab_Slice.Enabled = true;
                this.nudReconstructionTab_Slice.Enabled = true;
                this.btnReconstructionTab_Preview.Enabled = true;
                this.nudReconstructionTab_Slice.Minimum = 0;
                this.nudReconstructionTab_Slice.Maximum = TDFReader.GetNumberOfSlices(zString) - 1;
                this.nudReconstructionTab_Slice.Value = Convert.ToDecimal(TDFReader.GetNumberOfSlices(zString) / 2);

                this.nudRollShift.Maximum = Convert.ToDecimal(TDFReader.GetNumberOfProjections(zString) -1);


                this.lblReconstructionTab_ExecuteFrom.Enabled = true;
                this.nudReconstructionTab_ExecuteFrom.Enabled = true;
                this.lblReconstructionTab_ExecuteTo.Enabled = true;
                this.nudReconstructionTab_ExecuteTo.Enabled = true;
                this.nudReconstructionTab_ExecuteFrom.Minimum = 0;
                this.nudReconstructionTab_ExecuteFrom.Maximum = TDFReader.GetNumberOfSlices(zString) - 1;
                this.nudReconstructionTab_ExecuteFrom.Value = 0;
                this.nudReconstructionTab_ExecuteTo.Minimum = 0;
                this.nudReconstructionTab_ExecuteTo.Maximum = TDFReader.GetNumberOfSlices(zString) - 1;
                this.nudReconstructionTab_ExecuteTo.Value = TDFReader.GetNumberOfSlices(zString) - 1;
                this.btnReconstructionTab_ExecuteRunSubset.Enabled = true;
                this.btnReconstructionTab_ExecuteRunAll.Enabled = true;


                this.nudAnglesProjFrom.Enabled = true;
                this.nudAnglesProjFrom.Minimum = 0;
                this.nudAnglesProjFrom.Maximum = TDFReader.GetNumberOfProjections(zString) - 1;
                this.nudAnglesProjFrom.Value = 0;

                this.nudAnglesProjTo.Enabled = true;
                this.nudAnglesProjTo.Minimum = 0;
                this.nudAnglesProjTo.Maximum = TDFReader.GetNumberOfProjections(zString) - 1;
                this.nudAnglesProjTo.Value = this.nudAnglesProjTo.Maximum;

                // Preview by default the central projection:
                //PreviewImageFromTDF(zString, (int)(this.nudPhaseretrievalTab_ProjectionPreview.Value), true);                
            }

            mGlass.Dispose();
        }

        private void btnPreprocessingTab_Preview_Click(object sender, EventArgs e)
        {
            IJob zJob;
            string zTempFile;
            bool zDynamicFlatFielding;

            // Modify the cursor:
            mGlass = new HourGlass();

            // Prepare the temporary file name:
            zTempFile = Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar
                + Properties.Settings.Default.SessionID + Path.DirectorySeparatorChar +
                Program.GetTimestamp(DateTime.Now);

            string zRingRemString;

            zRingRemString = ((KeyValuePair<string, string>)this.cbxRingRem.SelectedItem).Key + ":" +
                Convert.ToInt32(nudRingRemParam1.Value).ToString() + ";" + (Convert.ToDouble(nudRingRemParam2.Value)).ToString(CultureInfo.InvariantCulture);

            zDynamicFlatFielding = !(this.cbxFlatField.SelectedIndex == 0);

            // Create an instance for the job:
            zJob = new PreProcessingPreviewJob(
                   Convert.ToInt32(this.nudPreprocessingTab_Preview.Value),
                   ((KeyValuePair<string, string>)this.cbxPreProcessing_Input.SelectedItem).Key,
                   zTempFile,
                   Convert.ToInt32(this.nudNormSx.Value),
                   Convert.ToInt32(this.nudNormDx.Value),
                   chkDarkFlatEnd.Checked, // use flat at the end
                   chkHalfHalfMode.Checked,
                   Convert.ToInt32(this.nudHalfHalfMode.Value),
                   chkExtendedFOV.Checked,
                   chkExtFOV_AirRight.Checked,
                   Convert.ToInt32(nudExtendedFOVOverlap.Value),
                   chkExtFOVNormalize.Checked,
                   chkExtFOVAverage.Checked,
                   zRingRemString,
                   zDynamicFlatFielding
            );


            // Create an instance of JobExecuter with the job:
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:            
            mBgwPreview.RunWorkerAsync(zTempFile);
        }

        private void btnPhaseretrievalTab_Preview_Click(object sender, EventArgs e)
        {
            IJob zJob;
            string zTempFile;

            // Modify the cursor:
            mGlass = new HourGlass();

            // Prepare the temporary file name:
            zTempFile = Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar +
                Properties.Settings.Default.SessionID + Path.DirectorySeparatorChar +
                Program.GetTimestamp(DateTime.Now);

            // Create an instance for the phase retrieval job:
            zJob = new PhaseRetrievalPreviewJob(
                    Convert.ToInt32(nudPhaseretrievalTab_ProjectionPreview.Value),
                // Get combobox selection (in handler)
                   ((KeyValuePair<string, string>)this.cbxPhaseRetrieval_Input.SelectedItem).Key,
                   zTempFile,
                   Convert.ToInt32(((KeyValuePair<string, string>)this.cbxPhaseRetrievalTab_Algorithms.SelectedItem).Key),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Beta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_BetaExp.Value)),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Delta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_DeltaExp.Value)),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Distance.Value),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_Energy.Value),
                   Convert.ToDouble(this.nudPhaseRetrievalTab_PixelSize.Value),
                   this.chkPhaseRetrievalTab_OverPadding.Checked
            );

            // Create an instance of JobExecuter with the job:
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:            
            mBgwPreview.RunWorkerAsync(zTempFile);
        }

        private void btnReconstructionTab_Preview_Click(object sender, EventArgs e)
        {
            IJob zJob;
            string zTempFile;

            // Modify the cursor:
            mGlass = new HourGlass();

            // Prepare the temporary file name:
            zTempFile = Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar +
                Properties.Settings.Default.SessionID + Path.DirectorySeparatorChar +
                Program.GetTimestamp(DateTime.Now);

            double zScale = 1.0;
            double zCorrectionOffset = 0.0;
            string zRingRemString;
            string zConvertTo8String;
            string zCropString;
            string zParam1;
            bool zDynamicFlatFielding;

            zDynamicFlatFielding = !(this.cbxFlatField.SelectedIndex == 0);

            zRingRemString = ((KeyValuePair<string, string>)this.cbxRingRem.SelectedItem).Key + ":" +
                Convert.ToInt32(nudRingRemParam1.Value).ToString() + ";" + (Convert.ToDouble(nudRingRemParam2.Value)).ToString(CultureInfo.InvariantCulture);

            zConvertTo8String = ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key + ":" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMin.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture) + ";" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMax.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);

            zCropString = Convert.ToInt32(nudConvertToTDF_CropTop.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropBottom.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropLeft.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropRight.Value).ToString();

            double zVal = Convert.ToDouble(this.nudCenter_Middle.Value);
            if ((Math.Abs(zVal - Math.Floor(zVal))) > Double.Epsilon)
                zScale = 2.0;

            if (this.chkCorrectionOffset.Checked)
                zCorrectionOffset = Convert.ToDouble(this.nudCorrectionOffset.Value);

            // Get algorithm-specific parameters:
            if ((((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FBP_CUDA") ||
                 (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "SCIKIT-FBP"))
            {
                zParam1 = ((KeyValuePair<string, string>)this.cbxAlgorithmParameterFilter.SelectedItem).Key.ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "GRIDREC")
            {
                zParam1 = Convert.ToDouble(this.nudGridRec.Value).ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FISTA-TV_CUDA")
            {
                zParam1 = Convert.ToDouble(this.txbReconstructionLambda.Text).ToString();
            }
            else
            {
                zParam1 = Convert.ToInt32(this.nudAlgorithmParameterIterations.Value).ToString();
            }

            zJob = new ReconstructionPreviewJob(
                Convert.ToInt32(this.nudReconstructionTab_Slice.Value),
                ((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key,
                zTempFile,
                this.chkApplyPreProcessing.Checked,
                Convert.ToInt32(this.nudNormSx.Value),
                Convert.ToInt32(this.nudNormDx.Value),
                chkDarkFlatEnd.Checked, // use flat at the end
                chkHalfHalfMode.Checked,
                Convert.ToInt32(this.nudHalfHalfMode.Value),
                chkExtendedFOV.Checked,
                chkExtFOV_AirRight.Checked,
                Convert.ToInt32(nudExtendedFOVOverlap.Value),
                chkExtFOVNormalize.Checked,
                chkExtFOVAverage.Checked,
                zRingRemString,
                Convert.ToDouble(this.nudAngles.Value) * Math.PI / 180.0,
                Convert.ToInt32(this.nudAnglesProjFrom.Value),
                Convert.ToInt32(this.nudAnglesProjTo.Value),
                Convert.ToDouble(this.nudCenter_Middle.Value),
                ((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key,
                zParam1,
                zScale,
                chkOverPadding.Checked,
                this.chkLogTransform.Checked,
                chkCircleMask.Checked,
                (chkZeroneMode.Checked) && (!chkApplyPreProcessing.Checked),
                zCorrectionOffset,
                Convert.ToInt32(this.nudReconstructionTab_Decimate.Value),
                Convert.ToInt32(this.nudReconstructionTab_Downscale.Value),
                this.chkReconstructionTab_PostProcess.Checked,
                zConvertTo8String,
                zCropString,
                this.chkPhrtOnTheFly.Checked,
                Convert.ToInt32(((KeyValuePair<string, string>)this.cbxPhaseRetrievalTab_Algorithms.SelectedItem).Key),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Beta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_BetaExp.Value)),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Delta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_DeltaExp.Value)),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Distance.Value),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Energy.Value),
                Convert.ToDouble(this.nudPhaseRetrievalTab_PixelSize.Value),
                this.chkPhaseRetrievalTab_OverPadding.Checked,
                zDynamicFlatFielding,
                this.gbxRolling.Enabled,
                Convert.ToInt32(this.nudRollShift.Value)  
            );

            // Create an instance of JobExecuter with the job:
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:            
            mBgwPreview.RunWorkerAsync(zTempFile);
        }

        private void mBgwPreview_DoWork(object sender, DoWorkEventArgs e)
        {
            int ct = 0;
            string zTempFile = (string)e.Argument;
            string[] files;

            // Wait 'till file exists:
            do
            {
                System.Threading.Thread.Sleep(100);

                files = Directory.GetFiles(Path.GetDirectoryName(zTempFile), Path.GetFileNameWithoutExtension(zTempFile) + "*");
                ct = files.Length;

            } while (ct == 0);

            // Get the modified file name:
            zTempFile = files[0];

            // Modify the UI:
            this.Invoke((MethodInvoker)delegate
            {
                try
                {
                    this.PreviewImageFromTemporaryFile(zTempFile);
                }
                catch (Exception)
                {
                }
            });

            // Delete temporary file:
            try
            {
                if (File.Exists(zTempFile))
                    File.Delete(zTempFile);
            }
            catch (Exception)
            {
            }
        }

        private void mBgwPreview_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mGlass.Dispose();
        }

        #endregion

        private void cbxDegradationMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key.StartsWith("linear"))
            {
                this.lblPostProcessingTab_LinearRescaleMin.Visible = true;
                this.lblPostProcessingTab_LinearRescaleMax.Visible = true;
                this.txbPostProcessingTab_LinearRescaleMin.Visible = true;
                this.txbPostProcessingTab_LinearRescaleMax.Visible = true;
                this.btnPostProcessingTab_AutoLimit.Visible = true;
            }
            else
            {
                this.lblPostProcessingTab_LinearRescaleMin.Visible = false;
                this.lblPostProcessingTab_LinearRescaleMax.Visible = false;
                this.txbPostProcessingTab_LinearRescaleMin.Visible = false;
                this.txbPostProcessingTab_LinearRescaleMax.Visible = false;
                this.btnPostProcessingTab_AutoLimit.Visible = false;
            }
        }

        private void cbxPreProcessing_Input_DropDownClosed(object sender, EventArgs e)
        {
            string zString;

            zString = ((KeyValuePair<string, string>)this.cbxPreProcessing_Input.SelectedItem).Key;

            // Modify the cursor:
            mGlass = new HourGlass();

            // Check if selected TDF exists:
            if (File.Exists(zString))
            {
                // Modify UI in preprocessing tab:
                this.gbxPreProcessing_Preview.Enabled = true;
                this.gbxPreProcessing_Execute.Enabled = true;

                lblPreProcessing_Output.Text = zString.Remove(zString.Length - 4) + "_corr.tdf";

                this.nudPreprocessingTab_Preview.Minimum = 0;
                this.nudPreprocessingTab_Preview.Maximum = TDFReader.GetNumberOfSlices(zString) - 1;
                this.nudPreprocessingTab_Preview.Value = Convert.ToDecimal(TDFReader.GetNumberOfSlices(zString) / 2);

                this.nudNormSx.Maximum = TDFReader.GetDetectorSize(zString) - 1;
                this.nudNormDx.Maximum = TDFReader.GetDetectorSize(zString) - 1;

                this.nudHalfHalfMode.Maximum = TDFReader.GetNumberOfProjections(zString) - 1;
                this.nudHalfHalfMode.Value = this.nudHalfHalfMode.Maximum / 2;

                this.nudExtendedFOVOverlap.Maximum = TDFReader.GetDetectorSize(zString) - 1;

                this.nudPreprocessingTab_Preview.Maximum = TDFReader.GetNumberOfSlices(zString) - 1;
                this.nudPreprocessingTab_Preview.Value = this.nudPreprocessingTab_Preview.Maximum / 2;

                // Preview by default the central projection:
                //PreviewImageFromTDF(zString, (int)(this.nudDatasetTab_Projection.Value), true);
                //PreviewImageFromTDF(zString, (int) (this.nudDatasetTab_Sinogram.Value), false);
            }

            mGlass.Dispose();
        }

        private void cbxPreProcessing_Input_Click_1(object sender, EventArgs e)
        {
            // Populate the list:
            this.SuspendLayout();

            string zFilter = "*" + Properties.Settings.Default.TomoDataFormatExtension;
            string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.FormSettings_WorkingPath, zFilter, SearchOption.TopDirectoryOnly);
            Dictionary<string, string> zDict = new Dictionary<string, string>();
            if (fileEntries.Length == 0)
                zDict.Add("<none>", "<none>");
            else
            {
                foreach (string fileName in fileEntries)
                    zDict.Add(fileName, Path.GetFileName(fileName));

                // Enable UI controls:
                this.groupBox12.Enabled = true;
                this.groupBox28.Enabled = true;
                this.groupBox8.Enabled = true;
                this.gbxPreProcessing_Preview.Enabled = true;
                this.gbxPreProcessing_Execute.Enabled = true;
            }

            cbxPreProcessing_Input.DataSource = new BindingSource(zDict, null);
            cbxPreProcessing_Input.DisplayMember = "Value";
            cbxPreProcessing_Input.ValueMember = "Key";


            this.ResumeLayout();
        }

        private void RefreshPreprocessingPreviewBitmap()
        {
            int zLeft, zRight;

            Bitmap zBitmapIn = this.kpImageViewer1.Image;

            if (zBitmapIn != null)
            {
                Bitmap zBitmapOut = new Bitmap(zBitmapIn.Width, zBitmapIn.Height, PixelFormat.Format32bppArgb);

                BitmapData zBitmapDataIn = zBitmapIn.LockBits(new Rectangle(0, 0, zBitmapIn.Width, zBitmapIn.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, zBitmapIn.PixelFormat);

                BitmapData zBitmapDataOut = zBitmapOut.LockBits(new Rectangle(0, 0, zBitmapIn.Width, zBitmapIn.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, zBitmapOut.PixelFormat);

                zLeft = nudNormSx.Enabled ? Convert.ToInt32(nudNormSx.Value) : 0;
                zRight = nudNormDx.Enabled ? zBitmapOut.Width - Convert.ToInt32(nudNormDx.Value) : zBitmapOut.Width;

                unsafe
                {
                    int pixelSize = 4;
                    int i, j, j1;

                    for (i = 0; i < zBitmapDataIn.Height; ++i)
                    {
                        byte* rowIn = (byte*)zBitmapDataIn.Scan0 + (i * zBitmapDataIn.Stride);
                        byte* rowOut = (byte*)zBitmapDataOut.Scan0 + (i * zBitmapDataOut.Stride);

                        for (j = 0; j < zBitmapDataIn.Width; ++j)
                        {
                            j1 = j * pixelSize;
                            rowOut[j1] = rowIn[j1];
                            rowOut[j1 + 1] = rowIn[j1 + 1];
                            rowOut[j1 + 2] = rowIn[j1 + 2];

                            rowOut[j1 + 3] = (byte)(((j < zLeft) || (j > zRight)) ? 128 : 255); // Alpha
                        }
                    }

                }
                zBitmapIn.UnlockBits(zBitmapDataIn);
                zBitmapOut.UnlockBits(zBitmapDataOut);

                // Add the Bitmap to the image viewer:
                this.kpImageViewer1.Image = zBitmapOut;
            }
        }

        private void RefreshPostprocessingPreviewBitmap()
        {
            int zLeft, zRight, zTop, zBottom;

            Bitmap zBitmapIn = this.kpImageViewer1.Image;

            if (zBitmapIn != null)
            {
                Bitmap zBitmapOut = new Bitmap(zBitmapIn.Width, zBitmapIn.Height, PixelFormat.Format32bppArgb);

                BitmapData zBitmapDataIn = zBitmapIn.LockBits(new Rectangle(0, 0, zBitmapIn.Width, zBitmapIn.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, zBitmapIn.PixelFormat);

                BitmapData zBitmapDataOut = zBitmapOut.LockBits(new Rectangle(0, 0, zBitmapIn.Width, zBitmapIn.Height),
                   System.Drawing.Imaging.ImageLockMode.WriteOnly, zBitmapOut.PixelFormat);

                zLeft = Convert.ToInt32(nudConvertToTDF_CropLeft.Value);
                zRight = zBitmapOut.Width - Convert.ToInt32(nudConvertToTDF_CropRight.Value);
                zTop = Convert.ToInt32(nudConvertToTDF_CropTop.Value);
                zBottom = zBitmapOut.Height - Convert.ToInt32(nudConvertToTDF_CropBottom.Value);

                unsafe
                {
                    int pixelSize = 4;
                    int i, j, j1;

                    for (i = 0; i < zBitmapDataIn.Height; ++i)
                    {
                        byte* rowIn = (byte*)zBitmapDataIn.Scan0 + (i * zBitmapDataIn.Stride);
                        byte* rowOut = (byte*)zBitmapDataOut.Scan0 + (i * zBitmapDataOut.Stride);

                        for (j = 0; j < zBitmapDataIn.Width; ++j)
                        {
                            j1 = j * pixelSize;
                            rowOut[j1] = rowIn[j1];
                            rowOut[j1 + 1] = rowIn[j1 + 1];
                            rowOut[j1 + 2] = rowIn[j1 + 2];

                            rowOut[j1 + 3] = (byte)((((j < zLeft) || (j > zRight)) ||
                                 ((i < zTop) || (i > zBottom))) ? 128 : 255); // Alpha
                        }
                    }

                }
                zBitmapIn.UnlockBits(zBitmapDataIn);
                zBitmapOut.UnlockBits(zBitmapDataOut);

                // Add the Bitmap to the image viewer:
                this.kpImageViewer1.Image = zBitmapOut;
            }
        }

        private void nudNormSx_ValueChanged(object sender, EventArgs e)
        {
            RefreshPreprocessingPreviewBitmap();
        }

        private void nudNormDx_ValueChanged(object sender, EventArgs e)
        {
            RefreshPreprocessingPreviewBitmap();
        }

        private void nudConvertToTDF_CropTop_ValueChanged(object sender, EventArgs e)
        {
            RefreshPostprocessingPreviewBitmap();
        }

        private void nudConvertToTDF_CropLeft_ValueChanged(object sender, EventArgs e)
        {
            RefreshPostprocessingPreviewBitmap();
        }

        private void nudConvertToTDF_CropBottom_ValueChanged(object sender, EventArgs e)
        {
            RefreshPostprocessingPreviewBitmap();
        }

        private void nudConvertToTDF_CropRight_ValueChanged(object sender, EventArgs e)
        {
            RefreshPostprocessingPreviewBitmap();
        }

        private void btnPostProcessingTab_BrowseInput_Click(object sender, EventArgs e)
        {

            if (zInputTIFFsBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbPostProcessingTab_InputFolder.Text = zInputTIFFsBrowserDialog.SelectedPath;
            }
        }

        private void btnPostProcessinTab_BrowseOutput_Click(object sender, EventArgs e)
        {
            if (zOutputPathBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbPostProcessingTab_OutputPath.Text = zOutputPathBrowserDialog.SelectedPath;

                // Set the numerical controls:                
                nudPostProcessingTab_ExecuteFrom.Enabled = true;
                nudPostProcessingTab_ExecuteTo.Enabled = true;

                btnPostProcessingTab_RunSubset.Enabled = true;
                btnPostProcessingTab_RunAll.Enabled = true;
            }
        }

        private void btnPostProcessingTab_RunSubset_Click(object sender, EventArgs e)
        {
            IJob zJob;
            JobExecuter zExecuter;

            // Create an instance for the post processing job:
            zJob = new PostProcessingJob(
                // Get combobox selection (in handler)
                   txbPostProcessingTab_InputFolder.Text,
                   txbPostProcessingTab_OutputPath.Text,
                   Convert.ToInt32(nudPostProcessingTab_ExecuteFrom.Value),
                   Convert.ToInt32(nudPostProcessingTab_ExecuteTo.Value),
                   ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key,
                   Convert.ToDouble(txbPostProcessingTab_LinearRescaleMin.Text),
                   Convert.ToDouble(txbPostProcessingTab_LinearRescaleMax.Text),
                   Convert.ToInt32(nudConvertToTDF_CropLeft.Value),
                   Convert.ToInt32(nudConvertToTDF_CropRight.Value),
                   Convert.ToInt32(nudConvertToTDF_CropTop.Value),
                   Convert.ToInt32(nudConvertToTDF_CropBottom.Value),
                   Properties.Settings.Default.FormSettings_OutputPrefix,
                   Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses)
            );

            // Create an instance of JobExecuter with the post processing job:
            zExecuter = new JobExecuter(zJob);


            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, Properties.Settings.Default.FormSettings_OutputPrefix);
        }

        private void btnPostProcessingTab_RunAll_Click(object sender, EventArgs e)
        {
            IJob zJob;
            JobExecuter zExecuter;

            // Create an instance for the post processing job:
            zJob = new PostProcessingJob(
                // Get combobox selection (in handler)
                   txbPostProcessingTab_InputFolder.Text,
                   txbPostProcessingTab_OutputPath.Text,
                   Convert.ToInt32(nudPostProcessingTab_ExecuteFrom.Value),
                   Convert.ToInt32(nudPostProcessingTab_ExecuteTo.Value),
                   ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key,
                   Convert.ToDouble(txbPostProcessingTab_LinearRescaleMin.Text),
                   Convert.ToDouble(txbPostProcessingTab_LinearRescaleMax.Text),
                   Convert.ToInt32(nudConvertToTDF_CropLeft.Value),
                   Convert.ToInt32(nudConvertToTDF_CropRight.Value),
                   Convert.ToInt32(nudConvertToTDF_CropTop.Value),
                   Convert.ToInt32(nudConvertToTDF_CropBottom.Value),
                   Properties.Settings.Default.FormSettings_OutputPrefix,
                   Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses)
            );

            // Create an instance of JobExecuter with the post processing job:
            zExecuter = new JobExecuter(zJob);


            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, Properties.Settings.Default.FormSettings_OutputPrefix);
        }

        private void txbPostProcessingTab_InputFolder_TextChanged(object sender, EventArgs e)
        {
            string zFilter;
            int zNrOfProjections;

            if ((txbPostProcessingTab_InputFolder.Text == string.Empty) || !(Directory.Exists(txbPostProcessingTab_InputFolder.Text)))
            {
                gbxPostProcessingTab_Preview.Enabled = false;
                gbxPostProcessingTab_Execute.Enabled = false;
                gbxPostProcessingTab_MethodSettings.Enabled = false;
            }
            else
            {
                gbxPostProcessingTab_Preview.Enabled = true;
                gbxPostProcessingTab_Execute.Enabled = true;
                gbxPostProcessingTab_MethodSettings.Enabled = true;

                // Get the number of projection files:
                zFilter = Properties.Settings.Default.FormSettings_OutputPrefix + "*" + Properties.Settings.Default.TIFFFileFormatExtension + "*";
                zNrOfProjections = (int)(Directory.GetFiles(txbPostProcessingTab_InputFolder.Text, zFilter, SearchOption.TopDirectoryOnly).Length);

                // Set the numerical controls:
                if (zNrOfProjections != 0)
                {
                    nudPostProcessingTab_PreviewSlice.Minimum = 0;
                    nudPostProcessingTab_PreviewSlice.Maximum = zNrOfProjections - 1;
                    nudPostProcessingTab_PreviewSlice.Value = zNrOfProjections / 2;

                    nudPostProcessingTab_ExecuteFrom.Maximum = zNrOfProjections - 1;
                    nudPostProcessingTab_ExecuteFrom.Value = 0;

                    nudPostProcessingTab_ExecuteTo.Maximum = zNrOfProjections;
                    nudPostProcessingTab_ExecuteTo.Value = zNrOfProjections - 1;

                    btnPostProcessingTab_Preview.Enabled = true;
                }
            }
        }

        private void btnPostProcessingTab_Preview_Click(object sender, EventArgs e)
        {
            IJob zJob;
            JobExecuter zExecuter;
            string zTempFile;

            // Modify the cursor:
            mGlass = new HourGlass();

            // Prepare the temporary file name:
            zTempFile = Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar +
                Properties.Settings.Default.SessionID + Path.DirectorySeparatorChar +
                Program.GetTimestamp(DateTime.Now);


            // Create an instance for the phase retrieval job:
            zJob = new PostProcessingPreviewJob(
                    Convert.ToInt32(this.nudPostProcessingTab_PreviewSlice.Value),
                    txbPostProcessingTab_InputFolder.Text,
                    zTempFile,
                    ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key,
                    Convert.ToDouble(txbPostProcessingTab_LinearRescaleMin.Text),
                    Convert.ToDouble(txbPostProcessingTab_LinearRescaleMax.Text),
                    Convert.ToInt32(nudConvertToTDF_CropLeft.Value),
                    Convert.ToInt32(nudConvertToTDF_CropRight.Value),
                    Convert.ToInt32(nudConvertToTDF_CropTop.Value),
                    Convert.ToInt32(nudConvertToTDF_CropBottom.Value),
                    Properties.Settings.Default.FormSettings_OutputPrefix
             );

            // Create an instance of JobExecuter with the Phase Retrieval job:
            zExecuter = new JobExecuter(zJob);


            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Prepare the preview:           
            mBgwPostProcessingPreview.RunWorkerAsync(zTempFile);
        }

        private void txbPostProcessingTab_OutputPath_TextChanged(object sender, EventArgs e)
        {
            if (txbPostProcessingTab_InputFolder.Text == string.Empty)
            {
                nudPostProcessingTab_ExecuteFrom.Enabled = false;
                nudPostProcessingTab_ExecuteTo.Enabled = false;
                btnPostProcessingTab_RunSubset.Enabled = false;
                btnPostProcessingTab_RunAll.Enabled = false;
                lblPostProcessingTab_From.Enabled = false;
                lblPostProcessingTab_To.Enabled = false;
            }
            else
            {
                nudPostProcessingTab_ExecuteFrom.Enabled = true;
                nudPostProcessingTab_ExecuteTo.Enabled = true;
                btnPostProcessingTab_RunSubset.Enabled = true;
                btnPostProcessingTab_RunAll.Enabled = true;
                lblPostProcessingTab_From.Enabled = true;
                lblPostProcessingTab_To.Enabled = true;
            }
        }

        private void mStatusBarProgressBar_DoubleClick(object sender, EventArgs e)
        {
            // Abort current operation (if any):

        }

        private void chkCorrectionOffset_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCorrectionOffset.Checked)
                this.nudCorrectionOffset.Enabled = true;
            else
                this.nudCorrectionOffset.Enabled = false;
        }

        private void convertHISToTDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HISToTDF zForm = new HISToTDF();
            zForm.Show(this);
        }

        private void UpdateDeltaBetaLbl()
        {
            double zVal, zDelta, zBeta;

            zDelta = ((double)(this.nudPhaseRetrievalTab_Delta.Value)) * Math.Pow(10.0, (double)(this.nudPhaseRetrievalTab_DeltaExp.Value));
            zBeta = ((double)(this.nudPhaseRetrievalTab_Beta.Value)) * Math.Pow(10.0, (double)(this.nudPhaseRetrievalTab_BetaExp.Value));

            zVal = (int)(Math.Round(zDelta / zBeta));

            this.lblDeltaBetaRatio.Text = "δ/β = " + zVal.ToString();
        }

        private void zProjections_OptionsDeltaNud_ValueChanged(object sender, EventArgs e)
        {
            UpdateDeltaBetaLbl();
        }

        private void zProjections_OptionsBetaNud_ValueChanged(object sender, EventArgs e)
        {
            UpdateDeltaBetaLbl();
        }

        private void nudExpDelta_ValueChanged(object sender, EventArgs e)
        {
            UpdateDeltaBetaLbl();
        }

        private void nudExpBeta_ValueChanged(object sender, EventArgs e)
        {
            UpdateDeltaBetaLbl();
        }

        private void btnPostProcessingTab_AutoLimit_Click(object sender, EventArgs e)
        {
            IJob zJob;

            mGlass = new HourGlass();

            // Create an instance for the phase retrieval job:
            zJob = new GuessLimitJob(txbPostProcessingTab_InputFolder.Text);

            // Create an instance of JobExecuter with the Phase Retrieval job:
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:            
            this.bgwAutoLimit.RunWorkerAsync(zJob.LogFile);
            //mJobMonitor.Run(zExecuter, BTPSettings.TomoPrefix);

        }

        private void bgwAutoLimit_DoWork(object sender, DoWorkEventArgs e)
        {
            string zLogFile = (string)e.Argument;
            string[] zStrings;

            // Wait 'till file exists:
            while (!(File.Exists(zLogFile)))
            {
                System.Threading.Thread.Sleep(100);
            }

            // Read the file:
            string zValue = System.IO.File.ReadAllText(zLogFile);

            // Modify the UI:
            this.Invoke((MethodInvoker)delegate
            {
                zStrings = zValue.Split(':');
                this.txbPostProcessingTab_LinearRescaleMin.Text = String.Format("{0:0.0000}", System.Convert.ToDecimal(zStrings[0]));
                this.txbPostProcessingTab_LinearRescaleMax.Text = String.Format("{0:0.0000}", System.Convert.ToDecimal(zStrings[1]));
            });


            // Delete the file:
            File.Delete(zLogFile);
        }

        private void bgwAutoLimit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mGlass.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm mAboutForm = new AboutForm();
            mAboutForm.ShowDialog(this);


            //AboutScreen.CloseForm();
        }

        private void mBgwPostProcessingPreview_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mGlass.Dispose();

            // Re-apply cropping windows:
            RefreshPostprocessingPreviewBitmap();
        }

        private void convertEDFsToEDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EDFToTDF zForm = new EDFToTDF();
            zForm.Show(this);
        }

        private void btnMultipleCenters_Click(object sender, EventArgs e)
        {
            double zScale = 1.0;
            double zCorrectionOffset = 0.0;
            string zRingRemString;
            string zConvertTo8String;
            string zCropString;
            string zParam1;

            zRingRemString = ((KeyValuePair<string, string>)this.cbxRingRem.SelectedItem).Key + ":" +
                Convert.ToInt32(nudRingRemParam1.Value).ToString() + ";" + (Convert.ToDouble(nudRingRemParam2.Value)).ToString(CultureInfo.InvariantCulture);

            zConvertTo8String = ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key + ":" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMin.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture) + ";" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMax.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);

            zCropString = Convert.ToInt32(nudConvertToTDF_CropTop.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropBottom.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropLeft.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropRight.Value).ToString();

            double zVal = Convert.ToDouble(this.nudCenter_Middle.Value);
            if ((Math.Abs(zVal - Math.Floor(zVal))) > Double.Epsilon)
                zScale = 2.0;

            if (this.chkCorrectionOffset.Checked)
                zCorrectionOffset = Convert.ToDouble(this.nudCorrectionOffset.Value);

            // Get algorithm-specific parameters:
            if ((((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FBP_CUDA") ||
                 (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "SCIKIT-FBP"))
            {
                zParam1 = ((KeyValuePair<string, string>)this.cbxAlgorithmParameterFilter.SelectedItem).Key.ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "GRIDREC")
            {
                zParam1 = Convert.ToDouble(this.nudGridRec.Value).ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FISTA-TV_CUDA")
            {
                zParam1 = Convert.ToDouble(this.txbReconstructionLambda.Text).ToString();
            }
            else
            {
                zParam1 = Convert.ToInt32(this.nudAlgorithmParameterIterations.Value).ToString();
            }

            MultiOffset zForm = new MultiOffset(
                Properties.Settings.Default.FormSettings_OutputPrefix,
                 Convert.ToInt32(this.nudReconstructionTab_Slice.Value),
                ((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key,
                this.chkApplyPreProcessing.Checked,
                Convert.ToInt32(this.nudNormSx.Value),
                Convert.ToInt32(this.nudNormDx.Value),
                chkDarkFlatEnd.Checked, // use flat at the end
                chkHalfHalfMode.Checked,
                Convert.ToInt32(this.nudHalfHalfMode.Value),
                chkExtendedFOV.Checked,
                chkExtFOV_AirRight.Checked,
                Convert.ToInt32(nudExtendedFOVOverlap.Value),
                zRingRemString,
                Convert.ToDouble(this.nudAngles.Value) * Math.PI / 180.0,
                Convert.ToDouble(this.nudCenter_Middle.Value),
                ((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key,
                zParam1,
                zScale,
                chkOverPadding.Checked,
                this.chkLogTransform.Checked,
                chkCircleMask.Checked,
                (chkZeroneMode.Checked) && (!chkApplyPreProcessing.Checked),
                zCorrectionOffset,
                Convert.ToInt32(this.nudReconstructionTab_Decimate.Value),
                Convert.ToInt32(this.nudReconstructionTab_Downscale.Value),
                this.chkReconstructionTab_PostProcess.Checked,
                zConvertTo8String,
                zCropString,
                this.chkPhrtOnTheFly.Checked,
                Convert.ToInt32(((KeyValuePair<string, string>)this.cbxPhaseRetrievalTab_Algorithms.SelectedItem).Key),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Beta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_BetaExp.Value)),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Delta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_DeltaExp.Value)),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Distance.Value),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Energy.Value),
                Convert.ToDouble(this.nudPhaseRetrievalTab_PixelSize.Value),
                this.chkPhaseRetrievalTab_OverPadding.Checked,
                Convert.ToInt32(this.nudAnglesProjFrom.Value),
                Convert.ToInt32(this.nudAnglesProjTo.Value)
                );
            zForm.Show(this);
        }

        private void openSourceLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSourceAboutBox zAboutBox = new OpenSourceAboutBox();
            
            zAboutBox.ShowDialog(this);
        }

        private void cbxPhaseRetrievalTab_Algorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxPhaseRetrievalTab_Algorithms.SelectedIndex == 0)
            {
                // Paganin's:             
                this.label9.Visible = true;
                this.label10.Visible = true;
                this.nudPhaseRetrievalTab_DeltaExp.Visible = true;
                this.nudPhaseRetrievalTab_BetaExp.Visible = true;
                this.lblDeltaBetaRatio.Visible = true;

                this.label3.Text = "δ:";
                this.label15.Text = "β:";

                this.nudPhaseRetrievalTab_Delta.Minimum = Convert.ToDecimal(0.0001);
                this.nudPhaseRetrievalTab_Delta.Maximum = Convert.ToDecimal(999999.9);
                this.nudPhaseRetrievalTab_Delta.DecimalPlaces = 5;

                this.nudPhaseRetrievalTab_Beta.Minimum = Convert.ToDecimal(0.0001);
                this.nudPhaseRetrievalTab_Beta.Maximum = Convert.ToDecimal(999999.9);
                this.nudPhaseRetrievalTab_Beta.DecimalPlaces = 5;

                this.nudPhaseRetrievalTab_DeltaExp.Value = Convert.ToDecimal(0);
                this.nudPhaseRetrievalTab_BetaExp.Value = Convert.ToDecimal(0);

                this.nudPhaseRetrievalTab_BetaExp.Value = Properties.Settings.Default.PhaseRetrievalTab_BetaExp;
                this.nudPhaseRetrievalTab_Beta.Value = Properties.Settings.Default.PhaseRetrievalTab_Beta;
                this.nudPhaseRetrievalTab_DeltaExp.Value = Properties.Settings.Default.PhaseRetrievalTab_DeltaExp;
                this.nudPhaseRetrievalTab_Delta.Value = Properties.Settings.Default.PhaseRetrievalTab_Delta;
            }
            else
            {
                // Moosmann: 
                this.label9.Visible = false;
                this.label10.Visible = false;
                this.nudPhaseRetrievalTab_DeltaExp.Visible = false;
                this.nudPhaseRetrievalTab_BetaExp.Visible = false;
                this.lblDeltaBetaRatio.Visible = false;

                this.label3.Text = "Regular:";
                this.label15.Text = "Threshold:";

                this.nudPhaseRetrievalTab_Delta.Minimum = Convert.ToDecimal(0.01);
                this.nudPhaseRetrievalTab_Delta.Maximum = Convert.ToDecimal(5.00);
                this.nudPhaseRetrievalTab_Delta.Value = Convert.ToDecimal(2.5);
                this.nudPhaseRetrievalTab_Delta.DecimalPlaces = 2;

                this.nudPhaseRetrievalTab_Beta.Minimum = Convert.ToDecimal(0.01);
                this.nudPhaseRetrievalTab_Beta.Maximum = Convert.ToDecimal(1.00);
                this.nudPhaseRetrievalTab_Beta.Value = Convert.ToDecimal(0.1);
                this.nudPhaseRetrievalTab_Beta.DecimalPlaces = 2;

                this.nudPhaseRetrievalTab_DeltaExp.Value = Convert.ToDecimal(0);
                this.nudPhaseRetrievalTab_BetaExp.Value = Convert.ToDecimal(0);
            }
        }

        private void cbxFlatField_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Modify the cursor:
            mGlass = new HourGlass();

            try
            {
                // First check if a dataset has been selected (an exception is raised):
                string zString = ((KeyValuePair<string, string>)this.cbxPreProcessing_Input.SelectedItem).Key;

                if (this.cbxFlatField.SelectedIndex == 0)
                {
                    // Conventional flat fielding:                    
                    this.chkDarkFlatEnd.Visible = true;
                    this.chkHalfHalfMode.Visible = true;
                    this.nudHalfHalfMode.Visible = true;
                }
                else
                {
                    // Dynamic flat fielding:                 
                    this.chkDarkFlatEnd.Visible = false;
                    this.chkHalfHalfMode.Visible = false;
                    this.nudHalfHalfMode.Visible = false;                  
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                mGlass.Dispose();
            }
        }

        private void btnMultipleAngles_Click(object sender, EventArgs e)
        {
            double zScale = 1.0;
            double zCorrectionOffset = 0.0;
            string zRingRemString;
            string zConvertTo8String;
            string zCropString;
            string zParam1;

            zRingRemString = ((KeyValuePair<string, string>)this.cbxRingRem.SelectedItem).Key + ":" +
                Convert.ToInt32(nudRingRemParam1.Value).ToString() + ";" + (Convert.ToDouble(nudRingRemParam2.Value)).ToString(CultureInfo.InvariantCulture);

            zConvertTo8String = ((KeyValuePair<string, string>)this.cbxDegradationMethods.SelectedItem).Key + ":" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMin.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture) + ";" +
                (double.Parse(txbPostProcessingTab_LinearRescaleMax.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);

            zCropString = Convert.ToInt32(nudConvertToTDF_CropTop.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropBottom.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropLeft.Value).ToString() + ":" +
                          Convert.ToInt32(nudConvertToTDF_CropRight.Value).ToString();

            double zVal = Convert.ToDouble(this.nudCenter_Middle.Value);
            if ((Math.Abs(zVal - Math.Floor(zVal))) > Double.Epsilon)
                zScale = 2.0;

            if (this.chkCorrectionOffset.Checked)
                zCorrectionOffset = Convert.ToDouble(this.nudCorrectionOffset.Value);

            // Get algorithm-specific parameters:
            if ((((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FBP_CUDA") ||
                 (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "SCIKIT-FBP"))
            {
                zParam1 = ((KeyValuePair<string, string>)this.cbxAlgorithmParameterFilter.SelectedItem).Key.ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "GRIDREC")
            {
                zParam1 = Convert.ToDouble(this.nudGridRec.Value).ToString();
            }
            else if (((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key == "FISTA-TV_CUDA")
            {
                zParam1 = Convert.ToDouble(this.txbReconstructionLambda.Text).ToString();
            }
            else
            {
                zParam1 = Convert.ToInt32(this.nudAlgorithmParameterIterations.Value).ToString();
            }

            MultiAngle zForm = new MultiAngle(
                Properties.Settings.Default.FormSettings_OutputPrefix,
                 Convert.ToInt32(this.nudReconstructionTab_Slice.Value),
                ((KeyValuePair<string, string>)this.tbxDatasetName.SelectedItem).Key,
                this.chkApplyPreProcessing.Checked,
                Convert.ToInt32(this.nudNormSx.Value),
                Convert.ToInt32(this.nudNormDx.Value),
                chkDarkFlatEnd.Checked, // use flat at the end
                chkHalfHalfMode.Checked,
                Convert.ToInt32(this.nudHalfHalfMode.Value),
                chkExtendedFOV.Checked,
                chkExtFOV_AirRight.Checked,
                Convert.ToInt32(nudExtendedFOVOverlap.Value),
                zRingRemString,
                Convert.ToDouble(this.nudAngles.Value) * Math.PI / 180.0,
                Convert.ToDouble(this.nudCenter_Middle.Value),
                ((KeyValuePair<string, string>)this.cbxAlgorithm.SelectedItem).Key,
                zParam1,
                zScale,
                chkOverPadding.Checked,
                this.chkLogTransform.Checked,
                chkCircleMask.Checked,
                (chkZeroneMode.Checked) && (!chkApplyPreProcessing.Checked),
                zCorrectionOffset,
                Convert.ToInt32(this.nudReconstructionTab_Decimate.Value),
                Convert.ToInt32(this.nudReconstructionTab_Downscale.Value),
                this.chkReconstructionTab_PostProcess.Checked,
                zConvertTo8String,
                zCropString,
                this.chkPhrtOnTheFly.Checked,
                Convert.ToInt32(((KeyValuePair<string, string>)this.cbxPhaseRetrievalTab_Algorithms.SelectedItem).Key),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Beta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_BetaExp.Value)),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Delta.Value) * Math.Pow(10, Convert.ToDouble(this.nudPhaseRetrievalTab_DeltaExp.Value)),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Distance.Value),
                Convert.ToDouble(this.nudPhaseRetrievalTab_Energy.Value),
                Convert.ToDouble(this.nudPhaseRetrievalTab_PixelSize.Value),
                this.chkPhaseRetrievalTab_OverPadding.Checked,
                Convert.ToInt32(this.nudAnglesProjFrom.Value),
                Convert.ToInt32(this.nudAnglesProjTo.Value)
                );
            zForm.Show(this);
        }

        private void nudRollShift_ValueChanged(object sender, EventArgs e)
        {
            double zVal = Convert.ToDouble(this.nudRollShift.Value) / Convert.ToDouble(this.nudRollShift.Maximum) * Convert.ToDouble(this.nudAngles.Value);

            this.lblRollShift.Text = "projections (i.e. " + zVal.ToString("0.0")  + " deg counterclockwise rotation)";
        }

        private void nudAngles_ValueChanged(object sender, EventArgs e)
        {
            if (Math.Abs(Convert.ToDouble(nudAngles.Value) - 180.0) < 0.001)
            {
                this.gbxRolling.Enabled = true;
            }
            else
            {
                if (Math.Abs(Convert.ToDouble(nudAngles.Value) - 360.0) < 0.001)
                {
                    this.gbxRolling.Enabled = true;
                }
                else
                {
                    this.gbxRolling.Enabled = false;
                }
            }
        }

    }
}
