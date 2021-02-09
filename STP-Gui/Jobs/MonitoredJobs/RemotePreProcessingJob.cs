﻿/***************************************************************************/
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
    public class RemotePreProcessingJob : IRemoteMonitoredJob
    {
        private string mInputFile;
        private string mOutputFile;
        private int mFrom; 
        private int mTo;
        private int mNormSx;
        private int mNormDx;
        private bool mFlatEnd;
        private bool mHalfHalf;
        private int mHalfHalfLine;
        private bool mExtFOV;
        private bool mExtFOVRight;
        private int mExtFOVOverlap;
        private bool mExtFOVNormalize;
        private bool mExtFOVAverage;
        private string mRingRem;
        private bool mDynamicFlatFielding;
        private int mThreads;
        private bool mPreviewMode;
        private string mPreviewModeOutFile;
        private string mLogFile; 

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
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="threads"></param>
        public RemotePreProcessingJob(
            string inputFile,      
            string outputFile,
            int from,
            int to,
            int normSx,
            int normDx,
            bool flatEnd,
            bool halfHalf,
            int halfHalfLine,
            bool extFOV,
            bool extFOVRight,
            int extFOVOverlap,
            bool extFOVNormalize,
            bool extFOVAverage,
            string ringRem,  
            bool dynamicFlatFielding,
            int threads,
            bool previewMode,
            string previewModeOutFile
            )
        {
            mInputFile = inputFile;
            mOutputFile = outputFile;
            mFrom = from;
            mTo = to;
            mNormDx = normDx;
            mNormSx = normSx;
            mFlatEnd = flatEnd;
            mHalfHalf = halfHalf;
            mHalfHalfLine = halfHalfLine;
            mExtFOV = extFOV;
            mExtFOVRight = extFOVRight;
            mExtFOVOverlap = extFOVOverlap;
            mExtFOVNormalize = extFOVNormalize;
            mExtFOVAverage = extFOVAverage;
            mRingRem = ringRem;
            mDynamicFlatFielding = dynamicFlatFielding;
            mThreads = threads;
            mPreviewMode = previewMode;
            mPreviewModeOutFile = previewModeOutFile;

            // Windows style path:
            //mLogFile = Properties.Settings.Default.SYRMEP_HPC_MappedTempPath + Path.DirectorySeparatorChar + inputFile.Remove(inputFile.Length - 4) + "_corr_00.txt"; // It should be "*_00.txt"

            // Unix monitoring:
            //mLogFile = Properties.Settings.Default.SYRMEP_HPC_TempPath + '/' + mInputFile.Remove(mInputFile.Length - 4) + "_corr_00.txt"; 
            mLogFile = Properties.Settings.Default.SYRMEP_HPC_TempPath + "/" + Program.GetTimestamp(DateTime.Now) + "_" + mInputFile.Remove(mInputFile.Length - 4) + ".log"; 
            


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="threads"></param>
        /// <param name="logFile"></param>
        /*public RemotePreProcessingJob(
            string inputFile, 
            string outputFile,
            int from,
            int to,
            int normSx,
            int normDx,
            bool flatEnd,
            bool halfHalf,
            int halfHalfLine,
            bool extFOV,
            bool extFOVRight,
            int extFOVOverlap,
            bool extFOVNormalize,
            bool extFOVAverage,
            string ringRem,   
            bool dynamicFlatFielding,
            int threads,
            bool previewMode,
            string previewModeOutFile,
            string logFile
            )
            : this(inputFile, outputFile, from, to, normSx, normDx, flatEnd, halfHalf, halfHalfLine, extFOV, extFOVRight, extFOVOverlap,
                extFOVNormalize, extFOVAverage, ringRem, dynamicFlatFielding, threads, previewMode, previewModeOutFile)         
        {
            mLogFile = logFile;
        }*/

        /// <summary>
        /// Get the command line for current Phase Retrieval filter instance.
        /// </summary>
        /// <returns>The string to execute.</returns>
        public string GetCommandLine()
        {
         
            string zString = string.Empty;

            string pythoncmd = (string.IsNullOrEmpty(Properties.Settings.Default.SYRMEP_HPC_PythonPath)) ? "python " : Properties.Settings.Default.SYRMEP_HPC_PythonPath + "/python ";

            // Unix-like command line:
            zString = pythoncmd + Properties.Settings.Default.SYRMEP_HPC_SourcePath + '/' +
                    Properties.Settings.Default.PreProcessingJob + " " +
                    mFrom.ToString() + " " +
                    mTo.ToString() + " " + 
                    Properties.Settings.Default.SYRMEP_HPC_InputPath + "/" + mInputFile + " " +
                    Properties.Settings.Default.SYRMEP_HPC_TempPath + "/" + mInputFile.Remove(mInputFile.Length - 4) + "_corr" + Properties.Settings.Default.TomoDataFormatExtension + " " +
                    mNormSx.ToString() + " " +
                    mNormDx.ToString() + " " +
                    mFlatEnd.ToString() + " " +
                    mHalfHalf.ToString() + " " +
                    mHalfHalfLine.ToString() + " " +
                    mExtFOV.ToString() + " " +
                    mExtFOVRight.ToString() + " " +
                    mExtFOVOverlap.ToString() + " " +
                    mExtFOVNormalize.ToString() + " " +
                    mExtFOVAverage.ToString() + " \"" +
                    mRingRem + "\" " +
                    mDynamicFlatFielding.ToString() + " " +
                    mThreads.ToString() + " " +
                    // Unix style:
                    mLogFile; // It should be "*_00.txt"
          
            return zString;
        }

        /// <summary>
        /// Return a descriptor for current job.
        /// </summary>
        /// <returns>A string with the description of the job.</returns>
        public override string ToString()
        {
            return "pre-processing";
        }
    }
}
