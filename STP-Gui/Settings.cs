using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrunTomoProject
{
    public static class BTPSettings
    {
        // Folders:
        private static string mInputPath = string.Empty;
        private static string mWorkingPath = "S:\\STP";
        private static string mTestPath = "S:\\STP";
        private static string mOutputPath = "E:\\STP";

        private static int mNumberOfProjections = 0;

        // Tomo prefixes:
        private static string mTomoPrefix = "tomo"; // Default
        private static string mFlatPrefix = "flat"; // Default
        private static string mDarkPrefix = "dark"; // Default
        private static string mSinoPrefix = "sino"; // Default
        private static string mOutputPrefix = "slice"; // Default
        // Experimental settings:
        private static double mEnergy = 0.0; // keV
        private static double mDistance = 0.0; // mm
        private static double mPixelSize = 0.0; // micron
        private static bool mWhiteBeam = false;
        private static string mExperimentalNote = string.Empty;
        // Reconstruction settings:
        private static string mReconParam1 = "shepp-logan";


        /// <summary>
        /// Input path or file name.
        /// </summary>
        public static string InputPath 
        {
            get { return mInputPath; }
            set { mInputPath = value; }
        }

        /// <summary>
        /// Working path.
        /// </summary>
        public static string WorkingPath
        {
            get { return mWorkingPath; }
            set { mWorkingPath = value; }
        }

        /// <summary>
        /// Test path.
        /// </summary>
        public static string TestPath
        {
            get { return mTestPath; }
            set { mTestPath = value; }
        }

        /// <summary>
        /// Output path.
        /// </summary>
        public static string OutputPath
        {
            get { return mOutputPath; }
            set { mOutputPath = value; }
        }     

        /// <summary>
        /// Gets or sets the number of projections of the current dataset.
        /// </summary>
        public static int NumberOfProjections
        {
            get { return mNumberOfProjections; }
            set { mNumberOfProjections = value; }
        }

        /// <summary>
        /// Tomo prefix.
        /// </summary>
        public static string TomoPrefix
        {
            get { return mTomoPrefix; }
            set { mTomoPrefix = value; }
        }

        /// <summary>
        /// Flat prefix.
        /// </summary>
        public static string FlatPrefix
        {
            get { return mFlatPrefix; }
            set { mFlatPrefix = value; }
        }

        /// <summary>
        /// Dark prefix.
        /// </summary>
        public static string DarkPrefix
        {
            get { return mDarkPrefix; }
            set { mDarkPrefix = value; }
        }

        /// <summary>
        /// Sino prefix.
        /// </summary>
        public static string SinoPrefix
        {
            get { return mSinoPrefix; }
            set { mSinoPrefix = value; }
        }

        /// <summary>
        /// Output prefix.
        /// </summary>
        public static string OutputPrefix
        {
            get { return mOutputPrefix; }
            set { mOutputPrefix = value; }
        }

        /// <summary>
        /// Experimental energy in keV.
        /// </summary>
        public static double Energy
        {
            get { return mEnergy; }
            set { mEnergy = value; }
        }

        /// <summary>
        /// Experimental distance in mm.
        /// </summary>
        public static double Distance
        {
            get { return mDistance; }
            set { mDistance = value; }
        }

        /// <summary>
        /// Experimental pixel size in microns.
        /// </summary>
        public static double PixelSize
        {
            get { return mPixelSize; }
            set { mPixelSize = value; }
        }

        /// <summary>
        /// Flag for white beam (if true the Energy property is disregarded).
        /// </summary>
        public static bool WhiteBeam
        {
            get { return mWhiteBeam; }
            set { mWhiteBeam = value; }
        }

        /// <summary>
        /// Additional comments about the experimental setup.
        /// </summary>
        public static string ExperimentalNote
        {
            get { return mExperimentalNote; }
            set { mExperimentalNote = value; }
        }

        /// <summary>
        /// Reconstruction parameter.
        /// </summary>
        public static string ReconParam1
        {
            get { return mReconParam1; }
            set { mReconParam1 = value; }
        }


    }
}
