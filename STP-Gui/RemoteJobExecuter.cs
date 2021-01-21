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
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Globalization;
using System.Threading.Tasks;

using SYRMEPTomoProject.Jobs;

namespace SYRMEPTomoProject
{
    /// <summary>
    /// Class that takes care of the execution of IJob instances.
    /// </summary>
    public class RemoteJobExecuter : IJobExecuter
    {
        private IJob mJob;
        private int mProcesses = 1;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="job">The IJob instance to execute using a single process.</param>
        public RemoteJobExecuter(IJob job)
        {
            mJob = job;
            mProcesses = 1;
        }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="job">The IJob instance to execute.</param>
        /// <param name="processes">The number of processes to use for the execution of the IJob instance.</param>
        /*public RemoteJobExecuter(IJob job, int processes)
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
            // Run asynchronously:
            new Task(() => { SYRMEP_HPC.Execute(mJob.GetCommandLine()); }).Start();
        }     
    }
}
