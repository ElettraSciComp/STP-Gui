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
    partial class GDEI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GDEI));
            this.gbxCrop = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudGDEI_RightShiftVert = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nudGDEI_RightShiftHoriz = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudGDEI_LeftShiftVert = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudGDEI_LeftShiftHoriz = new System.Windows.Forms.NumericUpDown();
            this.gbxAlignmentTop = new System.Windows.Forms.GroupBox();
            this.nudGDEI_TopShiftVert = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.nudGDEI_TopShiftHoriz = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxGDEI_InputRight = new System.Windows.Forms.ComboBox();
            this.cbxGDEI_InputLeft = new System.Windows.Forms.ComboBox();
            this.cbxGDEI_InputTop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.nudGDEI_r1 = new System.Windows.Forms.NumericUpDown();
            this.nudGDEI_r2 = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.gbxSubset = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudGDEI_dd3 = new System.Windows.Forms.NumericUpDown();
            this.nudGDEI_dd1 = new System.Windows.Forms.NumericUpDown();
            this.nudGDEI_dd2 = new System.Windows.Forms.NumericUpDown();
            this.nudGDEI_d3 = new System.Windows.Forms.NumericUpDown();
            this.nudGDEI_d1 = new System.Windows.Forms.NumericUpDown();
            this.nudGDEI_d2 = new System.Windows.Forms.NumericUpDown();
            this.nudGDEI_r3 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.zLogTxb = new System.Windows.Forms.TextBox();
            this.zOutputPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.zInputTIFFsBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mJobMonitorBgw = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.zTiming_ToolStripLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mStatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbxDEIPreview = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kpImageViewer1 = new KaiwaProjects.KpImageViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.chkApplyPreProcessing = new System.Windows.Forms.CheckBox();
            this.gbxCrop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_RightShiftVert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_RightShiftHoriz)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_LeftShiftVert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_LeftShiftHoriz)).BeginInit();
            this.gbxAlignmentTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_TopShiftVert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_TopShiftHoriz)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_r1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_r2)).BeginInit();
            this.gbxSubset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_dd3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_dd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_dd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_d3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_d1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_d2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_r3)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbxDEIPreview.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCrop
            // 
            this.gbxCrop.Controls.Add(this.groupBox2);
            this.gbxCrop.Controls.Add(this.groupBox1);
            this.gbxCrop.Controls.Add(this.gbxAlignmentTop);
            this.gbxCrop.Enabled = false;
            this.gbxCrop.Location = new System.Drawing.Point(21, 229);
            this.gbxCrop.Margin = new System.Windows.Forms.Padding(4);
            this.gbxCrop.Name = "gbxCrop";
            this.gbxCrop.Padding = new System.Windows.Forms.Padding(4);
            this.gbxCrop.Size = new System.Drawing.Size(540, 126);
            this.gbxCrop.TabIndex = 36;
            this.gbxCrop.TabStop = false;
            this.gbxCrop.Text = "Alignment offset";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudGDEI_RightShiftVert);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.nudGDEI_RightShiftHoriz);
            this.groupBox2.Location = new System.Drawing.Point(361, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 92);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "3";
            // 
            // nudGDEI_RightShiftVert
            // 
            this.nudGDEI_RightShiftVert.Location = new System.Drawing.Point(87, 23);
            this.nudGDEI_RightShiftVert.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_RightShiftVert.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudGDEI_RightShiftVert.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudGDEI_RightShiftVert.Name = "nudGDEI_RightShiftVert";
            this.nudGDEI_RightShiftVert.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_RightShiftVert.TabIndex = 8;
            this.nudGDEI_RightShiftVert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Horizontal:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 26);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "Vertical:";
            // 
            // nudGDEI_RightShiftHoriz
            // 
            this.nudGDEI_RightShiftHoriz.Location = new System.Drawing.Point(87, 53);
            this.nudGDEI_RightShiftHoriz.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_RightShiftHoriz.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudGDEI_RightShiftHoriz.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudGDEI_RightShiftHoriz.Name = "nudGDEI_RightShiftHoriz";
            this.nudGDEI_RightShiftHoriz.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_RightShiftHoriz.TabIndex = 9;
            this.nudGDEI_RightShiftHoriz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudGDEI_LeftShiftVert);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudGDEI_LeftShiftHoriz);
            this.groupBox1.Location = new System.Drawing.Point(11, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 92);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1";
            // 
            // nudGDEI_LeftShiftVert
            // 
            this.nudGDEI_LeftShiftVert.Location = new System.Drawing.Point(87, 23);
            this.nudGDEI_LeftShiftVert.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_LeftShiftVert.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudGDEI_LeftShiftVert.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudGDEI_LeftShiftVert.Name = "nudGDEI_LeftShiftVert";
            this.nudGDEI_LeftShiftVert.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_LeftShiftVert.TabIndex = 8;
            this.nudGDEI_LeftShiftVert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Horizontal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Vertical:";
            // 
            // nudGDEI_LeftShiftHoriz
            // 
            this.nudGDEI_LeftShiftHoriz.Location = new System.Drawing.Point(87, 53);
            this.nudGDEI_LeftShiftHoriz.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_LeftShiftHoriz.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudGDEI_LeftShiftHoriz.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudGDEI_LeftShiftHoriz.Name = "nudGDEI_LeftShiftHoriz";
            this.nudGDEI_LeftShiftHoriz.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_LeftShiftHoriz.TabIndex = 9;
            this.nudGDEI_LeftShiftHoriz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxAlignmentTop
            // 
            this.gbxAlignmentTop.Controls.Add(this.nudGDEI_TopShiftVert);
            this.gbxAlignmentTop.Controls.Add(this.label22);
            this.gbxAlignmentTop.Controls.Add(this.label50);
            this.gbxAlignmentTop.Controls.Add(this.nudGDEI_TopShiftHoriz);
            this.gbxAlignmentTop.Location = new System.Drawing.Point(186, 24);
            this.gbxAlignmentTop.Name = "gbxAlignmentTop";
            this.gbxAlignmentTop.Size = new System.Drawing.Size(161, 92);
            this.gbxAlignmentTop.TabIndex = 11;
            this.gbxAlignmentTop.TabStop = false;
            this.gbxAlignmentTop.Text = "2";
            // 
            // nudGDEI_TopShiftVert
            // 
            this.nudGDEI_TopShiftVert.Location = new System.Drawing.Point(87, 23);
            this.nudGDEI_TopShiftVert.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_TopShiftVert.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudGDEI_TopShiftVert.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudGDEI_TopShiftVert.Name = "nudGDEI_TopShiftVert";
            this.nudGDEI_TopShiftVert.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_TopShiftVert.TabIndex = 8;
            this.nudGDEI_TopShiftVert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 56);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(76, 17);
            this.label22.TabIndex = 10;
            this.label22.Text = "Horizontal:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(26, 26);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(59, 17);
            this.label50.TabIndex = 7;
            this.label50.Text = "Vertical:";
            // 
            // nudGDEI_TopShiftHoriz
            // 
            this.nudGDEI_TopShiftHoriz.Location = new System.Drawing.Point(87, 53);
            this.nudGDEI_TopShiftHoriz.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_TopShiftHoriz.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudGDEI_TopShiftHoriz.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudGDEI_TopShiftHoriz.Name = "nudGDEI_TopShiftHoriz";
            this.nudGDEI_TopShiftHoriz.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_TopShiftHoriz.TabIndex = 9;
            this.nudGDEI_TopShiftHoriz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxGDEI_InputRight);
            this.groupBox3.Controls.Add(this.cbxGDEI_InputLeft);
            this.groupBox3.Controls.Add(this.cbxGDEI_InputTop);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(21, 25);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(540, 128);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input (with reference to the rocking curve)";
            // 
            // cbxGDEI_InputRight
            // 
            this.cbxGDEI_InputRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGDEI_InputRight.FormattingEnabled = true;
            this.cbxGDEI_InputRight.Location = new System.Drawing.Point(109, 89);
            this.cbxGDEI_InputRight.Margin = new System.Windows.Forms.Padding(4);
            this.cbxGDEI_InputRight.Name = "cbxGDEI_InputRight";
            this.cbxGDEI_InputRight.Size = new System.Drawing.Size(403, 24);
            this.cbxGDEI_InputRight.TabIndex = 28;
            // 
            // cbxGDEI_InputLeft
            // 
            this.cbxGDEI_InputLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGDEI_InputLeft.FormattingEnabled = true;
            this.cbxGDEI_InputLeft.Location = new System.Drawing.Point(109, 57);
            this.cbxGDEI_InputLeft.Margin = new System.Windows.Forms.Padding(4);
            this.cbxGDEI_InputLeft.Name = "cbxGDEI_InputLeft";
            this.cbxGDEI_InputLeft.Size = new System.Drawing.Size(403, 24);
            this.cbxGDEI_InputLeft.TabIndex = 27;
            // 
            // cbxGDEI_InputTop
            // 
            this.cbxGDEI_InputTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGDEI_InputTop.FormattingEnabled = true;
            this.cbxGDEI_InputTop.Location = new System.Drawing.Point(109, 25);
            this.cbxGDEI_InputTop.Margin = new System.Windows.Forms.Padding(4);
            this.cbxGDEI_InputTop.Name = "cbxGDEI_InputTop";
            this.cbxGDEI_InputTop.Size = new System.Drawing.Size(403, 24);
            this.cbxGDEI_InputTop.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "3 (TDF):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "1 (TDF):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 60);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "2 (TDF):";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(462, 663);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnConvert.Location = new System.Drawing.Point(358, 663);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(4);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(99, 28);
            this.btnConvert.TabIndex = 25;
            this.btnConvert.Text = "Process";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // nudGDEI_r1
            // 
            this.nudGDEI_r1.DecimalPlaces = 2;
            this.nudGDEI_r1.Enabled = false;
            this.nudGDEI_r1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudGDEI_r1.Location = new System.Drawing.Point(104, 23);
            this.nudGDEI_r1.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_r1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_r1.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_r1.Name = "nudGDEI_r1";
            this.nudGDEI_r1.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_r1.TabIndex = 16;
            this.nudGDEI_r1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_r1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGDEI_r2
            // 
            this.nudGDEI_r2.DecimalPlaces = 2;
            this.nudGDEI_r2.Enabled = false;
            this.nudGDEI_r2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudGDEI_r2.Location = new System.Drawing.Point(104, 54);
            this.nudGDEI_r2.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_r2.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_r2.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_r2.Name = "nudGDEI_r2";
            this.nudGDEI_r2.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_r2.TabIndex = 17;
            this.nudGDEI_r2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_r2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(71, 56);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(30, 17);
            this.label57.TabIndex = 18;
            this.label57.Text = "R2:";
            // 
            // gbxSubset
            // 
            this.gbxSubset.Controls.Add(this.label11);
            this.gbxSubset.Controls.Add(this.label14);
            this.gbxSubset.Controls.Add(this.label15);
            this.gbxSubset.Controls.Add(this.label8);
            this.gbxSubset.Controls.Add(this.label9);
            this.gbxSubset.Controls.Add(this.label10);
            this.gbxSubset.Controls.Add(this.label7);
            this.gbxSubset.Controls.Add(this.nudGDEI_dd3);
            this.gbxSubset.Controls.Add(this.nudGDEI_dd1);
            this.gbxSubset.Controls.Add(this.nudGDEI_dd2);
            this.gbxSubset.Controls.Add(this.nudGDEI_d3);
            this.gbxSubset.Controls.Add(this.nudGDEI_d1);
            this.gbxSubset.Controls.Add(this.nudGDEI_d2);
            this.gbxSubset.Controls.Add(this.nudGDEI_r3);
            this.gbxSubset.Controls.Add(this.nudGDEI_r1);
            this.gbxSubset.Controls.Add(this.nudGDEI_r2);
            this.gbxSubset.Controls.Add(this.label57);
            this.gbxSubset.Controls.Add(this.label1);
            this.gbxSubset.Enabled = false;
            this.gbxSubset.Location = new System.Drawing.Point(21, 362);
            this.gbxSubset.Margin = new System.Windows.Forms.Padding(4);
            this.gbxSubset.Name = "gbxSubset";
            this.gbxSubset.Padding = new System.Windows.Forms.Padding(4);
            this.gbxSubset.Size = new System.Drawing.Size(540, 121);
            this.gbxSubset.TabIndex = 5;
            this.gbxSubset.TabStop = false;
            this.gbxSubset.Text = "DEI Coefficients";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(410, 86);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "R\'\'3:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(409, 55);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 32;
            this.label14.Text = "R\'\'2:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(410, 25);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 17);
            this.label15.TabIndex = 33;
            this.label15.Text = "R\'\'1:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 17);
            this.label8.TabIndex = 31;
            this.label8.Text = "R\'3:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(237, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "R\'2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "R\'1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 87);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "R3:";
            // 
            // nudGDEI_dd3
            // 
            this.nudGDEI_dd3.DecimalPlaces = 2;
            this.nudGDEI_dd3.Enabled = false;
            this.nudGDEI_dd3.Location = new System.Drawing.Point(448, 84);
            this.nudGDEI_dd3.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_dd3.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_dd3.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_dd3.Name = "nudGDEI_dd3";
            this.nudGDEI_dd3.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_dd3.TabIndex = 27;
            this.nudGDEI_dd3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_dd3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGDEI_dd1
            // 
            this.nudGDEI_dd1.DecimalPlaces = 2;
            this.nudGDEI_dd1.Enabled = false;
            this.nudGDEI_dd1.Location = new System.Drawing.Point(448, 22);
            this.nudGDEI_dd1.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_dd1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_dd1.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_dd1.Name = "nudGDEI_dd1";
            this.nudGDEI_dd1.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_dd1.TabIndex = 25;
            this.nudGDEI_dd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_dd1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGDEI_dd2
            // 
            this.nudGDEI_dd2.DecimalPlaces = 2;
            this.nudGDEI_dd2.Enabled = false;
            this.nudGDEI_dd2.Location = new System.Drawing.Point(448, 53);
            this.nudGDEI_dd2.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_dd2.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_dd2.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_dd2.Name = "nudGDEI_dd2";
            this.nudGDEI_dd2.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_dd2.TabIndex = 26;
            this.nudGDEI_dd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_dd2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGDEI_d3
            // 
            this.nudGDEI_d3.DecimalPlaces = 2;
            this.nudGDEI_d3.Enabled = false;
            this.nudGDEI_d3.Location = new System.Drawing.Point(276, 85);
            this.nudGDEI_d3.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_d3.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_d3.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_d3.Name = "nudGDEI_d3";
            this.nudGDEI_d3.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_d3.TabIndex = 24;
            this.nudGDEI_d3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_d3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGDEI_d1
            // 
            this.nudGDEI_d1.DecimalPlaces = 2;
            this.nudGDEI_d1.Enabled = false;
            this.nudGDEI_d1.Location = new System.Drawing.Point(276, 23);
            this.nudGDEI_d1.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_d1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_d1.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_d1.Name = "nudGDEI_d1";
            this.nudGDEI_d1.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_d1.TabIndex = 22;
            this.nudGDEI_d1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_d1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGDEI_d2
            // 
            this.nudGDEI_d2.DecimalPlaces = 2;
            this.nudGDEI_d2.Enabled = false;
            this.nudGDEI_d2.Location = new System.Drawing.Point(276, 54);
            this.nudGDEI_d2.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_d2.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_d2.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_d2.Name = "nudGDEI_d2";
            this.nudGDEI_d2.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_d2.TabIndex = 23;
            this.nudGDEI_d2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_d2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGDEI_r3
            // 
            this.nudGDEI_r3.DecimalPlaces = 2;
            this.nudGDEI_r3.Enabled = false;
            this.nudGDEI_r3.Location = new System.Drawing.Point(104, 85);
            this.nudGDEI_r3.Margin = new System.Windows.Forms.Padding(4);
            this.nudGDEI_r3.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudGDEI_r3.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudGDEI_r3.Name = "nudGDEI_r3";
            this.nudGDEI_r3.Size = new System.Drawing.Size(67, 22);
            this.nudGDEI_r3.TabIndex = 21;
            this.nudGDEI_r3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGDEI_r3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "R1:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.zLogTxb);
            this.groupBox6.Location = new System.Drawing.Point(22, 491);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(539, 162);
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
            this.zLogTxb.Margin = new System.Windows.Forms.Padding(4);
            this.zLogTxb.Multiline = true;
            this.zLogTxb.Name = "zLogTxb";
            this.zLogTxb.ReadOnly = true;
            this.zLogTxb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.zLogTxb.Size = new System.Drawing.Size(531, 139);
            this.zLogTxb.TabIndex = 1;
            // 
            // zOutputPathBrowserDialog
            // 
            this.zOutputPathBrowserDialog.Description = "Select output folder:";
            // 
            // zInputTIFFsBrowserDialog
            // 
            this.zInputTIFFsBrowserDialog.Description = "Browse for TIFF files:";
            this.zInputTIFFsBrowserDialog.ShowNewFolderButton = false;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 699);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1367, 26);
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1212, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mStatusBarProgressBar
            // 
            this.mStatusBarProgressBar.Name = "mStatusBarProgressBar";
            this.mStatusBarProgressBar.Size = new System.Drawing.Size(133, 20);
            // 
            // gbxDEIPreview
            // 
            this.gbxDEIPreview.Controls.Add(this.panel2);
            this.gbxDEIPreview.Controls.Add(this.panel1);
            this.gbxDEIPreview.Location = new System.Drawing.Point(577, 25);
            this.gbxDEIPreview.Name = "gbxDEIPreview";
            this.gbxDEIPreview.Size = new System.Drawing.Size(767, 666);
            this.gbxDEIPreview.TabIndex = 43;
            this.gbxDEIPreview.TabStop = false;
            this.gbxDEIPreview.Text = "Alignment Preview";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.kpImageViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(761, 515);
            this.panel2.TabIndex = 6;
            // 
            // kpImageViewer1
            // 
            this.kpImageViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.kpImageViewer1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.kpImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpImageViewer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kpImageViewer1.Image = null;
            this.kpImageViewer1.Location = new System.Drawing.Point(0, 0);
            this.kpImageViewer1.Margin = new System.Windows.Forms.Padding(5);
            this.kpImageViewer1.MenuColor = System.Drawing.Color.Transparent;
            this.kpImageViewer1.MenuPanelColor = System.Drawing.Color.Transparent;
            this.kpImageViewer1.MinimumSize = new System.Drawing.Size(605, 193);
            this.kpImageViewer1.Name = "kpImageViewer1";
            this.kpImageViewer1.NavigationPanelColor = System.Drawing.Color.Transparent;
            this.kpImageViewer1.NavigationTextColor = System.Drawing.SystemColors.MenuText;
            this.kpImageViewer1.OpenButton = true;
            this.kpImageViewer1.Pix32 = ((System.Collections.Generic.List<float>)(resources.GetObject("kpImageViewer1.Pix32")));
            this.kpImageViewer1.Pix32Max = 0F;
            this.kpImageViewer1.Pix32Min = 0F;
            this.kpImageViewer1.Pix8 = ((System.Collections.Generic.List<byte>)(resources.GetObject("kpImageViewer1.Pix8")));
            this.kpImageViewer1.PreviewButton = false;
            this.kpImageViewer1.PreviewPanelColor = System.Drawing.Color.Transparent;
            this.kpImageViewer1.PreviewText = "";
            this.kpImageViewer1.PreviewTextColor = System.Drawing.SystemColors.MenuText;
            this.kpImageViewer1.Rotation = 0;
            this.kpImageViewer1.Scrollbars = false;
            this.kpImageViewer1.ShowPreview = true;
            this.kpImageViewer1.Size = new System.Drawing.Size(761, 515);
            this.kpImageViewer1.TabIndex = 1;
            this.kpImageViewer1.TextColor = System.Drawing.SystemColors.MenuText;
            this.kpImageViewer1.Zoom = 100D;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 130);
            this.panel1.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton7);
            this.groupBox4.Controls.Add(this.radioButton8);
            this.groupBox4.Controls.Add(this.radioButton9);
            this.groupBox4.Location = new System.Drawing.Point(120, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(110, 114);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Red Overlay";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(20, 79);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(37, 21);
            this.radioButton7.TabIndex = 2;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "3";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(20, 25);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(37, 21);
            this.radioButton8.TabIndex = 0;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "1";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(20, 52);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(37, 21);
            this.radioButton9.TabIndex = 1;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "2";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton10);
            this.groupBox5.Controls.Add(this.radioButton11);
            this.groupBox5.Controls.Add(this.radioButton12);
            this.groupBox5.Location = new System.Drawing.Point(13, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(101, 114);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Gray";
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(20, 79);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(37, 21);
            this.radioButton10.TabIndex = 2;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "3";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(20, 25);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(37, 21);
            this.radioButton11.TabIndex = 0;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "1";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(20, 52);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(37, 21);
            this.radioButton12.TabIndex = 1;
            this.radioButton12.TabStop = true;
            this.radioButton12.Text = "2";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.chkApplyPreProcessing);
            this.groupBox18.Location = new System.Drawing.Point(21, 158);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox18.Size = new System.Drawing.Size(539, 65);
            this.groupBox18.TabIndex = 44;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Pre-processing";
            // 
            // chkApplyPreProcessing
            // 
            this.chkApplyPreProcessing.AutoSize = true;
            this.chkApplyPreProcessing.Location = new System.Drawing.Point(25, 27);
            this.chkApplyPreProcessing.Margin = new System.Windows.Forms.Padding(4);
            this.chkApplyPreProcessing.Name = "chkApplyPreProcessing";
            this.chkApplyPreProcessing.Size = new System.Drawing.Size(428, 21);
            this.chkApplyPreProcessing.TabIndex = 42;
            this.chkApplyPreProcessing.Text = "Pre-process the sinogram on-the-fly (see \"Pre-processing\" tab)";
            this.chkApplyPreProcessing.UseVisualStyleBackColor = true;
            // 
            // GDEI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 725);
            this.Controls.Add(this.groupBox18);
            this.Controls.Add(this.gbxDEIPreview);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbxSubset);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbxCrop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GDEI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generalized Diffraction Enhanced Imaging (DEI)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TIFFToTDF_FormClosing);
            this.Load += new System.EventHandler(this.TIFFToTDF_Load);
            this.gbxCrop.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_RightShiftVert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_RightShiftHoriz)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_LeftShiftVert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_LeftShiftHoriz)).EndInit();
            this.gbxAlignmentTop.ResumeLayout(false);
            this.gbxAlignmentTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_TopShiftVert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_TopShiftHoriz)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_r1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_r2)).EndInit();
            this.gbxSubset.ResumeLayout(false);
            this.gbxSubset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_dd3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_dd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_dd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_d3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_d1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_d2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGDEI_r3)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbxDEIPreview.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCrop;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudGDEI_TopShiftHoriz;
        private System.Windows.Forms.NumericUpDown nudGDEI_TopShiftVert;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.NumericUpDown nudGDEI_r1;
        private System.Windows.Forms.NumericUpDown nudGDEI_r2;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox gbxSubset;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox zLogTxb;
        private System.Windows.Forms.FolderBrowserDialog zOutputPathBrowserDialog;
        private System.Windows.Forms.FolderBrowserDialog zInputTIFFsBrowserDialog;
        private System.ComponentModel.BackgroundWorker mJobMonitorBgw;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel zTiming_ToolStripLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip mToolTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar mStatusBarProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudGDEI_dd3;
        private System.Windows.Forms.NumericUpDown nudGDEI_dd1;
        private System.Windows.Forms.NumericUpDown nudGDEI_dd2;
        private System.Windows.Forms.NumericUpDown nudGDEI_d3;
        private System.Windows.Forms.NumericUpDown nudGDEI_d1;
        private System.Windows.Forms.NumericUpDown nudGDEI_d2;
        private System.Windows.Forms.NumericUpDown nudGDEI_r3;
        private System.Windows.Forms.GroupBox gbxDEIPreview;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton12;
        private KaiwaProjects.KpImageViewer kpImageViewer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudGDEI_RightShiftVert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudGDEI_RightShiftHoriz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudGDEI_LeftShiftVert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudGDEI_LeftShiftHoriz;
        private System.Windows.Forms.GroupBox gbxAlignmentTop;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.CheckBox chkApplyPreProcessing;
        private System.Windows.Forms.ComboBox cbxGDEI_InputRight;
        private System.Windows.Forms.ComboBox cbxGDEI_InputLeft;
        private System.Windows.Forms.ComboBox cbxGDEI_InputTop;
    }
}