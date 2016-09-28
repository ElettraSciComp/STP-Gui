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
    public class PreProcessingPreviewJob : IJob
    {
        private int mImageIndex;
        private string mInputFile;
        private string mPreviewFile;
        private int mNormSx;
        private int mNormDx;
        private bool mFlatEnd;
        private bool mHalfHalf;
        private int mHalfHalfLine;
        private bool mExtFOV;
        private bool mExtFOVRight;
        private int mExtFOVOverlap;
        private string mRingRem;
        private bool mDynamicFlatFielding;
        private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
            Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
            Path.DirectorySeparatorChar + "_corr_log_00.txt"; // It should be "*_00.txt"

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
        public PreProcessingPreviewJob(
            int imageIndex,
            string inputFile,      
            string outputFile,
            int normSx,
            int normDx,
            bool flatEnd,
            bool halfHalf,
            int halfHalfLine,
            bool extFOV,
            bool extFOVRight,
            int extFOVOverlap,
            string ringRem,
            bool dynamicFlatFielding
            )
        {
            mImageIndex = imageIndex;
            mInputFile = inputFile;
            mPreviewFile = outputFile;
            mNormDx = normDx;
            mNormSx = normSx;
            mFlatEnd = flatEnd;
            mHalfHalf = halfHalf;
            mHalfHalfLine = halfHalfLine;
            mExtFOV = extFOV;
            mExtFOVRight = extFOVRight;
            mExtFOVOverlap = extFOVOverlap;
            mRingRem = ringRem;
            mDynamicFlatFielding = dynamicFlatFielding;
        }

        /// <summary>
        /// 
        /// </summary>
        public PreProcessingPreviewJob(
            int imageIndex,
            string inputFile, 
            string outputFile,
            int normSx,
            int normDx,
            bool flatEnd,
            bool halfHalf,
            int halfHalfLine,
            bool extFOV,
            bool extFOVRight,
            int extFOVOverlap,
            string ringRem,     
            bool dynamicFlatFielding,
            string logFile
            )
            : this(imageIndex, inputFile, outputFile, normSx, normDx, flatEnd, halfHalf,
                halfHalfLine, extFOV, extFOVRight, extFOVOverlap, ringRem, dynamicFlatFielding)         
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
         
            string zString = string.Empty;

            // Multithread version:
            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + 
                Properties.Settings.Default.PreProcessingPreviewJob + "\" " +
                mImageIndex.ToString() + " \"" + 
                mInputFile + "\" \"" +
                mPreviewFile + "\" " +
                mNormSx.ToString() + " " + 
                mNormDx.ToString() + " " +
                mFlatEnd.ToString() + " " + 
                mHalfHalf.ToString() + " " +
                mHalfHalfLine.ToString() + " " +
                mExtFOV.ToString() + " " + 
                mExtFOVRight.ToString() + " " +
                mExtFOVOverlap.ToString() + " " +
                mRingRem + " " +
                mDynamicFlatFielding.ToString() + " \"" + 
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
            return "pre-processing";
        }
    }
}
