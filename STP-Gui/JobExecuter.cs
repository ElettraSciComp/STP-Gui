/***************************************************************************/
/* (C) 2016 Elettra - Sincrotrone Trieste S.C.p.A.. All rights reserved.   */
/*                                                                         */
/*                                                                         */
/* This file is part of STP-Core, the Python core of SYRMEP Tomo Project,  */
/* a software tool for the reconstruction of experimental CT datasets.     */
/*                                                                         */
/* STP-Core is free software: you can redistribute it and/or modify it     */
/* under the terms of the GNU General Public License as published by the   */
/* Free Software Foundation, either version 3 of the License, or (at your  */
/* option) any later version.                                              */
/*                                                                         */
/* STP-Core is distributed in the hope that it will be useful, but WITHOUT */
/* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or   */
/* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License    */
/* for more details.                                                       */
/*                                                                         */
/* You should have received a copy of the GNU General Public License       */
/* along with STP-Core. If not, see <http://www.gnu.org/licenses/>.        */
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
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Globalization;

using SYRMEPTomoProject.Jobs;

namespace SYRMEPTomoProject
{
    /// <summary>
    /// Class that takes care of the execution of IJob instances.
    /// </summary>
    public class JobExecuter
    {
        private IJob mJob;
        private int mProcesses = 1;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="job">The IJob instance to execute using a single process.</param>
        public JobExecuter(IJob job)
        {
            mJob = job;
            mProcesses = 1;
        }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="job">The IJob instance to execute.</param>
        /// <param name="processes">The number of processes to use for the execution of the IJob instance.</param>
        /*public JobExecuter(IJob job, int processes)
        {
            mJob = job;
            mProcesses = processes;
        }*/

        /// <summary>
        /// Gets the IJob instance that the JobExecuter will execute.
        /// </summary>
        public IJob Job { get { return mJob; } }

        /// <summary>
        /// Gets the number of processes the JobExecuter will use to split the execution of the IJob instance.
        /// </summary>
        public int Processes { get { return mProcesses; } }


        /// <summary>
        /// Single process execution of the filter.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public void Run()
        {                        
            // Prepare the process to run
            //string retMessage;
            
            Process aProcess = new Process();
            ProcessStartInfo aProcessStartInfo = new ProcessStartInfo();

            aProcessStartInfo.Arguments = mJob.GetCommandLine();
            aProcessStartInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + Properties.Settings.Default.PythonExe;
            //Debug.Assert(false, aProcessStartInfo.FileName + " " + aProcessStartInfo.Arguments);
            aProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            aProcessStartInfo.UseShellExecute = false;
            aProcessStartInfo.RedirectStandardInput = true;
            aProcessStartInfo.RedirectStandardError = true;
            aProcessStartInfo.RedirectStandardOutput = true;
            aProcessStartInfo.CreateNoWindow = true;     

            aProcess.StartInfo = aProcessStartInfo;
            aProcess.Start();

            // START DEBUG WITH BREAKPOINTS AND VISUALIZATION OF THE VARIABLE VALUE
            //
            // Read in all the text from the process with the StreamReader.
            //
            /*using (StreamReader reader = aProcess.StandardError)
            {
                retMessage = reader.ReadToEnd();
                //Console.Write(retMessage);
            }*/
            // END DEBUG

            // Now clean up after ourselves:
            //aProcess.Dispose();
            //aProcessStartInfo = null;           





            //
            // Log some infos (thread safe execution):    
            //
            /*if ((retMessage != String.Empty) || (aErrorOccured))
            {
                SetTextPropertyValue(aLog, "Text", "\n" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " - Error while converting " + e.Name + ": " + retMessage);
                SetSelectionStartPropertyValue(aLog, "SelectionStart");
            }
            else
            {
                SetTextPropertyValue(aLog, "Text", "\n" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " - " + e.Name + " converted successfully.");
                SetSelectionStartPropertyValue(aLog, "SelectionStart");
            }
            SetFocusMethod(aLog, "ScrollToCaret");*/

            /*aExitCode = aProcess.ExitCode;

            //Now we need to see if the process was successful
            if ((aExitCode > 0) & (!aProcess.HasExited))
            {
                aProcess.Kill();
                aErrorOccured = true;
            }

            //now clean up after ourselves
            aProcess.Dispose();
            aProcessStartInfo = null;

            return 1;*/
        }     
    }
}
