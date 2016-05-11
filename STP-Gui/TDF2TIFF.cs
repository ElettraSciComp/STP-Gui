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
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;

using SYRMEPTomoProject.Jobs;

namespace SYRMEPTomoProject
{
    public partial class TDFToTIFF : Form
    {
        private string mInputTDF;
        private string mOutputTIFFs;

        private DateTime mDt;      

        private JobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        public TDFToTIFF()
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

                    try
                    {
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
                    catch (Exception )
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
                zLogTxb.AppendText(e.Line);// runs on UI thread           

                // Update status bar:
                zTiming_ToolStripLbl.Text = String.Empty;

                // Update progress bar:
                mStatusBarProgressBar.Value = 0;

                btnConvert.Enabled = true;
                btnClose.Enabled = true;
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

        private void TDFToTIFF_Load(object sender, EventArgs e)
        {
            // Center parent:
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);

            // Load settings:
            this.tbxProjectionPrefix.Text = Properties.Settings.Default.TDF2TIFF_FilePrefixProjection;
            this.tbxDarkPrefix.Text = Properties.Settings.Default.TDF2TIFF_FilePrefixDark;
            this.tbxFlatPrefix.Text = Properties.Settings.Default.TDF2TIFF_FilePrefixFlat;

            this.rbtDirectOrder.Checked = Properties.Settings.Default.TDF2TIFF_ProjectionOrderChecked;
            this.rbtSinogramOrder.Checked = !Properties.Settings.Default.TDF2TIFF_ProjectionOrderChecked;

            this.btnTIFFFormat.Checked = Properties.Settings.Default.TDF2TIFF_FormatTIFFChecked;
            this.btnRawFormat.Checked = !Properties.Settings.Default.TDF2TIFF_FormatTIFFChecked;

            this.chkData.Checked = Properties.Settings.Default.TDF2TIFF_DatasetToExportTomo;
            this.chkDataWhite.Checked = Properties.Settings.Default.TDF2TIFF_DatasetToExportFlat;
            this.chkDataDark.Checked = Properties.Settings.Default.TDF2TIFF_DatasetToExportDark;
        }

        private void TDFToTIFF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mRunning)
            {
                e.Cancel = true;
                return;
            }

            // Serialize settings:
            if (!e.Cancel)
            {
                Properties.Settings.Default["TDF2TIFF_FilePrefixProjection"] = this.tbxProjectionPrefix.Text;
                Properties.Settings.Default["TDF2TIFF_FilePrefixDark"] = this.tbxDarkPrefix.Text;
                Properties.Settings.Default["TDF2TIFF_FilePrefixFlat"] = this.tbxFlatPrefix.Text;

                Properties.Settings.Default["TDF2TIFF_ProjectionOrderChecked"] = this.rbtDirectOrder.Checked;

                Properties.Settings.Default["TDF2TIFF_FormatTIFFChecked"] = this.btnTIFFFormat.Checked;

                Properties.Settings.Default["TDF2TIFF_DatasetToExportTomo"] = this.chkData.Checked;
                Properties.Settings.Default["TDF2TIFF_DatasetToExportFlat"] = this.chkDataWhite.Checked;
                Properties.Settings.Default["TDF2TIFF_DatasetToExportDark"] = this.chkDataDark.Checked;

                Properties.Settings.Default.Save();
            }
        }

        private void cbxInput_Click(object sender, EventArgs e)
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

            cbxInput.DataSource = new BindingSource(zDict, null);
            cbxInput.DisplayMember = "Value";
            cbxInput.ValueMember = "Key";

            this.ResumeLayout();
        }

        private void cbxInput_DropDownClosed(object sender, EventArgs e)
        {         
            mInputTDF = ((KeyValuePair<string, string>)this.cbxInput.SelectedItem).Key;
                       
            
            // Check if selected TDF exists:
            if (File.Exists(mInputTDF))
            {                
                if (rbtDirectOrder.Checked)
                {
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfProjections(mInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfProjections(mInputTDF) - 1;

                }
                else
                {
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfSlices(mInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfSlices(mInputTDF) - 1;
                }             
            }
        }


        private void rbtDirectOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDirectOrder.Checked)
            {
                this.tbxProjectionPrefix.Text = "tomo";
                this.lblProjections.Text = "Projections:";
                this.lblProjections.Location = new Point(19, 26);

                if (File.Exists(mInputTDF))
                {
              
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfProjections(mInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfProjections(mInputTDF) - 1;                    
                }
            }
        }

        private void rbtSinogramOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSinogramOrder.Checked)
            {
                this.tbxProjectionPrefix.Text = "sino";
                this.lblProjections.Text = "Sinograms:";
                this.lblProjections.Location = new Point(22, 26);

                if (File.Exists(mInputTDF))
                {               
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfSlices(mInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfSlices(mInputTDF) - 1;                    
                }
            }
        }

        private void chkFlatDark_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDataWhite.Checked)
            {
                this.tbxDarkPrefix.Enabled = true;
                this.tbxFlatPrefix.Enabled = true;
                //this.tbxPostDarkPrefix.Enabled = true;
                //this.tbxPostFlatPrefix.Enabled = true;
            }
            else
            {
                this.tbxDarkPrefix.Enabled = false;
                this.tbxFlatPrefix.Enabled = false;
                //this.tbxPostDarkPrefix.Enabled = false;
                //this.tbxPostFlatPrefix.Enabled = false;
            }
        }

        private void btnOutputTIFFs_Click(object sender, EventArgs e)
        {
            if (zOutputTIFFsBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                zOutputPathTxb.Text = zOutputTIFFsBrowserDialog.SelectedPath;
                mOutputTIFFs = zOutputTIFFsBrowserDialog.SelectedPath;               

                btnConvert.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void chkConsiderSubset_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkConsiderSubset.Checked)
            {
                this.nudTDFToTIFFFrom.Enabled = true;
                this.nudTDFToTIFFTo.Enabled = true;
            }
            else
            {
                this.nudTDFToTIFFFrom.Enabled = false;
                this.nudTDFToTIFFTo.Enabled = false;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // Run Job Convert To TDF:
            IJob zJob;

            // Create an instance for the phase retrieval job:
            zJob = new TDF2TIFFJob(                    
                    ((KeyValuePair<string, string>)this.cbxInput.SelectedItem).Key,
                    this.zOutputPathTxb.Text,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudTDFToTIFFFrom.Value) : 0,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudTDFToTIFFTo.Value) : Convert.ToInt32(this.nudTDFToTIFFTo.Maximum),
                    tbxProjectionPrefix.Text,
                    (this.chkDataWhite.Checked) ? tbxFlatPrefix.Text : "-",
                    (this.chkDataWhite.Checked) ? tbxDarkPrefix.Text : "-",                    
                    this.rbtDirectOrder.Checked,
                    this.btnTIFFFormat.Checked,
                    1
                    );

            // Create an instance of JobExecuter with the Phase Retrieval job 
            // splitting it into several processes (if specified):
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job: 
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, tbxProjectionPrefix.Text);
        }


    }
}