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
    public class TDF2TIFFJob : IMonitoredJob
    {
        private string mInputFile;
        private string mOutputFile;
        private int mFrom; 
        private int mTo;
        private string mTomoPrefix;
        private string mFlatPrefix;
        private string mDarkPrefix;
        private int mThreads;    
        private bool mInputProj;
        private string mLogFile;
        private bool mTIFFFormat;

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
        public TDF2TIFFJob(
            string inputFile,      
            string outputFile,
            int from,
            int to,      
            string tomoPrefix,
            string flatPrefix,
            string darkPrefix,
            bool inputProj,
            bool TIFFFormat,
            int threads
            )
        {
            mInputFile = inputFile;
            mOutputFile = outputFile;
            mFrom = from;
            mTo = to;
            mTomoPrefix = tomoPrefix;
            mFlatPrefix = flatPrefix;
            mDarkPrefix = darkPrefix;
            mInputProj = inputProj;
            mThreads = threads;
            mTIFFFormat = TIFFFormat;

            mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
                Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
                Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(outputFile) + "_totiff_00.txt";
        }


        /// <summary>
        /// Get the command line for current Phase Retrieval filter instance.
        /// </summary>
        /// <returns>The string to execute.</returns>
        public string GetCommandLine()
        {

            string zString = string.Empty; 

            // Create output path if does not exist:
            Directory.CreateDirectory(Properties.Settings.Default.FormSettings_OutputPath);

            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.ConvertToTIFFJob + "\" " 
                + mFrom.ToString() + " " +
                mTo.ToString() + " \"" + mInputFile + "\" \"" + mOutputFile + "\" " +
                mTomoPrefix + " " + mFlatPrefix + " " +
                mDarkPrefix + " " + " " +
                mInputProj.ToString() + " " + mTIFFFormat.ToString() + " " +
                Properties.Settings.Default.FormSettings_NrOfProcesses.ToString() + 
                " \"" + mLogFile + "\"";

            return zString;
        }

        /// <summary>
        /// Return a descriptor for current job.
        /// </summary>
        /// <returns>A string with the description of the job.</returns>
        public override string ToString()
        {
            return "conversion to TIFF";
        }
    }
}
