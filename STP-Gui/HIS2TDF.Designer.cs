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
    partial class HISToTDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HISToTDF));
            this.nudConvertToTDF_CropRight = new System.Windows.Forms.NumericUpDown();
            this.nudConvertToTDF_CropLeft = new System.Windows.Forms.NumericUpDown();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.nudConvertToTDF_CropBottom = new System.Windows.Forms.NumericUpDown();
            this.nudConvertToTDF_CropTop = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.btnBrowseFlatPost = new System.Windows.Forms.Button();
            this.txbPostFlatHIS = new System.Windows.Forms.TextBox();
            this.lblFlatPost = new System.Windows.Forms.Label();
            this.btnBrowseDarkPost = new System.Windows.Forms.Button();
            this.txbPostDarkHIS = new System.Windows.Forms.TextBox();
            this.lblDarkPost = new System.Windows.Forms.Label();
            this.btnBrowseFlat = new System.Windows.Forms.Button();
            this.txbFlatHIS = new System.Windows.Forms.TextBox();
            this.lblFlat = new System.Windows.Forms.Label();
            this.btnBrowseDark = new System.Windows.Forms.Button();
            this.txbDarkHIS = new System.Windows.Forms.TextBox();
            this.lblDark = new System.Windows.Forms.Label();
            this.btnBrowseProjHIS = new System.Windows.Forms.Button();
            this.txbProjectionHIS = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.nudConvertToTDFFrom = new System.Windows.Forms.NumericUpDown();
            this.nudConvertToTDFTo = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkConsiderSubset = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.zLogTxb = new System.Windows.Forms.TextBox();
            this.mJobMonitorBgw = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.zTiming_ToolStripLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mStatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbOutputTDF = new System.Windows.Forms.TextBox();
            this.nudOutputCompression = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ofdHISProjections = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropLeft)).BeginInit();
            this.groupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropTop)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFTo)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCompression)).BeginInit();
            this.SuspendLayout();
            // 
            // nudConvertToTDF_CropRight
            // 
            this.nudConvertToTDF_CropRight.Location = new System.Drawing.Point(144, 45);
            this.nudConvertToTDF_CropRight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropRight.Name = "nudConvertToTDF_CropRight";
            this.nudConvertToTDF_CropRight.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropRight.TabIndex = 13;
            this.nudConvertToTDF_CropRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudConvertToTDF_CropLeft
            // 
            this.nudConvertToTDF_CropLeft.Location = new System.Drawing.Point(144, 19);
            this.nudConvertToTDF_CropLeft.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropLeft.Name = "nudConvertToTDF_CropLeft";
            this.nudConvertToTDF_CropLeft.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropLeft.TabIndex = 12;
            this.nudConvertToTDF_CropLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.nudConvertToTDF_CropRight);
            this.groupBox25.Controls.Add(this.label42);
            this.groupBox25.Controls.Add(this.nudConvertToTDF_CropLeft);
            this.groupBox25.Controls.Add(this.label70);
            this.groupBox25.Controls.Add(this.label22);
            this.groupBox25.Controls.Add(this.nudConvertToTDF_CropBottom);
            this.groupBox25.Controls.Add(this.nudConvertToTDF_CropTop);
            this.groupBox25.Controls.Add(this.label50);
            this.groupBox25.Location = new System.Drawing.Point(212, 248);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(209, 80);
            this.groupBox25.TabIndex = 36;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Crop";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(110, 48);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(35, 13);
            this.label42.TabIndex = 14;
            this.label42.Text = "Right:";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(117, 22);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(28, 13);
            this.label70.TabIndex = 11;
            this.label70.Text = "Left:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 13);
            this.label22.TabIndex = 10;
            this.label22.Text = "Bottom:";
            // 
            // nudConvertToTDF_CropBottom
            // 
            this.nudConvertToTDF_CropBottom.Location = new System.Drawing.Point(52, 45);
            this.nudConvertToTDF_CropBottom.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropBottom.Name = "nudConvertToTDF_CropBottom";
            this.nudConvertToTDF_CropBottom.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropBottom.TabIndex = 9;
            this.nudConvertToTDF_CropBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudConvertToTDF_CropTop
            // 
            this.nudConvertToTDF_CropTop.Location = new System.Drawing.Point(52, 19);
            this.nudConvertToTDF_CropTop.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropTop.Name = "nudConvertToTDF_CropTop";
            this.nudConvertToTDF_CropTop.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropTop.TabIndex = 8;
            this.nudConvertToTDF_CropTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(22, 22);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(29, 13);
            this.label50.TabIndex = 7;
            this.label50.Text = "Top:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkLock);
            this.groupBox3.Controls.Add(this.btnBrowseFlatPost);
            this.groupBox3.Controls.Add(this.txbPostFlatHIS);
            this.groupBox3.Controls.Add(this.lblFlatPost);
            this.groupBox3.Controls.Add(this.btnBrowseDarkPost);
            this.groupBox3.Controls.Add(this.txbPostDarkHIS);
            this.groupBox3.Controls.Add(this.lblDarkPost);
            this.groupBox3.Controls.Add(this.btnBrowseFlat);
            this.groupBox3.Controls.Add(this.txbFlatHIS);
            this.groupBox3.Controls.Add(this.lblFlat);
            this.groupBox3.Controls.Add(this.btnBrowseDark);
            this.groupBox3.Controls.Add(this.txbDarkHIS);
            this.groupBox3.Controls.Add(this.lblDark);
            this.groupBox3.Controls.Add(this.btnBrowseProjHIS);
            this.groupBox3.Controls.Add(this.txbProjectionHIS);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(16, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 161);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input (HIS)";
            // 
            // chkLock
            // 
            this.chkLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLock.AutoSize = true;
            this.chkLock.Checked = true;
            this.chkLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLock.Image = ((System.Drawing.Image)(resources.GetObject("chkLock.Image")));
            this.chkLock.Location = new System.Drawing.Point(12, 50);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(22, 22);
            this.chkLock.TabIndex = 43;
            this.mToolTip.SetToolTip(this.chkLock, "Lock/Unlock dark/flat file names");
            this.chkLock.UseVisualStyleBackColor = true;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // btnBrowseFlatPost
            // 
            this.btnBrowseFlatPost.Enabled = false;
            this.btnBrowseFlatPost.Location = new System.Drawing.Point(318, 129);
            this.btnBrowseFlatPost.Name = "btnBrowseFlatPost";
            this.btnBrowseFlatPost.Size = new System.Drawing.Size(74, 23);
            this.btnBrowseFlatPost.TabIndex = 32;
            this.btnBrowseFlatPost.Text = "Browse...";
            this.btnBrowseFlatPost.UseVisualStyleBackColor = true;
            this.btnBrowseFlatPost.Click += new System.EventHandler(this.btnBrowseFlatPost_Click);
            // 
            // txbPostFlatHIS
            // 
            this.txbPostFlatHIS.Enabled = false;
            this.txbPostFlatHIS.Location = new System.Drawing.Point(83, 131);
            this.txbPostFlatHIS.Name = "txbPostFlatHIS";
            this.txbPostFlatHIS.Size = new System.Drawing.Size(229, 20);
            this.txbPostFlatHIS.TabIndex = 31;
            // 
            // lblFlatPost
            // 
            this.lblFlatPost.AutoSize = true;
            this.lblFlatPost.Enabled = false;
            this.lblFlatPost.Location = new System.Drawing.Point(31, 134);
            this.lblFlatPost.Name = "lblFlatPost";
            this.lblFlatPost.Size = new System.Drawing.Size(50, 13);
            this.lblFlatPost.TabIndex = 33;
            this.lblFlatPost.Text = "Flat post:";
            // 
            // btnBrowseDarkPost
            // 
            this.btnBrowseDarkPost.Enabled = false;
            this.btnBrowseDarkPost.Location = new System.Drawing.Point(318, 103);
            this.btnBrowseDarkPost.Name = "btnBrowseDarkPost";
            this.btnBrowseDarkPost.Size = new System.Drawing.Size(74, 23);
            this.btnBrowseDarkPost.TabIndex = 29;
            this.btnBrowseDarkPost.Text = "Browse...";
            this.btnBrowseDarkPost.UseVisualStyleBackColor = true;
            this.btnBrowseDarkPost.Click += new System.EventHandler(this.btnBrowseDarkPost_Click);
            // 
            // txbPostDarkHIS
            // 
            this.txbPostDarkHIS.Enabled = false;
            this.txbPostDarkHIS.Location = new System.Drawing.Point(83, 105);
            this.txbPostDarkHIS.Name = "txbPostDarkHIS";
            this.txbPostDarkHIS.Size = new System.Drawing.Size(229, 20);
            this.txbPostDarkHIS.TabIndex = 28;
            // 
            // lblDarkPost
            // 
            this.lblDarkPost.AutoSize = true;
            this.lblDarkPost.Enabled = false;
            this.lblDarkPost.Location = new System.Drawing.Point(25, 108);
            this.lblDarkPost.Name = "lblDarkPost";
            this.lblDarkPost.Size = new System.Drawing.Size(56, 13);
            this.lblDarkPost.TabIndex = 30;
            this.lblDarkPost.Text = "Dark post:";
            // 
            // btnBrowseFlat
            // 
            this.btnBrowseFlat.Enabled = false;
            this.btnBrowseFlat.Location = new System.Drawing.Point(318, 75);
            this.btnBrowseFlat.Name = "btnBrowseFlat";
            this.btnBrowseFlat.Size = new System.Drawing.Size(74, 23);
            this.btnBrowseFlat.TabIndex = 26;
            this.btnBrowseFlat.Text = "Browse...";
            this.btnBrowseFlat.UseVisualStyleBackColor = true;
            this.btnBrowseFlat.Click += new System.EventHandler(this.btnBrowseFlat_Click);
            // 
            // txbFlatHIS
            // 
            this.txbFlatHIS.Enabled = false;
            this.txbFlatHIS.Location = new System.Drawing.Point(83, 77);
            this.txbFlatHIS.Name = "txbFlatHIS";
            this.txbFlatHIS.Size = new System.Drawing.Size(229, 20);
            this.txbFlatHIS.TabIndex = 25;
            // 
            // lblFlat
            // 
            this.lblFlat.AutoSize = true;
            this.lblFlat.Enabled = false;
            this.lblFlat.Location = new System.Drawing.Point(54, 81);
            this.lblFlat.Name = "lblFlat";
            this.lblFlat.Size = new System.Drawing.Size(27, 13);
            this.lblFlat.TabIndex = 27;
            this.lblFlat.Text = "Flat:";
            // 
            // btnBrowseDark
            // 
            this.btnBrowseDark.Enabled = false;
            this.btnBrowseDark.Location = new System.Drawing.Point(318, 48);
            this.btnBrowseDark.Name = "btnBrowseDark";
            this.btnBrowseDark.Size = new System.Drawing.Size(74, 23);
            this.btnBrowseDark.TabIndex = 23;
            this.btnBrowseDark.Text = "Browse...";
            this.btnBrowseDark.UseVisualStyleBackColor = true;
            this.btnBrowseDark.Click += new System.EventHandler(this.btnBrowseDark_Click);
            // 
            // txbDarkHIS
            // 
            this.txbDarkHIS.Enabled = false;
            this.txbDarkHIS.Location = new System.Drawing.Point(83, 50);
            this.txbDarkHIS.Name = "txbDarkHIS";
            this.txbDarkHIS.Size = new System.Drawing.Size(229, 20);
            this.txbDarkHIS.TabIndex = 22;
            // 
            // lblDark
            // 
            this.lblDark.AutoSize = true;
            this.lblDark.Enabled = false;
            this.lblDark.Location = new System.Drawing.Point(47, 53);
            this.lblDark.Name = "lblDark";
            this.lblDark.Size = new System.Drawing.Size(33, 13);
            this.lblDark.TabIndex = 24;
            this.lblDark.Text = "Dark:";
            // 
            // btnBrowseProjHIS
            // 
            this.btnBrowseProjHIS.Location = new System.Drawing.Point(318, 19);
            this.btnBrowseProjHIS.Name = "btnBrowseProjHIS";
            this.btnBrowseProjHIS.Size = new System.Drawing.Size(74, 23);
            this.btnBrowseProjHIS.TabIndex = 1;
            this.btnBrowseProjHIS.Text = "Browse...";
            this.btnBrowseProjHIS.UseVisualStyleBackColor = true;
            this.btnBrowseProjHIS.Click += new System.EventHandler(this.btnBrowseProjectionHIS_Click);
            // 
            // txbProjectionHIS
            // 
            this.txbProjectionHIS.Location = new System.Drawing.Point(83, 21);
            this.txbProjectionHIS.Name = "txbProjectionHIS";
            this.txbProjectionHIS.Size = new System.Drawing.Size(229, 20);
            this.txbProjectionHIS.TabIndex = 0;
            this.txbProjectionHIS.TextChanged += new System.EventHandler(this.txbProjectionHIS_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Projections:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 455);
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
            this.btnConvert.Location = new System.Drawing.Point(270, 455);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(74, 23);
            this.btnConvert.TabIndex = 25;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // nudConvertToTDFFrom
            // 
            this.nudConvertToTDFFrom.Enabled = false;
            this.nudConvertToTDFFrom.Location = new System.Drawing.Point(43, 46);
            this.nudConvertToTDFFrom.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDFFrom.Name = "nudConvertToTDFFrom";
            this.nudConvertToTDFFrom.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDFFrom.TabIndex = 16;
            this.nudConvertToTDFFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudConvertToTDFTo
            // 
            this.nudConvertToTDFTo.Enabled = false;
            this.nudConvertToTDFTo.Location = new System.Drawing.Point(128, 46);
            this.nudConvertToTDFTo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDFTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConvertToTDFTo.Name = "nudConvertToTDFTo";
            this.nudConvertToTDFTo.Size = new System.Drawing.Size(50, 20);
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
            this.label57.Location = new System.Drawing.Point(104, 48);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(23, 13);
            this.label57.TabIndex = 18;
            this.label57.Text = "To:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nudConvertToTDFFrom);
            this.groupBox5.Controls.Add(this.nudConvertToTDFTo);
            this.groupBox5.Controls.Add(this.label57);
            this.groupBox5.Controls.Add(this.chkConsiderSubset);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(16, 248);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(190, 80);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Subset";
            // 
            // chkConsiderSubset
            // 
            this.chkConsiderSubset.AutoSize = true;
            this.chkConsiderSubset.Location = new System.Drawing.Point(13, 22);
            this.chkConsiderSubset.Name = "chkConsiderSubset";
            this.chkConsiderSubset.Size = new System.Drawing.Size(173, 17);
            this.chkConsiderSubset.TabIndex = 19;
            this.chkConsiderSubset.Text = "Process a subset of the images";
            this.chkConsiderSubset.UseVisualStyleBackColor = true;
            this.chkConsiderSubset.CheckedChanged += new System.EventHandler(this.chkConsiderSubset_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "From:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.zLogTxb);
            this.groupBox6.Location = new System.Drawing.Point(16, 334);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(405, 113);
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
            this.zLogTxb.Size = new System.Drawing.Size(399, 94);
            this.zLogTxb.TabIndex = 1;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(436, 22);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // zTiming_ToolStripLbl
            // 
            this.zTiming_ToolStripLbl.AutoSize = false;
            this.zTiming_ToolStripLbl.Name = "zTiming_ToolStripLbl";
            this.zTiming_ToolStripLbl.Size = new System.Drawing.Size(319, 17);
            this.zTiming_ToolStripLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // mStatusBarProgressBar
            // 
            this.mStatusBarProgressBar.Name = "mStatusBarProgressBar";
            this.mStatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(23, 23);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txbOutputTDF);
            this.groupBox4.Controls.Add(this.nudOutputCompression);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(16, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 55);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output (TDF)";
            // 
            // txbOutputTDF
            // 
            this.txbOutputTDF.Location = new System.Drawing.Point(83, 20);
            this.txbOutputTDF.Name = "txbOutputTDF";
            this.txbOutputTDF.Size = new System.Drawing.Size(229, 20);
            this.txbOutputTDF.TabIndex = 34;
            this.txbOutputTDF.Text = "mydataset.tdf";
            this.mToolTip.SetToolTip(this.txbOutputTDF, "A TDF file with the specified name will be in created in the temporary folder. ");
            // 
            // nudOutputCompression
            // 
            this.nudOutputCompression.Location = new System.Drawing.Point(352, 21);
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
            this.nudOutputCompression.Size = new System.Drawing.Size(37, 20);
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
            this.label3.Location = new System.Drawing.Point(320, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "gZip:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(39, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Output:";
            // 
            // ofdHISProjections
            // 
            this.ofdHISProjections.FileName = "openFileDialog1";
            // 
            // HISToTDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 508);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox25);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HISToTDF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convert HIS to TDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HIS2TDF_FormClosing);
            this.Load += new System.EventHandler(this.HISToTDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropLeft)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropTop)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDFTo)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutputCompression)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropRight;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropLeft;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropBottom;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropTop;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowseProjHIS;
        private System.Windows.Forms.TextBox txbProjectionHIS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.NumericUpDown nudConvertToTDFFrom;
        private System.Windows.Forms.NumericUpDown nudConvertToTDFTo;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkConsiderSubset;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox zLogTxb;
        private System.ComponentModel.BackgroundWorker mJobMonitorBgw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel zTiming_ToolStripLbl;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txbOutputTDF;
        private System.Windows.Forms.NumericUpDown nudOutputCompression;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip mToolTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar mStatusBarProgressBar;
        private System.Windows.Forms.Button btnBrowseFlat;
        private System.Windows.Forms.TextBox txbFlatHIS;
        private System.Windows.Forms.Label lblFlat;
        private System.Windows.Forms.Button btnBrowseDark;
        private System.Windows.Forms.TextBox txbDarkHIS;
        private System.Windows.Forms.Label lblDark;
        private System.Windows.Forms.Button btnBrowseFlatPost;
        private System.Windows.Forms.TextBox txbPostFlatHIS;
        private System.Windows.Forms.Label lblFlatPost;
        private System.Windows.Forms.Button btnBrowseDarkPost;
        private System.Windows.Forms.TextBox txbPostDarkHIS;
        private System.Windows.Forms.Label lblDarkPost;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.OpenFileDialog ofdHISProjections;
    }
}