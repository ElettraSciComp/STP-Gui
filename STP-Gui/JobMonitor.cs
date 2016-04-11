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
using System.Globalization;
using System.Threading;
using System.IO;
using System.Diagnostics;

using SYRMEPTomoProject.Jobs;

namespace SYRMEPTomoProject
{
    public class JobEventArgs : EventArgs
    {
        private string mLine;
        private double mStep;

        /// <summary>
        /// Gets the line to log.
        /// </summary>
        public string Line { get { return mLine; } }

        /// <summary>
        /// Gets the numerical value of the ratio (between 0 and 1, i.e. percentage) of job completion.
        /// </summary>
        public double Step { get { return mStep; } }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="line">The text line to log.</param>
        public JobEventArgs(string line, double step)
        {
            mLine = line;
            mStep = step;
        }
    }

    public delegate void JobStartedEventHandler(object sender, JobEventArgs e);
    public delegate void JobStepEventHandler(object sender, JobEventArgs e);
    public delegate void JobCompletedEventHandler(object sender, JobEventArgs e);
    public delegate void JobErrorEventHandler(object sender, JobEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    class JobMonitor
    {
        private bool mMonitorStarted = false;
        private JobExecuter mJobExecuter = null;
        private string mStrToMonitor = string.Empty;
        private int mNrOfLinesToMonitor;

        public event JobStartedEventHandler JobStarted;
        public event JobStepEventHandler JobStep;
        public event JobCompletedEventHandler JobCompleted;
        public event JobErrorEventHandler JobError;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public JobMonitor()
        {

        }

        /// <summary>
        /// Activate the monitoring (usually this has to be run by exploiting the BackgroundWorker pattern).
        /// No effects are produced if no JobExecuter instance is associated to the JobMonitor.
        /// </summary>
        public void Start()
        {
            this.mMonitorStarted = true;
           

            while (mMonitorStarted == true)
            {
                if (mJobExecuter != null)
                {
                    List<string> zFileNameList = new List<string>();
                    List<int> zCountList = new List<int>();
                    List<int> zLocalCountList = new List<int>();

                    IMonitoredJob zJob = (IMonitoredJob)mJobExecuter.Job;

                    string zLine;
                    DateTime zT0, zT1;
                    TimeSpan zElapsedTime;
                    //int zProcessedFiles = 0;
                    //int zProcessedLines = 0;
                    bool zFinished = false;



                    // Number of files to process (in order to return the percentage of job completion):
                    int zFilesToProcess = zJob.To - zJob.From + 1;

                    StringBuilder aStringBuilder;

                    //
                    // Raise up the the event for the start up of the monitoring:
                    //
                    if (JobStarted != null)
                    {
                        JobStarted(this, new JobEventArgs(Environment.NewLine + "Job for " + zJob.ToString() + " submitted...", 0.0));
                    }

                    try
                    {
                        // Get a first timestamp:
                        zT0 = DateTime.Now;

                        // Create a list of the log files to monitor:
                        for (int i = 0; i < mJobExecuter.Processes; i++)
                        {
                            aStringBuilder = new StringBuilder(zJob.LogFile);
                            aStringBuilder.Remove(zJob.LogFile.Length - 6, 2);
                            aStringBuilder.Insert(zJob.LogFile.Length - 6, i.ToString("00", CultureInfo.InvariantCulture));
                            zFileNameList.Add(aStringBuilder.ToString());
                            zCountList.Add(0);
                            zLocalCountList.Add(0);
                        }

                        // Wait until the files exist:
                        TimeSpan zTimeOut = TimeSpan.FromSeconds(Properties.Settings.Default.TimeOutWaitForLogInSeconds);
                        Stopwatch zStopWatch = Stopwatch.StartNew();
                        bool zDone = false;

                        while (zStopWatch.Elapsed < zTimeOut && !zDone)
                        {
                            // If all the work is completed set zDone to True:
                            zDone = true;

                            for (int i = 0; i < mJobExecuter.Processes; i++)
                            {
                                string zFileName = (zFileNameList[i]);

                                if (!File.Exists(zFileName))
                                {
                                    zDone = false;
                                }
                            }
                            Thread.Sleep(500);
                        }

                        if (zDone == false)
                        {
                            if (JobError != null)
                            {
                                // Add the time for the execution of the whole job:
                                JobError(this, new JobEventArgs(Environment.NewLine + "Job error: A time out occurred while looking for log files.", 1.0));
                            }
                        }


                        // Start a loop 'till the last file has been processed. Set also a timeout. 
                        //while (zProcessedFiles < zFilesToProcess)
                        while (!zFinished)
                        {
                            int zProcessedFiles = 0;

                            // For each file to log:
                            for (int i = 0; i < mJobExecuter.Processes; i++)
                            {                                
                                string zFileName = zFileNameList[i];
                                zLocalCountList[i] = 0;                                

                                // Get first the number of lines into this log file:
                                using (FileStream zFileStream = new FileStream(zFileName,
                                       FileMode.Open,
                                       FileAccess.Read,
                                       FileShare.ReadWrite))
                                {
                                    using (StreamReader zStreamReader = new StreamReader(zFileStream))
                                    {
                                        while ((zLine = zStreamReader.ReadLine()) != null)
                                        {
                                            zLocalCountList[i]++;

                                            string zTestString = "\t" + this.mStrToMonitor;
                                            if (zLine.StartsWith(zTestString))
                                            {
                                                zProcessedFiles++;
                                            }
                                        }
                                    }
                                }                                


                                // Check if the number of lines in this log file is greater than the number of lines read 
                                // at the previous step:
                                int zNumberOfLines = zLocalCountList[i];
                                zLocalCountList[i] = 0;
                                if (zNumberOfLines > zCountList[i])
                                {
                                    using (FileStream zFileStream = new FileStream(zFileName,
                                        FileMode.Open,
                                        FileAccess.Read,
                                        FileShare.ReadWrite))
                                    {
                                        using (StreamReader zStreamReader = new StreamReader(zFileStream))
                                        {
                                            while ((zLine = zStreamReader.ReadLine()) != null)
                                            {
                                                // If something to log has been found raise up the event:
                                                if (zLocalCountList[i] >= zCountList[i])
                                                {
                                                    // The number of processed files is determined by reading the log line:
                                                    /*string zTestString = "\t" + this.mStrToMonitor;
                                                    if (zLine.StartsWith(zTestString))
                                                    {
                                                        // Get processed counter:
                                                        string zString = zLine.Substring(zTestString.Length + 1, 4);
                                                        int zInt = Convert.ToInt32(zString);
                                                        zProcessedFiles = Convert.ToInt32(zLine.Substring(zTestString.Length + 1, 4)) - mJobExecuter.Job.From + 1;
                                                        //zProcessedLines++;

                                                        // Ending condition:
                                                        //if (zLine.StartsWith(zTestString + "_" + mJobExecuter.Job.To.ToString("D4")))
                                                        //if ( zProcessedLines >= mNrOfLinesToMonitor )
                                                        //    zFinished = true;
                                                    }*/
                                                  
                                                    // Raise up the event:
                                                    if (JobStep != null)
                                                    {
                                                        JobStep(this, new JobEventArgs(Environment.NewLine + zLine, zProcessedFiles / ((double)(zFilesToProcess))));
                                                        //JobStep(this, new JobEventArgs(Environment.NewLine + zLine, zProcessedLines / ((double)(mNrOfLinesToMonitor))));
                                                    }                                                    
                                                }

                                                // Increment counter:
                                                zLocalCountList[i]++;
                                            }
                                        }
                                    }
                                }
                                zCountList[i] = zNumberOfLines;
                            }

                            // Check ending condition:
                            if (zProcessedFiles >= zFilesToProcess)
                            {
                                zFinished = true;
                            }

                            // Sleep the thread:
                            Thread.Sleep(500);
                        }

                        //
                        // Raise up the the event for completion of the monitoring:
                        //

                        // Get the last timestamp:
                        zT1 = DateTime.Now;
                        zElapsedTime = zT1 - zT0;

                        // Delete logs:
                        for (int i = 0; i < mJobExecuter.Processes; i++)
                        {
                            string zFileName = (zFileNameList[i]);

                            if (File.Exists(zFileName))
                            {
                                File.Delete(zFileName);
                            }
                        }


                        if (JobCompleted != null)
                        {
                            // Add the time for the execution of the whole job:
                            JobCompleted(this, new JobEventArgs(Environment.NewLine + "Job for " + zJob.ToString() + " completed successfully in "
                                + zElapsedTime.ToString(@"hh\:mm\:ss") + ".", 1.0));
                        }
                        mJobExecuter = null;
                    }
                    catch (Exception e)
                    {
                        if (JobError != null)
                        {
                            // Add the time for the execution of the whole job:
                            JobError(this, new JobEventArgs(Environment.NewLine + "Job error: " + e.Message + ".", 1.0));
                            
                        }
                        mJobExecuter = null;
                    }
                }

                // Sleep:
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Run the actual monitoring.
        /// </summary>
        /// <param name="jobExecuter">The JobExecutor instance to monitor.</param>
        public void Run(JobExecuter jobExecuter, string strToMonitor, int nrOfLinesToMonitor)
        {
            mJobExecuter = jobExecuter;
            mStrToMonitor = strToMonitor;
            mNrOfLinesToMonitor = nrOfLinesToMonitor;
        }

        /// <summary>
        /// Run the actual monitoring.
        /// </summary>
        /// <param name="jobExecuter">The JobExecutor instance to monitor.</param>
        public void Run(JobExecuter jobExecuter, string strToMonitor)
        {
            mJobExecuter = jobExecuter;
            mStrToMonitor = strToMonitor;
            mNrOfLinesToMonitor = 0;
        }


        /// <summary>
        /// Stop the monitoring.
        /// </summary>
        /// <param name="jobExecuter">The JobExecutor instance to monitor.</param>
        public void Stop(JobExecuter jobExecuter)
        {
            mJobExecuter = jobExecuter;
        }
    }
}
