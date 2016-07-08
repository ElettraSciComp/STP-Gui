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
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Management;
using System.Globalization;
using Microsoft.Win32;

namespace SYRMEPTomoProject
{
    static class Program
    {

        /// <summary>
        /// Checks the ability to create and write to a file in the supplied directory.
        /// </summary>
        /// <param name="path">String of the directory path to check.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool CheckDirectoryAccess(string path)
        {
            bool success = false;

            if (Directory.Exists(path))
            {
                try
                {
                    if (!(path.EndsWith(Path.DirectorySeparatorChar.ToString())))
                        path = path + Path.DirectorySeparatorChar.ToString();

                    string fullPath = path + "test.dat";

                    using (FileStream fs = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write))
                    {
                        fs.WriteByte(0xff);
                    }

                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                        success = true;
                    }
                }
                catch (Exception)
                {
                    success = false;
                }
            }

            return success;
        }

        /// <summary>
        /// Check if the specified absolute paht is an empty directory.
        /// </summary>
        /// <param name="path">String of the directory path to check.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        public static void StartProcess(string process, string args)
        {
            int aExitCode;

            Process aProcess = new Process();
            ProcessStartInfo aProcessStartInfo = new ProcessStartInfo();

            aProcessStartInfo.Arguments = args;
            aProcessStartInfo.FileName = process;            
            aProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            aProcessStartInfo.UseShellExecute = false;
            aProcessStartInfo.RedirectStandardInput = true;
            aProcessStartInfo.RedirectStandardError = true;
            aProcessStartInfo.RedirectStandardOutput = true;
            aProcessStartInfo.CreateNoWindow = true;

            aProcess.StartInfo = aProcessStartInfo;
            aProcess.Start();
            aProcess.WaitForExit();

            aExitCode = aProcess.ExitCode;

            //Now we need to see if the process was successful
            if ((aExitCode > 0) & (!aProcess.HasExited))
            {
                aProcess.Kill();
            }

            // Now clean up after ourselves:
            aProcess.Dispose();
            aProcessStartInfo = null;
        }

        /// <summary>
        /// Return a string timestamp from the input date time value.
        /// </summary>
        /// <param name="value">The DateTime instance to consider.</param>
        /// <returns>A string value generated from the the specified timestamp</returns>
        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }

        /// <summary>
        /// Wait till a file is readable.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static FileStream WaitForFile(string fullPath)
        {
            for (int numTries = 0; numTries < 10; numTries++)
            {
                try
                {
                    FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                    fs.ReadByte();
                    fs.Seek(0, SeekOrigin.Begin);

                    return fs;
                }
                catch (IOException)
                {
                    Thread.Sleep(50);
                }
            }

            return null;
        }

        /// <summary>
        /// Return true if a graphic card whose description includes "NVIDIA" is found, false otherwise.
        /// </summary>
        /// <returns>Bool value</returns>
        public static bool CheckGPU()
        {
            bool zFlag = false;
            List<string> zStringList = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");

            string graphicsCard = string.Empty;
            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        zStringList.Add(property.Value.ToString());                        
                    }
                }
            }

            // Browse string list:
            foreach (String item in zStringList)
            {
                if (item.ToUpperInvariant().StartsWith("NVIDIA"))
                {
                    zFlag = true;
                }
            }

            return zFlag;
            //return false;
        }


        /*private static string GetProductCode(string productName)
        {
            string query = string.Format("select * from Win32_Product where Name='{0}'", productName);
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject product in searcher.Get())
                    return product["IdentifyingNumber"].ToString();
            }
            return null;
        }*/

        private static bool CheckVC10Redistributable()
        {
            bool zVal = true;

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\10.0\VC\VCRedist\x64"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("Installed");
                        if (o != null)
                        {
                            string zString = o.ToString();

                            zVal = (zString == "1");
                        }
                    }
                }
            }
            catch (Exception)  
            {
            }

            return zVal;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //Properties.Settings.Default["FormSettings_OpenOnce"] = false;
                Properties.Settings.Default["SessionID"] = Program.GetTimestamp(DateTime.Now);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                SplashScreen mSplashSchreen = new SplashScreen();
                mSplashSchreen.ShowSplashScreen();
                Application.DoEvents();

                Application.CurrentCulture = CultureInfo.InvariantCulture;

                // Things to do at startup:
                mSplashSchreen.SetStatus(Properties.Resources.Splash, "");
                /*StartProcess("\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + Properties.Settings.Default.MatlabPath
                    + Path.DirectorySeparatorChar + Properties.Settings.Default.MatlabOpen + "\"",
                    "\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar + Properties.Settings.Default.MatlabPath + "\" " +
                    Properties.Settings.Default.MatlabInvisible);*/

                //mSplashSchreen.SetStatus(Properties.Resources.Splash_GPU, "");
                //mSplashSchreen.SetStatus(Properties.Resources.Splash_Recon, "");
                //System.Threading.Thread.Sleep(1900);
                mSplashSchreen.SetStatus(Properties.Resources.Splash, "");

                if (Program.CheckVC10Redistributable())
                {
                    // Open the main form:
                    Application.Run(new MainForm());
                }
                else
                {
                    // Show a message:
                    SplashScreen.CloseForm();
                    DialogResult zResult = MessageBox.Show("Microsoft Visual C++ 2010 Redistributable Package (x64) is required.\nDo you want to install it now?", 
                        Properties.Settings.Default.ProgramName, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    

                    if (zResult == DialogResult.Yes)
                    {
                        // Run VC++ 2010 Redistributable x64:
                        Program.StartProcess("\"" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar +
                        Properties.Settings.Default.DependenciesPath + Path.DirectorySeparatorChar + Properties.Settings.Default.VC2010Redistributable_x64 + "\"", "");
                    }

                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
