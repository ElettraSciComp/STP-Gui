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

namespace SYRMEPTomoProject
{
    partial class FullReconstruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullReconstruction));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxInput = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.zLogTxb = new System.Windows.Forms.TextBox();
            this.zOutputPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.zInputEDFsBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mJobMonitorBgw = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.zTiming_ToolStripLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mStatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblPreProcessing = new System.Windows.Forms.Label();
            this.lblPhaseRetrieval = new System.Windows.Forms.Label();
            this.lblReconstruction = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxInput);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(16, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 62);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // cbxInput
            // 
            this.cbxInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInput.FormattingEnabled = true;
            this.cbxInput.Location = new System.Drawing.Point(85, 21);
            this.cbxInput.Name = "cbxInput";
            this.cbxInput.Size = new System.Drawing.Size(303, 21);
            this.cbxInput.TabIndex = 27;
            this.cbxInput.DropDownClosed += new System.EventHandler(this.cbxInput_DropDownClosed);
            this.cbxInput.Click += new System.EventHandler(this.cbxInput_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Input (TDF):";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(347, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(269, 415);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(74, 23);
            this.btnRun.TabIndex = 25;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.zLogTxb);
            this.groupBox6.Location = new System.Drawing.Point(16, 221);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(404, 186);
            this.groupBox6.TabIndex = 39;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Log";
            // 
            // zLogTxb
            // 
            this.zLogTxb.BackColor = System.Drawing.Color.White;
            this.zLogTxb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zLogTxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLogTxb.Location = new System.Drawing.Point(3, 16);
            this.zLogTxb.Multiline = true;
            this.zLogTxb.Name = "zLogTxb";
            this.zLogTxb.ReadOnly = true;
            this.zLogTxb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.zLogTxb.Size = new System.Drawing.Size(398, 167);
            this.zLogTxb.TabIndex = 1;
            // 
            // zOutputPathBrowserDialog
            // 
            this.zOutputPathBrowserDialog.Description = "Select output folder:";
            // 
            // zInputEDFsBrowserDialog
            // 
            this.zInputEDFsBrowserDialog.Description = "Browse for TIFF files:";
            this.zInputEDFsBrowserDialog.ShowNewFolderButton = false;
            // 
            // mJobMonitorBgw
            // 
            this.mJobMonitorBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.mJobMonitorBgw_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zTiming_ToolStripLbl,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.mStatusBarProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(436, 22);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // zTiming_ToolStripLbl
            // 
            this.zTiming_ToolStripLbl.Name = "zTiming_ToolStripLbl";
            this.zTiming_ToolStripLbl.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(319, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            // 
            // mStatusBarProgressBar
            // 
            this.mStatusBarProgressBar.Name = "mStatusBarProgressBar";
            this.mStatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // lblPreProcessing
            // 
            this.lblPreProcessing.AutoSize = true;
            this.lblPreProcessing.Location = new System.Drawing.Point(15, 29);
            this.lblPreProcessing.Name = "lblPreProcessing";
            this.lblPreProcessing.Size = new System.Drawing.Size(261, 13);
            this.lblPreProcessing.TabIndex = 44;
            this.lblPreProcessing.Text = "1. Pre-processing (settings as in \"Pre-Processing\" tab)";
            // 
            // lblPhaseRetrieval
            // 
            this.lblPhaseRetrieval.AutoSize = true;
            this.lblPhaseRetrieval.Location = new System.Drawing.Point(15, 59);
            this.lblPhaseRetrieval.Name = "lblPhaseRetrieval";
            this.lblPhaseRetrieval.Size = new System.Drawing.Size(265, 13);
            this.lblPhaseRetrieval.TabIndex = 45;
            this.lblPhaseRetrieval.Text = "2. Phase retrieval (settings as in \"Phase Retrieval\" tab)";
            // 
            // lblReconstruction
            // 
            this.lblReconstruction.AutoSize = true;
            this.lblReconstruction.Location = new System.Drawing.Point(14, 89);
            this.lblReconstruction.Name = "lblReconstruction";
            this.lblReconstruction.Size = new System.Drawing.Size(264, 13);
            this.lblReconstruction.TabIndex = 46;
            this.lblReconstruction.Text = "3. Reconstruction (settings as in \"Reconstruction\" tab)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPreProcessing);
            this.groupBox1.Controls.Add(this.lblPhaseRetrieval);
            this.groupBox1.Controls.Add(this.lblReconstruction);
            this.groupBox1.Location = new System.Drawing.Point(16, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 123);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reconstruction pipeline";
            // 
            // FullReconstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FullReconstruction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Complete Reconstruction";
            this.Load += new System.EventHandler(this.FullReconstruction_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox zLogTxb;
        private System.Windows.Forms.FolderBrowserDialog zOutputPathBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog zInputEDFsBrowserDialog;
        private System.ComponentModel.BackgroundWorker mJobMonitorBgw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel zTiming_ToolStripLbl;
        private System.Windows.Forms.ToolTip mToolTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar mStatusBarProgressBar;
        private System.Windows.Forms.Label lblPreProcessing;
        private System.Windows.Forms.Label lblPhaseRetrieval;
        private System.Windows.Forms.Label lblReconstruction;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxInput;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRemoteSubmit;
    }
}