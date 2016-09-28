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
// Last modified: April, 11th 2016
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace SYRMEPTomoProject.Jobs
{
    /// <summary>
    /// 
    /// </summary>
    public class ReconstructionJob : IMonitoredJob
    {
        private bool mPreProcess = false;
        private int mAirSx = 0;
        private int mAirDx = 0;
        private bool mFlatEnd = false;
        private bool mHalfHalf = false;
        private int mHalfHalfLine;
        private bool mExtFOV = false;
        private bool mExtFOVRight = false;
        private int mExtFOVOverlap;
        private string mRingRemoval = "-";
        private string mInputFile;
        private string mOutputPath; 
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
        private int mFrom; 
        private int mTo;         
        private int mThreads;
        private int mDecimateFactor;
        private int mDownscaleFactor;
        private bool mPostProcess;
        private string mPostProcessConvertArgs;
        private string mPostProcessCropArgs;
        private bool mDynamicFlatFielding;
        private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
            Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
            Path.DirectorySeparatorChar + "_rec_log_00.txt"; // It should be "*_00.txt"

        /// <summary>
        /// 
        /// </summary>
        public int From
        {
            get { return mFrom; }
            set { mFrom = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int To
        {
            get { return mTo; }
            set { mTo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LogFile
        {
            get { return mLogFile; }
            set { mLogFile = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="preProcess"></param>
        /// <param name="airSx"></param>
        /// <param name="airDx"></param>
        /// <param name="ringRemoval"></param>
        /// <param name="inputFile"></param>
        /// <param name="angles"></param>
        /// <param name="center"></param>
        /// <param name="reconFunc"></param>
        /// <param name="reconParam1"></param>
        /// <param name="scale"></param>
        /// <param name="overPadding"></param>
        /// <param name="logTransform"></param>
        /// <param name="circle"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="threads"></param>
        public ReconstructionJob(
            string inputFile,
            string outputPath,
            bool preProcess,
            int airSx,
            int airDx,
            bool flatEnd,
            bool halfHalf,
            int halfHalfLine,
            bool extFOV,
            bool extFOVRight,
            int extFOVOverlap,
            string ringRemoval,            
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
            int from,
            int to,      
            int threads,
            int decimateFactor,
            int downscaleFactor,
            bool postProcess,
            string postProcessConvertArgs,
            string postProcessCropArgs,
            bool dynamicFlatFielding
            )
        {
            mPreProcess = preProcess;
            mOutputPath = outputPath;
            mAirSx = airSx;
            mAirDx = airDx;
            mFlatEnd = flatEnd;
            mHalfHalf = halfHalf;
            mHalfHalfLine = halfHalfLine;
            mExtFOV = extFOV;
            mExtFOVRight = extFOVRight;
            mExtFOVOverlap = extFOVOverlap;
            mRingRemoval = ringRemoval;
            mInputFile = inputFile;           
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
            mFrom = from;
            mTo = to;
            mThreads = threads;
            mReconFunc = reconFunc;
            mDecimateFactor = decimateFactor;
            mDownscaleFactor = downscaleFactor;
            mPostProcess = postProcess;
            mPostProcessConvertArgs = postProcessConvertArgs;
            mPostProcessCropArgs = postProcessCropArgs;
            mDynamicFlatFielding = dynamicFlatFielding;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="angles"></param>
        /// <param name="center"></param>
        /// <param name="reconFunc"></param>
        /// <param name="reconParam1"></param>
        /// <param name="scale"></param>
        /// <param name="overPadding"></param>
        /// <param name="logTransform"></param>
        /// <param name="circle"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="threads"></param>
        /// <param name="logFile"></param>
        public ReconstructionJob(
            string inputFile,
            string outputPath,
            bool preProcess,
            int airSx,
            int airDx,
            bool flatEnd,
            bool halfHalf,
            int halfHalfLine,
            bool extFOV,
            bool extFOVRight,
            int extFOVOverlap,
            string ringRemoval,            
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
            int from,
            int to,      
            int threads,
            int decimateFactor,
            int downscaleFactor,
            bool postProcess,
            string postProcessConvertArgs,
            string postProcessCropArgs,
            bool dynamicFlatFielding,
            string logFile
            )
            : this(inputFile, outputPath, preProcess, airSx, airDx, flatEnd, halfHalf, halfHalfLine, extFOV, extFOVRight, extFOVOverlap, ringRemoval, angles, 
            angles_ProjFrom, angles_ProjTo,
            center, reconFunc, reconParam1, scale, overPadding, logTransform, circle, zeroneMode, correctionOffset, from, to, threads, decimateFactor, downscaleFactor,
            postProcess, postProcessConvertArgs, postProcessCropArgs, dynamicFlatFielding)         
        {
            mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
                Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
                Path.DirectorySeparatorChar + logFile;
        }

        /// <summary>
        /// Get the command line for current Phase Retrieval filter instance.
        /// </summary>
        /// <returns>The string to execute.</returns>
        public string GetCommandLine()
        {
            //
            // python reconstruct_astra.py 310 312 "D:\\test\\patchTravan_nophrt_flathalf.h5" "R:\\" 3.14159 -113.0 shepp-logan 1.0 False True 
            // True sino slice tomo flat dark R:\\ E:\\Brun\\BrunTomoProject\\matlab_def\\MatlabAutomation_Reconstruct.exe recon_astra_fbp
            //
            //

            string zString = string.Empty; 

            // Create output path if does not exist:
            Directory.CreateDirectory(Properties.Settings.Default.FormSettings_OutputPath);

            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.ReconstructionJob + "\" " 
                + mFrom.ToString() + " " +
                mTo.ToString() + " \"" + mInputFile + "\" \"" + mOutputPath.Remove(mOutputPath.Length - 1) + "\" " +
                mAngles.ToString(CultureInfo.InvariantCulture) + " " +
                mCenter.ToString(CultureInfo.InvariantCulture) + " " +
                mReconParam1.ToString() + " " +
                mScale.ToString(CultureInfo.InvariantCulture) + " " +
                mOverPaddding.ToString() + " " +
                mLogTransform.ToString() + " " +
                mCircle.ToString() + " " +
                Properties.Settings.Default.FormSettings_OutputPrefix + " " +
                mPreProcess.ToString() + " " +                 
                mFlatEnd.ToString() + " " + mHalfHalf.ToString() + " " +
                mHalfHalfLine.ToString() + " " +
                mExtFOV.ToString() + " " + mExtFOVRight.ToString() + " " +
                mExtFOVOverlap.ToString() + " " + 
                mAirSx.ToString() + " " + mAirDx.ToString() + " False \"" +  // This has to be modified...
                mRingRemoval + "\" " +
                mZeroneMode.ToString() + " " +
                mCorrectionOffset.ToString() + " " +
                mReconFunc + " " +
                mDecimateFactor.ToString() + " " +
                mDownscaleFactor.ToString() + " " +
                mPostProcess.ToString() + " " +
                mPostProcessConvertArgs + " " +
                mPostProcessCropArgs + " " +
                mAngles_ProjFrom.ToString() + " " +
                mAngles_ProjTo.ToString() + " " + 
                mDynamicFlatFielding.ToString() + " " +
                mThreads.ToString() + 
                " \"" + mLogFile + "\"";

            return zString;
        }

        /// <summary>
        /// Return a descriptor for current job.
        /// </summary>
        /// <returns>A string with the description of the job.</returns>
        public override string ToString()
        {
            return "tomographic reconstruction";
        }
    }
}
