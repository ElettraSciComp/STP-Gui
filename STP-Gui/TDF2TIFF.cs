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
        private string zInputTDF;
        private string mOutputTIFFs;

        private DateTime mDt;      

        private IJobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        public TDFToTIFF()
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
            this.SuspendLayout();

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

            chkData_CheckedChanged(null, null);

            this.ResumeLayout();
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
            this.SuspendLayout();

            zInputTDF = ((KeyValuePair<string, string>)this.cbxInput.SelectedItem).Key;
                       
            
            // Check if selected TDF exists:
            if (File.Exists(zInputTDF))
            {                
                if (rbtDirectOrder.Checked)
                {
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfProjections(zInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfProjections(zInputTDF) - 1;
                }
                else
                {
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfSlices(zInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfSlices(zInputTDF) - 1;
                }

                this.chkDataDark.Enabled = (TDFReader.HasDarks(zInputTDF));
                if (!(this.chkDataDark.Enabled))
                {
                    this.tbxDarkPrefix.Enabled = false;
                }
                else
                {
                    this.chkDataDark_CheckedChanged(null, null);
                }
                this.chkDataWhite.Enabled = (TDFReader.HasDarks(zInputTDF));
                if (!(this.chkDataWhite.Enabled))
                {
                    this.tbxFlatPrefix.Enabled = false;
                }
                else
                {
                    this.chkDataWhite_CheckedChanged(null, null);
                }
            }

            this.ResumeLayout();
        }


        private void rbtDirectOrder_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (rbtDirectOrder.Checked)
            {
                this.tbxProjectionPrefix.Text = "tomo";
                this.lblProjections.Text = "Projections:";
                this.lblProjections.Location = new Point(19, 26);

                if (File.Exists(zInputTDF))
                {
              
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfProjections(zInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfProjections(zInputTDF) - 1;                    
                }
            }

            this.ResumeLayout();
        }

        private void rbtSinogramOrder_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (rbtSinogramOrder.Checked)
            {
                this.tbxProjectionPrefix.Text = "sino";
                this.lblProjections.Text = "Sinograms:";
                this.lblProjections.Location = new Point(22, 26);

                if (File.Exists(zInputTDF))
                {               
                    this.nudTDFToTIFFFrom.Maximum = TDFReader.GetNumberOfSlices(zInputTDF) - 1;
                    this.nudTDFToTIFFTo.Maximum = TDFReader.GetNumberOfSlices(zInputTDF) - 1;                    
                }
            }

            this.ResumeLayout();
        }

        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (chkData.Checked)
            {
                this.tbxProjectionPrefix.Enabled = true;
                this.gbxSubset.Enabled = true;
                this.gbxOrder.Enabled = true;
            }
            else
            {
                this.tbxProjectionPrefix.Enabled = false;
                this.gbxSubset.Enabled = false;
                this.gbxOrder.Enabled = false;
            }

            if (Directory.Exists(zOutputPathTxb.Text))
            {
                if ((chkData.Checked) || ((chkDataDark.Enabled) && (chkDataDark.Checked)) ||
                   ((chkDataWhite.Enabled) && (chkDataWhite.Checked)))
                {
                    btnConvert.Enabled = true;
                }
                else
                {
                    btnConvert.Enabled = false;
                }
            }

            this.ResumeLayout();
        }

        private void chkDataWhite_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (chkDataWhite.Checked)
            {             
                this.tbxFlatPrefix.Enabled = true;
            }
            else
            {             
                this.tbxFlatPrefix.Enabled = false;
            }

            if (Directory.Exists(zOutputPathTxb.Text))
            {
                if ((chkData.Checked) || ((chkDataDark.Enabled) && (chkDataDark.Checked)) ||
                   ((chkDataWhite.Enabled) && (chkDataWhite.Checked)))
                {
                    btnConvert.Enabled = true;
                }
                else
                {
                    btnConvert.Enabled = false;
                }
            }

            this.ResumeLayout();
        }

        private void chkDataDark_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (chkDataDark.Checked)
            {
                this.tbxDarkPrefix.Enabled = true;
            }
            else
            {
                this.tbxDarkPrefix.Enabled = false;
            }

            if (Directory.Exists(zOutputPathTxb.Text))
            {
                if ((chkData.Checked) || ((chkDataDark.Enabled) && (chkDataDark.Checked)) ||
                   ((chkDataWhite.Enabled) && (chkDataWhite.Checked)))
                {
                    btnConvert.Enabled = true;
                }
                else
                {
                    btnConvert.Enabled = false;
                }
            }

            this.ResumeLayout();
        }

        private void btnOutputTIFFs_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();

            // Load previous setting:
            if (Directory.Exists(Properties.Settings.Default.TDF2TIFF_LastPath))
            {
                zOutputTIFFsBrowserDialog.SelectedPath = Properties.Settings.Default.TDF2TIFF_LastPath;
            }

            if (zOutputTIFFsBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                zOutputPathTxb.Text = zOutputTIFFsBrowserDialog.SelectedPath;
                Properties.Settings.Default.TDF2TIFF_LastPath = zOutputTIFFsBrowserDialog.SelectedPath;
                mOutputTIFFs = zOutputTIFFsBrowserDialog.SelectedPath;               

                btnConvert.Enabled = true;
            }

            this.ResumeLayout();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void chkConsiderSubset_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

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

            this.ResumeLayout();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string zTDFFile = ((KeyValuePair<string, string>)this.cbxInput.SelectedItem).Key;
            IJob zJob;
            
            // Create an instance for the phase retrieval job:
            zJob = new TDF2TIFFJob(
                    zTDFFile,
                    this.zOutputPathTxb.Text,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudTDFToTIFFFrom.Value) : 0,
                    (this.chkConsiderSubset.Checked) ? Convert.ToInt32(this.nudTDFToTIFFTo.Value) : Convert.ToInt32(this.nudTDFToTIFFTo.Maximum),
                    (this.chkData.Checked) ? tbxProjectionPrefix.Text : "-",
                    (this.tbxFlatPrefix.Enabled) ? ((this.chkDataWhite.Checked) ? tbxFlatPrefix.Text : "-") : "-",
                    (this.tbxDarkPrefix.Enabled) ? ((this.chkDataDark.Checked) ? tbxDarkPrefix.Text : "-") : "-",                    
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
            if (chkData.Checked)
            {
                mJobMonitor.Run(zExecuter, tbxProjectionPrefix.Text);
            }
            else
            {
                if ((chkDataDark.Checked) && !(chkDataWhite.Checked))
                {
                    // Only darks are created:
                    mJobMonitor.Run(zExecuter, this.tbxDarkPrefix.Text, TDFReader.GetNumberOfDarks(zTDFFile));
                }
                else
                {
                    if (!(chkDataDark.Checked) && (chkDataWhite.Checked))
                    {
                        // Only flats are created:
                        mJobMonitor.Run(zExecuter, this.tbxFlatPrefix.Text, TDFReader.GetNumberOfFlats(zTDFFile));
                    }
                    else
                    {
                        // Both flats and darks are created but STP-Core first creates 
                        // flats and then darks, so monitor the dark prefix:
                        mJobMonitor.Run(zExecuter, this.tbxDarkPrefix.Text, TDFReader.GetNumberOfDarks(zTDFFile));
                    }
                }
            }
        }

        private void zOutputPathTxb_TextChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();

            if (Directory.Exists(zOutputPathTxb.Text))
            {
                if ((chkData.Checked) || ((chkDataDark.Enabled) && (chkDataDark.Checked)) ||
                    ((chkDataWhite.Enabled) && (chkDataWhite.Checked)))
                {
                    btnConvert.Enabled = true;
                }
                this.toolStripStatusLabel1.Text = "";
            }
            else
            {
                if ((chkData.Checked) || ((chkDataDark.Enabled) && (chkDataDark.Checked)) ||
                   ((chkDataWhite.Enabled) && (chkDataWhite.Checked)))
                {
                    btnConvert.Enabled = false;
                }                
                this.toolStripStatusLabel1.Text = "Invalid output folder.";
            }

            this.ResumeLayout();
        }

       

       


    }
}