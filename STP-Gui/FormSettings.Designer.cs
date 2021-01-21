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
            this.nudSettings_ChunkSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
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
            this.tabSYRMEP_HPC = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txbSYRMEP_HPC_Output = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSYRMEP_HPC_Temp = new System.Windows.Forms.TextBox();
            this.txbSYRMEP_HPC_Input = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mButtonOk = new System.Windows.Forms.Button();
            this.mButtonCancel = new System.Windows.Forms.Button();
            this.zWorkingPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.zTestPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.zOutputPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txbSYRMEP_HPC_Output_LocallyMapped = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txbSYRMEP_HPC_Temp_LocallyMapped = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txbSYRMEP_HPC_Input_LocallyMapped = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_ChunkSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_Processes)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabSYRMEP_HPC.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabSYRMEP_HPC);
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
            // tabSYRMEP_HPC
            // 
            this.tabSYRMEP_HPC.Controls.Add(this.groupBox2);
            this.tabSYRMEP_HPC.Controls.Add(this.groupBox3);
            this.tabSYRMEP_HPC.Location = new System.Drawing.Point(4, 22);
            this.tabSYRMEP_HPC.Name = "tabSYRMEP_HPC";
            this.tabSYRMEP_HPC.Padding = new System.Windows.Forms.Padding(3);
            this.tabSYRMEP_HPC.Size = new System.Drawing.Size(435, 244);
            this.tabSYRMEP_HPC.TabIndex = 1;
            this.tabSYRMEP_HPC.Text = "SYRMEP HPC";
            this.tabSYRMEP_HPC.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txbSYRMEP_HPC_Output);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txbSYRMEP_HPC_Temp);
            this.groupBox3.Controls.Add(this.txbSYRMEP_HPC_Input);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(15, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 106);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Path on HPC (Unix/Linux format)";
            // 
            // txbSYRMEP_HPC_Output
            // 
            this.txbSYRMEP_HPC_Output.Location = new System.Drawing.Point(89, 75);
            this.txbSYRMEP_HPC_Output.Name = "txbSYRMEP_HPC_Output";
            this.txbSYRMEP_HPC_Output.Size = new System.Drawing.Size(310, 20);
            this.txbSYRMEP_HPC_Output.TabIndex = 25;
            this.mToolTip.SetToolTip(this.txbSYRMEP_HPC_Output, "Reconstructed images will be written here. Usually this refers to user\'s external" +
        " hard drive (USB3 or eSATA suggested).");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Output path:";
            this.mToolTip.SetToolTip(this.label7, "Reconstructed images will be written here. Usually this refers to user\'s external" +
        " hard drive (USB3 or eSATA suggested).");
            // 
            // txbSYRMEP_HPC_Temp
            // 
            this.txbSYRMEP_HPC_Temp.Location = new System.Drawing.Point(89, 48);
            this.txbSYRMEP_HPC_Temp.Name = "txbSYRMEP_HPC_Temp";
            this.txbSYRMEP_HPC_Temp.Size = new System.Drawing.Size(310, 20);
            this.txbSYRMEP_HPC_Temp.TabIndex = 4;
            this.mToolTip.SetToolTip(this.txbSYRMEP_HPC_Temp, "Log files will be written here. Fast (and small) RAMDrive or SSD suggested.");
            // 
            // txbSYRMEP_HPC_Input
            // 
            this.txbSYRMEP_HPC_Input.Location = new System.Drawing.Point(89, 21);
            this.txbSYRMEP_HPC_Input.Name = "txbSYRMEP_HPC_Input";
            this.txbSYRMEP_HPC_Input.Size = new System.Drawing.Size(310, 20);
            this.txbSYRMEP_HPC_Input.TabIndex = 2;
            this.mToolTip.SetToolTip(this.txbSYRMEP_HPC_Input, "Input and temporary TDFs go here. Fast SSD suggested.");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Temporary path:";
            this.mToolTip.SetToolTip(this.label8, "Log files will be written here. Fast (and small) RAMDrive or SSD suggested.");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Input path:";
            this.mToolTip.SetToolTip(this.label9, "Input and temporary TDFs go here. Fast SSD suggested.");
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
            // zOutputPathBrowserDialog
            // 
            this.zOutputPathBrowserDialog.Description = "Select output folder:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txbSYRMEP_HPC_Output_LocallyMapped);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txbSYRMEP_HPC_Temp_LocallyMapped);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.txbSYRMEP_HPC_Input_LocallyMapped);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(15, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 106);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Locally mapped path (Windows format)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txbSYRMEP_HPC_Output_LocallyMapped
            // 
            this.txbSYRMEP_HPC_Output_LocallyMapped.Location = new System.Drawing.Point(89, 75);
            this.txbSYRMEP_HPC_Output_LocallyMapped.Name = "txbSYRMEP_HPC_Output_LocallyMapped";
            this.txbSYRMEP_HPC_Output_LocallyMapped.Size = new System.Drawing.Size(221, 20);
            this.txbSYRMEP_HPC_Output_LocallyMapped.TabIndex = 25;
            this.mToolTip.SetToolTip(this.txbSYRMEP_HPC_Output_LocallyMapped, "Reconstructed images will be written here. Usually this refers to user\'s external" +
        " hard drive (USB3 or eSATA suggested).");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Output path:";
            this.mToolTip.SetToolTip(this.label4, "Reconstructed images will be written here. Usually this refers to user\'s external" +
        " hard drive (USB3 or eSATA suggested).");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Browse...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txbSYRMEP_HPC_Temp_LocallyMapped
            // 
            this.txbSYRMEP_HPC_Temp_LocallyMapped.Location = new System.Drawing.Point(89, 48);
            this.txbSYRMEP_HPC_Temp_LocallyMapped.Name = "txbSYRMEP_HPC_Temp_LocallyMapped";
            this.txbSYRMEP_HPC_Temp_LocallyMapped.Size = new System.Drawing.Size(220, 20);
            this.txbSYRMEP_HPC_Temp_LocallyMapped.TabIndex = 4;
            this.mToolTip.SetToolTip(this.txbSYRMEP_HPC_Temp_LocallyMapped, "Log files will be written here. Fast (and small) RAMDrive or SSD suggested.");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(315, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Browse...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txbSYRMEP_HPC_Input_LocallyMapped
            // 
            this.txbSYRMEP_HPC_Input_LocallyMapped.Location = new System.Drawing.Point(89, 21);
            this.txbSYRMEP_HPC_Input_LocallyMapped.Name = "txbSYRMEP_HPC_Input_LocallyMapped";
            this.txbSYRMEP_HPC_Input_LocallyMapped.Size = new System.Drawing.Size(220, 20);
            this.txbSYRMEP_HPC_Input_LocallyMapped.TabIndex = 2;
            this.mToolTip.SetToolTip(this.txbSYRMEP_HPC_Input_LocallyMapped, "Input and temporary TDFs go here. Fast SSD suggested.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Temporary path:";
            this.mToolTip.SetToolTip(this.label5, "Log files will be written here. Fast (and small) RAMDrive or SSD suggested.");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Input path:";
            this.mToolTip.SetToolTip(this.label6, "Input and temporary TDFs go here. Fast SSD suggested.");
            // 
            // FormSettings
            // 
            this.AcceptButton = this.mButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mButtonCancel;
            this.ClientSize = new System.Drawing.Size(464, 323);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_ChunkSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSettings_Processes)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabSYRMEP_HPC.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TabPage tabSYRMEP_HPC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txbSYRMEP_HPC_Output;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbSYRMEP_HPC_Temp;
        private System.Windows.Forms.TextBox txbSYRMEP_HPC_Input;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbSYRMEP_HPC_Output_LocallyMapped;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbSYRMEP_HPC_Temp_LocallyMapped;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txbSYRMEP_HPC_Input_LocallyMapped;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}