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
	public class GDEIJob : IMonitoredJob
	{
		private string mInputFile_1;
		private string mInputFile_2;
		private string mInputFile_3;
		private string mOutputFile_Abs;
		private string mOutputFile_Refr;
		private string mOutputFile_Sca;
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
        private int mTopShiftVert;
        private int mTopShiftHoriz;
        private int mLeftShiftVert;
        private int mLeftShiftHoriz;
        private int mRightShiftVert;
        private int mRightShiftHoriz;
        private double mR_1;
        private double mR_2;
        private double mR_3;
        private double mR1_1;
        private double mR1_2;
        private double mR1_3;
        private double mR2_1;
        private double mR2_2;
        private double mR2_3;
		private int mThreads;
		private string mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
			Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
			Path.DirectorySeparatorChar + "_exec_gdei_log_00.txt"; // It should be "*_00.txt"

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
		public GDEIJob(
			string inputFile_1,
			string inputFile_2,
			string inputFile_3,
			string outputFile_Abs,
			string outputFile_Refr,
			string outputFile_Sca,
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
            int topShiftVert,
            int topShiftHoriz,
            int leftShiftVert,
            int leftShiftHoriz,
            int rightShiftVert,
            int rightShiftHoriz,
            double r_1,
            double r_2,
            double r_3,
            double r1_1,
            double r1_2,
            double r1_3,
            double r2_1,
            double r2_2,
            double r2_3,
			int threads
			)
		{
			mInputFile_1 = inputFile_1;
			mInputFile_2 = inputFile_2;
			mInputFile_3 = inputFile_3;
			mOutputFile_Abs = outputFile_Abs;
			mOutputFile_Refr = outputFile_Refr;
			mOutputFile_Sca = outputFile_Sca;
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

            mTopShiftVert = topShiftVert;
            mTopShiftHoriz = topShiftHoriz;
            mLeftShiftVert = leftShiftVert;
            mLeftShiftHoriz = leftShiftHoriz;
            mRightShiftVert = rightShiftVert;
            mRightShiftHoriz = rightShiftHoriz;
            mR_1 = r_1;
            mR_2 = r_2;
            mR_3 = r_3;
            mR1_1 = r1_1;
            mR1_2 = r1_2;
            mR1_3 = r1_3;
            mR2_1 = r2_1;
            mR2_2 = r2_2;
            mR2_3 = r2_3;

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
		public GDEIJob(
			string inputFile_1,
			string inputFile_2,
			string inputFile_3,
			string outputFile_Abs,
			string outputFile_Refr,
			string outputFile_Sca,
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
            int topShiftVert,
            int topShiftHoriz,
            int leftShiftVert,
            int leftShiftHoriz,
            int rightShiftVert,
            int rightShiftHoriz,
            float r_1,
            float r_2,
            float r_3,
            float r1_1,
            float r1_2,
            float r1_3,
            float r2_1,
            float r2_2,
            float r2_3,
			int threads,
			string logFile
			)
			: this(inputFile_1,
					inputFile_2,
					inputFile_3,
					outputFile_Abs,
					outputFile_Refr,
					outputFile_Sca,
					from,
					to,
					normSx,
					normDx,
					flatEnd,
					halfHalf,
					halfHalfLine,
					extFOV,
					extFOVRight,
					extFOVOverlap,
					extFOVNormalize,
					extFOVAverage,
					ringRem,
					dynamicFlatFielding,
                    topShiftVert,
                    topShiftHoriz,
                    leftShiftVert,
                    leftShiftHoriz,
                    rightShiftVert,
                    rightShiftHoriz,
                    r_1,
                    r_2,
                    r_3,
                    r1_1,
                    r1_2,
                    r1_3,
                    r2_1,
                    r2_2,
                    r2_3,
					threads)
		{
			mLogFile = Properties.Settings.Default.FormSettings_TemporaryPath +
				Path.DirectorySeparatorChar + Properties.Settings.Default.SessionID +
				Path.DirectorySeparatorChar + logFile;
		}

		/// <summary>
		/// Get the command line for current job instance.
		/// </summary>
		/// <returns>The string to execute.</returns>
		public string GetCommandLine()
		{

			string zString = string.Empty;

			// Multithread version:
			zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
				+ Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.GDEIJob + "\" "
				+ mFrom.ToString() + " " +
				mTo.ToString() + " \"" +
				mInputFile_1 + "\" \"" +
				mInputFile_2 + "\" \"" +
				mInputFile_3 + "\" \"" +
				mOutputFile_Abs + "\" \"" +
				mOutputFile_Refr + "\" \"" +
				mOutputFile_Sca + "\" " +
				mNormSx.ToString() + " " +
				mNormDx.ToString() + " " +
				mFlatEnd.ToString() + " " +
				mHalfHalf.ToString() + " " +
				mHalfHalfLine.ToString() + " " +
				mExtFOV.ToString() + " " +
				mExtFOVRight.ToString() + " " +
				mExtFOVOverlap.ToString() + " " +
				mExtFOVNormalize.ToString() + " " +
				mExtFOVAverage.ToString() + " " +
				mRingRem + " " +
				mDynamicFlatFielding.ToString() + " " +

                mTopShiftVert.ToString() + " " +
                mTopShiftHoriz.ToString() + " " +
                mLeftShiftVert.ToString() + " " +
                mLeftShiftHoriz.ToString() + " " + 
                mRightShiftVert.ToString() + " " +
                mRightShiftHoriz.ToString() + " " +

                mR_1.ToString() + " " +
                mR_2.ToString() + " " + 
                mR_3.ToString() + " " + 
                mR1_1.ToString() + " " +
                mR1_2.ToString() + " " +
                mR1_3.ToString() + " " +
                mR2_1.ToString() + " " +
                mR2_2.ToString() + " " +
                mR2_3.ToString() + " " +

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
			return "pre-processing";
		}
	}
}
