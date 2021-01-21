using System;
namespace SYRMEPTomoProject
{
    interface IJobExecuter
    {
        SYRMEPTomoProject.Jobs.IJob Job { get; }

        int Processes { get; }

        void Run();
    }
}
