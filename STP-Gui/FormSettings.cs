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

            //
            // Validate fields:
            //

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
                // Check if paths end with path separator:
                if (this.txbOutputPath.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))                
                    this.txbOutputPath.Text = this.txbOutputPath.Text.Remove(this.txbOutputPath.Text.Length - 1);
                if (this.txbWorkingPath.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    this.txbWorkingPath.Text = this.txbWorkingPath.Text.Remove(this.txbWorkingPath.Text.Length - 1);
                if (this.txbTemporaryPath.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    this.txbTemporaryPath.Text = this.txbTemporaryPath.Text.Remove(this.txbTemporaryPath.Text.Length - 1);

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
                Properties.Settings.Default["FormSettings_WorkingPath"] = this.txbWorkingPath.Text;
                Properties.Settings.Default["FormSettings_TemporaryPath"] = this.txbTemporaryPath.Text;
                Properties.Settings.Default["FormSettings_OutputPath"] = this.txbOutputPath.Text;

                Properties.Settings.Default["FormSettings_OutputPrefix"] = this.txbReconstructedPrefix.Text;
                Properties.Settings.Default["FormSettings_ProjectionPrefix"] = this.txbProjectionPrefix.Text;
                Properties.Settings.Default["FormSettings_SinoPrefix"] = this.txbSinoPrefix.Text;

                Properties.Settings.Default["FormSettings_NrOfProcesses"] = this.nudSettings_Processes.Value;
                Properties.Settings.Default["FormSettings_ChunkSize"] = this.nudSettings_ChunkSize.Value;
                //Properties.Settings.Default["FormSettings_OpenOnce"] = true;

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
