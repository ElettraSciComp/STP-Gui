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
    partial class TDFToTIFF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TDFToTIFF));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.cbxInput = new System.Windows.Forms.ComboBox();
            this.btnOutputTIFFs = new System.Windows.Forms.Button();
            this.zOutputPathTxb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxFlatPrefix = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxDarkPrefix = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxProjectionPrefix = new System.Windows.Forms.TextBox();
            this.lblProjections = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDataDark = new System.Windows.Forms.CheckBox();
            this.chkDataWhite = new System.Windows.Forms.CheckBox();
            this.chkData = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtSinogramOrder = new VIBlend.WinForms.Controls.vRadioButton();
            this.rbtDirectOrder = new VIBlend.WinForms.Controls.vRadioButton();
            this.nudTDFToTIFFFrom = new System.Windows.Forms.NumericUpDown();
            this.nudTDFToTIFFTo = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.chkConsiderSubset = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.zLogTxb = new System.Windows.Forms.TextBox();
            this.zOutputTIFFsBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mJobMonitorBgw = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.zTiming_ToolStripLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mStatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnRawFormat = new VIBlend.WinForms.Controls.vRadioButton();
            this.btnTIFFFormat = new VIBlend.WinForms.Controls.vRadioButton();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTDFToTIFFFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTDFToTIFFTo)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInfo);
            this.groupBox3.Controls.Add(this.cbxInput);
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
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(311, 22);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(74, 23);
            this.btnInfo.TabIndex = 26;
            this.btnInfo.Text = "Info...";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Visible = false;
            // 
            // cbxInput
            // 
            this.cbxInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInput.FormattingEnabled = true;
            this.cbxInput.Location = new System.Drawing.Point(82, 23);
            this.cbxInput.Name = "cbxInput";
            this.cbxInput.Size = new System.Drawing.Size(223, 21);
            this.cbxInput.TabIndex = 25;
            this.cbxInput.DropDownClosed += new System.EventHandler(this.cbxInput_DropDownClosed);
            this.cbxInput.Click += new System.EventHandler(this.cbxInput_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxFlatPrefix);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.tbxDarkPrefix);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbxProjectionPrefix);
            this.groupBox1.Controls.Add(this.lblProjections);
            this.groupBox1.Location = new System.Drawing.Point(17, 203);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 109);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIFF files prefixes";
            // 
            // tbxFlatPrefix
            // 
            this.tbxFlatPrefix.Location = new System.Drawing.Point(83, 74);
            this.tbxFlatPrefix.Name = "tbxFlatPrefix";
            this.tbxFlatPrefix.Size = new System.Drawing.Size(105, 20);
            this.tbxFlatPrefix.TabIndex = 26;
            this.tbxFlatPrefix.Text = "flat";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 23;
            this.label19.Text = "Flat images:";
            // 
            // tbxDarkPrefix
            // 
            this.tbxDarkPrefix.Location = new System.Drawing.Point(83, 49);
            this.tbxDarkPrefix.Name = "tbxDarkPrefix";
            this.tbxDarkPrefix.Size = new System.Drawing.Size(105, 20);
            this.tbxDarkPrefix.TabIndex = 25;
            this.tbxDarkPrefix.Text = "dark";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Dark images:";
            // 
            // tbxProjectionPrefix
            // 
            this.tbxProjectionPrefix.Location = new System.Drawing.Point(83, 23);
            this.tbxProjectionPrefix.Name = "tbxProjectionPrefix";
            this.tbxProjectionPrefix.Size = new System.Drawing.Size(105, 20);
            this.tbxProjectionPrefix.TabIndex = 24;
            this.tbxProjectionPrefix.Text = "tomo";
            // 
            // lblProjections
            // 
            this.lblProjections.AutoSize = true;
            this.lblProjections.Location = new System.Drawing.Point(19, 26);
            this.lblProjections.Name = "lblProjections";
            this.lblProjections.Size = new System.Drawing.Size(62, 13);
            this.lblProjections.TabIndex = 21;
            this.lblProjections.Text = "Projections:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(270, 441);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(74, 23);
            this.btnConvert.TabIndex = 25;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDataDark);
            this.groupBox2.Controls.Add(this.chkDataWhite);
            this.groupBox2.Controls.Add(this.chkData);
            this.groupBox2.Location = new System.Drawing.Point(17, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 86);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TDF datasets to export";
            // 
            // chkDataDark
            // 
            this.chkDataDark.AutoSize = true;
            this.chkDataDark.Checked = true;
            this.chkDataDark.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataDark.Location = new System.Drawing.Point(21, 63);
            this.chkDataDark.Name = "chkDataDark";
            this.chkDataDark.Size = new System.Drawing.Size(74, 17);
            this.chkDataDark.TabIndex = 2;
            this.chkDataDark.Text = "data_dark";
            this.chkDataDark.UseVisualStyleBackColor = true;
            // 
            // chkDataWhite
            // 
            this.chkDataWhite.AutoSize = true;
            this.chkDataWhite.Checked = true;
            this.chkDataWhite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataWhite.Location = new System.Drawing.Point(21, 41);
            this.chkDataWhite.Name = "chkDataWhite";
            this.chkDataWhite.Size = new System.Drawing.Size(78, 17);
            this.chkDataWhite.TabIndex = 1;
            this.chkDataWhite.Text = "data_white";
            this.chkDataWhite.UseVisualStyleBackColor = true;
            this.chkDataWhite.CheckedChanged += new System.EventHandler(this.chkFlatDark_CheckedChanged);
            // 
            // chkData
            // 
            this.chkData.AutoSize = true;
            this.chkData.Checked = true;
            this.chkData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkData.Location = new System.Drawing.Point(21, 19);
            this.chkData.Name = "chkData";
            this.chkData.Size = new System.Drawing.Size(47, 17);
            this.chkData.TabIndex = 0;
            this.chkData.Text = "data";
            this.chkData.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtSinogramOrder);
            this.groupBox4.Controls.Add(this.rbtDirectOrder);
            this.groupBox4.Location = new System.Drawing.Point(223, 160);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 64);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Export options";
            // 
            // rbtSinogramOrder
            // 
            this.rbtSinogramOrder.BackColor = System.Drawing.Color.Transparent;
            this.rbtSinogramOrder.Flat = true;
            this.rbtSinogramOrder.Image = null;
            this.rbtSinogramOrder.Location = new System.Drawing.Point(11, 36);
            this.rbtSinogramOrder.Name = "rbtSinogramOrder";
            this.rbtSinogramOrder.Size = new System.Drawing.Size(104, 24);
            this.rbtSinogramOrder.TabIndex = 2;
            this.rbtSinogramOrder.Text = "Sinogram-order";
            this.rbtSinogramOrder.UseVisualStyleBackColor = false;
            this.rbtSinogramOrder.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.rbtSinogramOrder.CheckedChanged += new System.EventHandler(this.rbtSinogramOrder_CheckedChanged);
            // 
            // rbtDirectOrder
            // 
            this.rbtDirectOrder.BackColor = System.Drawing.Color.Transparent;
            this.rbtDirectOrder.Checked = true;
            this.rbtDirectOrder.Flat = true;
            this.rbtDirectOrder.Image = null;
            this.rbtDirectOrder.Location = new System.Drawing.Point(11, 15);
            this.rbtDirectOrder.Name = "rbtDirectOrder";
            this.rbtDirectOrder.Size = new System.Drawing.Size(179, 24);
            this.rbtDirectOrder.TabIndex = 1;
            this.rbtDirectOrder.TabStop = true;
            this.rbtDirectOrder.Text = "Projection-order";
            this.rbtDirectOrder.UseVisualStyleBackColor = false;
            this.rbtDirectOrder.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.rbtDirectOrder.CheckedChanged += new System.EventHandler(this.rbtDirectOrder_CheckedChanged);
            // 
            // nudTDFToTIFFFrom
            // 
            this.nudTDFToTIFFFrom.Enabled = false;
            this.nudTDFToTIFFFrom.Location = new System.Drawing.Point(46, 45);
            this.nudTDFToTIFFFrom.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTDFToTIFFFrom.Name = "nudTDFToTIFFFrom";
            this.nudTDFToTIFFFrom.Size = new System.Drawing.Size(50, 20);
            this.nudTDFToTIFFFrom.TabIndex = 16;
            this.nudTDFToTIFFFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudTDFToTIFFTo
            // 
            this.nudTDFToTIFFTo.Enabled = false;
            this.nudTDFToTIFFTo.Location = new System.Drawing.Point(131, 45);
            this.nudTDFToTIFFTo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudTDFToTIFFTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTDFToTIFFTo.Name = "nudTDFToTIFFTo";
            this.nudTDFToTIFFTo.Size = new System.Drawing.Size(50, 20);
            this.nudTDFToTIFFTo.TabIndex = 17;
            this.nudTDFToTIFFTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTDFToTIFFTo.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label57);
            this.groupBox5.Controls.Add(this.nudTDFToTIFFFrom);
            this.groupBox5.Controls.Add(this.chkConsiderSubset);
            this.groupBox5.Controls.Add(this.nudTDFToTIFFTo);
            this.groupBox5.Location = new System.Drawing.Point(222, 232);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(199, 80);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Subset";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "From:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(106, 49);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(23, 13);
            this.label57.TabIndex = 21;
            this.label57.Text = "To:";
            // 
            // chkConsiderSubset
            // 
            this.chkConsiderSubset.AutoSize = true;
            this.chkConsiderSubset.Location = new System.Drawing.Point(16, 22);
            this.chkConsiderSubset.Name = "chkConsiderSubset";
            this.chkConsiderSubset.Size = new System.Drawing.Size(173, 17);
            this.chkConsiderSubset.TabIndex = 19;
            this.chkConsiderSubset.Text = "Process a subset of the images";
            this.chkConsiderSubset.UseVisualStyleBackColor = true;
            this.chkConsiderSubset.CheckedChanged += new System.EventHandler(this.chkConsiderSubset_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.zLogTxb);
            this.groupBox6.Location = new System.Drawing.Point(17, 318);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 472);
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(320, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = " ";
            // 
            // mStatusBarProgressBar
            // 
            this.mStatusBarProgressBar.Name = "mStatusBarProgressBar";
            this.mStatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnRawFormat);
            this.groupBox7.Controls.Add(this.btnTIFFFormat);
            this.groupBox7.Location = new System.Drawing.Point(222, 111);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(199, 43);
            this.groupBox7.TabIndex = 41;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Format";
            // 
            // btnRawFormat
            // 
            this.btnRawFormat.BackColor = System.Drawing.Color.Transparent;
            this.btnRawFormat.Flat = true;
            this.btnRawFormat.Image = null;
            this.btnRawFormat.Location = new System.Drawing.Point(68, 15);
            this.btnRawFormat.Name = "btnRawFormat";
            this.btnRawFormat.Size = new System.Drawing.Size(104, 24);
            this.btnRawFormat.TabIndex = 2;
            this.btnRawFormat.Text = "RAW";
            this.btnRawFormat.UseVisualStyleBackColor = false;
            this.btnRawFormat.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // btnTIFFFormat
            // 
            this.btnTIFFFormat.BackColor = System.Drawing.Color.Transparent;
            this.btnTIFFFormat.Checked = true;
            this.btnTIFFFormat.Flat = true;
            this.btnTIFFFormat.Image = null;
            this.btnTIFFFormat.Location = new System.Drawing.Point(11, 15);
            this.btnTIFFFormat.Name = "btnTIFFFormat";
            this.btnTIFFFormat.Size = new System.Drawing.Size(51, 24);
            this.btnTIFFFormat.TabIndex = 1;
            this.btnTIFFFormat.TabStop = true;
            this.btnTIFFFormat.Text = "TIFF";
            this.btnTIFFFormat.UseVisualStyleBackColor = false;
            this.btnTIFFFormat.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // TDFToTIFF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 494);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TDFToTIFF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert TDF to TIFFs/RAWs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TDFToTIFF_FormClosing);
            this.Load += new System.EventHandler(this.TDFToTIFF_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTDFToTIFFFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTDFToTIFFTo)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOutputTIFFs;
        private System.Windows.Forms.TextBox zOutputPathTxb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxFlatPrefix;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbxDarkPrefix;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxProjectionPrefix;
        private System.Windows.Forms.Label lblProjections;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private VIBlend.WinForms.Controls.vRadioButton rbtSinogramOrder;
        private VIBlend.WinForms.Controls.vRadioButton rbtDirectOrder;
        private System.Windows.Forms.NumericUpDown nudTDFToTIFFFrom;
        private System.Windows.Forms.NumericUpDown nudTDFToTIFFTo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkConsiderSubset;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox zLogTxb;
        private System.Windows.Forms.CheckBox chkDataWhite;
        private System.Windows.Forms.CheckBox chkData;
        private System.Windows.Forms.ComboBox cbxInput;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.FolderBrowserDialog zOutputTIFFsBrowserDialog;
        private System.ComponentModel.BackgroundWorker mJobMonitorBgw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel zTiming_ToolStripLbl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar mStatusBarProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.CheckBox chkDataDark;
        private System.Windows.Forms.GroupBox groupBox7;
        private VIBlend.WinForms.Controls.vRadioButton btnTIFFFormat;
        private VIBlend.WinForms.Controls.vRadioButton btnRawFormat;
    }
}