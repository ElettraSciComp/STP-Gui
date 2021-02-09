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
// Last modified: November, 20th 2019
//


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using SYRMEPTomoProject.Jobs;
using KaiwaProjects;

namespace SYRMEPTomoProject
{
    public partial class GDEI : Form
    {
        private DateTime mDt;

        private IJobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        private string mInputPath = string.Empty;
        private string mTempOutputName = string.Empty;
        private int mNrOfProjections = 0;

        private bool mPreProcess = false;
        private int mAirSx = 0;
        private int mAirDx = 0;
        private bool mFlatEnd = false;
        private bool mHalfHalf = false;
        private int mHalfHalfLine;
        private bool mExtFOV = false;
        private bool mExtFOVRight = false;
        private int mExtFOVOverlap;
        private bool mExtFOVNormalize = false;
        private bool mExtFOVAverage = false;
        private string mRingRemoval = "-";
        private bool mDynamicFlatFielding = false;

        public GDEI(
            int airSx,
            int airDx,
            bool flatEnd,
            bool halfHalf,
            int halfHalfLine,
            bool extFOV,
            bool extFOVRight,
            int extFOVOverlap,
            bool extFOVNormalize,
            bool extFOVAverage,
            string ringRemoval,
            bool dynamicFlatFielding
            )
        {
            InitializeComponent();
            
            mAirSx = airSx;
            mAirDx = airDx;
            mFlatEnd = flatEnd;
            mHalfHalf = halfHalf;
            mHalfHalfLine = halfHalfLine;
            mExtFOV = extFOV;
            mExtFOVRight = extFOVRight;
            mExtFOVOverlap = extFOVOverlap;
            mExtFOVNormalize = extFOVNormalize;
            mExtFOVAverage = extFOVAverage;
            mRingRemoval = ringRemoval;
            mDynamicFlatFielding = dynamicFlatFielding;

            // Settings for the JobMonitor instance:
            mJobMonitor = new LocalJobMonitor();
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
            TimeSpan zElapsedTime, zRemainingTime;

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
                    }
                    catch (Exception)
                    {
                    }
                });
            }
        }

        void mJobMonitor_JobError(object sender, JobEventArgs e)
        {
            mRunning = false;

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

                    btnConvert.Enabled = true;
                    btnClose.Enabled = true;

                    // Rename file:
                    if (File.Exists(this.mTempOutputName))
                    {
                        FileStream zFS = Program.WaitForFile(this.mTempOutputName);
                        zFS.Close();
                        File.Delete(this.mTempOutputName);
                    }
                }
                catch (Exception)
                {
                }
            });
        }

        void mJobMonitor_JobCompleted(object sender, JobEventArgs e)
        {
            mRunning = false;

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

                    btnConvert.Enabled = true;
                    btnClose.Enabled = true;


                    // Rename file:
                    /*if (File.Exists(this.mTempOutputName))
                    {
                        FileStream zFS = Program.WaitForFile(this.mTempOutputName);
                        zFS.Close();
                        File.Move(this.mTempOutputName, Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar +
                            Path.GetFileNameWithoutExtension(txbOutputTDF.Text) + ".tdf");
                    }*/
                }
                catch (Exception)
                {
                }

            });
        }

        void mJobMonitor_JobStarted(object sender, JobEventArgs e)
        {
            string zString;

            mRunning = true;

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
                    btnConvert.Enabled = false;
                    btnClose.Enabled = false;
                }
                catch (Exception)
                {
                }
            });
        }

        private void mJobMonitorBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            mJobMonitor.Start();
        }

        #endregion

        /// <summary>
        /// To be called by the tbxProjectionPrefix_TextChanged and zProject_InputPathTxb_TextChanged events.
        /// </summary>
        private void UpdateValues()
        {
           /* if (Directory.Exists(mInputPath))
            {
                // Get the number of projection files:
                string zFilter;

                // Get the number of projection files:
                zFilter = tbxProjectionPrefix.Text + "*" + Properties.Settings.Default.TIFFFileFormatExtension + "*";
                mNrOfProjections = (int)(Directory.GetFiles(mInputPath, zFilter, SearchOption.TopDirectoryOnly).Length);

                if ((mNrOfProjections > 0) && (tbxProjectionPrefix.Text != string.Empty))
                {
                    nudConvertToTDFFrom.Maximum = mNrOfProjections - 1;
                    nudConvertToTDFTo.Maximum = mNrOfProjections - 1;

                    // Set the default name for the dataset as folder name:
                    string fullPath = Path.GetFullPath(mInputPath).TrimEnd(Path.DirectorySeparatorChar);
                    string projectName = Path.GetFileName(fullPath);
                    this.txbOutputTDF.Text = projectName + Properties.Settings.Default.TomoDataFormatExtension;

                    btnConvert.Enabled = true;
                    gbxOutput.Enabled = true;
                    gbxCrop.Enabled = true;
                    gbxSubset.Enabled = true;
                    gbxFormat.Enabled = true;
                    this.toolStripStatusLabel1.Text = mNrOfProjections.ToString() + " files found.";
                }
                else
                {
                    btnConvert.Enabled = false;
                    gbxOutput.Enabled = false;
                    gbxCrop.Enabled = false;
                    gbxSubset.Enabled = false;
                    gbxFormat.Enabled = false;
                    this.toolStripStatusLabel1.Text = "Files not found. Check folder and prefixes.";
                }
            }
            else
            {
                btnConvert.Enabled = false;
                gbxOutput.Enabled = false;
                gbxCrop.Enabled = false;
                gbxSubset.Enabled = false;
                gbxFormat.Enabled = false;
                this.toolStripStatusLabel1.Text = "Invalid folder.";
            }*/
        }
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Run GDEI Job:
            IJob zJob;         
   
            string zInputFile_1 = ((KeyValuePair<string, string>)this.cbxGDEI_Input2.SelectedItem).Key;
            string zInputFile_2 = ((KeyValuePair<string, string>)this.cbxGDEI_Input1.SelectedItem).Key;
            string zInputFile_3 = ((KeyValuePair<string, string>)this.cbxGDEI_Input3.SelectedItem).Key;

            String[] zSubStrings = Path.GetFileName(zInputFile_1).Split('_');
            string zOutputPrefix = string.Empty;
            for (int i = 0; i < zSubStrings.Length - 1; i++)
                zOutputPrefix += zSubStrings[i];

            string zOutputFile_Abs = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + zOutputPrefix + "_abs" + Properties.Settings.Default.TomoDataFormatExtension;
            string zOutputFile_Refr = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + zOutputPrefix + "_ref" + Properties.Settings.Default.TomoDataFormatExtension;
            string zOutputFile_Sca = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + zOutputPrefix + "_sca" + Properties.Settings.Default.TomoDataFormatExtension;

            // Create an instance for the phase retrieval job:
            zJob = new GDEIJob(
                zInputFile_1,
                zInputFile_2,
                zInputFile_3,
                zOutputFile_Abs,
                zOutputFile_Refr,
                zOutputFile_Sca,
                0, //(this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudConvertToTDFFrom.Value) : 0,
                TDFReader.GetNumberOfSlices(zInputFile_1) - 1, //-1, //(this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudConvertToTDFTo.Value) : -1,
                this.mAirSx,
                this.mAirDx,
                this.mFlatEnd,
                this.mHalfHalf,
                this.mHalfHalfLine,
                this.mExtFOV,
                this.mExtFOVRight,
                this.mExtFOVOverlap,
                this.mExtFOVNormalize,
                this.mExtFOVAverage,
                this.mRingRemoval,
                this.mDynamicFlatFielding,
                Convert.ToInt32(this.nudGDEI_ShiftVert1.Value),
                Convert.ToInt32(this.nudGDEI_ShiftHoriz1.Value),
                Convert.ToInt32(this.nudGDEI_ShiftVert2.Value),
                Convert.ToInt32(this.nudGDEI_ShiftHoriz2.Value),
                Convert.ToInt32(this.nudGDEI_ShiftVert3.Value),
                Convert.ToInt32(this.nudGDEI_ShiftHoriz3.Value),

                Convert.ToDouble(this.nudGDEI_r1.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_r1Exp.Value)),
                Convert.ToDouble(this.nudGDEI_r2.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_r2Exp.Value)),
                Convert.ToDouble(this.nudGDEI_r3.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_r3Exp.Value)),

                Convert.ToDouble(this.nudGDEI_d1.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_d1Exp.Value)),
                Convert.ToDouble(this.nudGDEI_d2.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_d2Exp.Value)),
                Convert.ToDouble(this.nudGDEI_d3.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_d3Exp.Value)),

                Convert.ToDouble(this.nudGDEI_dd1.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_dd1Exp.Value)),
                Convert.ToDouble(this.nudGDEI_dd2.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_dd2Exp.Value)),
                Convert.ToDouble(this.nudGDEI_dd3.Value) * Math.Pow(10, Convert.ToDouble(this.nudGDEI_dd3Exp.Value)),

                 Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses)
                 );

            // Create an instance of JobExecuter with the Phase Retrieval job 
            // splitting it into several processes (if specified):
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job: 
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, "sino");

            // Reset status bar:
            this.toolStripStatusLabel1.Text = string.Empty;
        }

        private void GDEI_Load(object sender, EventArgs e)
        {
            // Deactivate preview:
            this.gbxDEIPreview.Visible = false;
            this.Width = 494;

            this.label26.Enabled = false;
            this.label27.Enabled = false;
            this.label28.Enabled = false;

            this.nudGDEI_Rolling1.Enabled = false;
            this.nudGDEI_Rolling2.Enabled = false;
            this.nudGDEI_Rolling3.Enabled = false;

            // Center parent:
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);

         

            // Load settings:
            this.nudGDEI_ShiftVert1.Value = Properties.Settings.Default.GDEI_ShiftVert1;
            this.nudGDEI_ShiftHoriz1.Value = Properties.Settings.Default.GDEI_ShiftHoriz1;
            this.nudGDEI_ShiftVert2.Value = Properties.Settings.Default.GDEI_ShiftVert2;
            this.nudGDEI_ShiftHoriz2.Value = Properties.Settings.Default.GDEI_ShiftHoriz2;
            this.nudGDEI_ShiftVert3.Value = Properties.Settings.Default.GDEI_ShiftVert3;
            this.nudGDEI_ShiftHoriz3.Value = Properties.Settings.Default.GDEI_ShiftHoriz3;
            this.nudGDEI_Rolling1.Value = Properties.Settings.Default.GDEI_Rolling1;
            this.nudGDEI_Rolling2.Value = Properties.Settings.Default.GDEI_Rolling2;
            this.nudGDEI_Rolling3.Value = Properties.Settings.Default.GDEI_Rolling3;

            this.nudGDEI_r1.Value = Properties.Settings.Default.GDEI_r1;
            this.nudGDEI_r1Exp.Value = Properties.Settings.Default.GDEI_r1Exp;
            this.nudGDEI_d1.Value = Properties.Settings.Default.GDEI_d1;
            this.nudGDEI_d1Exp.Value = Properties.Settings.Default.GDEI_d1Exp;
            this.nudGDEI_dd1.Value = Properties.Settings.Default.GDEI_dd1;
            this.nudGDEI_dd1Exp.Value = Properties.Settings.Default.GDEI_dd1Exp;

            this.nudGDEI_r2.Value = Properties.Settings.Default.GDEI_r2;
            this.nudGDEI_r2Exp.Value = Properties.Settings.Default.GDEI_r2Exp;
            this.nudGDEI_d2.Value = Properties.Settings.Default.GDEI_d2;
            this.nudGDEI_d2Exp.Value = Properties.Settings.Default.GDEI_d2Exp;
            this.nudGDEI_dd2.Value = Properties.Settings.Default.GDEI_dd2;
            this.nudGDEI_dd2Exp.Value = Properties.Settings.Default.GDEI_dd2Exp;

            this.nudGDEI_r3.Value = Properties.Settings.Default.GDEI_r3;
            this.nudGDEI_r3Exp.Value = Properties.Settings.Default.GDEI_r3Exp;
            this.nudGDEI_d3.Value = Properties.Settings.Default.GDEI_d3;
            this.nudGDEI_d3Exp.Value = Properties.Settings.Default.GDEI_d3Exp;
            this.nudGDEI_dd3.Value = Properties.Settings.Default.GDEI_dd3;
            this.nudGDEI_dd3Exp.Value = Properties.Settings.Default.GDEI_dd3Exp;
        }

        private void GDEI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mRunning)
            {
                e.Cancel = true;
                return;
            }

            // Serialize settings:
            if (!e.Cancel)
            {
                Properties.Settings.Default["GDEI_ShiftVert1"] = this.nudGDEI_ShiftVert1.Value;
                Properties.Settings.Default["GDEI_ShiftHoriz1"] = this.nudGDEI_ShiftHoriz1.Value;
                Properties.Settings.Default["GDEI_ShiftVert2"] = this.nudGDEI_ShiftVert2.Value;
                Properties.Settings.Default["GDEI_ShiftHoriz2"] = this.nudGDEI_ShiftHoriz2.Value;
                Properties.Settings.Default["GDEI_ShiftVert3"] = this.nudGDEI_ShiftVert3.Value;
                Properties.Settings.Default["GDEI_ShiftHoriz3"] = this.nudGDEI_ShiftHoriz3.Value;

                Properties.Settings.Default["GDEI_Rolling1"] = this.nudGDEI_Rolling1.Value;
                Properties.Settings.Default["GDEI_Rolling2"] = this.nudGDEI_Rolling2.Value;
                Properties.Settings.Default["GDEI_Rolling3"] = this.nudGDEI_Rolling3.Value;

                Properties.Settings.Default["GDEI_r1"] = this.nudGDEI_r1.Value;
                Properties.Settings.Default["GDEI_r1Exp"] = this.nudGDEI_r1Exp.Value;
                Properties.Settings.Default["GDEI_d1"] = this.nudGDEI_d1.Value;
                Properties.Settings.Default["GDEI_d1Exp"] = this.nudGDEI_d1Exp.Value;
                Properties.Settings.Default["GDEI_dd1"] = this.nudGDEI_dd1.Value;
                Properties.Settings.Default["GDEI_dd1Exp"] = this.nudGDEI_dd1Exp.Value;

                Properties.Settings.Default["GDEI_r2"] = this.nudGDEI_r2.Value;
                Properties.Settings.Default["GDEI_r2Exp"] = this.nudGDEI_r2Exp.Value;
                Properties.Settings.Default["GDEI_d2"] = this.nudGDEI_d2.Value;
                Properties.Settings.Default["GDEI_d2Exp"] = this.nudGDEI_d2Exp.Value;
                Properties.Settings.Default["GDEI_dd2"] = this.nudGDEI_dd2.Value;
                Properties.Settings.Default["GDEI_dd2Exp"] = this.nudGDEI_dd2Exp.Value;

                Properties.Settings.Default["GDEI_r3"] = this.nudGDEI_r3.Value;
                Properties.Settings.Default["GDEI_r3Exp"] = this.nudGDEI_r3Exp.Value;
                Properties.Settings.Default["GDEI_d3"] = this.nudGDEI_d3.Value;
                Properties.Settings.Default["GDEI_d3Exp"] = this.nudGDEI_d3Exp.Value;
                Properties.Settings.Default["GDEI_dd3"] = this.nudGDEI_dd3.Value;
                Properties.Settings.Default["GDEI_dd3Exp"] = this.nudGDEI_dd3Exp.Value;

                Properties.Settings.Default.Save();
            }
        }
              

        private void cbxGDEI_Input1_Click(object sender, EventArgs e)
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

            cbxGDEI_Input1.DataSource = new BindingSource(zDict, null);
            cbxGDEI_Input1.DisplayMember = "Value";
            cbxGDEI_Input1.ValueMember = "Key";

            this.ResumeLayout();
        }

        private void cbxGDEI_Input2_Click(object sender, EventArgs e)
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

            cbxGDEI_Input2.DataSource = new BindingSource(zDict, null);
            cbxGDEI_Input2.DisplayMember = "Value";
            cbxGDEI_Input2.ValueMember = "Key";

            this.ResumeLayout();
        }

        private void cbxGDEI_Input3_Click(object sender, EventArgs e)
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

            cbxGDEI_Input3.DataSource = new BindingSource(zDict, null);
            cbxGDEI_Input3.DisplayMember = "Value";
            cbxGDEI_Input3.ValueMember = "Key";

            this.ResumeLayout();
        }

        

        private void cbxGDEI_Input1_DropDownClosed(object sender, EventArgs e)
        {
            this.SuspendLayout();

            string zInputTDF = ((KeyValuePair<string, string>)this.cbxGDEI_Input1.SelectedItem).Key;


            // Check if selected TDF exists:
            if (File.Exists(zInputTDF))
            {              
                this.gbxCoeff1.Enabled = true;
                this.gbxAlignmentLeft.Enabled = true;

                try
                {
                    string zTDF_2 = ((KeyValuePair<string, string>)this.cbxGDEI_Input2.SelectedItem).Key;
                    string zTDF_3 = ((KeyValuePair<string, string>)this.cbxGDEI_Input3.SelectedItem).Key;

                    if (File.Exists(zTDF_2) & File.Exists(zTDF_3))
                    {
                        this.btnConvert.Enabled = true;
                    }
                    else
                    {
                        this.btnConvert.Enabled = false;
                    }
                }
                catch (Exception) { }
            }
            else
            {
                this.gbxCoeff1.Enabled = false;
                this.gbxAlignmentLeft.Enabled = false;
            }

            this.ResumeLayout();
        }

        private void cbxGDEI_Input2_DropDownClosed(object sender, EventArgs e)
        {
            this.SuspendLayout();

            string zInputTDF = ((KeyValuePair<string, string>)this.cbxGDEI_Input2.SelectedItem).Key;


            // Check if selected TDF exists:
            if (File.Exists(zInputTDF))
            {
                this.gbxCoeff2.Enabled = true;
                this.gbxAlignmentTop.Enabled = true;

                try
                {
                    string zTDF_1 = ((KeyValuePair<string, string>)this.cbxGDEI_Input1.SelectedItem).Key;
                    string zTDF_3 = ((KeyValuePair<string, string>)this.cbxGDEI_Input3.SelectedItem).Key;

                    if (File.Exists(zTDF_1) & File.Exists(zTDF_3))
                    {
                        this.btnConvert.Enabled = true;
                    }
                    else
                    {
                        this.btnConvert.Enabled = false;
                    }
                }
                catch (Exception) { }
            }
            else
            {
                this.gbxCoeff2.Enabled = false;
                this.gbxAlignmentTop.Enabled = false;
            }

            this.ResumeLayout();
        }

        private void cbxGDEI_Input3_DropDownClosed(object sender, EventArgs e)
        {
            this.SuspendLayout();

            string zInputTDF = ((KeyValuePair<string, string>)this.cbxGDEI_Input3.SelectedItem).Key;


            // Check if selected TDF exists:
            if (File.Exists(zInputTDF))
            {                
                this.gbxCoeff3.Enabled = true;
                this.gbxAlignmentRight.Enabled = true;

                try
                {
                    string zTDF_2 = ((KeyValuePair<string, string>)this.cbxGDEI_Input2.SelectedItem).Key;
                    string zTDF_1 = ((KeyValuePair<string, string>)this.cbxGDEI_Input1.SelectedItem).Key;

                    if (File.Exists(zTDF_2) & File.Exists(zTDF_1))
                    {
                        this.btnConvert.Enabled = true;
                    }
                    else
                    {
                        this.btnConvert.Enabled = false;
                    }
                }
                catch (Exception) { }
            }
            else
            {
                this.gbxCoeff3.Enabled = false;
                this.gbxAlignmentRight.Enabled = false;
            }

            this.ResumeLayout();
        }
    }
}
