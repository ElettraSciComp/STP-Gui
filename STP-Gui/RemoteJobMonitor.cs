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
// Last modified: July, 8th 2016
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

    /// <summary>
    /// 
    /// </summary>
    class RemoteJobMonitor : IJobMonitor
    {
        private bool mMonitorStarted = false;
        private IJobExecuter mJobExecuter = null;
        private string mStrToMonitor = string.Empty;
        private int mNrOfLinesToMonitor;

        public event JobStartedEventHandler JobStarted;
        public event JobStepEventHandler JobStep;
        public event JobCompletedEventHandler JobCompleted;
        public event JobErrorEventHandler JobError;

        public IMonitoredJob MonitoredJob
        {
            get { return (IMonitoredJob)mJobExecuter.Job; }
        }


        /// <summary>
        /// Class constructor.
        /// </summary>
        public RemoteJobMonitor()
        {

        }

        static int countFreq(String pat, String txt)
        {
            int M = pat.Length;
            int N = txt.Length;
            int res = 0;

            /* A loop to slide pat[] one by one */
            for (int i = 0; i <= N - M; i++)
            {
                /* For current index i, check for pattern match */
                int j;
                for (j = 0; j < M; j++)
                {
                    if (txt[i + j] != pat[j])
                    {
                        break;
                    }
                }

                // if pat[0...M-1] = txt[i, i+1, ...i+M-1]  
                if (j == M)
                {
                    res++;
                    j = 0;
                }
            }
            return res;
        } 

        /// <summary>
        /// Activate the monitoring (usually this has to be run by exploiting the BackgroundWorker pattern).
        /// No effects are produced if no JobExecuter instance is associated to the RemoteJobMonitor.
        /// </summary>
        public void Start()
        {
            this.mMonitorStarted = true;


            while (mMonitorStarted == true)
            {
                if (mJobExecuter != null)
                {
                    /* List<string> zFileNameList = new List<string>();
                     List<int> zCountList = new List<int>();
                     List<int> zLocalCountList = new List<int>();*/

                    int zCount = 0;
                    int zLocalCount = 0;

                    IMonitoredJob zJob = (IMonitoredJob)mJobExecuter.Job;

                    string zLine;
                    DateTime zT0, zT1;
                    TimeSpan zElapsedTime;
                    //int zProcessedFiles = 0;
                    //int zProcessedLines = 0;
                    bool zFinished = false;



                    // Number of files to process (in order to return the percentage of job completion):
                    int zFilesToProcess;
                    if (mNrOfLinesToMonitor == 0)
                    {
                        zFilesToProcess = zJob.To - zJob.From + 1;
                    }
                    else
                    {
                        zFilesToProcess = mNrOfLinesToMonitor;
                    }


                  
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

                        // Wait until the files exist:
                        TimeSpan zTimeOut = TimeSpan.FromSeconds(Properties.Settings.Default.TimeOutWaitForLogInSeconds);
                        Stopwatch zStopWatch = Stopwatch.StartNew();
                        bool zDone = false;

                        while ((zStopWatch.Elapsed < zTimeOut) && (zDone == false))
                        {
                            string zresult = SYRMEP_HPC.Execute("ls " + zJob.LogFile);

                            if (zresult.StartsWith(zJob.LogFile))
                            {
                                zDone = true;
                            }
                            // Sleep the thread:
                            if (zJob is IRemoteMonitoredJob)
                            {
                                Thread.Sleep(Properties.Settings.Default.RemoteLogRefreshRateMilliseconds);
                            }
                            else
                            {
                                Thread.Sleep(Properties.Settings.Default.LocalLogRefreshRateMilliseconds);
                            }
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
                        while (!zFinished)
                        {
                            int zProcessedFiles = 0;

                            // For each file to log:
                            zLocalCount = 0;

                            string zResult = SYRMEP_HPC.Execute("cat " + zJob.LogFile);

                            string[] zLines = zResult.Split('\n');
                            zLocalCount = zLines.Length - 1;
                            zProcessedFiles = countFreq("\t" + this.mStrToMonitor, zResult);  


                            // Check if the number of lines in the log file is greater than the number of lines read 
                            // at the previous step. If true there is something to log and we raise up the event:
                            if (zLocalCount >= zCount)
                            {
                                int diff = zLocalCount - zCount;

                                for (int k = 0; k < diff; k++)
                                {
                                    zLine = zLines[zCount + k];

                                    // Raise up the event:
                                    if (JobStep != null)
                                    {
                                        JobStep(this, new JobEventArgs(Environment.NewLine + zLine, zProcessedFiles / ((double)(zFilesToProcess))));
                                    }
                                }
                            }


                            zCount = zLocalCount;


                            // Check ending condition:
                            if (zProcessedFiles >= zFilesToProcess)
                            {
                                zFinished = true;
                            }

                            // Sleep the thread:
                            if (zJob is IRemoteMonitoredJob)
                            {
                                Thread.Sleep(Properties.Settings.Default.RemoteLogRefreshRateMilliseconds);
                            }
                            else
                            {
                                Thread.Sleep(Properties.Settings.Default.LocalLogRefreshRateMilliseconds);
                            }
                        }


                        //
                        // Raise up the the event for completion of the monitoring:
                        //

                        // Get the last timestamp:
                        zT1 = DateTime.Now;
                        zElapsedTime = zT1 - zT0;

                        // Delete log:
                        if (File.Exists(zJob.LogFile))
                        {
                            string zResult = SYRMEP_HPC.Execute("rm " + zJob.LogFile);                            
                        }

                        // Raise the event:
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
                Thread.Sleep(Properties.Settings.Default.LocalLogRefreshRateMilliseconds);
            }
        }

        /// <summary>
        /// Run the actual monitoring.
        /// </summary>
        /// <param name="jobExecuter">The JobExecutor instance to monitor.</param>
        public void Run(IJobExecuter jobExecuter, string strToMonitor, int nrOfLinesToMonitor)
        {
            mJobExecuter = jobExecuter;
            mStrToMonitor = strToMonitor;
            mNrOfLinesToMonitor = nrOfLinesToMonitor;
        }

        /// <summary>
        /// Run the actual monitoring.
        /// </summary>
        /// <param name="jobExecuter">The JobExecutor instance to monitor.</param>
        public void Run(IJobExecuter jobExecuter, string strToMonitor)
        {
            mJobExecuter = jobExecuter;
            mStrToMonitor = strToMonitor;
            mNrOfLinesToMonitor = 0;
        }


        /// <summary>
        /// Stop the monitoring.
        /// </summary>
        /// <param name="jobExecuter">The JobExecutor instance to monitor.</param>
        public void Stop(IJobExecuter jobExecuter)
        {
            mJobExecuter = jobExecuter;
        }
    }
}
