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
    public class PostProcessingJob : IMonitoredJob
    {
        private string mInputPath;
        private string mOutputPath;
        private int mFrom; 
        private int mTo;
        private string mConvertTo8Method;
        private double mConvertTo8Min;
        private double mConvertTo8Max;        
        private int mCropLeft;
        private int mCropRight;
        private int mCropTop;
        private int mCropBottom; 
        private int mThreads;
        private string mOutPrefix;
        private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
            Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
            Path.DirectorySeparatorChar + "_exec_postproc_log_00.txt"; // It should be "*_00.txt"

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
        public PostProcessingJob(
            string inputPath,      
            string outputPath,
            int from,
            int to,
            string convertTo8Method,
            double convertTo8Min,
            double convertTo8Max,        
            int cropLeft,
            int cropRight,
            int cropTop,
            int cropBottom,
            string outPrefix,
            int threads
            )
        {
            mInputPath = inputPath;
            mOutputPath = outputPath;
            mFrom = from;
            mTo = to;
            mConvertTo8Method = convertTo8Method;
            mConvertTo8Min = convertTo8Min;
            mConvertTo8Max = convertTo8Max;
            mCropLeft = cropLeft;
            mCropRight = cropRight;
            mCropTop = cropTop;
            mCropBottom = cropBottom; 
            mOutPrefix = outPrefix;
            mThreads = threads;
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
        public PostProcessingJob(
            string inputPath,      
            string outputPath,
            int from,
            int to,
            string convertTo8Method,
            double convertTo8Min,
            double convertTo8Max,        
            int cropLeft,
            int cropRight,
            int cropTop,
            int cropBottom,
            string outPrefix,
            int threads,
            string logFile
            )
            : this(inputPath, outputPath, from, to, convertTo8Method, convertTo8Min, convertTo8Max, 
                    cropLeft, cropRight, cropTop, cropBottom, outPrefix, threads)         
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

            // Create output path if does not exist:
            Directory.CreateDirectory(mOutputPath);

            string zConvertTo8Args = "\"" + mConvertTo8Method + ":" + mConvertTo8Min.ToString(CultureInfo.InvariantCulture) + ";" + mConvertTo8Max.ToString(CultureInfo.InvariantCulture) + "\"";
            string zCropArgs = "\"" + mCropTop.ToString() + ":" + mCropBottom.ToString() + ":" + mCropLeft.ToString() + ":" + mCropRight.ToString() + "\"";

            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.PostProcessJob + "\" " +
                mFrom.ToString() + " " +
                mTo.ToString() + " \"" + 
                mInputPath + "\" \"" + 
                mOutputPath + "\" " +             
                zConvertTo8Args + " " +
                zCropArgs + " " +
                mOutPrefix + " " +
                mThreads.ToString() + " \"" + 
                mLogFile + "\"";

            return zString;
        }

        /// <summary>
        /// Return a descriptor for current job.
        /// </summary>
        /// <returns>A string with the description of the job.</returns>
        public override string ToString()
        {
            return "post-processing";
        }
    }
}
