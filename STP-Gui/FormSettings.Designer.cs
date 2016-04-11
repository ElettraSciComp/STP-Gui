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


namespace SYRMEPTomoProject
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSettings_Processes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txbProjectionPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbReconstructedPrefix = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txbSinoPrefix = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOutputPath = new System.Windows.Forms.Button();
            this.txbOutputPath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnTemporaryPath = new System.Windows.Forms.Button();
            this.txbTemporaryPath = new System.Windows.Forms.TextBox();
            this.btnWorkingPath = new System.Windows.Forms.Button();
            this.txbWorkingPath = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.mButtonOk = new System.Windows.Forms.Button();
            this.mButtonCancel = new System.Windows.Forms.Button();
            this.zWorkingPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.zTestPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.zOutputPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nudSettings_ChunkSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_Processes)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_ChunkSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 270);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(435, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dataset";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudSettings_ChunkSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudSettings_Processes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(223, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 103);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Performances";
            // 
            // nudSettings_Processes
            // 
            this.nudSettings_Processes.Location = new System.Drawing.Point(73, 22);
            this.nudSettings_Processes.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudSettings_Processes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSettings_Processes.Name = "nudSettings_Processes";
            this.nudSettings_Processes.Size = new System.Drawing.Size(38, 20);
            this.nudSettings_Processes.TabIndex = 12;
            this.nudSettings_Processes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSettings_Processes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Processes:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txbProjectionPrefix);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txbReconstructedPrefix);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txbSinoPrefix);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Location = new System.Drawing.Point(15, 123);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(197, 103);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Output prefixes";
            // 
            // txbProjectionPrefix
            // 
            this.txbProjectionPrefix.Location = new System.Drawing.Point(89, 18);
            this.txbProjectionPrefix.Name = "txbProjectionPrefix";
            this.txbProjectionPrefix.Size = new System.Drawing.Size(94, 20);
            this.txbProjectionPrefix.TabIndex = 12;
            this.txbProjectionPrefix.Text = "tomo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Projection:";
            // 
            // txbReconstructedPrefix
            // 
            this.txbReconstructedPrefix.Location = new System.Drawing.Point(89, 71);
            this.txbReconstructedPrefix.Name = "txbReconstructedPrefix";
            this.txbReconstructedPrefix.Size = new System.Drawing.Size(94, 20);
            this.txbReconstructedPrefix.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Reconstructed:";
            // 
            // txbSinoPrefix
            // 
            this.txbSinoPrefix.Location = new System.Drawing.Point(89, 45);
            this.txbSinoPrefix.Name = "txbSinoPrefix";
            this.txbSinoPrefix.Size = new System.Drawing.Size(94, 20);
            this.txbSinoPrefix.TabIndex = 9;
            this.txbSinoPrefix.Text = "sino";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(33, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Sinogram:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOutputPath);
            this.groupBox4.Controls.Add(this.txbOutputPath);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnTemporaryPath);
            this.groupBox4.Controls.Add(this.txbTemporaryPath);
            this.groupBox4.Controls.Add(this.btnWorkingPath);
            this.groupBox4.Controls.Add(this.txbWorkingPath);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(15, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 106);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Paths";
            // 
            // btnOutputPath
            // 
            this.btnOutputPath.Location = new System.Drawing.Point(316, 74);
            this.btnOutputPath.Name = "btnOutputPath";
            this.btnOutputPath.Size = new System.Drawing.Size(74, 23);
            this.btnOutputPath.TabIndex = 26;
            this.btnOutputPath.Text = "Browse...";
            this.btnOutputPath.UseVisualStyleBackColor = true;
            this.btnOutputPath.Click += new System.EventHandler(this.btnOutputPath_Click);
            // 
            // txbOutputPath
            // 
            this.txbOutputPath.Location = new System.Drawing.Point(89, 75);
            this.txbOutputPath.Name = "txbOutputPath";
            this.txbOutputPath.Size = new System.Drawing.Size(221, 20);
            this.txbOutputPath.TabIndex = 25;
            this.mToolTip.SetToolTip(this.txbOutputPath, "Reconstructed images will be written here. Usually this refers to user\'s external" +
                    " hard drive (USB3 or eSATA suggested).");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Output path:";
            this.mToolTip.SetToolTip(this.label13, "Reconstructed images will be written here. Usually this refers to user\'s external" +
                    " hard drive (USB3 or eSATA suggested).");
            // 
            // btnTemporaryPath
            // 
            this.btnTemporaryPath.Location = new System.Drawing.Point(315, 46);
            this.btnTemporaryPath.Name = "btnTemporaryPath";
            this.btnTemporaryPath.Size = new System.Drawing.Size(75, 23);
            this.btnTemporaryPath.TabIndex = 5;
            this.btnTemporaryPath.Text = "Browse...";
            this.btnTemporaryPath.UseVisualStyleBackColor = true;
            this.btnTemporaryPath.Click += new System.EventHandler(this.btnTempPath_Click);
            // 
            // txbTemporaryPath
            // 
            this.txbTemporaryPath.Location = new System.Drawing.Point(89, 48);
            this.txbTemporaryPath.Name = "txbTemporaryPath";
            this.txbTemporaryPath.Size = new System.Drawing.Size(220, 20);
            this.txbTemporaryPath.TabIndex = 4;
            this.mToolTip.SetToolTip(this.txbTemporaryPath, "Log files will be written here. Fast (and small) RAMDrive or SSD suggested.");
            // 
            // btnWorkingPath
            // 
            this.btnWorkingPath.Location = new System.Drawing.Point(315, 19);
            this.btnWorkingPath.Name = "btnWorkingPath";
            this.btnWorkingPath.Size = new System.Drawing.Size(75, 23);
            this.btnWorkingPath.TabIndex = 3;
            this.btnWorkingPath.Text = "Browse...";
            this.btnWorkingPath.UseVisualStyleBackColor = true;
            this.btnWorkingPath.Click += new System.EventHandler(this.btnWorkingPath_Click);
            // 
            // txbWorkingPath
            // 
            this.txbWorkingPath.Location = new System.Drawing.Point(89, 21);
            this.txbWorkingPath.Name = "txbWorkingPath";
            this.txbWorkingPath.Size = new System.Drawing.Size(220, 20);
            this.txbWorkingPath.TabIndex = 2;
            this.mToolTip.SetToolTip(this.txbWorkingPath, "Input and temporary TDFs go here. Fast SSD suggested.");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Temporary path:";
            this.mToolTip.SetToolTip(this.label16, "Log files will be written here. Fast (and small) RAMDrive or SSD suggested.");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Working path:";
            this.mToolTip.SetToolTip(this.label15, "Input and temporary TDFs go here. Fast SSD suggested.");
            // 
            // mButtonOk
            // 
            this.mButtonOk.Location = new System.Drawing.Point(296, 288);
            this.mButtonOk.Name = "mButtonOk";
            this.mButtonOk.Size = new System.Drawing.Size(75, 23);
            this.mButtonOk.TabIndex = 12;
            this.mButtonOk.Text = "OK";
            this.mButtonOk.UseVisualStyleBackColor = true;
            this.mButtonOk.Click += new System.EventHandler(this.mButtonOk_Click);
            // 
            // mButtonCancel
            // 
            this.mButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mButtonCancel.Location = new System.Drawing.Point(377, 288);
            this.mButtonCancel.Name = "mButtonCancel";
            this.mButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.mButtonCancel.TabIndex = 13;
            this.mButtonCancel.Text = "Cancel";
            this.mButtonCancel.UseVisualStyleBackColor = true;
            // 
            // zWorkingPathBrowserDialog
            // 
            this.zWorkingPathBrowserDialog.Description = "Select working folder:";
            // 
            // zTestPathBrowserDialog
            // 
            this.zTestPathBrowserDialog.Description = "Select temporary folder:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Restore to Default";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // zOutputPathBrowserDialog
            // 
            this.zOutputPathBrowserDialog.Description = "Select output folder:";
            // 
            // nudSettings_ChunkSize
            // 
            this.nudSettings_ChunkSize.Location = new System.Drawing.Point(73, 48);
            this.nudSettings_ChunkSize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.nudSettings_ChunkSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudSettings_ChunkSize.Name = "nudSettings_ChunkSize";
            this.nudSettings_ChunkSize.Size = new System.Drawing.Size(38, 20);
            this.nudSettings_ChunkSize.TabIndex = 14;
            this.nudSettings_ChunkSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSettings_ChunkSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Chunk size:";
            // 
            // FormSettings
            // 
            this.AcceptButton = this.mButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mButtonCancel;
            this.ClientSize = new System.Drawing.Size(464, 323);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mButtonOk);
            this.Controls.Add(this.mButtonCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_Processes)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_ChunkSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTemporaryPath;
        private System.Windows.Forms.TextBox txbTemporaryPath;
        private System.Windows.Forms.Button btnWorkingPath;
        private System.Windows.Forms.TextBox txbWorkingPath;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button mButtonOk;
        private System.Windows.Forms.Button mButtonCancel;
        private System.Windows.Forms.FolderBrowserDialog zWorkingPathBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog zTestPathBrowserDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOutputPath;
        private System.Windows.Forms.TextBox txbOutputPath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FolderBrowserDialog zOutputPathBrowserDialog;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txbReconstructedPrefix;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ToolTip mToolTip;
        private System.Windows.Forms.TextBox txbSinoPrefix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudSettings_Processes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbProjectionPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSettings_ChunkSize;
        private System.Windows.Forms.Label label3;

    }
}