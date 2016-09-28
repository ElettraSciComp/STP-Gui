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
    public class GuessCenterJob : IJob
    {
        private string mInputFile;
        private double mScale;
        private double mAngles;
        private int mProjFrom;
        private int mProjTo;
        private string mMethod = "registration";
        private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
            Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
            Path.DirectorySeparatorChar + "_center_log_00.txt"; // It should be "*_00.txt"
        
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
        public GuessCenterJob(
            string inputFile, 
            double scale,
            double angles,
            int projFrom,
            int projTo
            )
        {
            mInputFile = inputFile;
            mScale = scale;
            mAngles = angles;
            mProjFrom = projFrom;
            mProjTo = projTo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="logFile"></param>
        public GuessCenterJob(
            string inputFile,            
            double scale,
            double angles,
            int projFrom,
            int projTo,
            string logFile
            ) : this(inputFile, scale, angles, projFrom, projTo)         
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

            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.GuessCenterJob + "\" \"" 
                + mInputFile + "\" \"" 
                + mLogFile + "\" " 
                + mScale.ToString() + " "
                + mAngles.ToString() + " "
                + mProjFrom.ToString() + " "
                + mProjTo.ToString() + " "
                + mMethod + " " 
                + Properties.Settings.Default.FormSettings_TemporaryPath + Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID;

            return zString;
        }

        /// <summary>
        /// Return a descriptor for current job.
        /// </summary>
        /// <returns>A string with the description of the job.</returns>
        public override string ToString()
        {
            return "determination of the reconstruction offset";
        }
    }
}
