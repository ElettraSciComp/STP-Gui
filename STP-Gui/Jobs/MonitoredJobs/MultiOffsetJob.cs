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
// Last modified: Sept, 28th 2016
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
    public class MultiOffsetJob : IMonitoredJob
    {
        private string mSlicePrefix;
        private int mImageIndex;
        private int mOffsetFrom;
        private int mOffsetTo;
        private string mInputFile;
        private string mOutputPath;
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
        private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
            Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
            Path.DirectorySeparatorChar + "_multioffset_log_00.txt"; // It should be "*_00.txt"

        /// <summary>
        /// 
        /// </summary>
        public int From
        {
            get { return mOffsetFrom; }
            set { mOffsetFrom = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int To
        {
            get { return mOffsetTo; }
            set { mOffsetTo = value; }
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
        /// <param name="offset_from"></param>
        /// <param name="offsetTo"></param>
        public MultiOffsetJob(
            string slicePrefix,
            int imageIndex,
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
            int offsetFrom,
            int offsetTo,
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
            mSlicePrefix = slicePrefix;
            mImageIndex = imageIndex;
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
            mExtFOVNormalize = extFOVNormalize;
            mExtFOVAverage = extFOVAverage;
            mRingRemoval = ringRemoval;
            mInputFile = inputFile;
            mAngles = angles;
            mCenter = center;
            mReconParam1 = reconParam1;
            mScale = scale;
            mOverPaddding = overPadding;
            mLogTransform = logTransform;
            mCircle = circle;
            mZeroneMode = zeroneMode;
            mCorrectionOffset = correctionOffset;
            mOffsetFrom = offsetFrom;
            mOffsetTo = offsetTo;
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
        public MultiOffsetJob(
            string slicePrefix,
            int imageIndex,
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
            int offsetFrom,
            int offsetTo,
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
            int anglesProjTo,
            string logFile
            )
            : this(slicePrefix, imageIndex, inputFile, outputPath, preProcess, airSx, airDx, flatEnd, halfHalf, halfHalfLine, extFOV, extFOVRight, extFOVOverlap, 
            extFOVNormalize, extFOVAverage, ringRemoval, angles,
            center, reconFunc, reconParam1, scale, overPadding, logTransform, circle, zeroneMode, correctionOffset, offsetFrom, offsetTo, decimateFactor, downscaleFactor,
            postProcess, postProcessConvertArgs, postProcessCropArgs, phaseRetrieval, phrtMethod, param1, param2, distance, energy, pixelsize, phrtPad, anglesProjFrom, anglesProjTo )
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
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.MultiOffsetJob + "\" "
                + mImageIndex.ToString() + " \"" + 
                mInputFile + "\" \"" + 
                mOutputPath + "\" " +
                mAngles.ToString(CultureInfo.InvariantCulture) + " " +
                mCenter.ToString(CultureInfo.InvariantCulture) + " " +
                mReconParam1.ToString() + " " +
                mScale.ToString(CultureInfo.InvariantCulture) + " " +
                mOverPaddding.ToString() + " " +
                mLogTransform.ToString() + " " +
                mCircle.ToString() + " " +
                //Properties.Settings.Default.FormSettings_OutputPrefix + " " +
                mPreProcess.ToString() + " " +
                mFlatEnd.ToString() + " " + 
                mHalfHalf.ToString() + " " +
                mHalfHalfLine.ToString() + " " +
                mExtFOV.ToString() + " " + 
                mExtFOVRight.ToString() + " " +
                mExtFOVOverlap.ToString() + " " +
                mExtFOVNormalize.ToString() + " " +
                mExtFOVAverage.ToString() + " " +
                mAirSx.ToString() + " " + 
                mAirDx.ToString() + " False \"" +  // This has to be modified...
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
                mAnglesProjFrom.ToString() + " " +
                mAnglesProjTo.ToString() + " True \"" +
                Properties.Settings.Default.FormSettings_TemporaryPath
                + Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID + "\" " +
                (Convert.ToInt32(Properties.Settings.Default.FormSettings_NrOfProcesses)).ToString() + " " +
                mOffsetFrom.ToString() + " " +
                mOffsetTo.ToString() + " \"" +
                mSlicePrefix + "\" \"" +
                mLogFile + "\"";

            return zString;
        }

        /// <summary>
        /// Return a descriptor for current job.
        /// </summary>
        /// <returns>A string with the description of the job.</returns>
        public override string ToString()
        {
            return "test reconstruction";
        }
    }
}
