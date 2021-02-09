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
    public partial class RemoteReconstruction : Form
    {
        private bool mPreProcessOnGoing = false;
        private bool mPhaseRetrievalOnGoing = false;
        private bool mReconstructionOnGoing = false;

        private DateTime mDt;
        private MainForm mMainForm;

        private IJobMonitor mJobMonitor;
        private bool mFirstRun = false;
        private bool mRunning = false;

        private string mInputPath = string.Empty;
        private string mTempOutputName = string.Empty;

        private string mInputTDF;

        // Pre-processing:
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

        // Phase retrieval:
        private int mMethod; // 0 for Paganin, 5 for Quasiparticle
        private double mParam1;
        private double mParam2;
        private double mDistance;
        private double mEnergy;
        private double mPixelsize;        
        private int mThreads;
        private bool mPad;

        // Reconstruction:        
        private double mAngles;
        private int mAngles_ProjFrom;
        private int mAngles_ProjTo;
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
        private string mPostProcessPolarFilt;
        private string mPostProcessConvertArgs;
        private string mPostProcessCropArgs; 
        private bool mRolling;
        private int mRollShift;


        public RemoteReconstruction(
            // Pre-processing:
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
            bool dynamicFlatFielding,

            // Phase retrieval:
            int method,
            double param1,
            double param2, 
            double distance, 
            double energy, 
            double pixelsize,
            bool pad,

            // Reconstruction:           
            double angles,
            int angles_ProjFrom,
            int angles_ProjTo,
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
            string postProcessPolarFilt,
            string postProcessConvertArgs,
            string postProcessCropArgs,
            bool rolling,
            int rollShift
            )
        {
            // Pre-processing:
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

            // Phase retrieval:
            mMethod = method;
            mParam1 = param1;
            mParam2 = param2;
            mDistance = distance;
            mEnergy = energy;
            mPixelsize = pixelsize;
            mPad = pad;

            // Reconstruction:
            mPreProcess = false;  // "false"
            mAngles = angles;
            mAngles_ProjFrom = angles_ProjFrom;
            mAngles_ProjTo = angles_ProjTo;
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
            mPostProcessPolarFilt = postProcessPolarFilt;
            mPostProcessConvertArgs = postProcessConvertArgs;
            mPostProcessCropArgs = postProcessCropArgs;

            mRolling = rolling;
            mRollShift = rollShift;


            InitializeComponent();

            // Settings for the JobMonitor instance:
            mJobMonitor = new RemoteJobMonitor();
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

            mPreProcessOnGoing = false;
            mPhaseRetrievalOnGoing = false;
            mReconstructionOnGoing = false;

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

                    btnRun.Enabled = true;
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

                    // Rename file:
                    if (File.Exists(this.mTempOutputName))
                    {
                        FileStream zFS = Program.WaitForFile(this.mTempOutputName);
                        zFS.Close();
                    }


                    /* Start the new job: */
                    if (mPreProcessOnGoing)
                    {
                        BackgroundWorker aBgdWrk = new BackgroundWorker();

                        aBgdWrk.DoWork += new DoWorkEventHandler(this.runRemotePhaseRetrieval);
                        aBgdWrk.RunWorkerAsync();


                        this.lblPhaseRetrieval.Enabled = true;
                        this.lblPreProcessing.Enabled = false;
                        this.lblReconstruction.Enabled = false;

                        // Delete file:
                        /*string zFile = this.mInputTDF.Remove(this.mInputTDF.Length - 4) + "_corr_00.txt"; // It should be "*_00.txt"
                        if (File.Exists(zFile))
                        {
                            FileStream zFS = Program.WaitForFile(zFile);
                            zFS.Close();
                        }
                        File.Delete(zFile);*/

                    }
                    else if (mPhaseRetrievalOnGoing)
                    {
                        BackgroundWorker aBgdWrk = new BackgroundWorker();

                        aBgdWrk.DoWork += new DoWorkEventHandler(this.runRemoteReconstruction);
                        aBgdWrk.RunWorkerAsync();

                        this.lblPreProcessing.Enabled = false;
                        this.lblPhaseRetrieval.Enabled = false;
                        this.lblReconstruction.Enabled = true;

                        // Delete file:
                        /*string zFile = this.mInputTDF.Remove(this.mInputTDF.Length - 4) + "_phrt_00.txt"; // It should be "*_00.txt"
                        if (File.Exists(zFile))
                        {
                            FileStream zFS = Program.WaitForFile(zFile);
                            zFS.Close();
                        }
                        File.Delete(zFile);*/
                       
                    }
                    else if (mReconstructionOnGoing)
                    {
                        mReconstructionOnGoing = false;    

                        this.lblPreProcessing.Enabled = true;
                        this.lblPhaseRetrieval.Enabled = true;
                        this.lblReconstruction.Enabled = true;
                    
                        // Update status bar:
                        zTiming_ToolStripLbl.Text = String.Empty;

                        // Update progress bar:
                        mStatusBarProgressBar.Value = 0;

                        btnRun.Enabled = true;
                        btnClose.Enabled = true;

                        // Delete file:
                        string zFile = this.mInputTDF.Remove(this.mInputTDF.Length - 4) + "_corr.tdf";
                        if (File.Exists(zFile))
                        {
                            FileStream zFS = Program.WaitForFile(zFile);
                            zFS.Close();
                        }
                        File.Delete(zFile);

                        // Delete file:
                        zFile = this.mInputTDF.Remove(this.mInputTDF.Length - 4) + "_corr_phrt.tdf";
                        if (File.Exists(zFile))
                        {
                            FileStream zFS = Program.WaitForFile(zFile);
                            zFS.Close();
                        }
                        File.Delete(zFile);

                        // Delete file:
                        /*zFile = this.mInputTDF.Remove(this.mInputTDF.Length - 4) + "_recon_00.txt"; // It should be "*_00.txt"
                        if (File.Exists(zFile))
                        {
                            FileStream zFS = Program.WaitForFile(zFile);
                            zFS.Close();
                        }
                        File.Delete(zFile);*/
                    }
                }
                catch (Exception)
                {
                    // Update status bar:
                    zTiming_ToolStripLbl.Text = String.Empty;

                    // Update progress bar:
                    mStatusBarProgressBar.Value = 0;

                    btnRun.Enabled = true;
                    btnClose.Enabled = true;
                }
                finally
                {                 
                }
            });
         
        }

        void mJobMonitor_JobStarted(object sender, JobEventArgs e)
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
                    btnRun.Enabled = false;
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

        private void RemoteReconstruction_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            // Center parent:
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);

            this.ResumeLayout();
        }


        private void cbxInput_Click(object sender, EventArgs e)
        {
            // Populate the list:
            this.SuspendLayout();

            //string zFilter = "*" + Properties.Settings.Default.TomoDataFormatExtension;
            //string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.SYRMEP_HPC_MappedInputPath, zFilter, SearchOption.TopDirectoryOnly);


            string zResult = SYRMEP_HPC.Execute("ls " + Properties.Settings.Default.SYRMEP_HPC_InputPath + "/*" + Properties.Settings.Default.TomoDataFormatExtension);
            string[] fileEntries = zResult.Split('\n');
            fileEntries = fileEntries.Take(fileEntries.Length - 1).ToArray();
            
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

            mInputTDF = ((KeyValuePair<string, string>)this.cbxInput.SelectedItem).Key;

            this.btnRun.Enabled = true;
            
            this.ResumeLayout();
            
        }


        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Run Job Convert To TDF:
            IJob zJob;

            string zFileName = Path.GetFileName(mInputTDF);


            string zString = string.Empty;
            string pythoncmd = (string.IsNullOrEmpty(Properties.Settings.Default.SYRMEP_HPC_PythonPath)) ? "python " : Properties.Settings.Default.SYRMEP_HPC_PythonPath + "/python ";

            // Unix-like command line:
            zString = pythoncmd + Properties.Settings.Default.SYRMEP_HPC_SourcePath + '/' + Properties.Settings.Default.GetTDFDimensionJob + " " + mInputTDF;
            string zResult = SYRMEP_HPC.Execute(zString);

            string[] zLines = zResult.Split('\n');
            int zProjections = Int32.Parse((zLines[0].Split(' '))[1]);
            int zSlices = Int32.Parse((zLines[1].Split(' '))[1]);
            
            int zTo = zSlices - 1;
 

            int zThreads = Convert.ToInt32(Properties.Settings.Default.SYRMEP_HPC_Processes);
                          
            // Execute with conventional flat fielding:
            zJob = new RemotePreProcessingJob(
                   // Get combobox selection (in handler)
                   zFileName,
                   zFileName.Remove(zFileName.Length - 4) + "_corr.tdf",
                   0,
                   zTo,
                   mAirSx,
                   mAirDx,
                   this.mFlatEnd, // use flat at the end
                   this.mHalfHalf,
                   this.mHalfHalfLine,
                   this.mExtFOV,
                   this.mExtFOVRight,
                   this.mExtFOVOverlap,
                   this.mExtFOVNormalize,
                   this.mExtFOVAverage,
                   this.mRingRemoval,
                   this.mDynamicFlatFielding,
                   zThreads,
                   false,
                   "-"
            );


            // Create an instance of JobExecuter with the pre processing job:
            IJobExecuter zExecuter = new RemoteJobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, "sino");              



            this.mPreProcessOnGoing = true;

            this.lblPreProcessing.Enabled = true;
            this.lblPhaseRetrieval.Enabled = false;            
            this.lblReconstruction.Enabled = false;

            // Reset status bar:
            this.toolStripStatusLabel1.Text = string.Empty;



        }


        private void runRemotePhaseRetrieval(object sender, EventArgs e)
        {
            // Run Job Convert To TDF:
            IJob zJob;

            // Execute with conventional flat fielding:
            mPreProcessOnGoing = false;
            mReconstructionOnGoing = false;


            string zFileName = Path.GetFileName(mInputTDF);
            zFileName = zFileName.Remove(zFileName.Length - 4) + "_corr.tdf";



            string zString = string.Empty;
            string pythoncmd = (string.IsNullOrEmpty(Properties.Settings.Default.SYRMEP_HPC_PythonPath)) ? "python " : Properties.Settings.Default.SYRMEP_HPC_PythonPath + "/python ";

            // Unix-like command line:
            zString = pythoncmd + Properties.Settings.Default.SYRMEP_HPC_SourcePath + '/' + Properties.Settings.Default.GetTDFDimensionJob + " " + mInputTDF;
            string zResult = SYRMEP_HPC.Execute(zString);

            string[] zLines = zResult.Split('\n');
            int zProjections = Int32.Parse((zLines[0].Split(' '))[1]);
            int zSlices = Int32.Parse((zLines[1].Split(' '))[1]);


            int zTo = zProjections - 1;
                        
            int zThreads = Convert.ToInt32(Properties.Settings.Default.SYRMEP_HPC_Processes);
          
            zJob = new RemotePhaseRetrievalJob(
                  zFileName,
                  zFileName.Remove(zFileName.Length - 4) + "_phrt.tdf",
                  this.mMethod,
                  0,
                  zTo,
                  this.mParam1,
                  this.mParam2,
                  this.mDistance,
                  this.mEnergy,
                  this.mPixelsize,
                  this.mPad,
                  zThreads
           );


            // Create an instance of JobExecuter with the pre processing job:
            IJobExecuter zExecuter = new RemoteJobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();            

            mJobMonitor.Run(zExecuter, "tomo");

            // Reset status bar:
            this.toolStripStatusLabel1.Text = string.Empty;

            mPhaseRetrievalOnGoing = true;     
        }


        private void runRemoteReconstruction(object sender, EventArgs e)
        {
            // Run Job Convert To TDF:
            IJob zJob;

            mPreProcessOnGoing = false;
            mPhaseRetrievalOnGoing = false;                


            string zFileName = Path.GetFileName(mInputTDF);
            zFileName = zFileName.Remove(zFileName.Length - 4) + "_corr_phrt.tdf";

            string zString = string.Empty; 
            string pythoncmd = (string.IsNullOrEmpty(Properties.Settings.Default.SYRMEP_HPC_PythonPath)) ? "python " : Properties.Settings.Default.SYRMEP_HPC_PythonPath + "/python ";

            // Unix-like command line:
            zString = pythoncmd + Properties.Settings.Default.SYRMEP_HPC_SourcePath + '/' + Properties.Settings.Default.GetTDFDimensionJob + " " + mInputTDF;
            string zResult = SYRMEP_HPC.Execute(zString);

            string[] zLines = zResult.Split('\n');
            int zProjections = Int32.Parse((zLines[0].Split(' '))[1]);
            int zSlices = Int32.Parse((zLines[1].Split(' '))[1]);


            int zTo = zSlices - 1;
            
            int zThreads = Convert.ToInt32(Properties.Settings.Default.SYRMEP_HPC_Processes);

            // Unix-style:
            string zOutputPath = Properties.Settings.Default.SYRMEP_HPC_OutputPath + '/' + Path.GetFileNameWithoutExtension(mInputTDF) + '/' + @"slices" + '/';

            if (mAngles_ProjTo == 0)
                mAngles_ProjTo = zProjections - 1;
       

            
            // Create an instance for the reconstruction job:
            zJob = new RemoteReconstructionJob(                
                zFileName,
                zOutputPath,
                false,
                mAirSx,
                mAirDx,
                mFlatEnd,
                mHalfHalf,
                mHalfHalfLine,
                mExtFOV,
                mExtFOVRight,
                mExtFOVOverlap,
                mExtFOVNormalize,
                mExtFOVAverage,
                mRingRemoval,

                mAngles,
                mAngles_ProjFrom,
                mAngles_ProjTo,
                mCenter,
                mReconFunc,
                mReconParam1,
                mScale,
                mOverPaddding,
                mLogTransform,
                mCircle,
                mZeroneMode,
                mCorrectionOffset,
                0,
                zTo,
                zThreads,
                mDecimateFactor,
                mDownscaleFactor,

                mPostProcess,
                mPostProcessPolarFilt,
                mPostProcessConvertArgs,
                mPostProcessCropArgs,
                mDynamicFlatFielding,

                mRolling,
                mRollShift
            );


            // Create an instance of JobExecuter with the pre processing job:
            IJobExecuter zExecuter = new RemoteJobExecuter(zJob);

            // Execute the job splitting it with several processes (if specified):
            zExecuter.Run();

            // Start the monitoring of the job:
            mJobMonitor.Run(zExecuter, "slice");

            this.mReconstructionOnGoing = true;

            // Reset status bar:
            this.toolStripStatusLabel1.Text = string.Empty;
        }

    }
}
