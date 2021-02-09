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
// Last modified: March, 14th 2017
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
    public partial class PixiradToTDF : Form
    {
        private DateTime mDt;

        private IJobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        private string mTempOutputName = string.Empty;
        private int mNrOfProjections = 0;

        public PixiradToTDF()
        {
            InitializeComponent();

            // Settings for the LocalJobMonitor instance:
            mJobMonitor = new LocalJobMonitor();
            mJobMonitor.JobStarted += new JobStartedEventHandler(mJobMonitor_JobStarted);
            mJobMonitor.JobCompleted += new JobCompletedEventHandler(mJobMonitor_JobCompleted);
            mJobMonitor.JobError += new JobErrorEventHandler(mJobMonitor_JobError);
            mJobMonitor.JobStep += new JobStepEventHandler(mJobMonitor_JobStep);

            // Start the LocalJobMonitor with the background worker:
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
                            Path.GetFileNameWithoutExtension(txbOutputTDF.Text) + Properties.Settings.Default.TomoDataFormatExtension);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowseProjectionHIS_Click(object sender, EventArgs e)
        {
            if (ofdHISProjections.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbProjection.Text = String.Empty;
                txbProjection.Text = ofdHISProjections.FileName;
            }
        }



        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Run Job Convert To TDF:
            IMonitoredJob zJob;

            // Check output file:
            if (File.Exists(Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar +
                        Path.GetFileNameWithoutExtension(txbOutputTDF.Text) + Properties.Settings.Default.TomoDataFormatExtension))
            {
                if (MessageBox.Show("The specified TDF file already exists. Overwrite it?", "SYRMEP Tomo Project",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar +
                        Path.GetFileNameWithoutExtension(txbOutputTDF.Text) + Properties.Settings.Default.TomoDataFormatExtension);
                }
                else
                {
                    return;
                }
            } 

            //mTempOutputName = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + "_" + Program.GetTimestamp(DateTime.Now) + ".tmp";
            mTempOutputName = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + txbOutputTDF.Text;

            // Create an instance for the phase retrieval job:
            zJob = new Pixirad2TDFJob(
                    this.txbProjection.Text,
                    this.txbFlat.Text,
                    mTempOutputName,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudConvertToTDFFrom.Value) : 0,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudConvertToTDFTo.Value) : Convert.ToInt32(this.nudConvertToTDFTo.Maximum),
                    Convert.ToInt32(this.nudConvertToTDF_CropLeft.Value),
                    Convert.ToInt32(this.nudConvertToTDF_CropRight.Value),
                    Convert.ToInt32(this.nudConvertToTDF_CropTop.Value),
                    Convert.ToInt32(this.nudConvertToTDF_CropBottom.Value),                  
                    true,
                    Convert.ToInt32(this.nudOutputCompression.Value)
                    );

            // Create an instance of JobExecuter with the Phase Retrieval job 
            // splitting it into several processes (if specified):
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job: 
            zExecuter.Run();
         
            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, Properties.Settings.Default.FormSettings_ProjectionPrefix);          
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

        private void HISToTDF_Load(object sender, EventArgs e)
        {
            // Center parent:
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);

            // Load settings:
            this.nudConvertToTDF_CropTop.Value = Properties.Settings.Default.HIS2TDF_CropTop;
            this.nudConvertToTDF_CropBottom.Value = Properties.Settings.Default.HIS2TDF_CropBottom;
            this.nudConvertToTDF_CropLeft.Value = Properties.Settings.Default.HIS2TDF_CropLeft;
            this.nudConvertToTDF_CropRight.Value = Properties.Settings.Default.HIS2TDF_CropRight;
            this.nudOutputCompression.Value = Properties.Settings.Default.HIS2TDF_gZipCompression;
        }

        private void HIS2TDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mRunning)
            {
                e.Cancel = true;
                return;
            }

            // Serialize settings:
            if (!e.Cancel)
            {
                Properties.Settings.Default["HIS2TDF_CropTop"]    = this.nudConvertToTDF_CropTop.Value;
                Properties.Settings.Default["HIS2TDF_CropBottom"] = this.nudConvertToTDF_CropBottom.Value;
                Properties.Settings.Default["HIS2TDF_CropLeft"]   = this.nudConvertToTDF_CropLeft.Value;
                Properties.Settings.Default["HIS2TDF_CropRight"]  = this.nudConvertToTDF_CropRight.Value;
                Properties.Settings.Default["HIS2TDF_gZipCompression"] = this.nudOutputCompression.Value;

                Properties.Settings.Default.Save();
            }
        }

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkLock.Checked)
            {
                this.chkLock.Image = Properties.Resources.LockIcon;

                this.lblFlat.Enabled = false;
                this.txbFlat.Enabled = false;

                this.btnBrowseFlat.Enabled = false;
            }
            else
            {
                this.chkLock.Image = Properties.Resources.UnLockIcon;

                this.lblFlat.Enabled = true;
                this.txbFlat.Enabled = true;
             
                this.btnBrowseFlat.Enabled = true;
             
            }
        }

        private void txbProjectionHIS_TextChanged(object sender, EventArgs e)
        {

            if (File.Exists(txbProjection.Text))
            {
                btnConvert.Enabled = true;
                mNrOfProjections = HISReader.GetNumberOfProjections(txbProjection.Text);
                if (mNrOfProjections > 0)
                {
                    this.nudConvertToTDFTo.Maximum = mNrOfProjections - 1;
                    this.nudConvertToTDFFrom.Maximum = mNrOfProjections - 1;
                    this.nudConvertToTDFTo.Value = mNrOfProjections - 1;
                }
                else
                {
                    this.nudConvertToTDFTo.Maximum = 9999;
                    this.nudConvertToTDFFrom.Maximum = 9999;
                    this.nudConvertToTDFTo.Value = 0;
                }

                if (this.chkLock.Checked)
                {
                    // Get extension:
                    string zExt = Path.GetExtension(txbProjection.Text);
                    string zFileName = Path.GetFileNameWithoutExtension(txbProjection.Text);
                    string zPath = Path.GetDirectoryName(txbProjection.Text);

                    if (zPath.EndsWith((Path.DirectorySeparatorChar).ToString()))
                        zPath = zPath.Remove(zPath.Length - 1);

                    txbFlat.Text = zPath + Path.DirectorySeparatorChar + zFileName + "_flat" + zExt;
             
                    txbOutputTDF.Text = zFileName + Properties.Settings.Default.TomoDataFormatExtension;
                }
            }
            else
            {
                btnConvert.Enabled = false;
            }

        }

        private void btnBrowseFlat_Click(object sender, EventArgs e)
        {
            if (ofdHISProjections.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbFlat.Text = ofdHISProjections.FileName;
            }
        }
    }
}
