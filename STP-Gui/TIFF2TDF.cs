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
// Last modified: April, 11th 2016
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
    public partial class TIFFToTDF : Form
    {
        private DateTime mDt;        

        private JobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        private string mInputPath = string.Empty;
        private string mTempOutputName = string.Empty;
        private int mNrOfProjections = 0;

        public TIFFToTDF()
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
                });
            }
        }

        void mJobMonitor_JobError(object sender, JobEventArgs e)
        {
            mRunning = false;

            // Thread safe (it runs on UI thread):
            this.Invoke((MethodInvoker)delegate
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
            });
        }

        void mJobMonitor_JobCompleted(object sender, JobEventArgs e)
        {
            mRunning = false;        


            // Thread safe (it runs on UI thread):           
            this.Invoke((MethodInvoker)delegate
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
                zLogTxb.AppendText(zString);
                btnConvert.Enabled = false;
                btnClose.Enabled = false;
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

        private void btnBrowseTIFFs_Click(object sender, EventArgs e)
        {
            string zFilter;

            if (zInputTIFFsBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                zProject_InputPathTxb.Text = zInputTIFFsBrowserDialog.SelectedPath;
                mInputPath = zInputTIFFsBrowserDialog.SelectedPath;

                // Get the number of projection files:
                zFilter = tbxProjectionPrefix.Text + "*" + Properties.Settings.Default.TIFFFileFormatExtension + "*";
                mNrOfProjections = (int)(Directory.GetFiles(mInputPath, zFilter, SearchOption.TopDirectoryOnly).Length);

                nudConvertToTDFFrom.Maximum = mNrOfProjections - 1;
                nudConvertToTDFTo.Maximum = mNrOfProjections - 1;

                btnConvert.Enabled = true;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Run Job Convert To TDF:
            IJob zJob;

            mTempOutputName = Properties.Settings.Default.FormSettings_WorkingPath + Path.DirectorySeparatorChar + "_" + Program.GetTimestamp(DateTime.Now) + ".tmp";

            // Create an instance for the phase retrieval job:
            zJob = new TIFF2TDFJob(
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
        }

        private void TIFFToTDF_Load(object sender, EventArgs e)
        {
            // Load settings:
            this.nudConvertToTDF_CropTop.Value = Properties.Settings.Default.TIFF2TDF_CropTop;
            this.nudConvertToTDF_CropBottom.Value = Properties.Settings.Default.TIFF2TDF_CropBottom;
            this.nudConvertToTDF_CropLeft.Value = Properties.Settings.Default.TIFF2TDF_CropLeft;
            this.nudConvertToTDF_CropRight.Value = Properties.Settings.Default.TIFF2TDF_CropRight;
            this.nudOutputCompression.Value = Properties.Settings.Default.TIFF2TDF_gZipCompression;

            this.tbxProjectionPrefix.Text = Properties.Settings.Default.TIFF2TDF_FilePrefixProjection;
            this.tbxDarkPrefix.Text = Properties.Settings.Default.TIFF2TDF_FilePrefixDark;
            this.tbxFlatPrefix.Text = Properties.Settings.Default.TIFF2TDF_FilePrefixFlat;

            this.rbtInputProjections.Checked = Properties.Settings.Default.TIFF2TDF_TiffProjectionChecked;
            this.rbtInputSinograms.Checked = ! Properties.Settings.Default.TIFF2TDF_TiffProjectionChecked;
        }

        private void TIFFToTDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mRunning)
            {
                e.Cancel = true;
                return;
            }

            // Serialize settings:
            if (!e.Cancel)
            {
                Properties.Settings.Default["TIFF2TDF_CropTop"] = this.nudConvertToTDF_CropTop.Value;
                Properties.Settings.Default["TIFF2TDF_CropBottom"] = this.nudConvertToTDF_CropBottom.Value;
                Properties.Settings.Default["TIFF2TDF_CropLeft"] = this.nudConvertToTDF_CropLeft.Value;
                Properties.Settings.Default["TIFF2TDF_CropRight"] = this.nudConvertToTDF_CropRight.Value;
                Properties.Settings.Default["TIFF2TDF_gZipCompression"] = this.nudOutputCompression.Value;

                Properties.Settings.Default["TIFF2TDF_FilePrefixProjection"] = this.tbxProjectionPrefix.Text;
                Properties.Settings.Default["TIFF2TDF_FilePrefixDark"] = this.tbxDarkPrefix.Text;
                Properties.Settings.Default["TIFF2TDF_FilePrefixFlat"] = this.tbxFlatPrefix.Text;
                Properties.Settings.Default["TIFF2TDF_TiffProjectionChecked"] = this.rbtInputProjections.Checked;

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
                this.lblProjections.Location = new Point(19,26);
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

  
    }
}
