using System;

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


    interface IJobMonitor
    {
        event JobCompletedEventHandler JobCompleted;
        event JobErrorEventHandler JobError;
        event JobStartedEventHandler JobStarted;
        event JobStepEventHandler JobStep;
        SYRMEPTomoProject.Jobs.IMonitoredJob MonitoredJob { get; }
        void Run(IJobExecuter jobExecuter, string strToMonitor);
        void Run(IJobExecuter jobExecuter, string strToMonitor, int nrOfLinesToMonitor);
        void Start();
        void Stop(IJobExecuter jobExecuter);
    }
}
