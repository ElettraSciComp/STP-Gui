/***************************************************************************/
/* (C) 2016 Elettra - Sincrotrone Trieste S.C.p.A.. All rights reserved.   */
/*                                                                         */
/*                                                                         */
/* This file is part of STP-Core, the Python core of SYRMEP Tomo Project,  */
/* a software tool for the reconstruction of experimental CT datasets.     */
/*                                                                         */
/* STP-Core is free software: you can redistribute it and/or modify it     */
/* under the terms of the GNU General Public License as published by the   */
/* Free Software Foundation, either version 3 of the License, or (at your  */
/* option) any later version.                                              */
/*                                                                         */
/* STP-Core is distributed in the hope that it will be useful, but WITHOUT */
/* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or   */
/* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License    */
/* for more details.                                                       */
/*                                                                         */
/* You should have received a copy of the GNU General Public License       */
/* along with STP-Core. If not, see <http://www.gnu.org/licenses/>.        */
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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using SYRMEPTomoProject.Jobs;
using KaiwaProjects;

namespace SYRMEPTomoProject
{
    public partial class EDFToTDF : Form
    {
        private DateTime mDt;

        private JobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        private string mInputPath = string.Empty;
        private string mTempOutputName = string.Empty;
        private int mNrOfProjections = 0;

        public EDFToTDF()
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
                    if (File.Exists(this.mTempOutputName))
                    {
                        FileStream zFS = Program.WaitForFile(this.mTempOutputName);
                        zFS.Close();
                        File.Move(this.mTempOutputName, Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar +
                            Path.GetFileNameWithoutExtension(txbOutputTDF.Text) + ".tdf");
                    }
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
        private void UpdateValues(bool flagPrefix)
        {
            if (Directory.Exists(mInputPath))
            {
                // Get the number of projection files:
                string zFilter;

                // Set the default name for the dataset as folder name:
                if (flagPrefix)
                {
                    string fullPath = Path.GetFullPath(mInputPath).TrimEnd(Path.DirectorySeparatorChar);
                    string projectName = Path.GetFileName(fullPath);
                    this.tbxProjectionPrefix.Text = projectName;
                }

                // Get the number of projection files:
                zFilter = tbxProjectionPrefix.Text + "*" + Properties.Settings.Default.EDFFileFormatExtension + "*";
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
            }
        }

        /// <summary>
        /// To be called by btnBrowseTIFFs_Click event by loading the first image.
        /// </summary>
        private void UpdateCropSizes()
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseEDFs_Click(object sender, EventArgs e)
        {
            if (zInputTIFFsBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                zProject_InputPathTxb.Text = zInputTIFFsBrowserDialog.SelectedPath;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Run Job Convert To TDF:
            IJob zJob;

            mTempOutputName = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + "_" + Program.GetTimestamp(DateTime.Now) + ".tmp";

            // Create an instance for the phase retrieval job:
            zJob = new EDF2TDFJob(
                    mInputPath,
                    mTempOutputName,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudConvertToTDFFrom.Value) : 0,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudConvertToTDFTo.Value) : Convert.ToInt32(this.nudConvertToTDFTo.Maximum),
                    Convert.ToInt32(this.nudConvertToTDF_CropLeft.Value),
                    Convert.ToInt32(this.nudConvertToTDF_CropRight.Value),
                    Convert.ToInt32(this.nudConvertToTDF_CropTop.Value),
                    Convert.ToInt32(this.nudConvertToTDF_CropBottom.Value),
                    tbxProjectionPrefix.Text,
                    tbxFlatPrefix.Text,
                    tbxDarkPrefix.Text,
                    (this.rbtInputSinograms.Checked) ? false : true,
                    Convert.ToInt32(this.nudOutputCompression.Value),
                    Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses)
                    );

            // Create an instance of JobExecuter with the Phase Retrieval job 
            // splitting it into several processes (if specified):
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job: 
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, this.tbxProjectionPrefix.Text);

            // Reset status bar:
            this.toolStripStatusLabel1.Text = string.Empty;
        }

        private void EDFToTDF_Load(object sender, EventArgs e)
        {
            // Center parent:
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);

            // Load settings:
            
            this.nudConvertToTDF_CropTop.Value = Properties.Settings.Default.EDF2TDF_CropTop;
            this.nudConvertToTDF_CropBottom.Value = Properties.Settings.Default.EDF2TDF_CropBottom;
            this.nudConvertToTDF_CropLeft.Value = Properties.Settings.Default.EDF2TDF_CropLeft;
            this.nudConvertToTDF_CropRight.Value = Properties.Settings.Default.EDF2TDF_CropRight;
            this.nudOutputCompression.Value = Properties.Settings.Default.EDF2TDF_gZipCompression;

            this.tbxDarkPrefix.Text = Properties.Settings.Default.EDF2TDF_FilePrefixDark;
            this.tbxFlatPrefix.Text = Properties.Settings.Default.EDF2TDF_FilePrefixFlat;

            this.rbtInputProjections.Checked = Properties.Settings.Default.EDF2TDF_InputProjectionsChecked;
            this.rbtInputSinograms.Checked = !Properties.Settings.Default.EDF2TDF_InputProjectionsChecked;            
        }

        private void EDFToTDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mRunning)
            {
                e.Cancel = true;
                return;
            }

            // Serialize settings:
            if (!e.Cancel)
            {
                Properties.Settings.Default["EDF2TDF_CropTop"] = this.nudConvertToTDF_CropTop.Value;
                Properties.Settings.Default["EDF2TDF_CropBottom"] = this.nudConvertToTDF_CropBottom.Value;
                Properties.Settings.Default["EDF2TDF_CropLeft"] = this.nudConvertToTDF_CropLeft.Value;
                Properties.Settings.Default["EDF2TDF_CropRight"] = this.nudConvertToTDF_CropRight.Value;
                Properties.Settings.Default["EDF2TDF_gZipCompression"] = this.nudOutputCompression.Value;
                                
                Properties.Settings.Default["EDF2TDF_FilePrefixDark"] = this.tbxDarkPrefix.Text;
                Properties.Settings.Default["EDF2TDF_FilePrefixFlat"] = this.tbxFlatPrefix.Text;
                Properties.Settings.Default["EDF2TDF_InputProjectionsChecked"] = this.rbtInputProjections.Checked;
                
                Properties.Settings.Default.Save();
            }
        }

        private void rbtInputSinograms_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtInputSinograms.Checked)
            {
                /*this.rbtOuputDirect.Enabled = true;
                this.rbtOutputSinogram.Enabled = true;*/

                this.tbxProjectionPrefix.Text = "sino";
                this.lblProjections.Text = "Sinograms:";
                this.lblProjections.Location = new Point(22, 26);
                //this.lblDetail.Text = "(files e.g. sino_0001.tif are considered)";

                this.tbxDarkPrefix.Enabled = true;
                this.tbxFlatPrefix.Enabled = true;
                //this.tbxPostDarkPrefix.Enabled = true;
                //this.tbxPostFlatPrefix.Enabled = true;
            }
        }

        private void rbtInputProjections_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtInputProjections.Checked)
            {
                /*this.rbtOuputDirect.Enabled = true;
                this.rbtOutputSinogram.Enabled = true;*/

                this.tbxProjectionPrefix.Text = "tomo";
                this.lblProjections.Text = "Projections:";
                this.lblProjections.Location = new Point(19, 26);
                //this.lblDetail.Text = "(files e.g. tomo_0001.tif are considered)";

                this.tbxDarkPrefix.Enabled = true;
                this.tbxFlatPrefix.Enabled = true;
                // this.tbxPostDarkPrefix.Enabled = true;
                // this.tbxPostFlatPrefix.Enabled = true;
            }
        }

        private void chkConsiderSubset_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkConsiderSubset.Checked)
            {
                this.nudConvertToTDFFrom.Enabled = true;
                this.nudConvertToTDFTo.Enabled = true;
            }
            else
            {
                this.nudConvertToTDFFrom.Enabled = false;
                this.nudConvertToTDFTo.Enabled = false;
            }
        }

        private void tbxProjectionPrefix_TextChanged(object sender, EventArgs e)
        {
            UpdateValues(false);
        }

        private void zProject_InputPathTxb_TextChanged(object sender, EventArgs e)
        {
            mInputPath = zProject_InputPathTxb.Text;
            UpdateValues(true);
        }
    }
}
