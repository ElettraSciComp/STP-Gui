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
