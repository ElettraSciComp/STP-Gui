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
    public partial class MultiOffset : Form
    {
        private DateTime mDt;
        private IJobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;
        private string mSlicePrefix;
        private int mImageIndex;
        private string mInputTDF;
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
        private double mAngles;
        private double mCenter;
        private string mReconFunc;
        private string mReconParam1;
        private double mScale;
        private bool mZeroneMode;
        private double mCorrectionOffset;
        private bool mOverPaddding;
        private bool mLogTransform;
        private bool mCircle;
        private int mDecimateFactor;
        private int mDownscaleFactor;
        private bool mPostProcess;
        private string mPostProcessConvertArgs;
        private string mPostProcessCropArgs;
        private bool mPhaseRetrieval = false;
        private int mPhrtMethod;
        private double mParam1;
        private double mParam2;
        private double mDistance;
        private double mEnergy;
        private double mPixelsize;
        private bool mPhrtPad;
        private int mAnglesProjFrom;
        private int mAnglesProjTo;


        public MultiOffset(
            string slicePrefix,
            int imageIndex,
            string inputTDF,
            bool preProcess,
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
            double angles,
            double center,
            string reconFunc,
            string reconParam1,
            double scale,
            bool overPadding,
            bool logTransform,
            bool circle,
            bool zeroneMode,
            double correctionOffset,
            int decimateFactor,
            int downscaleFactor,
            bool postProcess,
            string postProcessConvertArgs,
            string postProcessCropArgs,
            bool phaseRetrieval,
            int phrtMethod,
            double param1,
            double param2,
            double distance,
            double energy,
            double pixelsize,
            bool phrtPad,
            int anglesProjFrom,
            int anglesProjTo
            )
        {
            InitializeComponent();

            mSlicePrefix = slicePrefix;
            mImageIndex = imageIndex;
            mPreProcess = preProcess;
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
            mInputTDF = inputTDF;
            mAngles = angles;
            mCenter = center;
            mReconParam1 = reconParam1;
            mScale = scale;
            mOverPaddding = overPadding;
            mLogTransform = logTransform;
            mCircle = circle;
            mZeroneMode = zeroneMode;
            mCorrectionOffset = correctionOffset;
            mReconFunc = reconFunc;
            mDecimateFactor = decimateFactor;
            mDownscaleFactor = downscaleFactor;
            mPostProcess = postProcess;
            mPostProcessConvertArgs = postProcessConvertArgs;
            mPostProcessCropArgs = postProcessCropArgs;
            mPhaseRetrieval = phaseRetrieval;
            mPhrtMethod = phrtMethod;
            mParam1 = param1;
            mParam2 = param2;
            mDistance = distance;
            mEnergy = energy;
            mPixelsize = pixelsize;
            mPhrtPad = phrtPad;

            mAnglesProjFrom = anglesProjFrom;
            mAnglesProjTo = anglesProjTo;

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

                btnReconstruct.Enabled = true;
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

                btnReconstruct.Enabled = true;
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
                btnReconstruct.Enabled = false;
                btnClose.Enabled = false;
            });
        }

        private void mJobMonitorBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            mJobMonitor.Start();
        }

        #endregion       

        private void MultiOffset_Load(object sender, EventArgs e)
        {
            // Center parent:
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);

            // Load settings:
            this.nudMultiOffset_From.Value = Properties.Settings.Default.MultiOffset_From;
            this.nudMultiOffset_To.Value = Properties.Settings.Default.MultiOffset_To;
            this.zOutputPathTxb.Text = Properties.Settings.Default.MultiOffset_Path;

            this.lblInputTDF.Text = Path.GetFileName(mInputTDF);
            this.lblSliceNr.Text = mImageIndex.ToString();
            this.lblAlgorithm.Text = mReconFunc;
            this.lblDecimationFactor.Text = mDecimateFactor.ToString();
            this.lblDownscalingFactor.Text = mDownscaleFactor.ToString();
            this.lblNrProjections.Text = (this.mAnglesProjTo - this.mAnglesProjFrom + 1).ToString();
            this.lblAngles.Text = (mAngles / Math.PI * 180.0).ToString("0.000");            
            this.lblPreProcessing.Text = mPreProcess ? "yes" : "no";
            this.lblPostProcessing.Text = mPostProcess ? "yes" : "no";
            this.lblPhaseRetrieval.Text = mPhaseRetrieval ? "yes" : "no";

            this.nudMultiOffset_From.Minimum = - TDFReader.GetDetectorSize(mInputTDF) / 2;
            this.nudMultiOffset_From.Maximum = TDFReader.GetDetectorSize(mInputTDF) / 2;

            this.nudMultiOffset_To.Minimum = - TDFReader.GetDetectorSize(mInputTDF) / 2;
            this.nudMultiOffset_To.Maximum = TDFReader.GetDetectorSize(mInputTDF) / 2;
        }

        private void MultiOffset_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mRunning)
            {
                e.Cancel = true;
                return;
            }

            // Serialize settings:
            if (!e.Cancel)
            {
                Properties.Settings.Default["MultiOffset_From"] = this.nudMultiOffset_From.Value;
                Properties.Settings.Default["MultiOffset_To"] = this.nudMultiOffset_To.Value;
                Properties.Settings.Default["MultiOffset_Path"] = this.zOutputPathTxb.Text;

                Properties.Settings.Default.Save();
            }
        }
        
        private void btnOutputTIFFs_Click(object sender, EventArgs e)
        {
            if (zOutputTIFFsBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                zOutputPathTxb.Text = zOutputTIFFsBrowserDialog.SelectedPath;
                btnReconstruct.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



      

        private void btnConvert_Click(object sender, EventArgs e)
        {            
            IJob zJob;

            // Create an instance for the multi offset job:
            zJob = new MultiOffsetJob(  
                this.mSlicePrefix,
                this.mImageIndex,
                this.mInputTDF,
                this.zOutputPathTxb.Text,
                this.mPreProcess,
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
                this.mAngles,
                this.mCenter,
                this.mReconFunc,
                this.mReconParam1,
                this.mScale,
                this.mOverPaddding,
                this.mLogTransform,
                this.mCircle,
                this.mZeroneMode,
                this.mCorrectionOffset,
                Convert.ToInt32(this.nudMultiOffset_From.Value),
                Convert.ToInt32(this.nudMultiOffset_To.Value),
                this.mDecimateFactor,
                this.mDownscaleFactor,
                this.mPostProcess,
                this.mPostProcessConvertArgs,
                this.mPostProcessCropArgs,
                this.mPhaseRetrieval,
                this.mPhrtMethod,
                this.mParam1,
                this.mParam2, 
                this.mDistance, 
                this.mEnergy, 
                this.mPixelsize,
                this.mPhrtPad,
                this.mAnglesProjFrom,
                this.mAnglesProjTo
                    );

            // Create an instance of JobExecuter with the Phase Retrieval job 
            // splitting it into several processes (if specified):
            JobExecuter zExecuter = new JobExecuter(zJob);

            // Execute the job: 
            zExecuter.Run();

            // Start the monitoring of the job:
            int zLines = (Convert.ToInt32(this.nudMultiOffset_To.Value - this.nudMultiOffset_From.Value))/mDownscaleFactor + 1;
            mJobMonitor.Run(zExecuter, this.mSlicePrefix, zLines);
        }

        private void zOutputPathTxb_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(zOutputPathTxb.Text))
            {
                this.nudMultiOffset_From.Enabled = true;
                this.nudMultiOffset_To.Enabled = true;
                this.btnReconstruct.Enabled = true;
                this.toolStripStatusLabel1.Text = "";               
            }
            else
            {
                this.nudMultiOffset_From.Enabled = false;
                this.nudMultiOffset_To.Enabled = false;
                this.btnReconstruct.Enabled = false;
                this.toolStripStatusLabel1.Text = "Invalid folder.";
            }           
        }

        private void nudMultiOffset_From_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudMultiOffset_To.Value < this.nudMultiOffset_From.Value)
            {
                this.nudMultiOffset_To.Value = this.nudMultiOffset_From.Value;
            }
            this.nudMultiOffset_To.Minimum = this.nudMultiOffset_From.Value;
        }

        private void nudMultiOffset_To_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudMultiOffset_From.Value > this.nudMultiOffset_To.Value)
            {
                this.nudMultiOffset_From.Value = this.nudMultiOffset_To.Value;
            }
            this.nudMultiOffset_From.Maximum = this.nudMultiOffset_To.Value;
        }


    }
}