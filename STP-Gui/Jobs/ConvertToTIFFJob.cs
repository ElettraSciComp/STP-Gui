using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace BrunTomoProject.Jobs
{
    /// <summary>
    /// 
    /// </summary>
    public class ConvertToTIFFJob : IJob
    {
        private string mInputFile;
        private string mOutputFile;
        private int mFrom; 
        private int mTo;
        private string mTomoPrefix;
        private string mFlatPrefix;
        private string mDarkPrefix;
        private string mFlatAfterPrefix;
        private string mDarkAfterPrefix;
        private int mThreads;
        private bool mSkipFlat;        
        private bool mInputProj;
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
        public ConvertToTIFFJob(
            string inputFile,      
            string outputFile,
            int from,
            int to,      
            string tomoPrefix,
            string flatPrefix,
            string darkPrefix,
            string flatAfterPrefix,
            string darkAfterPrefix,
            bool skipFlat,
            bool inputProj,
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
            mFlatAfterPrefix = flatAfterPrefix;
            mDarkAfterPrefix = darkAfterPrefix;
            mSkipFlat = skipFlat;
            mInputProj = inputProj;
            mThreads = threads;

            mLogFile = BTPSettings.TestPath + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(outputFile) + "_totiff_00.txt";
        }


        /// <summary>
        /// Get the command line for current Phase Retrieval filter instance.
        /// </summary>
        /// <returns>The string to execute.</returns>
        public string GetCommandLine()
        {

            string zString = string.Empty; 
            CultureInfo zCI = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.CultureInfo);

            // Create output path if does not exist:
            Directory.CreateDirectory(BTPSettings.OutputPath);

            zString = "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar
                + Properties.Settings.Default.PythonPath + Path.DirectorySeparatorChar + Properties.Settings.Default.ConvertToTIFFJob + "\" " 
                + mFrom.ToString() + " " +
                mTo.ToString() + " \"" + mInputFile + "\" \"" + mOutputFile + "\" " +
                mTomoPrefix + " " + mFlatPrefix + " " +
                mDarkPrefix + " " + mFlatAfterPrefix + " " +
                mDarkAfterPrefix + " " + mSkipFlat.ToString() + " " + 
                mInputProj.ToString() + " \"" + mLogFile + "\"";

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
