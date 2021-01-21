using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Renci.SshNet;
using Renci.SshNet.Common;


namespace SYRMEPTomoProject
{

    public sealed class SYRMEP_HPC
    {
        private static readonly SYRMEP_HPC instance = new SYRMEP_HPC();

        // Explicit static constructor to tell C# compiler  
        // not to mark type as beforefieldinit  
        static SYRMEP_HPC()
        {

        }
        private SYRMEP_HPC()
        {
            
        }

        public static string Execute(string command)
        {
            string zHost = Properties.Settings.Default.SYRMEP_HPC_Address;
            int zPort = Convert.ToInt32(Properties.Settings.Default.SYRMEP_HPC_Port);
            string zUser = Properties.Settings.Default.SYRMEP_HPC_User;
            string zPassword = Properties.Settings.Default.SYRMEP_HPC_Password;


            SshClient zClient = new SshClient(zHost, zPort, zUser, zPassword);

            zClient.Connect();

            var zCommand = zClient.CreateCommand(command);
            string zResult = zCommand.Execute();

            zClient.Disconnect();

            return zResult;
        }

        public static SYRMEP_HPC Instance
        {
            get
            {
                return instance;
            }
        }
    } 
}
