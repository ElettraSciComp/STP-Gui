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
