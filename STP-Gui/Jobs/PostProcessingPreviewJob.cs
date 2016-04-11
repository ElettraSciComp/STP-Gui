/***************************************************************************/
/* (C) 2016 Elettra - Sincrotrone Trieste S.C.p.A.. All rights reserved.   */
/*                                                                         */
/* Copyright 2016. Elettra - Sincrotrone Trieste S.C.p.A. THE COMPANY      */
/* ELETTRA - SINCROTRONE TRIESTE S.C.P.A. IS NOT REPONSIBLE FOR THE USE    */
/* OF THIS SOFTWARE. If software is modified to produce derivative works,  */
/* such modified software should be clearly marked, so as not to confuse   */
/* it with the version available from Elettra Sincrotrone Trieste S.C.p.A. */
/*                                                                         */
/* Additionally, redistribution and use in source and binary forms, with   */
/* or without modification, are permitted provided that the following      */
/* conditions are met:                                                     */
/*                                                                         */
/*     * Redistributions of source code must retain the above copyright    */
/*       notice, this list of conditions and the following disclaimer.     */
/*                                                                         */
/*     * Redistributions in binary form must reproduce the above copyright */
/*       notice, this list of conditions and the following disclaimer in   */
/*       the documentation and/or other materials provided with the        */
/*       distribution.                                                     */
/*                                                                         */
/*     * Neither the name of Elettra - Sincotrone Trieste S.C.p.A nor      */
/*       the names of its contributors may be used to endorse or promote   */
/*       products derived from this software without specific prior        */
/*       written permission.                                               */
/*                                                                         */
/* THIS SOFTWARE IS PROVIDED BY ELETTRA - SINCROTRONE TRIESTE S.C.P.A. AND */
/* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  */
/* BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND       */
/* FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL      */
/* ELETTRA - SINCROTRONE TRIESTE S.C.P.A. OR CONTRIBUTORS BE LIABLE FOR    */
/* ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL  */
/* DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE       */
/* GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS           */
/* INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER    */
/* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR         */
/* OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF  */
/* ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.                              */
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
    public class PostProcessingPreviewJob : IJob
    {
        private int mImageIndex;
        private string mInputPath;
        private string mPreviewFile;
        private string mConvertTo8Method;
        private double mConvertTo8Min;
        private double mConvertTo8Max;        
        private int mCropLeft;
        private int mCropRight;
        private int mCropTop;
        private int mCropBottom; 
        private string mOutPrefix;
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
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="threads"></param>
        public PostProcessingPreviewJob(
            int imageIndex,
            string inputPath,      
            string outputFile,
            string convertTo8Method,
            double convertTo8Min,
            double convertTo8Max,        
            int cropLeft,
            int cropRight,
            int cropTop,
            int cropBottom,
            string outPrefix
            )
        {
            mImageIndex = imageIndex;
            mInputPath = inputPath;
            mPreviewFile = outputFile;
            mConvertTo8Method = convertTo8Method;
            mConvertTo8Min = convertTo8Min;
            mConvertTo8Max = convertTo8Max;
            mCropLeft = cropLeft;
            mCropRight = cropRight;
            mCropTop = cropTop;
            mCropBottom = cropBottom; 
            mOutPrefix = outPrefix;
        }

        /// <summary>
        /// 
        /// </summary>
        public PostProcessingPreviewJob(
            int imageIndex,
            string inputPath,
            string outputFile,
            string convertTo8Method,
            double convertTo8Min,
            double convertTo8Max,        
            int cropLeft,
            int cropRight,
            int cropTop,
            int cropBottom,
            string outPrefix,
            string logFile
            )
            : this(imageIndex, inputPath, outputFile, convertTo8Method, convertTo8Min, convertTo8Max, 
                    cropLeft, cropRight, cropTop, cropBottom, outPrefix)         
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
            
            string zConvertTo8Args = "\"" + mConvertTo8Method + ":" + mConvertTo8Min.ToString(CultureInfo.InvariantCulture) + ";" + mConvertTo8Max.ToString(CultureInfo.InvariantCulture) + "\"";
            string zCropArgs = "\"" + mCropTop.ToString() + ":" + mCropBottom.ToString() + ":" + mCropLeft.ToString() + ":" + mCropRight.ToString() + "\"";

            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.PostProcessingPreviewJob + "\" " +
                mImageIndex.ToString() + " \"" +
                mInputPath + "\" \"" +
                mPreviewFile + "\" " +             
                zConvertTo8Args + " " +
                zCropArgs + " \"" +
                mOutPrefix + "\" \"" +
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
