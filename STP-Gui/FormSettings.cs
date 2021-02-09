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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SYRMEPTomoProject
{
    public partial class FormSettings : Form
    {     

        public FormSettings()
        {
            InitializeComponent();
        }

      

        private void btnWorkingPath_Click(object sender, EventArgs e)
        {
            if (zWorkingPathBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                this.txbWorkingPath.Text = zWorkingPathBrowserDialog.SelectedPath;
            }
        }

        private void btnTempPath_Click(object sender, EventArgs e)
        {
            if (zTestPathBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                this.txbTemporaryPath.Text = zTestPathBrowserDialog.SelectedPath;              
            }
        }

        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            if (zOutputPathBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txbOutputPath.Text = zOutputPathBrowserDialog.SelectedPath;
            }
        }

            

        private void mButtonOk_Click(object sender, EventArgs e)
        {
            DirectoryInfo zDirInfoWorkingPath = new DirectoryInfo(this.txbWorkingPath.Text);
            DirectoryInfo zDirInfoTempPath = new DirectoryInfo(this.txbTemporaryPath.Text);

            /*DirectoryInfo zDirInfoSYRMEP_HPC_Input_LocallyMappedPath = new DirectoryInfo(this.txbSYRMEP_HPC_Input_LocallyMapped.Text);
            DirectoryInfo zDirInfoSYRMEP_HPC_Temp_LocallyMappedPath = new DirectoryInfo(this.txbSYRMEP_HPC_Temp_LocallyMapped.Text);
            DirectoryInfo zDirInfoSYRMEP_HPC_Output_LocallyMappedPath = new DirectoryInfo(this.txbSYRMEP_HPC_Output_LocallyMapped.Text);*/

            //
            // Validate fields:
            //

            if (Properties.Settings.Default.SYRMEP_Version)
            {

                // Check if path exists:
                /*if (!Directory.Exists(this.txbSYRMEP_HPC_Input_LocallyMapped.Text))
                {
                    MessageBox.Show("The specified locally mapped SYRMEP HPC input path does not exist!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Directory.Exists(this.txbSYRMEP_HPC_Temp_LocallyMapped.Text))
                {
                    MessageBox.Show("The specified locally mapped SYRMEP HPC temporary path does not exist!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!Directory.Exists(this.txbSYRMEP_HPC_Output_LocallyMapped.Text))
                {
                    MessageBox.Show("The specified locally mapped SYRMEP HPC output path does not exist!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Check if path is not root:
                else if (zDirInfoSYRMEP_HPC_Input_LocallyMappedPath.Parent == null)
                {
                    MessageBox.Show("The specified locally mapped SYRMEP HPC input path can not be root (e.g. it can not be \"C:\\\")!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (zDirInfoSYRMEP_HPC_Temp_LocallyMappedPath.Parent == null)
                {
                    MessageBox.Show("The specified locally mapped SYRMEP HPC temporary path can not be root (e.g. it can not be \"C:\\\")!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (zDirInfoSYRMEP_HPC_Output_LocallyMappedPath.Parent == null)
                {
                    MessageBox.Show("The specified locally mapped SYRMEP HPC output path can not be root (e.g. it can not be \"C:\\\")!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Raise closing event:
                    this.Close();
                }*/
            }


            // Check if path exists:
            if (!Directory.Exists(this.txbWorkingPath.Text))
            {
                MessageBox.Show("The specified working path does not exist!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else if (!Directory.Exists(this.txbTemporaryPath.Text))
            {
                MessageBox.Show("The specified temporary path does not exist!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }


            // Check if path is not root:
            else if (zDirInfoWorkingPath.Parent == null)
            {
                MessageBox.Show("The specified working path can not be root (e.g. it can not be \"C:\\\")!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (zDirInfoTempPath.Parent == null)
            {
                MessageBox.Show("The specified temporary path can not be root (e.g. it can not be \"C:\\\")!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // Check for write permissions:
            else if (!(Program.CheckDirectoryAccess(txbWorkingPath.Text)))
            {
                MessageBox.Show("You do not have write permissions to the specified working path!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!(Program.CheckDirectoryAccess(txbTemporaryPath.Text)))
            {
                MessageBox.Show("You do not have write permissions to the specified temporary path!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*else if ( (Properties.Settings.Default.FormSettings_OpenOnce == false) && (!(Program.IsDirectoryEmpty(txbTemporaryPath.Text))))
            {
                MessageBox.Show("The specified temporary path should be an empty folder!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }*/


            // Check if path exists:
            else if (!Directory.Exists(txbOutputPath.Text))
            {
                MessageBox.Show("The specified output path does not exist!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check for write permissions:
            else if (!(Program.CheckDirectoryAccess(txbOutputPath.Text)))
            {
                MessageBox.Show("You do not have write permissions to the specified output path!", Properties.Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else            
            {

                // Raise closing event:
                this.Close();
            }            
        }



        /// <summary>
        /// Things performed before opening the form (i.e. reading settings).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_Load(object sender, EventArgs e)
        {  

            this.txbWorkingPath.Text = Properties.Settings.Default.FormSettings_WorkingPath;
            this.txbTemporaryPath.Text = Properties.Settings.Default.FormSettings_TemporaryPath;
            this.txbOutputPath.Text = Properties.Settings.Default.FormSettings_OutputPath;

            this.txbReconstructedPrefix.Text = Properties.Settings.Default.FormSettings_OutputPrefix;
            this.txbProjectionPrefix.Text = Properties.Settings.Default.FormSettings_ProjectionPrefix;
            this.txbSinoPrefix.Text = Properties.Settings.Default.FormSettings_SinoPrefix;

            this.nudSettings_Processes.Value = Properties.Settings.Default.FormSettings_NrOfProcesses;
            this.nudSettings_ChunkSize.Value = Properties.Settings.Default.FormSettings_ChunkSize;

            this.txbSYRMEP_HPC_Input.Text = Properties.Settings.Default.SYRMEP_HPC_InputPath;
            this.txbSYRMEP_HPC_Temp.Text = Properties.Settings.Default.SYRMEP_HPC_TempPath;
            this.txbSYRMEP_HPC_Output.Text = Properties.Settings.Default.SYRMEP_HPC_OutputPath;

            /*this.txbSYRMEP_HPC_Input_LocallyMapped.Text = Properties.Settings.Default.SYRMEP_HPC_MappedInputPath;
            this.txbSYRMEP_HPC_Temp_LocallyMapped.Text = Properties.Settings.Default.SYRMEP_HPC_MappedTempPath;
            this.txbSYRMEP_HPC_Output_LocallyMapped.Text = Properties.Settings.Default.SYRMEP_HPC_MappedOutputPath;*/

            // Only if SYRMEP Version:
            if (Properties.Settings.Default.SYRMEP_Version == false)
            {
                this.tabControl1.TabPages.Remove(this.tabSYRMEP_HPC);
            }           

        }


        private string RemoveBackslashWinPath(string path)
        {
            // They're always one character but EndsWith is shorter than
            // array style access to last path character. Change this
            // if performance are a (measured) issue.
            string separator1 = Path.DirectorySeparatorChar.ToString();
            string separator2 = Path.AltDirectorySeparatorChar.ToString();

            // Trailing white spaces are always ignored but folders may have
            // leading spaces. It's unusual but it may happen. If it's an issue
            // then just replace TrimEnd() with Trim(). Tnx Paul Groke to point this out.
            path = path.TrimEnd();

            // Argument is always a directory name then if there is one
            // of allowed separators then I have nothing to do.
            if (path.EndsWith(separator1) || path.EndsWith(separator2))
                path = path.Remove(path.Length - 1);
            
            return path;

        }

        private string RemoveBackslashUnixPath(string path)
        {
            // They're always one character but EndsWith is shorter than
            // array style access to last path character. Change this
            // if performance are a (measured) issue.
            string separator = "/";

            // Trailing white spaces are always ignored but folders may have
            // leading spaces. It's unusual but it may happen. If it's an issue
            // then just replace TrimEnd() with Trim(). Tnx Paul Groke to point this out.
            path = path.TrimEnd();

            // Argument is always a directory name then if there is one
            // of allowed separators then I have nothing to do.
            if (path.EndsWith(separator))
                path = path.Remove(path.Length - 1);
           
            return path;

        }


        /// <summary>
        /// Things performed before closing the form (i.e. serializing settings).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!e.Cancel)
            {
                // Validate path by removing trailing slash:


                Properties.Settings.Default["FormSettings_WorkingPath"] = RemoveBackslashWinPath(this.txbWorkingPath.Text);
                Properties.Settings.Default["FormSettings_TemporaryPath"] = RemoveBackslashWinPath(this.txbTemporaryPath.Text);
                Properties.Settings.Default["FormSettings_OutputPath"] = RemoveBackslashWinPath(this.txbOutputPath.Text);

                Properties.Settings.Default["FormSettings_OutputPrefix"] = this.txbReconstructedPrefix.Text;
                Properties.Settings.Default["FormSettings_ProjectionPrefix"] = this.txbProjectionPrefix.Text;
                Properties.Settings.Default["FormSettings_SinoPrefix"] = this.txbSinoPrefix.Text;

                Properties.Settings.Default["FormSettings_NrOfProcesses"] = this.nudSettings_Processes.Value;
                Properties.Settings.Default["FormSettings_ChunkSize"] = this.nudSettings_ChunkSize.Value;
                //Properties.Settings.Default["FormSettings_OpenOnce"] = true;

                Properties.Settings.Default["SYRMEP_HPC_InputPath"] = RemoveBackslashUnixPath(this.txbSYRMEP_HPC_Input.Text);
                Properties.Settings.Default["SYRMEP_HPC_TempPath"] = RemoveBackslashUnixPath(this.txbSYRMEP_HPC_Temp.Text);
                Properties.Settings.Default["SYRMEP_HPC_OutputPath"] = RemoveBackslashUnixPath(this.txbSYRMEP_HPC_Output.Text);

                /*Properties.Settings.Default["SYRMEP_HPC_MappedInputPath"] = RemoveBackslashWinPath(this.txbSYRMEP_HPC_Input_LocallyMapped.Text);
                Properties.Settings.Default["SYRMEP_HPC_MappedTempPath"] = RemoveBackslashWinPath(this.txbSYRMEP_HPC_Temp_LocallyMapped.Text);
                Properties.Settings.Default["SYRMEP_HPC_MappedOutputPath"] = RemoveBackslashWinPath(this.txbSYRMEP_HPC_Output_LocallyMapped.Text);*/

                Properties.Settings.Default.Save();

                try
                {
                    // Create temporary folder:
                    if (!Directory.Exists(this.txbTemporaryPath.Text + Path.DirectorySeparatorChar +
                        Properties.Settings.Default.SessionID))
                    {
                        Directory.CreateDirectory(this.txbTemporaryPath.Text + Path.DirectorySeparatorChar +
                        Properties.Settings.Default.SessionID);
                    }
                }
                catch
                {
                }
            }
        } 
    }
}
