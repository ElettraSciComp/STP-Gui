﻿/***************************************************************************/
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
    partial class EDFToTDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EDFToTDF));
            this.nudConvertToTDF_CropRight = new System.Windows.Forms.NumericUpDown();
            this.nudConvertToTDF_CropLeft = new System.Windows.Forms.NumericUpDown();
            this.gbxCrop = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.nudConvertToTDF_CropBottom = new System.Windows.Forms.NumericUpDown();
            this.nudConvertToTDF_CropTop = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBrowseTIFFs = new System.Windows.Forms.Button();
            this.zProject_InputPathTxb = new System.Windows.Forms.TextBox();
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
            this.gbxFormat = new System.Windows.Forms.GroupBox();
            this.rbtInputSinograms = new VIBlend.WinForms.Controls.vRadioButton();
            this.rbtInputProjections = new VIBlend.WinForms.Controls.vRadioButton();
            this.nudConvertToTDFFrom = new System.Windows.Forms.NumericUpDown();
            this.nudConvertToTDFTo = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.gbxSubset = new System.Windows.Forms.GroupBox();
            this.chkConsiderSubset = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.gbxOutput = new System.Windows.Forms.GroupBox();
            this.txbOutputTDF = new System.Windows.Forms.TextBox();
            this.nudOutputCompression = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropLeft)).BeginInit();
            this.gbxCrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropTop)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFTo)).BeginInit();
            this.gbxSubset.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbxOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCompression)).BeginInit();
            this.SuspendLayout();
            // 
            // nudConvertToTDF_CropRight
            // 
            this.nudConvertToTDF_CropRight.Location = new System.Drawing.Point(189, 55);
            this.nudConvertToTDF_CropRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudConvertToTDF_CropRight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropRight.Name = "nudConvertToTDF_CropRight";
            this.nudConvertToTDF_CropRight.Size = new System.Drawing.Size(67, 22);
            this.nudConvertToTDF_CropRight.TabIndex = 13;
            this.nudConvertToTDF_CropRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudConvertToTDF_CropLeft
            // 
            this.nudConvertToTDF_CropLeft.Location = new System.Drawing.Point(189, 23);
            this.nudConvertToTDF_CropLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudConvertToTDF_CropLeft.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropLeft.Name = "nudConvertToTDF_CropLeft";
            this.nudConvertToTDF_CropLeft.Size = new System.Drawing.Size(67, 22);
            this.nudConvertToTDF_CropLeft.TabIndex = 12;
            this.nudConvertToTDF_CropLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxCrop
            // 
            this.gbxCrop.Controls.Add(this.nudConvertToTDF_CropRight);
            this.gbxCrop.Controls.Add(this.label42);
            this.gbxCrop.Controls.Add(this.nudConvertToTDF_CropLeft);
            this.gbxCrop.Controls.Add(this.label70);
            this.gbxCrop.Controls.Add(this.label22);
            this.gbxCrop.Controls.Add(this.nudConvertToTDF_CropBottom);
            this.gbxCrop.Controls.Add(this.nudConvertToTDF_CropTop);
            this.gbxCrop.Controls.Add(this.label50);
            this.gbxCrop.Enabled = false;
            this.gbxCrop.Location = new System.Drawing.Point(280, 180);
            this.gbxCrop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxCrop.Name = "gbxCrop";
            this.gbxCrop.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxCrop.Size = new System.Drawing.Size(281, 94);
            this.gbxCrop.TabIndex = 36;
            this.gbxCrop.TabStop = false;
            this.gbxCrop.Text = "Crop";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(144, 59);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(45, 17);
            this.label42.TabIndex = 14;
            this.label42.Text = "Right:";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(153, 27);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(36, 17);
            this.label70.TabIndex = 11;
            this.label70.Text = "Left:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 59);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 17);
            this.label22.TabIndex = 10;
            this.label22.Text = "Bottom:";
            // 
            // nudConvertToTDF_CropBottom
            // 
            this.nudConvertToTDF_CropBottom.Location = new System.Drawing.Point(68, 55);
            this.nudConvertToTDF_CropBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudConvertToTDF_CropBottom.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropBottom.Name = "nudConvertToTDF_CropBottom";
            this.nudConvertToTDF_CropBottom.Size = new System.Drawing.Size(67, 22);
            this.nudConvertToTDF_CropBottom.TabIndex = 9;
            this.nudConvertToTDF_CropBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudConvertToTDF_CropTop
            // 
            this.nudConvertToTDF_CropTop.Location = new System.Drawing.Point(68, 23);
            this.nudConvertToTDF_CropTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudConvertToTDF_CropTop.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropTop.Name = "nudConvertToTDF_CropTop";
            this.nudConvertToTDF_CropTop.Size = new System.Drawing.Size(67, 22);
            this.nudConvertToTDF_CropTop.TabIndex = 8;
            this.nudConvertToTDF_CropTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(28, 27);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(37, 17);
            this.label50.TabIndex = 7;
            this.label50.Text = "Top:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBrowseTIFFs);
            this.groupBox3.Controls.Add(this.zProject_InputPathTxb);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(21, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(540, 76);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // btnBrowseTIFFs
            // 
            this.btnBrowseTIFFs.Location = new System.Drawing.Point(417, 26);
            this.btnBrowseTIFFs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseTIFFs.Name = "btnBrowseTIFFs";
            this.btnBrowseTIFFs.Size = new System.Drawing.Size(99, 28);
            this.btnBrowseTIFFs.TabIndex = 1;
            this.btnBrowseTIFFs.Text = "Browse...";
            this.btnBrowseTIFFs.UseVisualStyleBackColor = true;
            this.btnBrowseTIFFs.Click += new System.EventHandler(this.btnBrowseEDFs_Click);
            // 
            // zProject_InputPathTxb
            // 
            this.zProject_InputPathTxb.Location = new System.Drawing.Point(109, 28);
            this.zProject_InputPathTxb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zProject_InputPathTxb.Name = "zProject_InputPathTxb";
            this.zProject_InputPathTxb.Size = new System.Drawing.Size(296, 22);
            this.zProject_InputPathTxb.TabIndex = 0;
            this.zProject_InputPathTxb.TextChanged += new System.EventHandler(this.zProject_InputPathTxb_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 33);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "Input (EDFs):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxFlatPrefix);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.tbxDarkPrefix);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tbxProjectionPrefix);
            this.groupBox1.Controls.Add(this.lblProjections);
            this.groupBox1.Location = new System.Drawing.Point(23, 282);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(249, 134);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EDF files prefixes";
            // 
            // tbxFlatPrefix
            // 
            this.tbxFlatPrefix.Location = new System.Drawing.Point(109, 91);
            this.tbxFlatPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxFlatPrefix.Name = "tbxFlatPrefix";
            this.tbxFlatPrefix.Size = new System.Drawing.Size(124, 22);
            this.tbxFlatPrefix.TabIndex = 26;
            this.tbxFlatPrefix.Text = "ref";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 95);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 17);
            this.label19.TabIndex = 23;
            this.label19.Text = "Flat images:";
            // 
            // tbxDarkPrefix
            // 
            this.tbxDarkPrefix.Location = new System.Drawing.Point(109, 60);
            this.tbxDarkPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxDarkPrefix.Name = "tbxDarkPrefix";
            this.tbxDarkPrefix.Size = new System.Drawing.Size(124, 22);
            this.tbxDarkPrefix.TabIndex = 25;
            this.tbxDarkPrefix.Text = "dark";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 64);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 17);
            this.label18.TabIndex = 22;
            this.label18.Text = "Dark images:";
            // 
            // tbxProjectionPrefix
            // 
            this.tbxProjectionPrefix.Location = new System.Drawing.Point(109, 28);
            this.tbxProjectionPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxProjectionPrefix.Name = "tbxProjectionPrefix";
            this.tbxProjectionPrefix.Size = new System.Drawing.Size(124, 22);
            this.tbxProjectionPrefix.TabIndex = 24;
            this.tbxProjectionPrefix.TextChanged += new System.EventHandler(this.tbxProjectionPrefix_TextChanged);
            // 
            // lblProjections
            // 
            this.lblProjections.AutoSize = true;
            this.lblProjections.Location = new System.Drawing.Point(25, 32);
            this.lblProjections.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjections.Name = "lblProjections";
            this.lblProjections.Size = new System.Drawing.Size(82, 17);
            this.lblProjections.TabIndex = 21;
            this.lblProjections.Text = "Projections:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(463, 575);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 28);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(359, 575);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(99, 28);
            this.btnConvert.TabIndex = 25;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // gbxFormat
            // 
            this.gbxFormat.BackColor = System.Drawing.SystemColors.Control;
            this.gbxFormat.Controls.Add(this.rbtInputSinograms);
            this.gbxFormat.Controls.Add(this.rbtInputProjections);
            this.gbxFormat.Enabled = false;
            this.gbxFormat.Location = new System.Drawing.Point(23, 180);
            this.gbxFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxFormat.Name = "gbxFormat";
            this.gbxFormat.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxFormat.Size = new System.Drawing.Size(249, 94);
            this.gbxFormat.TabIndex = 37;
            this.gbxFormat.TabStop = false;
            this.gbxFormat.Text = "Input EDF image";
            // 
            // rbtInputSinograms
            // 
            this.rbtInputSinograms.BackColor = System.Drawing.Color.Transparent;
            this.rbtInputSinograms.Flat = true;
            this.rbtInputSinograms.Image = null;
            this.rbtInputSinograms.Location = new System.Drawing.Point(19, 49);
            this.rbtInputSinograms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtInputSinograms.Name = "rbtInputSinograms";
            this.rbtInputSinograms.Size = new System.Drawing.Size(139, 30);
            this.rbtInputSinograms.TabIndex = 1;
            this.rbtInputSinograms.Text = "Sinograms";
            this.rbtInputSinograms.UseVisualStyleBackColor = false;
            this.rbtInputSinograms.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.rbtInputSinograms.CheckedChanged += new System.EventHandler(this.rbtInputSinograms_CheckedChanged);
            // 
            // rbtInputProjections
            // 
            this.rbtInputProjections.BackColor = System.Drawing.Color.Transparent;
            this.rbtInputProjections.Checked = true;
            this.rbtInputProjections.Flat = true;
            this.rbtInputProjections.Image = null;
            this.rbtInputProjections.Location = new System.Drawing.Point(19, 23);
            this.rbtInputProjections.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtInputProjections.Name = "rbtInputProjections";
            this.rbtInputProjections.Size = new System.Drawing.Size(139, 30);
            this.rbtInputProjections.TabIndex = 0;
            this.rbtInputProjections.TabStop = true;
            this.rbtInputProjections.Text = "Projections";
            this.rbtInputProjections.UseVisualStyleBackColor = false;
            this.rbtInputProjections.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            this.rbtInputProjections.CheckedChanged += new System.EventHandler(this.rbtInputProjections_CheckedChanged);
            // 
            // nudConvertToTDFFrom
            // 
            this.nudConvertToTDFFrom.Enabled = false;
            this.nudConvertToTDFFrom.Location = new System.Drawing.Point(68, 59);
            this.nudConvertToTDFFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudConvertToTDFFrom.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudConvertToTDFFrom.Name = "nudConvertToTDFFrom";
            this.nudConvertToTDFFrom.Size = new System.Drawing.Size(67, 22);
            this.nudConvertToTDFFrom.TabIndex = 16;
            this.nudConvertToTDFFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudConvertToTDFTo
            // 
            this.nudConvertToTDFTo.Enabled = false;
            this.nudConvertToTDFTo.Location = new System.Drawing.Point(189, 59);
            this.nudConvertToTDFTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudConvertToTDFTo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudConvertToTDFTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConvertToTDFTo.Name = "nudConvertToTDFTo";
            this.nudConvertToTDFTo.Size = new System.Drawing.Size(67, 22);
            this.nudConvertToTDFTo.TabIndex = 17;
            this.nudConvertToTDFTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudConvertToTDFTo.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(159, 63);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(29, 17);
            this.label57.TabIndex = 18;
            this.label57.Text = "To:";
            // 
            // gbxSubset
            // 
            this.gbxSubset.Controls.Add(this.nudConvertToTDFFrom);
            this.gbxSubset.Controls.Add(this.chkConsiderSubset);
            this.gbxSubset.Controls.Add(this.nudConvertToTDFTo);
            this.gbxSubset.Controls.Add(this.label57);
            this.gbxSubset.Controls.Add(this.label1);
            this.gbxSubset.Enabled = false;
            this.gbxSubset.Location = new System.Drawing.Point(280, 282);
            this.gbxSubset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxSubset.Name = "gbxSubset";
            this.gbxSubset.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxSubset.Size = new System.Drawing.Size(281, 134);
            this.gbxSubset.TabIndex = 5;
            this.gbxSubset.TabStop = false;
            this.gbxSubset.Text = "Subset";
            // 
            // chkConsiderSubset
            // 
            this.chkConsiderSubset.AutoSize = true;
            this.chkConsiderSubset.Location = new System.Drawing.Point(31, 31);
            this.chkConsiderSubset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkConsiderSubset.Name = "chkConsiderSubset";
            this.chkConsiderSubset.Size = new System.Drawing.Size(228, 21);
            this.chkConsiderSubset.TabIndex = 19;
            this.chkConsiderSubset.Text = "Process a subset of the images";
            this.chkConsiderSubset.UseVisualStyleBackColor = true;
            this.chkConsiderSubset.CheckedChanged += new System.EventHandler(this.chkConsiderSubset_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "From:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.zLogTxb);
            this.groupBox6.Location = new System.Drawing.Point(23, 423);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox6.Size = new System.Drawing.Size(539, 139);
            this.groupBox6.TabIndex = 39;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Log";
            // 
            // zLogTxb
            // 
            this.zLogTxb.BackColor = System.Drawing.Color.White;
            this.zLogTxb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zLogTxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLogTxb.Location = new System.Drawing.Point(4, 19);
            this.zLogTxb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zLogTxb.Multiline = true;
            this.zLogTxb.Name = "zLogTxb";
            this.zLogTxb.ReadOnly = true;
            this.zLogTxb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.zLogTxb.Size = new System.Drawing.Size(531, 116);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 614);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(581, 26);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // zTiming_ToolStripLbl
            // 
            this.zTiming_ToolStripLbl.Name = "zTiming_ToolStripLbl";
            this.zTiming_ToolStripLbl.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(426, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            // 
            // mStatusBarProgressBar
            // 
            this.mStatusBarProgressBar.Name = "mStatusBarProgressBar";
            this.mStatusBarProgressBar.Size = new System.Drawing.Size(133, 20);
            // 
            // gbxOutput
            // 
            this.gbxOutput.Controls.Add(this.txbOutputTDF);
            this.gbxOutput.Controls.Add(this.nudOutputCompression);
            this.gbxOutput.Controls.Add(this.label3);
            this.gbxOutput.Controls.Add(this.label13);
            this.gbxOutput.Enabled = false;
            this.gbxOutput.Location = new System.Drawing.Point(21, 106);
            this.gbxOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxOutput.Name = "gbxOutput";
            this.gbxOutput.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxOutput.Size = new System.Drawing.Size(540, 68);
            this.gbxOutput.TabIndex = 42;
            this.gbxOutput.TabStop = false;
            this.gbxOutput.Text = "Output";
            // 
            // txbOutputTDF
            // 
            this.txbOutputTDF.Location = new System.Drawing.Point(111, 25);
            this.txbOutputTDF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbOutputTDF.Name = "txbOutputTDF";
            this.txbOutputTDF.Size = new System.Drawing.Size(296, 22);
            this.txbOutputTDF.TabIndex = 34;
            this.mToolTip.SetToolTip(this.txbOutputTDF, "A TDF file with the specified name will be in created in the temporary folder. ");
            // 
            // nudOutputCompression
            // 
            this.nudOutputCompression.Location = new System.Drawing.Point(464, 26);
            this.nudOutputCompression.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudOutputCompression.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudOutputCompression.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOutputCompression.Name = "nudOutputCompression";
            this.nudOutputCompression.Size = new System.Drawing.Size(49, 22);
            this.nudOutputCompression.TabIndex = 30;
            this.nudOutputCompression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudOutputCompression.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "gZip:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 30);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "Output (TDF):";
            // 
            // EDFToTDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 640);
            this.Controls.Add(this.gbxOutput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbxSubset);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.gbxFormat);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbxCrop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "EDFToTDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert EDFs (ESRF Data Format) to TDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EDFToTDF_FormClosing);
            this.Load += new System.EventHandler(this.EDFToTDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropLeft)).EndInit();
            this.gbxCrop.ResumeLayout(false);
            this.gbxCrop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropTop)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxFormat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFTo)).EndInit();
            this.gbxSubset.ResumeLayout(false);
            this.gbxSubset.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbxOutput.ResumeLayout(false);
            this.gbxOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCompression)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropRight;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropLeft;
        private System.Windows.Forms.GroupBox gbxCrop;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropBottom;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropTop;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowseTIFFs;
        private System.Windows.Forms.TextBox zProject_InputPathTxb;
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
        private System.Windows.Forms.GroupBox gbxFormat;
        private VIBlend.WinForms.Controls.vRadioButton rbtInputProjections;
        private VIBlend.WinForms.Controls.vRadioButton rbtInputSinograms;
        private System.Windows.Forms.NumericUpDown nudConvertToTDFFrom;
        private System.Windows.Forms.NumericUpDown nudConvertToTDFTo;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox gbxSubset;
        private System.Windows.Forms.CheckBox chkConsiderSubset;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox zLogTxb;
        private System.Windows.Forms.FolderBrowserDialog zOutputPathBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog zInputEDFsBrowserDialog;
        private System.ComponentModel.BackgroundWorker mJobMonitorBgw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel zTiming_ToolStripLbl;
        private System.Windows.Forms.GroupBox gbxOutput;
        private System.Windows.Forms.TextBox txbOutputTDF;
        private System.Windows.Forms.NumericUpDown nudOutputCompression;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip mToolTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar mStatusBarProgressBar;
    }
}