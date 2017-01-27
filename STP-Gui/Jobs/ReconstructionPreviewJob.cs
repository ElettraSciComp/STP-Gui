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
// Last modified: December, 12th 2016
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
    public class ReconstructionPreviewJob : IJob
    {
        private int mImageIndex;
        private bool mPreProcess = false;
        private int mAirSx = 0;
        private int mAirDx = 0;
        private bool mFlatEnd = false;
        private bool mHalfHalf = false;
        private int mHalfHalfLine;
        private bool mExtFOV = false;
        private bool mExtFOVRight = false;
        private int mExtFOVOverlap;
        private bool mExtFOVNormalize;
        private bool mExtFOVAverage;
        private string mRingRemoval = "-";
        private string mInputFile;
        private string mPreviewFile; 
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
        private bool mDynamicFlatFielding;
        private bool mRolling;
        private int mRollShift;
        private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
            Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
            Path.DirectorySeparatorChar + "_prev_rec_log_00.txt"; // It should be "*_00.txt"


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
        public ReconstructionPreviewJob(
            int imageIndex,
            string inputFile,
            string previewFile,
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
            bool dynamicFlatFielding,
            bool rolling,
            int rollShift
            )
        {
            mImageIndex = imageIndex;
            mPreProcess = preProcess;
            mPreviewFile = previewFile;
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
            mDynamicFlatFielding = dynamicFlatFielding;
            mRolling = rolling;
            mRollShift = rollShift;
        }

        /// <summary>
        /// 
        /// </summary>
        public ReconstructionPreviewJob(
            int imageIndex,
            string inputFile,
            string previewFile,
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
            bool dynamicFlatFielding,
            bool rolling,
            int rollShift,
            string logFile
            )
            : this(imageIndex, inputFile, previewFile, preProcess, airSx, airDx, flatEnd, halfHalf, halfHalfLine, extFOV, extFOVRight, 
                extFOVOverlap, extFOVNormalize, extFOVAverage, ringRemoval, angles, angles_ProjFrom, angles_ProjTo, center, reconFunc, 
                reconParam1, scale, overPadding, logTransform, circle, zeroneMode, correctionOffset, decimateFactor, downscaleFactor, 
                postProcess, postProcessConvertArgs, postProcessCropArgs, phaseRetrieval, phrtMethod, param1, param2, distance, energy, 
                pixelsize, phrtPad, dynamicFlatFielding, rolling, rollShift)         
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
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.ReconstructPreviewJob + "\" "
                + mImageIndex.ToString() + " \"" +
                mInputFile + "\" \"" +
                mPreviewFile + "\" " +
                mAngles.ToString(CultureInfo.InvariantCulture) + " " +
                mCenter.ToString(CultureInfo.InvariantCulture) + " " +
                mReconParam1.ToString() + " " +
                mScale.ToString(CultureInfo.InvariantCulture) + " " +
                mOverPaddding.ToString() + " " +
                mLogTransform.ToString() + " " +
                mCircle.ToString() + " " +
                mPreProcess.ToString() + " " +                 
                mFlatEnd.ToString() + " " + mHalfHalf.ToString() + " " +
                mHalfHalfLine.ToString() + " " +
                mExtFOV.ToString() + " " + mExtFOVRight.ToString() + " " +
                mExtFOVOverlap.ToString() + " " +
                mExtFOVNormalize.ToString() + " " +
                mExtFOVAverage.ToString() + " " + 
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
                mPhaseRetrieval.ToString() + " " +
                mPhrtMethod.ToString() + " " +
                mParam1.ToString(CultureInfo.InvariantCulture) + " " +
                mParam2.ToString(CultureInfo.InvariantCulture) + " " +
                mEnergy.ToString(CultureInfo.InvariantCulture) + " " +
                mDistance.ToString(CultureInfo.InvariantCulture) + " " +
                mPixelsize.ToString(CultureInfo.InvariantCulture) + " " +
                mPhrtPad.ToString() + " " +
                Properties.Settings.Default.FormSettings_ChunkSize.ToString() + " " +
                mAngles_ProjFrom.ToString() + " " +
                mAngles_ProjTo.ToString() + " " +
                mRolling.ToString() + " " + 
                mRollShift.ToString() +
                " True " +  
                mDynamicFlatFielding.ToString() + " 1 \"" +
                Properties.Settings.Default.FormSettings_TemporaryPath
                + Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID
                + "\" \"" +
                mLogFile + "\"";

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
