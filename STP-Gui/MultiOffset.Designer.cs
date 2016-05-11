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
    partial class MultiOffset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiOffset));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblInputTDF = new System.Windows.Forms.Label();
            this.btnOutputTIFFs = new System.Windows.Forms.Button();
            this.zOutputPathTxb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReconstruct = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.zLogTxb = new System.Windows.Forms.TextBox();
            this.zOutputTIFFsBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mJobMonitorBgw = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.zTiming_ToolStripLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mStatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.nudMultiOffset_From = new System.Windows.Forms.NumericUpDown();
            this.nudMultiOffset_To = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblNrProjections = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.lblPostProcessing = new System.Windows.Forms.Label();
            this.lblPhaseRetrieval = new System.Windows.Forms.Label();
            this.lblPreProcessing = new System.Windows.Forms.Label();
            this.lblAngles = new System.Windows.Forms.Label();
            this.lblDownscalingFactor = new System.Windows.Forms.Label();
            this.lblDecimationFactor = new System.Windows.Forms.Label();
            this.lblSliceNr = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiOffset_From)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiOffset_To)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblInputTDF);
            this.groupBox3.Controls.Add(this.btnOutputTIFFs);
            this.groupBox3.Controls.Add(this.zOutputPathTxb);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(16, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 85);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input/Output";
            // 
            // lblInputTDF
            // 
            this.lblInputTDF.AutoSize = true;
            this.lblInputTDF.Location = new System.Drawing.Point(81, 27);
            this.lblInputTDF.Name = "lblInputTDF";
            this.lblInputTDF.Size = new System.Drawing.Size(10, 13);
            this.lblInputTDF.TabIndex = 25;
            this.lblInputTDF.Text = "-";
            // 
            // btnOutputTIFFs
            // 
            this.btnOutputTIFFs.Location = new System.Drawing.Point(311, 49);
            this.btnOutputTIFFs.Name = "btnOutputTIFFs";
            this.btnOutputTIFFs.Size = new System.Drawing.Size(74, 23);
            this.btnOutputTIFFs.TabIndex = 3;
            this.btnOutputTIFFs.Text = "Browse...";
            this.btnOutputTIFFs.UseVisualStyleBackColor = true;
            this.btnOutputTIFFs.Click += new System.EventHandler(this.btnOutputTIFFs_Click);
            // 
            // zOutputPathTxb
            // 
            this.zOutputPathTxb.Location = new System.Drawing.Point(82, 50);
            this.zOutputPathTxb.Name = "zOutputPathTxb";
            this.zOutputPathTxb.Size = new System.Drawing.Size(223, 20);
            this.zOutputPathTxb.TabIndex = 2;
            this.zOutputPathTxb.TextChanged += new System.EventHandler(this.zOutputPathTxb_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Output (TIFFs):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Input (TDF):";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 424);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReconstruct
            // 
            this.btnReconstruct.Enabled = false;
            this.btnReconstruct.Location = new System.Drawing.Point(270, 424);
            this.btnReconstruct.Name = "btnReconstruct";
            this.btnReconstruct.Size = new System.Drawing.Size(74, 23);
            this.btnReconstruct.TabIndex = 25;
            this.btnReconstruct.Text = "Reconstruct";
            this.btnReconstruct.UseVisualStyleBackColor = true;
            this.btnReconstruct.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.zLogTxb);
            this.groupBox6.Location = new System.Drawing.Point(17, 302);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(404, 113);
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
            this.zLogTxb.Size = new System.Drawing.Size(398, 94);
            this.zLogTxb.TabIndex = 1;
            // 
            // zOutputTIFFsBrowserDialog
            // 
            this.zOutputTIFFsBrowserDialog.Description = "Browse for output folder:";
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
            this.mStatusBarProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(437, 22);
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(289, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = " ";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mStatusBarProgressBar
            // 
            this.mStatusBarProgressBar.Name = "mStatusBarProgressBar";
            this.mStatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // nudMultiOffset_From
            // 
            this.nudMultiOffset_From.Enabled = false;
            this.nudMultiOffset_From.Location = new System.Drawing.Point(252, 19);
            this.nudMultiOffset_From.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMultiOffset_From.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudMultiOffset_From.Name = "nudMultiOffset_From";
            this.nudMultiOffset_From.Size = new System.Drawing.Size(50, 20);
            this.nudMultiOffset_From.TabIndex = 17;
            this.nudMultiOffset_From.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMultiOffset_From.Value = new decimal(new int[] {
            40,
            0,
            0,
            -2147483648});
            // 
            // nudMultiOffset_To
            // 
            this.nudMultiOffset_To.Enabled = false;
            this.nudMultiOffset_To.Location = new System.Drawing.Point(333, 19);
            this.nudMultiOffset_To.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudMultiOffset_To.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudMultiOffset_To.Name = "nudMultiOffset_To";
            this.nudMultiOffset_To.Size = new System.Drawing.Size(50, 20);
            this.nudMultiOffset_To.TabIndex = 16;
            this.nudMultiOffset_To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMultiOffset_To.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.nudMultiOffset_To);
            this.groupBox5.Controls.Add(this.nudMultiOffset_From);
            this.groupBox5.Location = new System.Drawing.Point(17, 245);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(405, 51);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Reconstruct with offset for center of rotation from";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblNrProjections);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.lblAlgorithm);
            this.groupBox7.Controls.Add(this.lblPostProcessing);
            this.groupBox7.Controls.Add(this.lblPhaseRetrieval);
            this.groupBox7.Controls.Add(this.lblPreProcessing);
            this.groupBox7.Controls.Add(this.lblAngles);
            this.groupBox7.Controls.Add(this.lblDownscalingFactor);
            this.groupBox7.Controls.Add(this.lblDecimationFactor);
            this.groupBox7.Controls.Add(this.lblSliceNr);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Location = new System.Drawing.Point(16, 111);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(405, 130);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Significant settings (from Reconstruction tab)";
            // 
            // lblNrProjections
            // 
            this.lblNrProjections.AutoSize = true;
            this.lblNrProjections.Location = new System.Drawing.Point(311, 85);
            this.lblNrProjections.Name = "lblNrProjections";
            this.lblNrProjections.Size = new System.Drawing.Size(10, 13);
            this.lblNrProjections.TabIndex = 39;
            this.lblNrProjections.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(219, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Nr. of projections:";
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(84, 105);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(10, 13);
            this.lblAlgorithm.TabIndex = 37;
            this.lblAlgorithm.Text = "-";
            // 
            // lblPostProcessing
            // 
            this.lblPostProcessing.AutoSize = true;
            this.lblPostProcessing.Location = new System.Drawing.Point(310, 65);
            this.lblPostProcessing.Name = "lblPostProcessing";
            this.lblPostProcessing.Size = new System.Drawing.Size(10, 13);
            this.lblPostProcessing.TabIndex = 36;
            this.lblPostProcessing.Text = "-";
            // 
            // lblPhaseRetrieval
            // 
            this.lblPhaseRetrieval.AutoSize = true;
            this.lblPhaseRetrieval.Location = new System.Drawing.Point(310, 45);
            this.lblPhaseRetrieval.Name = "lblPhaseRetrieval";
            this.lblPhaseRetrieval.Size = new System.Drawing.Size(10, 13);
            this.lblPhaseRetrieval.TabIndex = 35;
            this.lblPhaseRetrieval.Text = "-";
            // 
            // lblPreProcessing
            // 
            this.lblPreProcessing.AutoSize = true;
            this.lblPreProcessing.Location = new System.Drawing.Point(310, 25);
            this.lblPreProcessing.Name = "lblPreProcessing";
            this.lblPreProcessing.Size = new System.Drawing.Size(10, 13);
            this.lblPreProcessing.TabIndex = 34;
            this.lblPreProcessing.Text = "-";
            // 
            // lblAngles
            // 
            this.lblAngles.AutoSize = true;
            this.lblAngles.Location = new System.Drawing.Point(84, 85);
            this.lblAngles.Name = "lblAngles";
            this.lblAngles.Size = new System.Drawing.Size(10, 13);
            this.lblAngles.TabIndex = 33;
            this.lblAngles.Text = "-";
            // 
            // lblDownscalingFactor
            // 
            this.lblDownscalingFactor.AutoSize = true;
            this.lblDownscalingFactor.Location = new System.Drawing.Point(84, 65);
            this.lblDownscalingFactor.Name = "lblDownscalingFactor";
            this.lblDownscalingFactor.Size = new System.Drawing.Size(10, 13);
            this.lblDownscalingFactor.TabIndex = 32;
            this.lblDownscalingFactor.Text = "-";
            // 
            // lblDecimationFactor
            // 
            this.lblDecimationFactor.AutoSize = true;
            this.lblDecimationFactor.Location = new System.Drawing.Point(84, 45);
            this.lblDecimationFactor.Name = "lblDecimationFactor";
            this.lblDecimationFactor.Size = new System.Drawing.Size(10, 13);
            this.lblDecimationFactor.TabIndex = 31;
            this.lblDecimationFactor.Text = "-";
            // 
            // lblSliceNr
            // 
            this.lblSliceNr.AutoSize = true;
            this.lblSliceNr.Location = new System.Drawing.Point(84, 25);
            this.lblSliceNr.Name = "lblSliceNr";
            this.lblSliceNr.Size = new System.Drawing.Size(10, 13);
            this.lblSliceNr.TabIndex = 30;
            this.lblSliceNr.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Algorithm:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Angles:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Post-processing (on-the-fly):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Phase-retrieval (on-the-fly):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Pre-processing (on-the-fly):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Downscaling:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Decimation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Slice nr:";
            // 
            // MultiOffset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 477);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReconstruct);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MultiOffset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test reconstruction with offset range";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiOffset_FormClosing);
            this.Load += new System.EventHandler(this.MultiOffset_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiOffset_From)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiOffset_To)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOutputTIFFs;
        private System.Windows.Forms.TextBox zOutputPathTxb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReconstruct;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox zLogTxb;
        private System.Windows.Forms.FolderBrowserDialog zOutputTIFFsBrowserDialog;
        private System.ComponentModel.BackgroundWorker mJobMonitorBgw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel zTiming_ToolStripLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar mStatusBarProgressBar;
        private System.Windows.Forms.Label lblInputTDF;
        private System.Windows.Forms.NumericUpDown nudMultiOffset_From;
        private System.Windows.Forms.NumericUpDown nudMultiOffset_To;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Label lblPostProcessing;
        private System.Windows.Forms.Label lblPhaseRetrieval;
        private System.Windows.Forms.Label lblPreProcessing;
        private System.Windows.Forms.Label lblAngles;
        private System.Windows.Forms.Label lblDownscalingFactor;
        private System.Windows.Forms.Label lblDecimationFactor;
        private System.Windows.Forms.Label lblSliceNr;
        private System.Windows.Forms.Label lblNrProjections;
        private System.Windows.Forms.Label label14;
    }
}