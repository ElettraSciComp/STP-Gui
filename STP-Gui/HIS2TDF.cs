/***************************************************************************/
/* (C) 2016 Elettra - Sincrotrone Trieste S.C.p.A.. All rights reserved.   */
/*                                                                         */
/* Copyright 2016. Elettra - Sincrotrone Trieste S.C.p.A. THE COMPANY      */
/* ELETTRA - SINCROTRONE TRIESTE S.C.P.A. IS NOT REPONSIBLE FOR THE USE    */
/* OF THIS SOFTWARE. If software is modified to produce derivative works,  */
/* such modified software should be clearly marked, so as not to confuse   */
/* it with the version available from Elettra Sincrotrone Trieste S.C.p.A. */
/*                                                                         */
/* Additionally, redistribution and use in source and binary forms, with   */
/* or without modification, are permitted provided that the following      */
/* conditions are met:                                                     */
/*                                                                         */
/*     * Redistributions of source code must retain the above copyright    */
/*       notice, this list of conditions and the following disclaimer.     */
/*                                                                         */
/*     * Redistributions in binary form must reproduce the above copyright */
/*       notice, this list of conditions and the following disclaimer in   */
/*       the documentation and/or other materials provided with the        */
/*       distribution.                                                     */
/*                                                                         */
/*     * Neither the name of Elettra - Sincotrone Trieste S.C.p.A nor      */
/*       the names of its contributors may be used to endorse or promote   */
/*       products derived from this software without specific prior        */
/*       written permission.                                               */
/*                                                                         */
/* THIS SOFTWARE IS PROVIDED BY ELETTRA - SINCROTRONE TRIESTE S.C.P.A. AND */
/* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  */
/* BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND       */
/* FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL      */
/* ELETTRA - SINCROTRONE TRIESTE S.C.P.A. OR CONTRIBUTORS BE LIABLE FOR    */
/* ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL  */
/* DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE       */
/* GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS           */
/* INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER    */
/* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR         */
/* OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF  */
/* ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.                              */
/***************************************************************************/

//
// Author: Francesco Brun
// Last modified: May, 4th 2016
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
    public partial class HISToTDF : Form
    {
        private DateTime mDt;

        private JobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        private string mTempOutputName = string.Empty;
        private int mNrOfProjections = 0;

        public HISToTDF()
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
                txbProjectionHIS.Text = String.Empty;
                txbProjectionHIS.Text = ofdHISProjections.FileName;
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

            mTempOutputName = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + "_" + Program.GetTimestamp(DateTime.Now) + ".tmp";

            // Create an instance for the phase retrieval job:
            zJob = new HIS2TDFJob(
                    this.txbProjectionHIS.Text,
                    this.txbDarkHIS.Text,
                    this.txbFlatHIS.Text,
                    this.txbPostDarkHIS.Text,
                    this.txbPostFlatHIS.Text,
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

                this.lblDark.Enabled = false;
                this.lblFlat.Enabled = false;
                this.lblDarkPost.Enabled = false;
                this.lblFlatPost.Enabled = false;

                this.txbDarkHIS.Enabled = false;
                this.txbFlatHIS.Enabled = false;
                this.txbPostDarkHIS.Enabled = false;
                this.txbPostFlatHIS.Enabled = false;

                this.btnBrowseFlat.Enabled = false;
                this.btnBrowseDark.Enabled = false;
                this.btnBrowseDarkPost.Enabled = false;
                this.btnBrowseFlatPost.Enabled = false;
            }
            else
            {
                this.chkLock.Image = Properties.Resources.UnLockIcon;

                this.lblDark.Enabled = true;
                this.lblFlat.Enabled = true;
                this.lblDarkPost.Enabled = true;
                this.lblFlatPost.Enabled = true;

                this.txbDarkHIS.Enabled = true;
                this.txbFlatHIS.Enabled = true;
                this.txbPostDarkHIS.Enabled = true;
                this.txbPostFlatHIS.Enabled = true;

                this.btnBrowseFlat.Enabled = true;
                this.btnBrowseDark.Enabled = true;
                this.btnBrowseDarkPost.Enabled = true;
                this.btnBrowseFlatPost.Enabled = true;
            }
        }

        private void txbProjectionHIS_TextChanged(object sender, EventArgs e)
        {

            if (File.Exists(txbProjectionHIS.Text))
            {
                btnConvert.Enabled = true;
                mNrOfProjections = HISReader.GetNumberOfProjections(txbProjectionHIS.Text);
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
                    string zExt = Path.GetExtension(txbProjectionHIS.Text);
                    string zFileName = Path.GetFileNameWithoutExtension(txbProjectionHIS.Text);
                    string zPath = Path.GetDirectoryName(txbProjectionHIS.Text);

                    if (zPath.EndsWith((Path.DirectorySeparatorChar).ToString()))
                        zPath = zPath.Remove(zPath.Length - 1);

                    txbDarkHIS.Text = zPath + Path.DirectorySeparatorChar + zFileName + "_dark" + zExt;
                    txbFlatHIS.Text = zPath + Path.DirectorySeparatorChar + zFileName + "_flat" + zExt;
                    txbPostDarkHIS.Text = zPath + Path.DirectorySeparatorChar + zFileName + "_postdark" + zExt;
                    txbPostFlatHIS.Text = zPath + Path.DirectorySeparatorChar + zFileName + "_postflat" + zExt;

                    txbOutputTDF.Text = zFileName + Properties.Settings.Default.TomoDataFormatExtension;
                }
            }
            else
            {
                btnConvert.Enabled = false;
            }

        }

        private void btnBrowseDark_Click(object sender, EventArgs e)
        {
            if (ofdHISProjections.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbDarkHIS.Text = ofdHISProjections.FileName;
            }
        }

        private void btnBrowseFlat_Click(object sender, EventArgs e)
        {
            if (ofdHISProjections.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txbFlatHIS.Text = ofdHISProjections.FileName;
            }
        }

        private void btnBrowseDarkPost_Click(object sender, EventArgs e)
        {
            if (ofdHISProjections.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txbPostDarkHIS.Text = ofdHISProjections.FileName;
            }
        }

        private void btnBrowseFlatPost_Click(object sender, EventArgs e)
        {
            if (ofdHISProjections.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txbPostFlatHIS.Text = ofdHISProjections.FileName;
            }
        }

    }
}
