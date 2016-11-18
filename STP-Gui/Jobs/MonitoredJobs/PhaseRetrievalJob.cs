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
    public class PhaseRetrievalJob : IMonitoredJob
    {
        private string mInputFile;
        private string mOutputFile;
        private double mParam1;
        private double mParam2;
        private double mDistance;
        private double mEnergy;
        private double mPixelsize;
        private int mMethod; // 0 for Paganin, 5 for Quasiparticle
        private int mFrom;
        private int mTo;        
        private int mThreads;
        private bool mPad;
        private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath
            + Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
            Path.DirectorySeparatorChar + "_phrt_log_00.txt"; // It should be "*_00.txt"

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
        /// Class constructor.
        /// </summary>
        /// <param name="skipPhrt"></param>
        /// <param name="flatEnd"></param>
        /// <param name="param1"></param>
        /// <param name="distance"></param>
        /// <param name="energy"></param>
        /// <param name="pixelsize"></param>
        /// <param name="normSx"></param>
        /// <param name="normDx"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="threads"></param>
        public PhaseRetrievalJob(
            string inputFile,
            string outputFile,
            int method,
            int from,
            int to,
            double param1,
            double param2, 
            double distance, 
            double energy, 
            double pixelsize,
            bool pad,
            int threads
            )
        {
            mInputFile = inputFile;
            mOutputFile = outputFile;
            mMethod = method;
            mParam1 = param1;
            mParam2 = param2;
            mDistance = distance;
            mEnergy = energy;
            mPixelsize = pixelsize;
            mFrom = from;
            mTo = to;
            mThreads = threads;
            mPad = pad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="method"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="distance"></param>
        /// <param name="energy"></param>
        /// <param name="pixelsize"></param>
        /// <param name="pad"></param>
        /// <param name="threads"></param>
        /// <param name="logFile"></param>
        public PhaseRetrievalJob(
            string inputFile,
            string outputFile,
            int method,
            int from,
            int to,
            double param1,
            double param2, 
            double distance, 
            double energy, 
            double pixelsize,
            bool pad,
            int threads,
            string logFile
            )
            : this(inputFile, outputFile, method, from, to, param1, param2, distance, energy, pixelsize, pad, threads)
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
            string zString;

            // Single Thread version:
            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.PhaseRetrievalJob + "\" "
                + mFrom.ToString() + " " +
                mTo.ToString() + " \"" + mInputFile + "\" \"" + mOutputFile + "\" " +
                mMethod.ToString() + " " +
                mParam1.ToString(CultureInfo.InvariantCulture) + " " +
                mParam2.ToString(CultureInfo.InvariantCulture) + " " +
                mEnergy.ToString(CultureInfo.InvariantCulture) + " " +
                mDistance.ToString(CultureInfo.InvariantCulture) + " " +
                mPixelsize.ToString(CultureInfo.InvariantCulture) + " " +
                mPad.ToString() + " " +
                mThreads.ToString() + " \"" + mLogFile + "\"";           
          
            return zString;
        }

        /// <summary>
        /// Return a descriptor for current job.
        /// </summary>
        /// <returns>A string with the description of the job.</returns>
        public override string ToString()
        {
            return "phase retrieval";
        }
    }
}
