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
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTIFF2TDF = new System.Windows.Forms.ToolStripMenuItem();
            this.convertHISToTDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertEDFsToEDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuTDF2TIFF = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionPreprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalizedDEIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.openSourceLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.zTiming_ToolStripLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.mStatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.vNavPane1 = new VIBlend.WinForms.Controls.vNavPane();
            this.vNavPaneItem1 = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.gbxDatasetInfo_Preview = new System.Windows.Forms.GroupBox();
            this.nudDatasetTab_Dark = new System.Windows.Forms.NumericUpDown();
            this.lblDatasetTab_Dark = new System.Windows.Forms.Label();
            this.btnDatasetTabPreviewDark = new System.Windows.Forms.Button();
            this.nudDatasetTab_Flat = new System.Windows.Forms.NumericUpDown();
            this.lblDatasetTab_Flat = new System.Windows.Forms.Label();
            this.btnDatasetTabPreviewFlat = new System.Windows.Forms.Button();
            this.nudDatasetTab_Sinogram = new System.Windows.Forms.NumericUpDown();
            this.lblDatasetTab_Sinogram = new System.Windows.Forms.Label();
            this.btnDatasetTabPreviewSinogram = new System.Windows.Forms.Button();
            this.nudDatasetTab_Projection = new System.Windows.Forms.NumericUpDown();
            this.lblDatasetTab_Projection = new System.Windows.Forms.Label();
            this.btnDatasetTabPreviewProjection = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbxDatasetInfo_Input = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.gbxDatasetInfo_Metadata = new System.Windows.Forms.GroupBox();
            this.lblMetadata_PixelSize = new System.Windows.Forms.Label();
            this.lblMetadata_NrProjections = new System.Windows.Forms.Label();
            this.lblMetadata_FOV = new System.Windows.Forms.Label();
            this.lblMetadata_Dataset = new System.Windows.Forms.Label();
            this.lblMetadata_Experiment = new System.Windows.Forms.Label();
            this.lblMetadata_Distance = new System.Windows.Forms.Label();
            this.lblMetadata_Energy = new System.Windows.Forms.Label();
            this.vNavPaneItem3 = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.gbxPreProcessing_Execute = new System.Windows.Forms.GroupBox();
            this.lblPreProcessing_Output = new System.Windows.Forms.Label();
            this.lblPreProcessing_ExecuteOutput = new System.Windows.Forms.Label();
            this.btnPreProcessing_ExecuteRun = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxPreProcessing_Input = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.chkExtFOVAverage = new System.Windows.Forms.CheckBox();
            this.chkExtFOVNormalize = new System.Windows.Forms.CheckBox();
            this.btnPreProcess_GuessOverlap = new System.Windows.Forms.Button();
            this.chkExtFOV_AirRight = new System.Windows.Forms.CheckBox();
            this.nudExtendedFOVOverlap = new System.Windows.Forms.NumericUpDown();
            this.chkExtendedFOV = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.nudRingRemParam2 = new System.Windows.Forms.NumericUpDown();
            this.nudRingRemParam1 = new System.Windows.Forms.NumericUpDown();
            this.lblRingRemParam1 = new System.Windows.Forms.Label();
            this.lblRingRemParam2 = new System.Windows.Forms.Label();
            this.cbxRingRem = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.nudHalfHalfMode = new System.Windows.Forms.NumericUpDown();
            this.chkHalfHalfMode = new System.Windows.Forms.CheckBox();
            this.chkDarkFlatEnd = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.nudNormSx = new System.Windows.Forms.NumericUpDown();
            this.nudNormDx = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.cbxFlatField = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.gbxPreProcessing_Preview = new System.Windows.Forms.GroupBox();
            this.btnPreprocessingTab_Preview = new System.Windows.Forms.Button();
            this.nudPreprocessingTab_Preview = new System.Windows.Forms.NumericUpDown();
            this.lblPreprocessingTab_Preview = new System.Windows.Forms.Label();
            this.vNavPaneItem7 = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.gbxPhaseRetrieval_Preview = new System.Windows.Forms.GroupBox();
            this.btnPhaseretrievalTab_Preview = new System.Windows.Forms.Button();
            this.nudPhaseretrievalTab_ProjectionPreview = new System.Windows.Forms.NumericUpDown();
            this.lblPhaseRetrievalTab_Projection = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.cbxPhaseRetrieval_Input = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.gbxPhaseRetrieval_Execution = new System.Windows.Forms.GroupBox();
            this.lblPhaseRetrieval_Output = new System.Windows.Forms.Label();
            this.lblPhaseRetrieval_ExecuteOutput = new System.Windows.Forms.Label();
            this.btnPhaseRetrieval_ExecuteRun = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkPhaseRetrievalTab_OverPadding = new System.Windows.Forms.CheckBox();
            this.lblDeltaBetaRatio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudPhaseRetrievalTab_BetaExp = new System.Windows.Forms.NumericUpDown();
            this.nudPhaseRetrievalTab_DeltaExp = new System.Windows.Forms.NumericUpDown();
            this.nudPhaseRetrievalTab_Beta = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.nudPhaseRetrievalTab_Delta = new System.Windows.Forms.NumericUpDown();
            this.nudPhaseRetrievalTab_PixelSize = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.cbxPhaseRetrievalTab_Algorithms = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.nudPhaseRetrievalTab_Distance = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.nudPhaseRetrievalTab_Energy = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.vNavPaneItem4 = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.gbxRolling = new System.Windows.Forms.GroupBox();
            this.lblRollShift = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudRollShift = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMultipleAngles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAnglesProjTo = new System.Windows.Forms.NumericUpDown();
            this.nudAnglesProjFrom = new System.Windows.Forms.NumericUpDown();
            this.label62 = new System.Windows.Forms.Label();
            this.nudAngles = new System.Windows.Forms.NumericUpDown();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.chkPhrtOnTheFly = new System.Windows.Forms.CheckBox();
            this.btnReconstructionTab_Preview = new System.Windows.Forms.Button();
            this.nudReconstructionTab_Slice = new System.Windows.Forms.NumericUpDown();
            this.lblReconstructionTab_Slice = new System.Windows.Forms.Label();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.nudReconstructionTab_Downscale = new System.Windows.Forms.NumericUpDown();
            this.label35 = new System.Windows.Forms.Label();
            this.nudReconstructionTab_Decimate = new System.Windows.Forms.NumericUpDown();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.chkReconstructionTab_PostProcess = new System.Windows.Forms.CheckBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnMultipleCenters = new System.Windows.Forms.Button();
            this.btnReconstructionGuess = new System.Windows.Forms.Button();
            this.label58 = new System.Windows.Forms.Label();
            this.nudCenter_Middle = new System.Windows.Forms.NumericUpDown();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.nudCorrectionOffset = new System.Windows.Forms.NumericUpDown();
            this.chkCorrectionOffset = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.nudLambdaExp = new System.Windows.Forms.NumericUpDown();
            this.nudLambdaBase = new System.Windows.Forms.NumericUpDown();
            this.lblLambdaTenTo = new System.Windows.Forms.Label();
            this.nudFISTAReconIter = new System.Windows.Forms.NumericUpDown();
            this.nudFISTAFGPIter = new System.Windows.Forms.NumericUpDown();
            this.lblFISTAReconIter = new System.Windows.Forms.Label();
            this.lblFISTAFGPIter = new System.Windows.Forms.Label();
            this.nudGridRec = new System.Windows.Forms.NumericUpDown();
            this.cbxAlgorithmParameterFilter = new System.Windows.Forms.ComboBox();
            this.nudAlgorithmParameterIterations = new System.Windows.Forms.NumericUpDown();
            this.lblAlgorithmParameter = new System.Windows.Forms.Label();
            this.chkZeroneMode = new System.Windows.Forms.CheckBox();
            this.chkLogTransform = new System.Windows.Forms.CheckBox();
            this.chkOverPadding = new System.Windows.Forms.CheckBox();
            this.chkCircleMask = new System.Windows.Forms.CheckBox();
            this.cbxAlgorithm = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.chkApplyPreProcessing = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxDatasetName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblReconstructionOutputPath = new System.Windows.Forms.Label();
            this.btnReconstructionTab_ExecuteRunAll = new System.Windows.Forms.Button();
            this.lblReconstructionTab_ExecuteTo = new System.Windows.Forms.Label();
            this.lblExecutionOutput = new System.Windows.Forms.Label();
            this.nudReconstructionTab_ExecuteTo = new System.Windows.Forms.NumericUpDown();
            this.nudReconstructionTab_ExecuteFrom = new System.Windows.Forms.NumericUpDown();
            this.lblReconstructionTab_ExecuteFrom = new System.Windows.Forms.Label();
            this.btnReconstructionTab_ExecuteRunSubset = new System.Windows.Forms.Button();
            this.vNavPaneItem8 = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.gbxPostProcessingTab_Execute = new System.Windows.Forms.GroupBox();
            this.txbPostProcessingTab_OutputPath = new System.Windows.Forms.TextBox();
            this.btnPostProcessinTab_BrowseOutput = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btnPostProcessingTab_RunAll = new System.Windows.Forms.Button();
            this.lblPostProcessingTab_To = new System.Windows.Forms.Label();
            this.nudPostProcessingTab_ExecuteTo = new System.Windows.Forms.NumericUpDown();
            this.nudPostProcessingTab_ExecuteFrom = new System.Windows.Forms.NumericUpDown();
            this.lblPostProcessingTab_From = new System.Windows.Forms.Label();
            this.btnPostProcessingTab_RunSubset = new System.Windows.Forms.Button();
            this.gbxPostProcessingTab_Preview = new System.Windows.Forms.GroupBox();
            this.btnPostProcessingTab_Preview = new System.Windows.Forms.Button();
            this.nudPostProcessingTab_PreviewSlice = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.txbPostProcessingTab_InputFolder = new System.Windows.Forms.TextBox();
            this.btnPostProcessingTab_BrowseInput = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.nudConvertToTDF_CropRight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudConvertToTDF_CropLeft = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.nudConvertToTDF_CropBottom = new System.Windows.Forms.NumericUpDown();
            this.nudConvertToTDF_CropTop = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxPostProcessingTab_MethodSettings = new System.Windows.Forms.GroupBox();
            this.btnPostProcessingTab_AutoLimit = new System.Windows.Forms.Button();
            this.txbPostProcessingTab_LinearRescaleMin = new System.Windows.Forms.TextBox();
            this.txbPostProcessingTab_LinearRescaleMax = new System.Windows.Forms.TextBox();
            this.lblPostProcessingTab_LinearRescaleMax = new System.Windows.Forms.Label();
            this.lblPostProcessingTab_LinearRescaleMin = new System.Windows.Forms.Label();
            this.cbxDegradationMethods = new System.Windows.Forms.ComboBox();
            this.label82 = new System.Windows.Forms.Label();
            this.gbxPostProc_PolarFiltr = new System.Windows.Forms.GroupBox();
            this.chkPostProc_PolarLock = new System.Windows.Forms.CheckBox();
            this.nudPostProc_PolarFilt_OverSampl = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nudPostProc_PolarCenterY = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudPostProc_PolarFilter_Param2 = new System.Windows.Forms.NumericUpDown();
            this.nudPostProc_PolarFilter_Param1 = new System.Windows.Forms.NumericUpDown();
            this.lblPostProc_PolarFilt_Param1 = new System.Windows.Forms.Label();
            this.lblPostProc_PolarFilt_Param2 = new System.Windows.Forms.Label();
            this.nudPostProc_PolarCenterX = new System.Windows.Forms.NumericUpDown();
            this.cbxPostProc_PolarFilt_Method = new System.Windows.Forms.ComboBox();
            this.lblPostProc_PolarCenterX = new System.Windows.Forms.Label();
            this.lblPostProc_PolarCenterY = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zInputTIFFsBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.zInputTDFFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.zOutputPathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mJobMonitorBgw = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vNavPaneImage = new VIBlend.WinForms.Controls.vNavPane();
            this.vNavPaneItem2 = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.kpImageViewer1 = new KaiwaProjects.KpImageViewer();
            this.vLogNavPane = new VIBlend.WinForms.Controls.vNavPane();
            this.vNavPaneItem6 = new VIBlend.WinForms.Controls.vNavPaneItem();
            this.zLogTxb = new System.Windows.Forms.TextBox();
            this.vImageNavPane = new VIBlend.WinForms.Controls.vNavPane();
            this.bgwGuessOffset = new System.ComponentModel.BackgroundWorker();
            this.bgwGuessOverlap = new System.ComponentModel.BackgroundWorker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.mBgwPreview = new System.ComponentModel.BackgroundWorker();
            this.bgwAutoLimit = new System.ComponentModel.BackgroundWorker();
            this.mBgwPostProcessingPreview = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.vNavPane1.SuspendLayout();
            this.vNavPaneItem1.ItemPanel.SuspendLayout();
            this.vNavPaneItem1.SuspendLayout();
            this.gbxDatasetInfo_Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Dark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Flat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Sinogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Projection)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.gbxDatasetInfo_Metadata.SuspendLayout();
            this.vNavPaneItem3.ItemPanel.SuspendLayout();
            this.vNavPaneItem3.SuspendLayout();
            this.gbxPreProcessing_Execute.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtendedFOVOverlap)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRingRemParam2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRingRemParam1)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHalfHalfMode)).BeginInit();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormSx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormDx)).BeginInit();
            this.gbxPreProcessing_Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreprocessingTab_Preview)).BeginInit();
            this.vNavPaneItem7.ItemPanel.SuspendLayout();
            this.vNavPaneItem7.SuspendLayout();
            this.gbxPhaseRetrieval_Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseretrievalTab_ProjectionPreview)).BeginInit();
            this.groupBox15.SuspendLayout();
            this.gbxPhaseRetrieval_Execution.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_BetaExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_DeltaExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Beta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Delta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_PixelSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Distance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Energy)).BeginInit();
            this.vNavPaneItem4.ItemPanel.SuspendLayout();
            this.vNavPaneItem4.SuspendLayout();
            this.gbxRolling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRollShift)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnglesProjTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnglesProjFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngles)).BeginInit();
            this.groupBox35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_Slice)).BeginInit();
            this.groupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_Downscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_Decimate)).BeginInit();
            this.groupBox23.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenter_Middle)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCorrectionOffset)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLambdaExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLambdaBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFISTAReconIter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFISTAFGPIter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlgorithmParameterIterations)).BeginInit();
            this.groupBox18.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_ExecuteTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_ExecuteFrom)).BeginInit();
            this.vNavPaneItem8.ItemPanel.SuspendLayout();
            this.vNavPaneItem8.SuspendLayout();
            this.gbxPostProcessingTab_Execute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProcessingTab_ExecuteTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProcessingTab_ExecuteFrom)).BeginInit();
            this.gbxPostProcessingTab_Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProcessingTab_PreviewSlice)).BeginInit();
            this.groupBox22.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropTop)).BeginInit();
            this.gbxPostProcessingTab_MethodSettings.SuspendLayout();
            this.gbxPostProc_PolarFiltr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarFilt_OverSampl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarCenterY)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarFilter_Param2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarFilter_Param1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarCenterX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.vNavPaneImage.SuspendLayout();
            this.vNavPaneItem2.ItemPanel.SuspendLayout();
            this.vNavPaneItem2.SuspendLayout();
            this.vLogNavPane.SuspendLayout();
            this.vNavPaneItem6.ItemPanel.SuspendLayout();
            this.vNavPaneItem6.SuspendLayout();
            this.vImageNavPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            //this.extraToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1185, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTIFF2TDF,
            this.convertHISToTDFToolStripMenuItem,
            this.convertEDFsToEDFToolStripMenuItem,
            this.toolStripMenuItem3,
            this.menuTDF2TIFF});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuTIFF2TDF
            // 
            this.menuTIFF2TDF.Name = "menuTIFF2TDF";
            this.menuTIFF2TDF.Size = new System.Drawing.Size(228, 22);
            this.menuTIFF2TDF.Text = "Convert TIFFs to TDF...";
            this.menuTIFF2TDF.Click += new System.EventHandler(this.menuTIFF2TDF_Click);
            // 
            // convertHISToTDFToolStripMenuItem
            // 
            this.convertHISToTDFToolStripMenuItem.Name = "convertHISToTDFToolStripMenuItem";
            this.convertHISToTDFToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.convertHISToTDFToolStripMenuItem.Text = "Convert HIS to TDF...";
            this.convertHISToTDFToolStripMenuItem.Click += new System.EventHandler(this.convertHISToTDFToolStripMenuItem_Click);
            // 
            // convertEDFsToEDFToolStripMenuItem
            // 
            this.convertEDFsToEDFToolStripMenuItem.Name = "convertEDFsToEDFToolStripMenuItem";
            this.convertEDFsToEDFToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.convertEDFsToEDFToolStripMenuItem.Text = "Convert EDFs to TDF...";
            this.convertEDFsToEDFToolStripMenuItem.Click += new System.EventHandler(this.convertEDFsToEDFToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 6);
            // 
            // menuTDF2TIFF
            // 
            this.menuTDF2TIFF.Name = "menuTDF2TIFF";
            this.menuTDF2TIFF.Size = new System.Drawing.Size(228, 22);
            this.menuTDF2TIFF.Text = "Convert TDF to TIFFs/RAWs...";
            this.menuTDF2TIFF.Click += new System.EventHandler(this.menuTDF2TIFF_Click);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectionPreprocessingToolStripMenuItem,
            this.generalizedDEIToolStripMenuItem});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // projectionPreprocessingToolStripMenuItem
            // 
            this.projectionPreprocessingToolStripMenuItem.Name = "projectionPreprocessingToolStripMenuItem";
            this.projectionPreprocessingToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.projectionPreprocessingToolStripMenuItem.Text = "Projection-domain preprocessing...";
            this.projectionPreprocessingToolStripMenuItem.Click += new System.EventHandler(this.projectionPreprocessingToolStripMenuItem_Click);
            // 
            // generalizedDEIToolStripMenuItem
            // 
            this.generalizedDEIToolStripMenuItem.Name = "generalizedDEIToolStripMenuItem";
            this.generalizedDEIToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.generalizedDEIToolStripMenuItem.Text = "Generalized DEI...";
            this.generalizedDEIToolStripMenuItem.Click += new System.EventHandler(this.generalizedDEIToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.openSourceLicensesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem5.Text = "User\'s Guide...";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(191, 6);
            // 
            // openSourceLicensesToolStripMenuItem
            // 
            this.openSourceLicensesToolStripMenuItem.Name = "openSourceLicensesToolStripMenuItem";
            this.openSourceLicensesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.openSourceLicensesToolStripMenuItem.Text = "Open source licenses...";
            this.openSourceLicensesToolStripMenuItem.Click += new System.EventHandler(this.openSourceLicensesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.zTiming_ToolStripLbl,
            this.mStatusBarProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1185, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(458, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zTiming_ToolStripLbl
            // 
            this.zTiming_ToolStripLbl.Name = "zTiming_ToolStripLbl";
            this.zTiming_ToolStripLbl.Size = new System.Drawing.Size(610, 17);
            this.zTiming_ToolStripLbl.Spring = true;
            this.zTiming_ToolStripLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mStatusBarProgressBar
            // 
            this.mStatusBarProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mStatusBarProgressBar.Name = "mStatusBarProgressBar";
            this.mStatusBarProgressBar.Size = new System.Drawing.Size(100, 16);
            this.mStatusBarProgressBar.DoubleClick += new System.EventHandler(this.mStatusBarProgressBar_DoubleClick);
            // 
            // vNavPane1
            // 
            this.vNavPane1.Controls.Add(this.vNavPaneItem1);
            this.vNavPane1.Controls.Add(this.vNavPaneItem3);
            this.vNavPane1.Controls.Add(this.vNavPaneItem7);
            this.vNavPane1.Controls.Add(this.vNavPaneItem4);
            this.vNavPane1.Controls.Add(this.vNavPaneItem8);
            this.vNavPane1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vNavPane1.Items.Add(this.vNavPaneItem1);
            this.vNavPane1.Items.Add(this.vNavPaneItem3);
            this.vNavPane1.Items.Add(this.vNavPaneItem7);
            this.vNavPane1.Items.Add(this.vNavPaneItem4);
            this.vNavPane1.Items.Add(this.vNavPaneItem8);
            this.vNavPane1.Location = new System.Drawing.Point(0, 24);
            this.vNavPane1.Name = "vNavPane1";
            this.vNavPane1.Size = new System.Drawing.Size(454, 687);
            this.vNavPane1.TabIndex = 3;
            this.vNavPane1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // vNavPaneItem1
            // 
            this.vNavPaneItem1.BackColor = System.Drawing.Color.White;
            this.vNavPaneItem1.HeaderText = "Dataset Info / Preview ";
            // 
            // vNavPaneItem1.ItemPanel
            // 
            this.vNavPaneItem1.ItemPanel.AutoScroll = true;
            this.vNavPaneItem1.ItemPanel.Controls.Add(this.gbxDatasetInfo_Preview);
            this.vNavPaneItem1.ItemPanel.Controls.Add(this.groupBox5);
            this.vNavPaneItem1.ItemPanel.Controls.Add(this.gbxDatasetInfo_Metadata);
            this.vNavPaneItem1.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItem1.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItem1.ItemPanel.Size = new System.Drawing.Size(452, 536);
            this.vNavPaneItem1.ItemPanel.TabIndex = 1;
            this.vNavPaneItem1.Location = new System.Drawing.Point(0, 0);
            this.vNavPaneItem1.Name = "vNavPaneItem1";
            this.vNavPaneItem1.Size = new System.Drawing.Size(454, 567);
            this.vNavPaneItem1.TabIndex = 0;
            this.vNavPaneItem1.Text = "vProjectPaneItem";
            this.vNavPaneItem1.TooltipText = "Dataset";
            // 
            // gbxDatasetInfo_Preview
            // 
            this.gbxDatasetInfo_Preview.Controls.Add(this.nudDatasetTab_Dark);
            this.gbxDatasetInfo_Preview.Controls.Add(this.lblDatasetTab_Dark);
            this.gbxDatasetInfo_Preview.Controls.Add(this.btnDatasetTabPreviewDark);
            this.gbxDatasetInfo_Preview.Controls.Add(this.nudDatasetTab_Flat);
            this.gbxDatasetInfo_Preview.Controls.Add(this.lblDatasetTab_Flat);
            this.gbxDatasetInfo_Preview.Controls.Add(this.btnDatasetTabPreviewFlat);
            this.gbxDatasetInfo_Preview.Controls.Add(this.nudDatasetTab_Sinogram);
            this.gbxDatasetInfo_Preview.Controls.Add(this.lblDatasetTab_Sinogram);
            this.gbxDatasetInfo_Preview.Controls.Add(this.btnDatasetTabPreviewSinogram);
            this.gbxDatasetInfo_Preview.Controls.Add(this.nudDatasetTab_Projection);
            this.gbxDatasetInfo_Preview.Controls.Add(this.lblDatasetTab_Projection);
            this.gbxDatasetInfo_Preview.Controls.Add(this.btnDatasetTabPreviewProjection);
            this.gbxDatasetInfo_Preview.Enabled = false;
            this.gbxDatasetInfo_Preview.Location = new System.Drawing.Point(23, 82);
            this.gbxDatasetInfo_Preview.Name = "gbxDatasetInfo_Preview";
            this.gbxDatasetInfo_Preview.Size = new System.Drawing.Size(404, 86);
            this.gbxDatasetInfo_Preview.TabIndex = 2;
            this.gbxDatasetInfo_Preview.TabStop = false;
            this.gbxDatasetInfo_Preview.Text = "Preview";
            // 
            // nudDatasetTab_Dark
            // 
            this.nudDatasetTab_Dark.Enabled = false;
            this.nudDatasetTab_Dark.Location = new System.Drawing.Point(257, 52);
            this.nudDatasetTab_Dark.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDatasetTab_Dark.Name = "nudDatasetTab_Dark";
            this.nudDatasetTab_Dark.Size = new System.Drawing.Size(50, 20);
            this.nudDatasetTab_Dark.TabIndex = 7;
            this.nudDatasetTab_Dark.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDatasetTab_Dark
            // 
            this.lblDatasetTab_Dark.AutoSize = true;
            this.lblDatasetTab_Dark.Enabled = false;
            this.lblDatasetTab_Dark.Location = new System.Drawing.Point(223, 55);
            this.lblDatasetTab_Dark.Name = "lblDatasetTab_Dark";
            this.lblDatasetTab_Dark.Size = new System.Drawing.Size(33, 13);
            this.lblDatasetTab_Dark.TabIndex = 35;
            this.lblDatasetTab_Dark.Text = "Dark:";
            // 
            // btnDatasetTabPreviewDark
            // 
            this.btnDatasetTabPreviewDark.Enabled = false;
            this.btnDatasetTabPreviewDark.Location = new System.Drawing.Point(319, 51);
            this.btnDatasetTabPreviewDark.Name = "btnDatasetTabPreviewDark";
            this.btnDatasetTabPreviewDark.Size = new System.Drawing.Size(75, 23);
            this.btnDatasetTabPreviewDark.TabIndex = 8;
            this.btnDatasetTabPreviewDark.Text = "Preview";
            this.btnDatasetTabPreviewDark.UseVisualStyleBackColor = true;
            this.btnDatasetTabPreviewDark.Click += new System.EventHandler(this.btnDatasetTabPreviewDark_Click);
            // 
            // nudDatasetTab_Flat
            // 
            this.nudDatasetTab_Flat.Enabled = false;
            this.nudDatasetTab_Flat.Location = new System.Drawing.Point(257, 23);
            this.nudDatasetTab_Flat.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDatasetTab_Flat.Name = "nudDatasetTab_Flat";
            this.nudDatasetTab_Flat.Size = new System.Drawing.Size(50, 20);
            this.nudDatasetTab_Flat.TabIndex = 5;
            this.nudDatasetTab_Flat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDatasetTab_Flat
            // 
            this.lblDatasetTab_Flat.AutoSize = true;
            this.lblDatasetTab_Flat.Enabled = false;
            this.lblDatasetTab_Flat.Location = new System.Drawing.Point(228, 25);
            this.lblDatasetTab_Flat.Name = "lblDatasetTab_Flat";
            this.lblDatasetTab_Flat.Size = new System.Drawing.Size(27, 13);
            this.lblDatasetTab_Flat.TabIndex = 33;
            this.lblDatasetTab_Flat.Text = "Flat:";
            // 
            // btnDatasetTabPreviewFlat
            // 
            this.btnDatasetTabPreviewFlat.Enabled = false;
            this.btnDatasetTabPreviewFlat.Location = new System.Drawing.Point(319, 21);
            this.btnDatasetTabPreviewFlat.Name = "btnDatasetTabPreviewFlat";
            this.btnDatasetTabPreviewFlat.Size = new System.Drawing.Size(75, 23);
            this.btnDatasetTabPreviewFlat.TabIndex = 6;
            this.btnDatasetTabPreviewFlat.Text = "Preview";
            this.btnDatasetTabPreviewFlat.UseVisualStyleBackColor = true;
            this.btnDatasetTabPreviewFlat.Click += new System.EventHandler(this.btnDatasetTabPreviewFlat_Click);
            // 
            // nudDatasetTab_Sinogram
            // 
            this.nudDatasetTab_Sinogram.Enabled = false;
            this.nudDatasetTab_Sinogram.Location = new System.Drawing.Point(66, 52);
            this.nudDatasetTab_Sinogram.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDatasetTab_Sinogram.Name = "nudDatasetTab_Sinogram";
            this.nudDatasetTab_Sinogram.Size = new System.Drawing.Size(50, 20);
            this.nudDatasetTab_Sinogram.TabIndex = 3;
            this.nudDatasetTab_Sinogram.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDatasetTab_Sinogram
            // 
            this.lblDatasetTab_Sinogram.AutoSize = true;
            this.lblDatasetTab_Sinogram.Enabled = false;
            this.lblDatasetTab_Sinogram.Location = new System.Drawing.Point(12, 55);
            this.lblDatasetTab_Sinogram.Name = "lblDatasetTab_Sinogram";
            this.lblDatasetTab_Sinogram.Size = new System.Drawing.Size(54, 13);
            this.lblDatasetTab_Sinogram.TabIndex = 29;
            this.lblDatasetTab_Sinogram.Text = "Sinogram:";
            // 
            // btnDatasetTabPreviewSinogram
            // 
            this.btnDatasetTabPreviewSinogram.Enabled = false;
            this.btnDatasetTabPreviewSinogram.Location = new System.Drawing.Point(128, 51);
            this.btnDatasetTabPreviewSinogram.Name = "btnDatasetTabPreviewSinogram";
            this.btnDatasetTabPreviewSinogram.Size = new System.Drawing.Size(75, 23);
            this.btnDatasetTabPreviewSinogram.TabIndex = 4;
            this.btnDatasetTabPreviewSinogram.Text = "Preview";
            this.btnDatasetTabPreviewSinogram.UseVisualStyleBackColor = true;
            this.btnDatasetTabPreviewSinogram.Click += new System.EventHandler(this.btnDatasetTabPreviewSinogram_Click);
            // 
            // nudDatasetTab_Projection
            // 
            this.nudDatasetTab_Projection.Enabled = false;
            this.nudDatasetTab_Projection.Location = new System.Drawing.Point(66, 23);
            this.nudDatasetTab_Projection.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudDatasetTab_Projection.Name = "nudDatasetTab_Projection";
            this.nudDatasetTab_Projection.Size = new System.Drawing.Size(50, 20);
            this.nudDatasetTab_Projection.TabIndex = 1;
            this.nudDatasetTab_Projection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDatasetTab_Projection
            // 
            this.lblDatasetTab_Projection.AutoSize = true;
            this.lblDatasetTab_Projection.Enabled = false;
            this.lblDatasetTab_Projection.Location = new System.Drawing.Point(9, 25);
            this.lblDatasetTab_Projection.Name = "lblDatasetTab_Projection";
            this.lblDatasetTab_Projection.Size = new System.Drawing.Size(57, 13);
            this.lblDatasetTab_Projection.TabIndex = 25;
            this.lblDatasetTab_Projection.Text = "Projection:";
            // 
            // btnDatasetTabPreviewProjection
            // 
            this.btnDatasetTabPreviewProjection.Enabled = false;
            this.btnDatasetTabPreviewProjection.Location = new System.Drawing.Point(128, 21);
            this.btnDatasetTabPreviewProjection.Name = "btnDatasetTabPreviewProjection";
            this.btnDatasetTabPreviewProjection.Size = new System.Drawing.Size(75, 23);
            this.btnDatasetTabPreviewProjection.TabIndex = 2;
            this.btnDatasetTabPreviewProjection.Text = "Preview";
            this.btnDatasetTabPreviewProjection.UseVisualStyleBackColor = true;
            this.btnDatasetTabPreviewProjection.Click += new System.EventHandler(this.btnDatasetTabPreviewProjection_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbxDatasetInfo_Input);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Location = new System.Drawing.Point(22, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(404, 59);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dataset";
            // 
            // cbxDatasetInfo_Input
            // 
            this.cbxDatasetInfo_Input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatasetInfo_Input.FormattingEnabled = true;
            this.cbxDatasetInfo_Input.Location = new System.Drawing.Point(67, 22);
            this.cbxDatasetInfo_Input.Name = "cbxDatasetInfo_Input";
            this.cbxDatasetInfo_Input.Size = new System.Drawing.Size(327, 21);
            this.cbxDatasetInfo_Input.TabIndex = 0;
            this.cbxDatasetInfo_Input.DropDownClosed += new System.EventHandler(this.cbxDatasetInfo_Input_DropDownClosed);
            this.cbxDatasetInfo_Input.Click += new System.EventHandler(this.cbxPreProcessing_Input_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "TDF File:";
            // 
            // gbxDatasetInfo_Metadata
            // 
            this.gbxDatasetInfo_Metadata.Controls.Add(this.lblMetadata_PixelSize);
            this.gbxDatasetInfo_Metadata.Controls.Add(this.lblMetadata_NrProjections);
            this.gbxDatasetInfo_Metadata.Controls.Add(this.lblMetadata_FOV);
            this.gbxDatasetInfo_Metadata.Controls.Add(this.lblMetadata_Dataset);
            this.gbxDatasetInfo_Metadata.Controls.Add(this.lblMetadata_Experiment);
            this.gbxDatasetInfo_Metadata.Controls.Add(this.lblMetadata_Distance);
            this.gbxDatasetInfo_Metadata.Controls.Add(this.lblMetadata_Energy);
            this.gbxDatasetInfo_Metadata.Enabled = false;
            this.gbxDatasetInfo_Metadata.Location = new System.Drawing.Point(23, 174);
            this.gbxDatasetInfo_Metadata.Name = "gbxDatasetInfo_Metadata";
            this.gbxDatasetInfo_Metadata.Size = new System.Drawing.Size(405, 189);
            this.gbxDatasetInfo_Metadata.TabIndex = 0;
            this.gbxDatasetInfo_Metadata.TabStop = false;
            this.gbxDatasetInfo_Metadata.Text = "Metadata";
            // 
            // lblMetadata_PixelSize
            // 
            this.lblMetadata_PixelSize.AutoSize = true;
            this.lblMetadata_PixelSize.Location = new System.Drawing.Point(40, 158);
            this.lblMetadata_PixelSize.Name = "lblMetadata_PixelSize";
            this.lblMetadata_PixelSize.Size = new System.Drawing.Size(53, 13);
            this.lblMetadata_PixelSize.TabIndex = 31;
            this.lblMetadata_PixelSize.Text = "Pixel size:";
            // 
            // lblMetadata_NrProjections
            // 
            this.lblMetadata_NrProjections.AutoSize = true;
            this.lblMetadata_NrProjections.Location = new System.Drawing.Point(4, 93);
            this.lblMetadata_NrProjections.Name = "lblMetadata_NrProjections";
            this.lblMetadata_NrProjections.Size = new System.Drawing.Size(90, 13);
            this.lblMetadata_NrProjections.TabIndex = 30;
            this.lblMetadata_NrProjections.Text = "Nr. of projections:";
            // 
            // lblMetadata_FOV
            // 
            this.lblMetadata_FOV.AutoSize = true;
            this.lblMetadata_FOV.Location = new System.Drawing.Point(62, 71);
            this.lblMetadata_FOV.Name = "lblMetadata_FOV";
            this.lblMetadata_FOV.Size = new System.Drawing.Size(31, 13);
            this.lblMetadata_FOV.TabIndex = 29;
            this.lblMetadata_FOV.Text = "FOV:";
            // 
            // lblMetadata_Dataset
            // 
            this.lblMetadata_Dataset.AutoSize = true;
            this.lblMetadata_Dataset.Location = new System.Drawing.Point(47, 47);
            this.lblMetadata_Dataset.Name = "lblMetadata_Dataset";
            this.lblMetadata_Dataset.Size = new System.Drawing.Size(47, 13);
            this.lblMetadata_Dataset.TabIndex = 28;
            this.lblMetadata_Dataset.Text = "Dataset:";
            // 
            // lblMetadata_Experiment
            // 
            this.lblMetadata_Experiment.AutoSize = true;
            this.lblMetadata_Experiment.Location = new System.Drawing.Point(33, 25);
            this.lblMetadata_Experiment.Name = "lblMetadata_Experiment";
            this.lblMetadata_Experiment.Size = new System.Drawing.Size(62, 13);
            this.lblMetadata_Experiment.TabIndex = 27;
            this.lblMetadata_Experiment.Text = "Experiment:";
            // 
            // lblMetadata_Distance
            // 
            this.lblMetadata_Distance.AutoSize = true;
            this.lblMetadata_Distance.Location = new System.Drawing.Point(41, 136);
            this.lblMetadata_Distance.Name = "lblMetadata_Distance";
            this.lblMetadata_Distance.Size = new System.Drawing.Size(52, 13);
            this.lblMetadata_Distance.TabIndex = 9;
            this.lblMetadata_Distance.Text = "Distance:";
            // 
            // lblMetadata_Energy
            // 
            this.lblMetadata_Energy.AutoSize = true;
            this.lblMetadata_Energy.Location = new System.Drawing.Point(50, 115);
            this.lblMetadata_Energy.Name = "lblMetadata_Energy";
            this.lblMetadata_Energy.Size = new System.Drawing.Size(43, 13);
            this.lblMetadata_Energy.TabIndex = 7;
            this.lblMetadata_Energy.Text = "Energy:";
            // 
            // vNavPaneItem3
            // 
            this.vNavPaneItem3.BackColor = System.Drawing.Color.White;
            this.vNavPaneItem3.HeaderText = "Pre-processing";
            // 
            // vNavPaneItem3.ItemPanel
            // 
            this.vNavPaneItem3.ItemPanel.AutoScroll = true;
            this.vNavPaneItem3.ItemPanel.Controls.Add(this.gbxPreProcessing_Execute);
            this.vNavPaneItem3.ItemPanel.Controls.Add(this.groupBox3);
            this.vNavPaneItem3.ItemPanel.Controls.Add(this.groupBox28);
            this.vNavPaneItem3.ItemPanel.Controls.Add(this.groupBox8);
            this.vNavPaneItem3.ItemPanel.Controls.Add(this.groupBox12);
            this.vNavPaneItem3.ItemPanel.Controls.Add(this.gbxPreProcessing_Preview);
            this.vNavPaneItem3.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItem3.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItem3.ItemPanel.Size = new System.Drawing.Size(452, 0);
            this.vNavPaneItem3.ItemPanel.TabIndex = 1;
            this.vNavPaneItem3.Location = new System.Drawing.Point(0, 567);
            this.vNavPaneItem3.Name = "vNavPaneItem3";
            this.vNavPaneItem3.Size = new System.Drawing.Size(454, 30);
            this.vNavPaneItem3.TabIndex = 2;
            this.vNavPaneItem3.Text = "vProjectionsPaneItem";
            this.vNavPaneItem3.TooltipText = "Pre-processing";
            // 
            // gbxPreProcessing_Execute
            // 
            this.gbxPreProcessing_Execute.Controls.Add(this.lblPreProcessing_Output);
            this.gbxPreProcessing_Execute.Controls.Add(this.lblPreProcessing_ExecuteOutput);
            this.gbxPreProcessing_Execute.Controls.Add(this.btnPreProcessing_ExecuteRun);
            this.gbxPreProcessing_Execute.Enabled = false;
            this.gbxPreProcessing_Execute.Location = new System.Drawing.Point(20, 463);
            this.gbxPreProcessing_Execute.Name = "gbxPreProcessing_Execute";
            this.gbxPreProcessing_Execute.Size = new System.Drawing.Size(404, 52);
            this.gbxPreProcessing_Execute.TabIndex = 8;
            this.gbxPreProcessing_Execute.TabStop = false;
            this.gbxPreProcessing_Execute.Text = "Execute";
            // 
            // lblPreProcessing_Output
            // 
            this.lblPreProcessing_Output.Location = new System.Drawing.Point(63, 22);
            this.lblPreProcessing_Output.Name = "lblPreProcessing_Output";
            this.lblPreProcessing_Output.Size = new System.Drawing.Size(235, 13);
            this.lblPreProcessing_Output.TabIndex = 18;
            // 
            // lblPreProcessing_ExecuteOutput
            // 
            this.lblPreProcessing_ExecuteOutput.AutoSize = true;
            this.lblPreProcessing_ExecuteOutput.Location = new System.Drawing.Point(17, 22);
            this.lblPreProcessing_ExecuteOutput.Name = "lblPreProcessing_ExecuteOutput";
            this.lblPreProcessing_ExecuteOutput.Size = new System.Drawing.Size(42, 13);
            this.lblPreProcessing_ExecuteOutput.TabIndex = 17;
            this.lblPreProcessing_ExecuteOutput.Text = "Output:";
            // 
            // btnPreProcessing_ExecuteRun
            // 
            this.btnPreProcessing_ExecuteRun.Location = new System.Drawing.Point(316, 17);
            this.btnPreProcessing_ExecuteRun.Name = "btnPreProcessing_ExecuteRun";
            this.btnPreProcessing_ExecuteRun.Size = new System.Drawing.Size(75, 23);
            this.btnPreProcessing_ExecuteRun.TabIndex = 27;
            this.btnPreProcessing_ExecuteRun.Text = "Run";
            this.btnPreProcessing_ExecuteRun.UseVisualStyleBackColor = true;
            this.btnPreProcessing_ExecuteRun.Click += new System.EventHandler(this.btnPreProcessingExecution_RunAll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxPreProcessing_Input);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(20, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dataset";
            // 
            // cbxPreProcessing_Input
            // 
            this.cbxPreProcessing_Input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPreProcessing_Input.FormattingEnabled = true;
            this.cbxPreProcessing_Input.Location = new System.Drawing.Point(62, 19);
            this.cbxPreProcessing_Input.Name = "cbxPreProcessing_Input";
            this.cbxPreProcessing_Input.Size = new System.Drawing.Size(331, 21);
            this.cbxPreProcessing_Input.TabIndex = 9;
            this.cbxPreProcessing_Input.DropDownClosed += new System.EventHandler(this.cbxPreProcessing_Input_DropDownClosed);
            this.cbxPreProcessing_Input.Click += new System.EventHandler(this.cbxPreProcessing_Input_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "TDF File:";
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.chkExtFOVAverage);
            this.groupBox28.Controls.Add(this.chkExtFOVNormalize);
            this.groupBox28.Controls.Add(this.btnPreProcess_GuessOverlap);
            this.groupBox28.Controls.Add(this.chkExtFOV_AirRight);
            this.groupBox28.Controls.Add(this.nudExtendedFOVOverlap);
            this.groupBox28.Controls.Add(this.chkExtendedFOV);
            this.groupBox28.Enabled = false;
            this.groupBox28.Location = new System.Drawing.Point(20, 178);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(404, 110);
            this.groupBox28.TabIndex = 5;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Extended Field Of View (FOV)";
            // 
            // chkExtFOVAverage
            // 
            this.chkExtFOVAverage.AutoSize = true;
            this.chkExtFOVAverage.Enabled = false;
            this.chkExtFOVAverage.Location = new System.Drawing.Point(62, 85);
            this.chkExtFOVAverage.Name = "chkExtFOVAverage";
            this.chkExtFOVAverage.Size = new System.Drawing.Size(146, 17);
            this.chkExtFOVAverage.TabIndex = 20;
            this.chkExtFOVAverage.Text = "Average the overlap area";
            this.chkExtFOVAverage.UseVisualStyleBackColor = true;
            // 
            // chkExtFOVNormalize
            // 
            this.chkExtFOVNormalize.AutoSize = true;
            this.chkExtFOVNormalize.Enabled = false;
            this.chkExtFOVNormalize.Location = new System.Drawing.Point(62, 64);
            this.chkExtFOVNormalize.Name = "chkExtFOVNormalize";
            this.chkExtFOVNormalize.Size = new System.Drawing.Size(305, 17);
            this.chkExtFOVNormalize.TabIndex = 19;
            this.chkExtFOVNormalize.Text = "Apply line-by-line normalization considering the overlap area";
            this.chkExtFOVNormalize.UseVisualStyleBackColor = true;
            // 
            // btnPreProcess_GuessOverlap
            // 
            this.btnPreProcess_GuessOverlap.Enabled = false;
            this.btnPreProcess_GuessOverlap.Location = new System.Drawing.Point(316, 19);
            this.btnPreProcess_GuessOverlap.Name = "btnPreProcess_GuessOverlap";
            this.btnPreProcess_GuessOverlap.Size = new System.Drawing.Size(75, 23);
            this.btnPreProcess_GuessOverlap.TabIndex = 21;
            this.btnPreProcess_GuessOverlap.Text = "Guess";
            this.btnPreProcess_GuessOverlap.UseVisualStyleBackColor = true;
            this.btnPreProcess_GuessOverlap.Click += new System.EventHandler(this.btnPreProcess_GuessOverlap_Click);
            // 
            // chkExtFOV_AirRight
            // 
            this.chkExtFOV_AirRight.AutoSize = true;
            this.chkExtFOV_AirRight.Enabled = false;
            this.chkExtFOV_AirRight.Location = new System.Drawing.Point(62, 43);
            this.chkExtFOV_AirRight.Name = "chkExtFOV_AirRight";
            this.chkExtFOV_AirRight.Size = new System.Drawing.Size(199, 17);
            this.chkExtFOV_AirRight.TabIndex = 18;
            this.chkExtFOV_AirRight.Text = "Off-center on the left side of the FOV";
            this.chkExtFOV_AirRight.UseVisualStyleBackColor = true;
            this.chkExtFOV_AirRight.CheckedChanged += new System.EventHandler(this.chkExtFOV_AirRight_CheckedChanged);
            // 
            // nudExtendedFOVOverlap
            // 
            this.nudExtendedFOVOverlap.Enabled = false;
            this.nudExtendedFOVOverlap.Location = new System.Drawing.Point(213, 20);
            this.nudExtendedFOVOverlap.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudExtendedFOVOverlap.Name = "nudExtendedFOVOverlap";
            this.nudExtendedFOVOverlap.Size = new System.Drawing.Size(50, 20);
            this.nudExtendedFOVOverlap.TabIndex = 17;
            this.nudExtendedFOVOverlap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkExtendedFOV
            // 
            this.chkExtendedFOV.AutoSize = true;
            this.chkExtendedFOV.Location = new System.Drawing.Point(43, 22);
            this.chkExtendedFOV.Name = "chkExtendedFOV";
            this.chkExtendedFOV.Size = new System.Drawing.Size(174, 17);
            this.chkExtendedFOV.TabIndex = 16;
            this.chkExtendedFOV.Text = "Extended field of view overlap: ";
            this.chkExtendedFOV.UseVisualStyleBackColor = true;
            this.chkExtendedFOV.CheckedChanged += new System.EventHandler(this.chkExtendedFOV_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.groupBox21);
            this.groupBox8.Controls.Add(this.cbxRingRem);
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.Enabled = false;
            this.groupBox8.Location = new System.Drawing.Point(20, 295);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(404, 97);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "De-striping (ring removal)";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.nudRingRemParam2);
            this.groupBox21.Controls.Add(this.nudRingRemParam1);
            this.groupBox21.Controls.Add(this.lblRingRemParam1);
            this.groupBox21.Controls.Add(this.lblRingRemParam2);
            this.groupBox21.Location = new System.Drawing.Point(271, 12);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(122, 74);
            this.groupBox21.TabIndex = 29;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Parameters";
            // 
            // nudRingRemParam2
            // 
            this.nudRingRemParam2.Location = new System.Drawing.Point(65, 46);
            this.nudRingRemParam2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudRingRemParam2.Name = "nudRingRemParam2";
            this.nudRingRemParam2.Size = new System.Drawing.Size(50, 20);
            this.nudRingRemParam2.TabIndex = 24;
            this.nudRingRemParam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudRingRemParam1
            // 
            this.nudRingRemParam1.Location = new System.Drawing.Point(65, 20);
            this.nudRingRemParam1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudRingRemParam1.Name = "nudRingRemParam1";
            this.nudRingRemParam1.Size = new System.Drawing.Size(50, 20);
            this.nudRingRemParam1.TabIndex = 23;
            this.nudRingRemParam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRingRemParam1
            // 
            this.lblRingRemParam1.Location = new System.Drawing.Point(2, 23);
            this.lblRingRemParam1.Name = "lblRingRemParam1";
            this.lblRingRemParam1.Size = new System.Drawing.Size(63, 13);
            this.lblRingRemParam1.TabIndex = 25;
            this.lblRingRemParam1.Text = "Width:";
            this.lblRingRemParam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRingRemParam2
            // 
            this.lblRingRemParam2.Location = new System.Drawing.Point(2, 49);
            this.lblRingRemParam2.Name = "lblRingRemParam2";
            this.lblRingRemParam2.Size = new System.Drawing.Size(63, 13);
            this.lblRingRemParam2.TabIndex = 26;
            this.lblRingRemParam2.Text = "Sigma:";
            this.lblRingRemParam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxRingRem
            // 
            this.cbxRingRem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRingRem.FormattingEnabled = true;
            this.cbxRingRem.Items.AddRange(new object[] {
            "Flat fielding with air normalization"});
            this.cbxRingRem.Location = new System.Drawing.Point(62, 19);
            this.cbxRingRem.Name = "cbxRingRem";
            this.cbxRingRem.Size = new System.Drawing.Size(201, 21);
            this.cbxRingRem.TabIndex = 22;
            this.cbxRingRem.SelectedIndexChanged += new System.EventHandler(this.cbxRingRem_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(14, 23);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(46, 13);
            this.label38.TabIndex = 28;
            this.label38.Text = "Method:";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.nudHalfHalfMode);
            this.groupBox12.Controls.Add(this.chkHalfHalfMode);
            this.groupBox12.Controls.Add(this.chkDarkFlatEnd);
            this.groupBox12.Controls.Add(this.groupBox17);
            this.groupBox12.Controls.Add(this.cbxFlatField);
            this.groupBox12.Controls.Add(this.label34);
            this.groupBox12.Enabled = false;
            this.groupBox12.Location = new System.Drawing.Point(20, 75);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(404, 96);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Correction/Normalization";
            // 
            // nudHalfHalfMode
            // 
            this.nudHalfHalfMode.Enabled = false;
            this.nudHalfHalfMode.Location = new System.Drawing.Point(213, 63);
            this.nudHalfHalfMode.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudHalfHalfMode.Name = "nudHalfHalfMode";
            this.nudHalfHalfMode.Size = new System.Drawing.Size(50, 20);
            this.nudHalfHalfMode.TabIndex = 13;
            this.nudHalfHalfMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkHalfHalfMode
            // 
            this.chkHalfHalfMode.AutoSize = true;
            this.chkHalfHalfMode.Enabled = false;
            this.chkHalfHalfMode.Location = new System.Drawing.Point(62, 66);
            this.chkHalfHalfMode.Name = "chkHalfHalfMode";
            this.chkHalfHalfMode.Size = new System.Drawing.Size(159, 17);
            this.chkHalfHalfMode.TabIndex = 12;
            this.chkHalfHalfMode.Text = "Use post dark/flat from line: ";
            this.chkHalfHalfMode.UseVisualStyleBackColor = true;
            // 
            // chkDarkFlatEnd
            // 
            this.chkDarkFlatEnd.AutoSize = true;
            this.chkDarkFlatEnd.Location = new System.Drawing.Point(43, 46);
            this.chkDarkFlatEnd.Name = "chkDarkFlatEnd";
            this.chkDarkFlatEnd.Size = new System.Drawing.Size(191, 17);
            this.chkDarkFlatEnd.TabIndex = 11;
            this.chkDarkFlatEnd.Text = "Use post dark/flat images (if found)";
            this.chkDarkFlatEnd.UseVisualStyleBackColor = true;
            this.chkDarkFlatEnd.CheckedChanged += new System.EventHandler(this.chkDarkFlatEnd_CheckedChanged);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.nudNormSx);
            this.groupBox17.Controls.Add(this.nudNormDx);
            this.groupBox17.Controls.Add(this.label52);
            this.groupBox17.Controls.Add(this.label51);
            this.groupBox17.Location = new System.Drawing.Point(271, 10);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(122, 74);
            this.groupBox17.TabIndex = 29;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Parameters";
            // 
            // nudNormSx
            // 
            this.nudNormSx.Location = new System.Drawing.Point(65, 19);
            this.nudNormSx.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudNormSx.Name = "nudNormSx";
            this.nudNormSx.Size = new System.Drawing.Size(50, 20);
            this.nudNormSx.TabIndex = 14;
            this.nudNormSx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNormSx.ValueChanged += new System.EventHandler(this.nudNormSx_ValueChanged);
            // 
            // nudNormDx
            // 
            this.nudNormDx.Location = new System.Drawing.Point(65, 46);
            this.nudNormDx.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudNormDx.Name = "nudNormDx";
            this.nudNormDx.Size = new System.Drawing.Size(50, 20);
            this.nudNormDx.TabIndex = 15;
            this.nudNormDx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNormDx.ValueChanged += new System.EventHandler(this.nudNormDx_ValueChanged);
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(2, 49);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 13);
            this.label52.TabIndex = 26;
            this.label52.Text = "Air right:";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(2, 22);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 13);
            this.label51.TabIndex = 25;
            this.label51.Text = "Air left:";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxFlatField
            // 
            this.cbxFlatField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFlatField.DropDownWidth = 265;
            this.cbxFlatField.FormattingEnabled = true;
            this.cbxFlatField.Items.AddRange(new object[] {
            "Flat fielding with air normalization"});
            this.cbxFlatField.Location = new System.Drawing.Point(62, 19);
            this.cbxFlatField.Name = "cbxFlatField";
            this.cbxFlatField.Size = new System.Drawing.Size(201, 21);
            this.cbxFlatField.TabIndex = 10;
            this.cbxFlatField.SelectedIndexChanged += new System.EventHandler(this.cbxFlatField_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(15, 23);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(46, 13);
            this.label34.TabIndex = 28;
            this.label34.Text = "Method:";
            // 
            // gbxPreProcessing_Preview
            // 
            this.gbxPreProcessing_Preview.Controls.Add(this.btnPreprocessingTab_Preview);
            this.gbxPreProcessing_Preview.Controls.Add(this.nudPreprocessingTab_Preview);
            this.gbxPreProcessing_Preview.Controls.Add(this.lblPreprocessingTab_Preview);
            this.gbxPreProcessing_Preview.Enabled = false;
            this.gbxPreProcessing_Preview.Location = new System.Drawing.Point(20, 398);
            this.gbxPreProcessing_Preview.Name = "gbxPreProcessing_Preview";
            this.gbxPreProcessing_Preview.Size = new System.Drawing.Size(404, 52);
            this.gbxPreProcessing_Preview.TabIndex = 7;
            this.gbxPreProcessing_Preview.TabStop = false;
            this.gbxPreProcessing_Preview.Text = "Preview";
            // 
            // btnPreprocessingTab_Preview
            // 
            this.btnPreprocessingTab_Preview.Location = new System.Drawing.Point(316, 18);
            this.btnPreprocessingTab_Preview.Name = "btnPreprocessingTab_Preview";
            this.btnPreprocessingTab_Preview.Size = new System.Drawing.Size(75, 23);
            this.btnPreprocessingTab_Preview.TabIndex = 26;
            this.btnPreprocessingTab_Preview.Text = "Preview";
            this.btnPreprocessingTab_Preview.UseVisualStyleBackColor = true;
            this.btnPreprocessingTab_Preview.Click += new System.EventHandler(this.btnPreprocessingTab_Preview_Click);
            // 
            // nudPreprocessingTab_Preview
            // 
            this.nudPreprocessingTab_Preview.Location = new System.Drawing.Point(62, 21);
            this.nudPreprocessingTab_Preview.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPreprocessingTab_Preview.Name = "nudPreprocessingTab_Preview";
            this.nudPreprocessingTab_Preview.Size = new System.Drawing.Size(50, 20);
            this.nudPreprocessingTab_Preview.TabIndex = 25;
            this.nudPreprocessingTab_Preview.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPreprocessingTab_Preview
            // 
            this.lblPreprocessingTab_Preview.AutoSize = true;
            this.lblPreprocessingTab_Preview.Location = new System.Drawing.Point(6, 24);
            this.lblPreprocessingTab_Preview.Name = "lblPreprocessingTab_Preview";
            this.lblPreprocessingTab_Preview.Size = new System.Drawing.Size(54, 13);
            this.lblPreprocessingTab_Preview.TabIndex = 22;
            this.lblPreprocessingTab_Preview.Text = "Sinogram:";
            this.lblPreprocessingTab_Preview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vNavPaneItem7
            // 
            this.vNavPaneItem7.BackColor = System.Drawing.Color.White;
            this.vNavPaneItem7.HeaderText = "Phase Retrieval";
            // 
            // vNavPaneItem7.ItemPanel
            // 
            this.vNavPaneItem7.ItemPanel.AutoScroll = true;
            this.vNavPaneItem7.ItemPanel.Controls.Add(this.gbxPhaseRetrieval_Preview);
            this.vNavPaneItem7.ItemPanel.Controls.Add(this.groupBox15);
            this.vNavPaneItem7.ItemPanel.Controls.Add(this.gbxPhaseRetrieval_Execution);
            this.vNavPaneItem7.ItemPanel.Controls.Add(this.groupBox7);
            this.vNavPaneItem7.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItem7.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItem7.ItemPanel.Size = new System.Drawing.Size(452, 0);
            this.vNavPaneItem7.ItemPanel.TabIndex = 1;
            this.vNavPaneItem7.Location = new System.Drawing.Point(0, 597);
            this.vNavPaneItem7.Name = "vNavPaneItem7";
            this.vNavPaneItem7.Size = new System.Drawing.Size(454, 30);
            this.vNavPaneItem7.TabIndex = 5;
            this.vNavPaneItem7.Text = "vNavPaneItem7";
            this.vNavPaneItem7.TooltipText = "Phase Retrieval";
            // 
            // gbxPhaseRetrieval_Preview
            // 
            this.gbxPhaseRetrieval_Preview.Controls.Add(this.btnPhaseretrievalTab_Preview);
            this.gbxPhaseRetrieval_Preview.Controls.Add(this.nudPhaseretrievalTab_ProjectionPreview);
            this.gbxPhaseRetrieval_Preview.Controls.Add(this.lblPhaseRetrievalTab_Projection);
            this.gbxPhaseRetrieval_Preview.Enabled = false;
            this.gbxPhaseRetrieval_Preview.Location = new System.Drawing.Point(20, 242);
            this.gbxPhaseRetrieval_Preview.Name = "gbxPhaseRetrieval_Preview";
            this.gbxPhaseRetrieval_Preview.Size = new System.Drawing.Size(404, 54);
            this.gbxPhaseRetrieval_Preview.TabIndex = 11;
            this.gbxPhaseRetrieval_Preview.TabStop = false;
            this.gbxPhaseRetrieval_Preview.Text = "Preview";
            // 
            // btnPhaseretrievalTab_Preview
            // 
            this.btnPhaseretrievalTab_Preview.Location = new System.Drawing.Point(315, 18);
            this.btnPhaseretrievalTab_Preview.Name = "btnPhaseretrievalTab_Preview";
            this.btnPhaseretrievalTab_Preview.Size = new System.Drawing.Size(75, 23);
            this.btnPhaseretrievalTab_Preview.TabIndex = 39;
            this.btnPhaseretrievalTab_Preview.Text = "Preview";
            this.btnPhaseretrievalTab_Preview.UseVisualStyleBackColor = true;
            this.btnPhaseretrievalTab_Preview.Click += new System.EventHandler(this.btnPhaseretrievalTab_Preview_Click);
            // 
            // nudPhaseretrievalTab_ProjectionPreview
            // 
            this.nudPhaseretrievalTab_ProjectionPreview.Location = new System.Drawing.Point(67, 22);
            this.nudPhaseretrievalTab_ProjectionPreview.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPhaseretrievalTab_ProjectionPreview.Name = "nudPhaseretrievalTab_ProjectionPreview";
            this.nudPhaseretrievalTab_ProjectionPreview.Size = new System.Drawing.Size(50, 20);
            this.nudPhaseretrievalTab_ProjectionPreview.TabIndex = 38;
            this.nudPhaseretrievalTab_ProjectionPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPhaseRetrievalTab_Projection
            // 
            this.lblPhaseRetrievalTab_Projection.AutoSize = true;
            this.lblPhaseRetrievalTab_Projection.Location = new System.Drawing.Point(10, 25);
            this.lblPhaseRetrievalTab_Projection.Name = "lblPhaseRetrievalTab_Projection";
            this.lblPhaseRetrievalTab_Projection.Size = new System.Drawing.Size(57, 13);
            this.lblPhaseRetrievalTab_Projection.TabIndex = 22;
            this.lblPhaseRetrievalTab_Projection.Text = "Projection:";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.cbxPhaseRetrieval_Input);
            this.groupBox15.Controls.Add(this.label48);
            this.groupBox15.Location = new System.Drawing.Point(20, 18);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(404, 56);
            this.groupBox15.TabIndex = 9;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Dataset";
            // 
            // cbxPhaseRetrieval_Input
            // 
            this.cbxPhaseRetrieval_Input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhaseRetrieval_Input.FormattingEnabled = true;
            this.cbxPhaseRetrieval_Input.Location = new System.Drawing.Point(67, 22);
            this.cbxPhaseRetrieval_Input.Name = "cbxPhaseRetrieval_Input";
            this.cbxPhaseRetrieval_Input.Size = new System.Drawing.Size(322, 21);
            this.cbxPhaseRetrieval_Input.TabIndex = 28;
            this.cbxPhaseRetrieval_Input.DropDownClosed += new System.EventHandler(this.cbxPhaseRetrieval_Input_DropDownClosed);
            this.cbxPhaseRetrieval_Input.Click += new System.EventHandler(this.cbxPhaseRetrieval_Input_Click);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(16, 26);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(50, 13);
            this.label48.TabIndex = 4;
            this.label48.Text = "TDF File:";
            // 
            // gbxPhaseRetrieval_Execution
            // 
            this.gbxPhaseRetrieval_Execution.Controls.Add(this.lblPhaseRetrieval_Output);
            this.gbxPhaseRetrieval_Execution.Controls.Add(this.lblPhaseRetrieval_ExecuteOutput);
            this.gbxPhaseRetrieval_Execution.Controls.Add(this.btnPhaseRetrieval_ExecuteRun);
            this.gbxPhaseRetrieval_Execution.Enabled = false;
            this.gbxPhaseRetrieval_Execution.Location = new System.Drawing.Point(20, 301);
            this.gbxPhaseRetrieval_Execution.Name = "gbxPhaseRetrieval_Execution";
            this.gbxPhaseRetrieval_Execution.Size = new System.Drawing.Size(404, 49);
            this.gbxPhaseRetrieval_Execution.TabIndex = 12;
            this.gbxPhaseRetrieval_Execution.TabStop = false;
            this.gbxPhaseRetrieval_Execution.Text = "Execute";
            // 
            // lblPhaseRetrieval_Output
            // 
            this.lblPhaseRetrieval_Output.Location = new System.Drawing.Point(69, 23);
            this.lblPhaseRetrieval_Output.Name = "lblPhaseRetrieval_Output";
            this.lblPhaseRetrieval_Output.Size = new System.Drawing.Size(239, 13);
            this.lblPhaseRetrieval_Output.TabIndex = 8;
            // 
            // lblPhaseRetrieval_ExecuteOutput
            // 
            this.lblPhaseRetrieval_ExecuteOutput.AutoSize = true;
            this.lblPhaseRetrieval_ExecuteOutput.Location = new System.Drawing.Point(25, 23);
            this.lblPhaseRetrieval_ExecuteOutput.Name = "lblPhaseRetrieval_ExecuteOutput";
            this.lblPhaseRetrieval_ExecuteOutput.Size = new System.Drawing.Size(42, 13);
            this.lblPhaseRetrieval_ExecuteOutput.TabIndex = 7;
            this.lblPhaseRetrieval_ExecuteOutput.Text = "Output:";
            // 
            // btnPhaseRetrieval_ExecuteRun
            // 
            this.btnPhaseRetrieval_ExecuteRun.Location = new System.Drawing.Point(315, 17);
            this.btnPhaseRetrieval_ExecuteRun.Name = "btnPhaseRetrieval_ExecuteRun";
            this.btnPhaseRetrieval_ExecuteRun.Size = new System.Drawing.Size(75, 23);
            this.btnPhaseRetrieval_ExecuteRun.TabIndex = 40;
            this.btnPhaseRetrieval_ExecuteRun.Text = "Run";
            this.btnPhaseRetrieval_ExecuteRun.UseVisualStyleBackColor = true;
            this.btnPhaseRetrieval_ExecuteRun.Click += new System.EventHandler(this.btnPhaseRetrievalRunAll_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkPhaseRetrievalTab_OverPadding);
            this.groupBox7.Controls.Add(this.lblDeltaBetaRatio);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.nudPhaseRetrievalTab_BetaExp);
            this.groupBox7.Controls.Add(this.nudPhaseRetrievalTab_DeltaExp);
            this.groupBox7.Controls.Add(this.nudPhaseRetrievalTab_Beta);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.nudPhaseRetrievalTab_Delta);
            this.groupBox7.Controls.Add(this.nudPhaseRetrievalTab_PixelSize);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.cbxPhaseRetrievalTab_Algorithms);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.nudPhaseRetrievalTab_Distance);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.nudPhaseRetrievalTab_Energy);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Location = new System.Drawing.Point(20, 80);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(404, 156);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "(Single distance) Phase retrieval";
            // 
            // chkPhaseRetrievalTab_OverPadding
            // 
            this.chkPhaseRetrievalTab_OverPadding.AutoSize = true;
            this.chkPhaseRetrievalTab_OverPadding.Location = new System.Drawing.Point(226, 128);
            this.chkPhaseRetrievalTab_OverPadding.Name = "chkPhaseRetrievalTab_OverPadding";
            this.chkPhaseRetrievalTab_OverPadding.Size = new System.Drawing.Size(132, 17);
            this.chkPhaseRetrievalTab_OverPadding.TabIndex = 37;
            this.chkPhaseRetrievalTab_OverPadding.Text = "Overpadding (ROI-CT)";
            this.chkPhaseRetrievalTab_OverPadding.UseVisualStyleBackColor = true;
            // 
            // lblDeltaBetaRatio
            // 
            this.lblDeltaBetaRatio.AutoSize = true;
            this.lblDeltaBetaRatio.Location = new System.Drawing.Point(50, 104);
            this.lblDeltaBetaRatio.Name = "lblDeltaBetaRatio";
            this.lblDeltaBetaRatio.Size = new System.Drawing.Size(68, 13);
            this.lblDeltaBetaRatio.TabIndex = 31;
            this.lblDeltaBetaRatio.Text = "delta/beta = ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "δ:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPhaseRetrievalTab_BetaExp
            // 
            this.nudPhaseRetrievalTab_BetaExp.Location = new System.Drawing.Point(165, 75);
            this.nudPhaseRetrievalTab_BetaExp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudPhaseRetrievalTab_BetaExp.Name = "nudPhaseRetrievalTab_BetaExp";
            this.nudPhaseRetrievalTab_BetaExp.Size = new System.Drawing.Size(38, 20);
            this.nudPhaseRetrievalTab_BetaExp.TabIndex = 33;
            this.nudPhaseRetrievalTab_BetaExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPhaseRetrievalTab_BetaExp.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudPhaseRetrievalTab_BetaExp.ValueChanged += new System.EventHandler(this.nudExpBeta_ValueChanged);
            // 
            // nudPhaseRetrievalTab_DeltaExp
            // 
            this.nudPhaseRetrievalTab_DeltaExp.Location = new System.Drawing.Point(165, 49);
            this.nudPhaseRetrievalTab_DeltaExp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudPhaseRetrievalTab_DeltaExp.Name = "nudPhaseRetrievalTab_DeltaExp";
            this.nudPhaseRetrievalTab_DeltaExp.Size = new System.Drawing.Size(38, 20);
            this.nudPhaseRetrievalTab_DeltaExp.TabIndex = 31;
            this.nudPhaseRetrievalTab_DeltaExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPhaseRetrievalTab_DeltaExp.Value = new decimal(new int[] {
            7,
            0,
            0,
            -2147483648});
            this.nudPhaseRetrievalTab_DeltaExp.ValueChanged += new System.EventHandler(this.nudExpDelta_ValueChanged);
            // 
            // nudPhaseRetrievalTab_Beta
            // 
            this.nudPhaseRetrievalTab_Beta.DecimalPlaces = 5;
            this.nudPhaseRetrievalTab_Beta.Location = new System.Drawing.Point(68, 75);
            this.nudPhaseRetrievalTab_Beta.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            65536});
            this.nudPhaseRetrievalTab_Beta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudPhaseRetrievalTab_Beta.Name = "nudPhaseRetrievalTab_Beta";
            this.nudPhaseRetrievalTab_Beta.Size = new System.Drawing.Size(66, 20);
            this.nudPhaseRetrievalTab_Beta.TabIndex = 32;
            this.nudPhaseRetrievalTab_Beta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPhaseRetrievalTab_Beta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPhaseRetrievalTab_Beta.ValueChanged += new System.EventHandler(this.zProjections_OptionsBetaNud_ValueChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(1, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 17);
            this.label15.TabIndex = 24;
            this.label15.Text = "β:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPhaseRetrievalTab_Delta
            // 
            this.nudPhaseRetrievalTab_Delta.DecimalPlaces = 5;
            this.nudPhaseRetrievalTab_Delta.Location = new System.Drawing.Point(68, 49);
            this.nudPhaseRetrievalTab_Delta.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            65536});
            this.nudPhaseRetrievalTab_Delta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudPhaseRetrievalTab_Delta.Name = "nudPhaseRetrievalTab_Delta";
            this.nudPhaseRetrievalTab_Delta.Size = new System.Drawing.Size(66, 20);
            this.nudPhaseRetrievalTab_Delta.TabIndex = 30;
            this.nudPhaseRetrievalTab_Delta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPhaseRetrievalTab_Delta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPhaseRetrievalTab_Delta.ValueChanged += new System.EventHandler(this.zProjections_OptionsDeltaNud_ValueChanged);
            // 
            // nudPhaseRetrievalTab_PixelSize
            // 
            this.nudPhaseRetrievalTab_PixelSize.DecimalPlaces = 3;
            this.nudPhaseRetrievalTab_PixelSize.Increment = new decimal(new int[] {
            500,
            0,
            0,
            196608});
            this.nudPhaseRetrievalTab_PixelSize.Location = new System.Drawing.Point(276, 49);
            this.nudPhaseRetrievalTab_PixelSize.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            196608});
            this.nudPhaseRetrievalTab_PixelSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudPhaseRetrievalTab_PixelSize.Name = "nudPhaseRetrievalTab_PixelSize";
            this.nudPhaseRetrievalTab_PixelSize.Size = new System.Drawing.Size(66, 20);
            this.nudPhaseRetrievalTab_PixelSize.TabIndex = 34;
            this.nudPhaseRetrievalTab_PixelSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPhaseRetrievalTab_PixelSize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(21, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Method:";
            // 
            // cbxPhaseRetrievalTab_Algorithms
            // 
            this.cbxPhaseRetrievalTab_Algorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPhaseRetrievalTab_Algorithms.FormattingEnabled = true;
            this.cbxPhaseRetrievalTab_Algorithms.Location = new System.Drawing.Point(68, 22);
            this.cbxPhaseRetrievalTab_Algorithms.Name = "cbxPhaseRetrievalTab_Algorithms";
            this.cbxPhaseRetrievalTab_Algorithms.Size = new System.Drawing.Size(274, 21);
            this.cbxPhaseRetrievalTab_Algorithms.TabIndex = 29;
            this.cbxPhaseRetrievalTab_Algorithms.SelectedIndexChanged += new System.EventHandler(this.cbxPhaseRetrievalTab_Algorithms_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(346, 52);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 13);
            this.label28.TabIndex = 10;
            this.label28.Text = "micron";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(223, 52);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 13);
            this.label29.TabIndex = 8;
            this.label29.Text = "Pixel size:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(346, 78);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(23, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "mm";
            // 
            // nudPhaseRetrievalTab_Distance
            // 
            this.nudPhaseRetrievalTab_Distance.DecimalPlaces = 1;
            this.nudPhaseRetrievalTab_Distance.Location = new System.Drawing.Point(276, 75);
            this.nudPhaseRetrievalTab_Distance.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudPhaseRetrievalTab_Distance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPhaseRetrievalTab_Distance.Name = "nudPhaseRetrievalTab_Distance";
            this.nudPhaseRetrievalTab_Distance.Size = new System.Drawing.Size(66, 20);
            this.nudPhaseRetrievalTab_Distance.TabIndex = 35;
            this.nudPhaseRetrievalTab_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPhaseRetrievalTab_Distance.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(224, 78);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Distance:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(346, 104);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(26, 13);
            this.label25.TabIndex = 4;
            this.label25.Text = "keV";
            // 
            // nudPhaseRetrievalTab_Energy
            // 
            this.nudPhaseRetrievalTab_Energy.DecimalPlaces = 1;
            this.nudPhaseRetrievalTab_Energy.Location = new System.Drawing.Point(276, 101);
            this.nudPhaseRetrievalTab_Energy.Name = "nudPhaseRetrievalTab_Energy";
            this.nudPhaseRetrievalTab_Energy.Size = new System.Drawing.Size(66, 20);
            this.nudPhaseRetrievalTab_Energy.TabIndex = 36;
            this.nudPhaseRetrievalTab_Energy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPhaseRetrievalTab_Energy.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(232, 104);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Energy:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "×10^";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(136, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "×10^";
            // 
            // vNavPaneItem4
            // 
            this.vNavPaneItem4.BackColor = System.Drawing.Color.White;
            this.vNavPaneItem4.HeaderText = "Reconstruction";
            // 
            // vNavPaneItem4.ItemPanel
            // 
            this.vNavPaneItem4.ItemPanel.AutoScroll = true;
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.gbxRolling);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox1);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox35);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox24);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox23);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox13);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox10);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox18);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox4);
            this.vNavPaneItem4.ItemPanel.Controls.Add(this.groupBox11);
            this.vNavPaneItem4.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItem4.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItem4.ItemPanel.Size = new System.Drawing.Size(452, 0);
            this.vNavPaneItem4.ItemPanel.TabIndex = 1;
            this.vNavPaneItem4.Location = new System.Drawing.Point(0, 627);
            this.vNavPaneItem4.Name = "vNavPaneItem4";
            this.vNavPaneItem4.Size = new System.Drawing.Size(454, 30);
            this.vNavPaneItem4.TabIndex = 3;
            this.vNavPaneItem4.Text = "vReconstructionPaneItem";
            this.vNavPaneItem4.TooltipText = "Reconstruction";
            // 
            // gbxRolling
            // 
            this.gbxRolling.Controls.Add(this.lblRollShift);
            this.gbxRolling.Controls.Add(this.label6);
            this.gbxRolling.Controls.Add(this.nudRollShift);
            this.gbxRolling.Location = new System.Drawing.Point(20, 282);
            this.gbxRolling.Name = "gbxRolling";
            this.gbxRolling.Size = new System.Drawing.Size(404, 54);
            this.gbxRolling.TabIndex = 18;
            this.gbxRolling.TabStop = false;
            this.gbxRolling.Text = "(Lossless) Rotation";
            // 
            // lblRollShift
            // 
            this.lblRollShift.AutoSize = true;
            this.lblRollShift.Location = new System.Drawing.Point(99, 28);
            this.lblRollShift.Name = "lblRollShift";
            this.lblRollShift.Size = new System.Drawing.Size(199, 13);
            this.lblRollShift.TabIndex = 46;
            this.lblRollShift.Text = "projections (i.e. 0 deg clockwise rotation)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Roll";
            // 
            // nudRollShift
            // 
            this.nudRollShift.Location = new System.Drawing.Point(37, 25);
            this.nudRollShift.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudRollShift.Name = "nudRollShift";
            this.nudRollShift.Size = new System.Drawing.Size(56, 20);
            this.nudRollShift.TabIndex = 52;
            this.nudRollShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRollShift.ValueChanged += new System.EventHandler(this.nudRollShift_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMultipleAngles);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudAnglesProjTo);
            this.groupBox1.Controls.Add(this.nudAnglesProjFrom);
            this.groupBox1.Controls.Add(this.label62);
            this.groupBox1.Controls.Add(this.nudAngles);
            this.groupBox1.Location = new System.Drawing.Point(20, 225);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 54);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Angles/Projections";
            // 
            // btnMultipleAngles
            // 
            this.btnMultipleAngles.Enabled = false;
            this.btnMultipleAngles.Location = new System.Drawing.Point(314, 21);
            this.btnMultipleAngles.Name = "btnMultipleAngles";
            this.btnMultipleAngles.Size = new System.Drawing.Size(75, 23);
            this.btnMultipleAngles.TabIndex = 51;
            this.btnMultipleAngles.Text = "Test...";
            this.btnMultipleAngles.UseVisualStyleBackColor = true;
            this.btnMultipleAngles.Click += new System.EventHandler(this.btnMultipleAngles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "to";
            // 
            // nudAnglesProjTo
            // 
            this.nudAnglesProjTo.Enabled = false;
            this.nudAnglesProjTo.Location = new System.Drawing.Point(255, 23);
            this.nudAnglesProjTo.Name = "nudAnglesProjTo";
            this.nudAnglesProjTo.Size = new System.Drawing.Size(49, 20);
            this.nudAnglesProjTo.TabIndex = 50;
            this.nudAnglesProjTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudAnglesProjFrom
            // 
            this.nudAnglesProjFrom.Enabled = false;
            this.nudAnglesProjFrom.Location = new System.Drawing.Point(188, 23);
            this.nudAnglesProjFrom.Name = "nudAnglesProjFrom";
            this.nudAnglesProjFrom.Size = new System.Drawing.Size(49, 20);
            this.nudAnglesProjFrom.TabIndex = 49;
            this.nudAnglesProjFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(71, 26);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(117, 13);
            this.label62.TabIndex = 31;
            this.label62.Text = "deg for projections from";
            // 
            // nudAngles
            // 
            this.nudAngles.DecimalPlaces = 2;
            this.nudAngles.Increment = new decimal(new int[] {
            174532925,
            0,
            0,
            655360});
            this.nudAngles.Location = new System.Drawing.Point(13, 23);
            this.nudAngles.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.nudAngles.Name = "nudAngles";
            this.nudAngles.Size = new System.Drawing.Size(56, 20);
            this.nudAngles.TabIndex = 48;
            this.nudAngles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAngles.Value = new decimal(new int[] {
            18000,
            0,
            0,
            131072});
            this.nudAngles.ValueChanged += new System.EventHandler(this.nudAngles_ValueChanged);
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.chkPhrtOnTheFly);
            this.groupBox35.Controls.Add(this.btnReconstructionTab_Preview);
            this.groupBox35.Controls.Add(this.nudReconstructionTab_Slice);
            this.groupBox35.Controls.Add(this.lblReconstructionTab_Slice);
            this.groupBox35.Location = new System.Drawing.Point(20, 572);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(404, 77);
            this.groupBox35.TabIndex = 21;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Preview";
            // 
            // chkPhrtOnTheFly
            // 
            this.chkPhrtOnTheFly.AutoSize = true;
            this.chkPhrtOnTheFly.Location = new System.Drawing.Point(18, 20);
            this.chkPhrtOnTheFly.Name = "chkPhrtOnTheFly";
            this.chkPhrtOnTheFly.Size = new System.Drawing.Size(334, 17);
            this.chkPhrtOnTheFly.TabIndex = 60;
            this.chkPhrtOnTheFly.Text = "Approximate phase retrieval on-the-fly (see \"Phase Retrieval\" tab)";
            this.chkPhrtOnTheFly.UseVisualStyleBackColor = true;
            // 
            // btnReconstructionTab_Preview
            // 
            this.btnReconstructionTab_Preview.Enabled = false;
            this.btnReconstructionTab_Preview.Location = new System.Drawing.Point(314, 42);
            this.btnReconstructionTab_Preview.Name = "btnReconstructionTab_Preview";
            this.btnReconstructionTab_Preview.Size = new System.Drawing.Size(75, 23);
            this.btnReconstructionTab_Preview.TabIndex = 62;
            this.btnReconstructionTab_Preview.Text = "Preview";
            this.btnReconstructionTab_Preview.UseVisualStyleBackColor = true;
            this.btnReconstructionTab_Preview.Click += new System.EventHandler(this.btnReconstructionTab_Preview_Click);
            // 
            // nudReconstructionTab_Slice
            // 
            this.nudReconstructionTab_Slice.Enabled = false;
            this.nudReconstructionTab_Slice.Location = new System.Drawing.Point(51, 45);
            this.nudReconstructionTab_Slice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudReconstructionTab_Slice.Name = "nudReconstructionTab_Slice";
            this.nudReconstructionTab_Slice.Size = new System.Drawing.Size(50, 20);
            this.nudReconstructionTab_Slice.TabIndex = 61;
            this.nudReconstructionTab_Slice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblReconstructionTab_Slice
            // 
            this.lblReconstructionTab_Slice.AutoSize = true;
            this.lblReconstructionTab_Slice.Enabled = false;
            this.lblReconstructionTab_Slice.Location = new System.Drawing.Point(15, 48);
            this.lblReconstructionTab_Slice.Name = "lblReconstructionTab_Slice";
            this.lblReconstructionTab_Slice.Size = new System.Drawing.Size(33, 13);
            this.lblReconstructionTab_Slice.TabIndex = 22;
            this.lblReconstructionTab_Slice.Text = "Slice:";
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.label37);
            this.groupBox24.Controls.Add(this.nudReconstructionTab_Downscale);
            this.groupBox24.Controls.Add(this.label35);
            this.groupBox24.Controls.Add(this.nudReconstructionTab_Decimate);
            this.groupBox24.Location = new System.Drawing.Point(20, 142);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(187, 77);
            this.groupBox24.TabIndex = 15;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Experimental";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(15, 48);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(71, 13);
            this.label37.TabIndex = 30;
            this.label37.Text = "Downscaling:";
            // 
            // nudReconstructionTab_Downscale
            // 
            this.nudReconstructionTab_Downscale.Location = new System.Drawing.Point(86, 45);
            this.nudReconstructionTab_Downscale.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudReconstructionTab_Downscale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReconstructionTab_Downscale.Name = "nudReconstructionTab_Downscale";
            this.nudReconstructionTab_Downscale.Size = new System.Drawing.Size(49, 20);
            this.nudReconstructionTab_Downscale.TabIndex = 44;
            this.nudReconstructionTab_Downscale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudReconstructionTab_Downscale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReconstructionTab_Downscale.ValueChanged += new System.EventHandler(this.nudReconstructionTab_Downscale_ValueChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(23, 25);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(63, 13);
            this.label35.TabIndex = 28;
            this.label35.Text = "Decimation:";
            // 
            // nudReconstructionTab_Decimate
            // 
            this.nudReconstructionTab_Decimate.Location = new System.Drawing.Point(86, 21);
            this.nudReconstructionTab_Decimate.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nudReconstructionTab_Decimate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReconstructionTab_Decimate.Name = "nudReconstructionTab_Decimate";
            this.nudReconstructionTab_Decimate.Size = new System.Drawing.Size(49, 20);
            this.nudReconstructionTab_Decimate.TabIndex = 43;
            this.nudReconstructionTab_Decimate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudReconstructionTab_Decimate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.chkReconstructionTab_PostProcess);
            this.groupBox23.Location = new System.Drawing.Point(20, 512);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(404, 53);
            this.groupBox23.TabIndex = 20;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Post-processing";
            // 
            // chkReconstructionTab_PostProcess
            // 
            this.chkReconstructionTab_PostProcess.AutoSize = true;
            this.chkReconstructionTab_PostProcess.Location = new System.Drawing.Point(19, 22);
            this.chkReconstructionTab_PostProcess.Name = "chkReconstructionTab_PostProcess";
            this.chkReconstructionTab_PostProcess.Size = new System.Drawing.Size(382, 17);
            this.chkReconstructionTab_PostProcess.TabIndex = 59;
            this.chkReconstructionTab_PostProcess.Text = "Post-process the reconstructed image on-the-fly (see \"Post-processing\" tab)";
            this.chkReconstructionTab_PostProcess.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnMultipleCenters);
            this.groupBox13.Controls.Add(this.btnReconstructionGuess);
            this.groupBox13.Controls.Add(this.label58);
            this.groupBox13.Controls.Add(this.nudCenter_Middle);
            this.groupBox13.Location = new System.Drawing.Point(216, 142);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(208, 77);
            this.groupBox13.TabIndex = 16;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Center of rotation";
            this.groupBox13.UseCompatibleTextRendering = true;
            // 
            // btnMultipleCenters
            // 
            this.btnMultipleCenters.Enabled = false;
            this.btnMultipleCenters.Location = new System.Drawing.Point(119, 45);
            this.btnMultipleCenters.Name = "btnMultipleCenters";
            this.btnMultipleCenters.Size = new System.Drawing.Size(75, 23);
            this.btnMultipleCenters.TabIndex = 47;
            this.btnMultipleCenters.Text = "Test...";
            this.btnMultipleCenters.UseVisualStyleBackColor = true;
            this.btnMultipleCenters.Click += new System.EventHandler(this.btnMultipleCenters_Click);
            // 
            // btnReconstructionGuess
            // 
            this.btnReconstructionGuess.Enabled = false;
            this.btnReconstructionGuess.Location = new System.Drawing.Point(119, 16);
            this.btnReconstructionGuess.Name = "btnReconstructionGuess";
            this.btnReconstructionGuess.Size = new System.Drawing.Size(75, 23);
            this.btnReconstructionGuess.TabIndex = 46;
            this.btnReconstructionGuess.Text = "Guess";
            this.btnReconstructionGuess.UseVisualStyleBackColor = true;
            this.btnReconstructionGuess.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(19, 37);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(38, 13);
            this.label58.TabIndex = 26;
            this.label58.Text = "Offset:";
            // 
            // nudCenter_Middle
            // 
            this.nudCenter_Middle.Location = new System.Drawing.Point(60, 33);
            this.nudCenter_Middle.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudCenter_Middle.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudCenter_Middle.Name = "nudCenter_Middle";
            this.nudCenter_Middle.Size = new System.Drawing.Size(49, 20);
            this.nudCenter_Middle.TabIndex = 45;
            this.nudCenter_Middle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.nudCorrectionOffset);
            this.groupBox10.Controls.Add(this.chkCorrectionOffset);
            this.groupBox10.Controls.Add(this.groupBox14);
            this.groupBox10.Controls.Add(this.chkZeroneMode);
            this.groupBox10.Controls.Add(this.chkLogTransform);
            this.groupBox10.Controls.Add(this.chkOverPadding);
            this.groupBox10.Controls.Add(this.chkCircleMask);
            this.groupBox10.Controls.Add(this.cbxAlgorithm);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Location = new System.Drawing.Point(20, 340);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(404, 166);
            this.groupBox10.TabIndex = 19;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Reconstruction";
            // 
            // nudCorrectionOffset
            // 
            this.nudCorrectionOffset.DecimalPlaces = 3;
            this.nudCorrectionOffset.Enabled = false;
            this.nudCorrectionOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nudCorrectionOffset.Location = new System.Drawing.Point(120, 126);
            this.nudCorrectionOffset.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudCorrectionOffset.Name = "nudCorrectionOffset";
            this.nudCorrectionOffset.Size = new System.Drawing.Size(56, 20);
            this.nudCorrectionOffset.TabIndex = 58;
            this.nudCorrectionOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCorrectionOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // chkCorrectionOffset
            // 
            this.chkCorrectionOffset.AutoSize = true;
            this.chkCorrectionOffset.Location = new System.Drawing.Point(16, 128);
            this.chkCorrectionOffset.Name = "chkCorrectionOffset";
            this.chkCorrectionOffset.Size = new System.Drawing.Size(106, 17);
            this.chkCorrectionOffset.TabIndex = 57;
            this.chkCorrectionOffset.Text = "Correction offset:";
            this.chkCorrectionOffset.UseVisualStyleBackColor = true;
            this.chkCorrectionOffset.CheckedChanged += new System.EventHandler(this.chkCorrectionOffset_CheckedChanged);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.nudLambdaExp);
            this.groupBox14.Controls.Add(this.nudLambdaBase);
            this.groupBox14.Controls.Add(this.lblLambdaTenTo);
            this.groupBox14.Controls.Add(this.nudFISTAReconIter);
            this.groupBox14.Controls.Add(this.nudFISTAFGPIter);
            this.groupBox14.Controls.Add(this.lblFISTAReconIter);
            this.groupBox14.Controls.Add(this.lblFISTAFGPIter);
            this.groupBox14.Controls.Add(this.nudGridRec);
            this.groupBox14.Controls.Add(this.cbxAlgorithmParameterFilter);
            this.groupBox14.Controls.Add(this.nudAlgorithmParameterIterations);
            this.groupBox14.Controls.Add(this.lblAlgorithmParameter);
            this.groupBox14.Location = new System.Drawing.Point(196, 51);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(195, 104);
            this.groupBox14.TabIndex = 30;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Algorithm settings";
            this.groupBox14.UseCompatibleTextRendering = true;
            // 
            // nudLambdaExp
            // 
            this.nudLambdaExp.Location = new System.Drawing.Point(147, 22);
            this.nudLambdaExp.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLambdaExp.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.nudLambdaExp.Name = "nudLambdaExp";
            this.nudLambdaExp.Size = new System.Drawing.Size(40, 20);
            this.nudLambdaExp.TabIndex = 37;
            this.nudLambdaExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLambdaExp.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nudLambdaExp.Visible = false;
            // 
            // nudLambdaBase
            // 
            this.nudLambdaBase.DecimalPlaces = 1;
            this.nudLambdaBase.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLambdaBase.Location = new System.Drawing.Point(74, 22);
            this.nudLambdaBase.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            65536});
            this.nudLambdaBase.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLambdaBase.Name = "nudLambdaBase";
            this.nudLambdaBase.Size = new System.Drawing.Size(43, 20);
            this.nudLambdaBase.TabIndex = 38;
            this.nudLambdaBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLambdaBase.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudLambdaBase.Visible = false;
            // 
            // lblLambdaTenTo
            // 
            this.lblLambdaTenTo.Location = new System.Drawing.Point(118, 25);
            this.lblLambdaTenTo.Name = "lblLambdaTenTo";
            this.lblLambdaTenTo.Size = new System.Drawing.Size(30, 11);
            this.lblLambdaTenTo.TabIndex = 36;
            this.lblLambdaTenTo.Text = "x10^";
            this.lblLambdaTenTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLambdaTenTo.Visible = false;
            // 
            // nudFISTAReconIter
            // 
            this.nudFISTAReconIter.Location = new System.Drawing.Point(97, 76);
            this.nudFISTAReconIter.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudFISTAReconIter.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudFISTAReconIter.Name = "nudFISTAReconIter";
            this.nudFISTAReconIter.Size = new System.Drawing.Size(43, 20);
            this.nudFISTAReconIter.TabIndex = 33;
            this.nudFISTAReconIter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFISTAReconIter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudFISTAReconIter.Visible = false;
            // 
            // nudFISTAFGPIter
            // 
            this.nudFISTAFGPIter.Location = new System.Drawing.Point(97, 49);
            this.nudFISTAFGPIter.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudFISTAFGPIter.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudFISTAFGPIter.Name = "nudFISTAFGPIter";
            this.nudFISTAFGPIter.Size = new System.Drawing.Size(43, 20);
            this.nudFISTAFGPIter.TabIndex = 32;
            this.nudFISTAFGPIter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFISTAFGPIter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudFISTAFGPIter.Visible = false;
            // 
            // lblFISTAReconIter
            // 
            this.lblFISTAReconIter.AutoSize = true;
            this.lblFISTAReconIter.Location = new System.Drawing.Point(5, 78);
            this.lblFISTAReconIter.Name = "lblFISTAReconIter";
            this.lblFISTAReconIter.Size = new System.Drawing.Size(91, 13);
            this.lblFISTAReconIter.TabIndex = 35;
            this.lblFISTAReconIter.Text = "Recon. Iterations:";
            this.lblFISTAReconIter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFISTAReconIter.Visible = false;
            // 
            // lblFISTAFGPIter
            // 
            this.lblFISTAFGPIter.Location = new System.Drawing.Point(5, 52);
            this.lblFISTAFGPIter.Name = "lblFISTAFGPIter";
            this.lblFISTAFGPIter.Size = new System.Drawing.Size(91, 13);
            this.lblFISTAFGPIter.TabIndex = 34;
            this.lblFISTAFGPIter.Text = "FGP Iterations:";
            this.lblFISTAFGPIter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFISTAFGPIter.Visible = false;
            // 
            // nudGridRec
            // 
            this.nudGridRec.DecimalPlaces = 1;
            this.nudGridRec.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudGridRec.Location = new System.Drawing.Point(79, 22);
            this.nudGridRec.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.nudGridRec.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudGridRec.Name = "nudGridRec";
            this.nudGridRec.Size = new System.Drawing.Size(43, 20);
            this.nudGridRec.TabIndex = 31;
            this.nudGridRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGridRec.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudGridRec.Visible = false;
            // 
            // cbxAlgorithmParameterFilter
            // 
            this.cbxAlgorithmParameterFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlgorithmParameterFilter.FormattingEnabled = true;
            this.cbxAlgorithmParameterFilter.Items.AddRange(new object[] {
            "<none>",
            "shepp-logan (default)",
            "ram-lak",
            "cosine",
            "hamming",
            "hann",
            "tukey",
            "lanczos",
            "triangular",
            "gaussian",
            "barlett-hann",
            "blackman",
            "nuttall ",
            "blackman-harris",
            "blackman-nuttall",
            "flat-top",
            "kaiser",
            "parzen"});
            this.cbxAlgorithmParameterFilter.Location = new System.Drawing.Point(57, 22);
            this.cbxAlgorithmParameterFilter.Name = "cbxAlgorithmParameterFilter";
            this.cbxAlgorithmParameterFilter.Size = new System.Drawing.Size(128, 21);
            this.cbxAlgorithmParameterFilter.TabIndex = 58;
            // 
            // nudAlgorithmParameterIterations
            // 
            this.nudAlgorithmParameterIterations.Location = new System.Drawing.Point(62, 22);
            this.nudAlgorithmParameterIterations.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAlgorithmParameterIterations.Name = "nudAlgorithmParameterIterations";
            this.nudAlgorithmParameterIterations.Size = new System.Drawing.Size(48, 20);
            this.nudAlgorithmParameterIterations.TabIndex = 27;
            this.nudAlgorithmParameterIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAlgorithmParameterIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblAlgorithmParameter
            // 
            this.lblAlgorithmParameter.Location = new System.Drawing.Point(6, 25);
            this.lblAlgorithmParameter.Name = "lblAlgorithmParameter";
            this.lblAlgorithmParameter.Size = new System.Drawing.Size(53, 13);
            this.lblAlgorithmParameter.TabIndex = 26;
            this.lblAlgorithmParameter.Text = "Iterations:";
            this.lblAlgorithmParameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkZeroneMode
            // 
            this.chkZeroneMode.AutoSize = true;
            this.chkZeroneMode.Location = new System.Drawing.Point(111, 59);
            this.chkZeroneMode.Name = "chkZeroneMode";
            this.chkZeroneMode.Size = new System.Drawing.Size(76, 17);
            this.chkZeroneMode.TabIndex = 35;
            this.chkZeroneMode.Text = "[0,1] mode";
            this.chkZeroneMode.UseVisualStyleBackColor = true;
            this.chkZeroneMode.Visible = false;
            // 
            // chkLogTransform
            // 
            this.chkLogTransform.AutoSize = true;
            this.chkLogTransform.Location = new System.Drawing.Point(16, 59);
            this.chkLogTransform.Name = "chkLogTransform";
            this.chkLogTransform.Size = new System.Drawing.Size(90, 17);
            this.chkLogTransform.TabIndex = 54;
            this.chkLogTransform.Text = "Log transform";
            this.chkLogTransform.UseVisualStyleBackColor = true;
            // 
            // chkOverPadding
            // 
            this.chkOverPadding.AutoSize = true;
            this.chkOverPadding.Location = new System.Drawing.Point(16, 105);
            this.chkOverPadding.Name = "chkOverPadding";
            this.chkOverPadding.Size = new System.Drawing.Size(132, 17);
            this.chkOverPadding.TabIndex = 56;
            this.chkOverPadding.Text = "Overpadding (ROI-CT)";
            this.chkOverPadding.UseVisualStyleBackColor = true;
            // 
            // chkCircleMask
            // 
            this.chkCircleMask.AutoSize = true;
            this.chkCircleMask.Location = new System.Drawing.Point(16, 82);
            this.chkCircleMask.Name = "chkCircleMask";
            this.chkCircleMask.Size = new System.Drawing.Size(80, 17);
            this.chkCircleMask.TabIndex = 55;
            this.chkCircleMask.Text = "Circle mask";
            this.chkCircleMask.UseVisualStyleBackColor = true;
            // 
            // cbxAlgorithm
            // 
            this.cbxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlgorithm.DropDownWidth = 400;
            this.cbxAlgorithm.FormattingEnabled = true;
            this.cbxAlgorithm.Location = new System.Drawing.Point(67, 23);
            this.cbxAlgorithm.Name = "cbxAlgorithm";
            this.cbxAlgorithm.Size = new System.Drawing.Size(322, 21);
            this.cbxAlgorithm.TabIndex = 53;
            this.cbxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cbxAlgorithm_SelectedIndexChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 27);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 13);
            this.label33.TabIndex = 0;
            this.label33.Text = "Algorithm:";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.chkApplyPreProcessing);
            this.groupBox18.Location = new System.Drawing.Point(20, 80);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(404, 53);
            this.groupBox18.TabIndex = 14;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Pre-processing";
            // 
            // chkApplyPreProcessing
            // 
            this.chkApplyPreProcessing.AutoSize = true;
            this.chkApplyPreProcessing.Location = new System.Drawing.Point(19, 22);
            this.chkApplyPreProcessing.Name = "chkApplyPreProcessing";
            this.chkApplyPreProcessing.Size = new System.Drawing.Size(318, 17);
            this.chkApplyPreProcessing.TabIndex = 42;
            this.chkApplyPreProcessing.Text = "Pre-process the sinogram on-the-fly (see \"Pre-processing\" tab)";
            this.chkApplyPreProcessing.UseVisualStyleBackColor = true;
            this.chkApplyPreProcessing.CheckedChanged += new System.EventHandler(this.chkApplyPreProcessing_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbxDatasetName);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(20, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(404, 57);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dataset";
            // 
            // tbxDatasetName
            // 
            this.tbxDatasetName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbxDatasetName.FormattingEnabled = true;
            this.tbxDatasetName.Location = new System.Drawing.Point(67, 22);
            this.tbxDatasetName.Name = "tbxDatasetName";
            this.tbxDatasetName.Size = new System.Drawing.Size(321, 21);
            this.tbxDatasetName.TabIndex = 41;
            this.tbxDatasetName.DropDownClosed += new System.EventHandler(this.tbxDatasetName_DropDownClosed);
            this.tbxDatasetName.Click += new System.EventHandler(this.tbxDatasetName_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "TDF File:";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lblReconstructionOutputPath);
            this.groupBox11.Controls.Add(this.btnReconstructionTab_ExecuteRunAll);
            this.groupBox11.Controls.Add(this.lblReconstructionTab_ExecuteTo);
            this.groupBox11.Controls.Add(this.lblExecutionOutput);
            this.groupBox11.Controls.Add(this.nudReconstructionTab_ExecuteTo);
            this.groupBox11.Controls.Add(this.nudReconstructionTab_ExecuteFrom);
            this.groupBox11.Controls.Add(this.lblReconstructionTab_ExecuteFrom);
            this.groupBox11.Controls.Add(this.btnReconstructionTab_ExecuteRunSubset);
            this.groupBox11.Location = new System.Drawing.Point(21, 655);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(404, 81);
            this.groupBox11.TabIndex = 22;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Execute";
            // 
            // lblReconstructionOutputPath
            // 
            this.lblReconstructionOutputPath.Enabled = false;
            this.lblReconstructionOutputPath.Location = new System.Drawing.Point(85, 22);
            this.lblReconstructionOutputPath.Name = "lblReconstructionOutputPath";
            this.lblReconstructionOutputPath.Size = new System.Drawing.Size(308, 13);
            this.lblReconstructionOutputPath.TabIndex = 10;
            this.lblReconstructionOutputPath.Text = "<file>";
            // 
            // btnReconstructionTab_ExecuteRunAll
            // 
            this.btnReconstructionTab_ExecuteRunAll.Enabled = false;
            this.btnReconstructionTab_ExecuteRunAll.Location = new System.Drawing.Point(316, 44);
            this.btnReconstructionTab_ExecuteRunAll.Name = "btnReconstructionTab_ExecuteRunAll";
            this.btnReconstructionTab_ExecuteRunAll.Size = new System.Drawing.Size(76, 23);
            this.btnReconstructionTab_ExecuteRunAll.TabIndex = 66;
            this.btnReconstructionTab_ExecuteRunAll.Text = "Run All";
            this.btnReconstructionTab_ExecuteRunAll.UseVisualStyleBackColor = true;
            this.btnReconstructionTab_ExecuteRunAll.Click += new System.EventHandler(this.btnReconstruction_RunAll_Click);
            // 
            // lblReconstructionTab_ExecuteTo
            // 
            this.lblReconstructionTab_ExecuteTo.AutoSize = true;
            this.lblReconstructionTab_ExecuteTo.Enabled = false;
            this.lblReconstructionTab_ExecuteTo.Location = new System.Drawing.Point(112, 49);
            this.lblReconstructionTab_ExecuteTo.Name = "lblReconstructionTab_ExecuteTo";
            this.lblReconstructionTab_ExecuteTo.Size = new System.Drawing.Size(23, 13);
            this.lblReconstructionTab_ExecuteTo.TabIndex = 22;
            this.lblReconstructionTab_ExecuteTo.Text = "To:";
            // 
            // lblExecutionOutput
            // 
            this.lblExecutionOutput.AutoSize = true;
            this.lblExecutionOutput.Enabled = false;
            this.lblExecutionOutput.Location = new System.Drawing.Point(9, 22);
            this.lblExecutionOutput.Name = "lblExecutionOutput";
            this.lblExecutionOutput.Size = new System.Drawing.Size(78, 13);
            this.lblExecutionOutput.TabIndex = 9;
            this.lblExecutionOutput.Text = "Output (TIFFs):";
            // 
            // nudReconstructionTab_ExecuteTo
            // 
            this.nudReconstructionTab_ExecuteTo.Enabled = false;
            this.nudReconstructionTab_ExecuteTo.Location = new System.Drawing.Point(136, 46);
            this.nudReconstructionTab_ExecuteTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReconstructionTab_ExecuteTo.Name = "nudReconstructionTab_ExecuteTo";
            this.nudReconstructionTab_ExecuteTo.Size = new System.Drawing.Size(49, 20);
            this.nudReconstructionTab_ExecuteTo.TabIndex = 64;
            this.nudReconstructionTab_ExecuteTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudReconstructionTab_ExecuteTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReconstructionTab_ExecuteTo.ValueChanged += new System.EventHandler(this.nudReconstructionTab_ExecuteTo_ValueChanged);
            // 
            // nudReconstructionTab_ExecuteFrom
            // 
            this.nudReconstructionTab_ExecuteFrom.Enabled = false;
            this.nudReconstructionTab_ExecuteFrom.Location = new System.Drawing.Point(52, 46);
            this.nudReconstructionTab_ExecuteFrom.Name = "nudReconstructionTab_ExecuteFrom";
            this.nudReconstructionTab_ExecuteFrom.Size = new System.Drawing.Size(49, 20);
            this.nudReconstructionTab_ExecuteFrom.TabIndex = 63;
            this.nudReconstructionTab_ExecuteFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudReconstructionTab_ExecuteFrom.ValueChanged += new System.EventHandler(this.nudReconstructionTab_ExecuteFrom_ValueChanged);
            // 
            // lblReconstructionTab_ExecuteFrom
            // 
            this.lblReconstructionTab_ExecuteFrom.AutoSize = true;
            this.lblReconstructionTab_ExecuteFrom.Enabled = false;
            this.lblReconstructionTab_ExecuteFrom.Location = new System.Drawing.Point(16, 49);
            this.lblReconstructionTab_ExecuteFrom.Name = "lblReconstructionTab_ExecuteFrom";
            this.lblReconstructionTab_ExecuteFrom.Size = new System.Drawing.Size(33, 13);
            this.lblReconstructionTab_ExecuteFrom.TabIndex = 19;
            this.lblReconstructionTab_ExecuteFrom.Text = "From:";
            // 
            // btnReconstructionTab_ExecuteRunSubset
            // 
            this.btnReconstructionTab_ExecuteRunSubset.Enabled = false;
            this.btnReconstructionTab_ExecuteRunSubset.Location = new System.Drawing.Point(233, 44);
            this.btnReconstructionTab_ExecuteRunSubset.Name = "btnReconstructionTab_ExecuteRunSubset";
            this.btnReconstructionTab_ExecuteRunSubset.Size = new System.Drawing.Size(76, 23);
            this.btnReconstructionTab_ExecuteRunSubset.TabIndex = 65;
            this.btnReconstructionTab_ExecuteRunSubset.Text = "Run Subset";
            this.btnReconstructionTab_ExecuteRunSubset.UseVisualStyleBackColor = true;
            this.btnReconstructionTab_ExecuteRunSubset.Click += new System.EventHandler(this.button22_Click);
            // 
            // vNavPaneItem8
            // 
            this.vNavPaneItem8.BackColor = System.Drawing.Color.White;
            this.vNavPaneItem8.HeaderText = "Post-processing";
            // 
            // vNavPaneItem8.ItemPanel
            // 
            this.vNavPaneItem8.ItemPanel.AutoScroll = true;
            this.vNavPaneItem8.ItemPanel.Controls.Add(this.gbxPostProcessingTab_Execute);
            this.vNavPaneItem8.ItemPanel.Controls.Add(this.gbxPostProcessingTab_Preview);
            this.vNavPaneItem8.ItemPanel.Controls.Add(this.groupBox22);
            this.vNavPaneItem8.ItemPanel.Controls.Add(this.groupBox33);
            this.vNavPaneItem8.ItemPanel.Controls.Add(this.gbxPostProc_PolarFiltr);
            this.vNavPaneItem8.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItem8.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItem8.ItemPanel.Size = new System.Drawing.Size(452, 0);
            this.vNavPaneItem8.ItemPanel.TabIndex = 1;
            this.vNavPaneItem8.Location = new System.Drawing.Point(0, 657);
            this.vNavPaneItem8.Name = "vNavPaneItem8";
            this.vNavPaneItem8.Size = new System.Drawing.Size(454, 30);
            this.vNavPaneItem8.TabIndex = 6;
            this.vNavPaneItem8.Text = "vPostProcessingPaneItem";
            this.vNavPaneItem8.TooltipText = "Post-processing";
            // 
            // gbxPostProcessingTab_Execute
            // 
            this.gbxPostProcessingTab_Execute.Controls.Add(this.txbPostProcessingTab_OutputPath);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.btnPostProcessinTab_BrowseOutput);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.label21);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.btnPostProcessingTab_RunAll);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.lblPostProcessingTab_To);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.nudPostProcessingTab_ExecuteTo);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.nudPostProcessingTab_ExecuteFrom);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.lblPostProcessingTab_From);
            this.gbxPostProcessingTab_Execute.Controls.Add(this.btnPostProcessingTab_RunSubset);
            this.gbxPostProcessingTab_Execute.Enabled = false;
            this.gbxPostProcessingTab_Execute.Location = new System.Drawing.Point(16, 398);
            this.gbxPostProcessingTab_Execute.Name = "gbxPostProcessingTab_Execute";
            this.gbxPostProcessingTab_Execute.Size = new System.Drawing.Size(404, 83);
            this.gbxPostProcessingTab_Execute.TabIndex = 26;
            this.gbxPostProcessingTab_Execute.TabStop = false;
            this.gbxPostProcessingTab_Execute.Text = "Execute";
            // 
            // txbPostProcessingTab_OutputPath
            // 
            this.txbPostProcessingTab_OutputPath.Location = new System.Drawing.Point(66, 19);
            this.txbPostProcessingTab_OutputPath.Name = "txbPostProcessingTab_OutputPath";
            this.txbPostProcessingTab_OutputPath.Size = new System.Drawing.Size(243, 20);
            this.txbPostProcessingTab_OutputPath.TabIndex = 78;
            this.txbPostProcessingTab_OutputPath.TextChanged += new System.EventHandler(this.txbPostProcessingTab_OutputPath_TextChanged);
            // 
            // btnPostProcessinTab_BrowseOutput
            // 
            this.btnPostProcessinTab_BrowseOutput.Location = new System.Drawing.Point(317, 17);
            this.btnPostProcessinTab_BrowseOutput.Name = "btnPostProcessinTab_BrowseOutput";
            this.btnPostProcessinTab_BrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.btnPostProcessinTab_BrowseOutput.TabIndex = 79;
            this.btnPostProcessinTab_BrowseOutput.Text = "Browse...";
            this.btnPostProcessinTab_BrowseOutput.UseVisualStyleBackColor = true;
            this.btnPostProcessinTab_BrowseOutput.Click += new System.EventHandler(this.btnPostProcessinTab_BrowseOutput_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "TIFF folder:";
            // 
            // btnPostProcessingTab_RunAll
            // 
            this.btnPostProcessingTab_RunAll.Enabled = false;
            this.btnPostProcessingTab_RunAll.Location = new System.Drawing.Point(316, 47);
            this.btnPostProcessingTab_RunAll.Name = "btnPostProcessingTab_RunAll";
            this.btnPostProcessingTab_RunAll.Size = new System.Drawing.Size(76, 23);
            this.btnPostProcessingTab_RunAll.TabIndex = 83;
            this.btnPostProcessingTab_RunAll.Text = "Run All";
            this.btnPostProcessingTab_RunAll.UseVisualStyleBackColor = true;
            this.btnPostProcessingTab_RunAll.Click += new System.EventHandler(this.btnPostProcessingTab_RunAll_Click);
            // 
            // lblPostProcessingTab_To
            // 
            this.lblPostProcessingTab_To.AutoSize = true;
            this.lblPostProcessingTab_To.Enabled = false;
            this.lblPostProcessingTab_To.Location = new System.Drawing.Point(116, 53);
            this.lblPostProcessingTab_To.Name = "lblPostProcessingTab_To";
            this.lblPostProcessingTab_To.Size = new System.Drawing.Size(23, 13);
            this.lblPostProcessingTab_To.TabIndex = 22;
            this.lblPostProcessingTab_To.Text = "To:";
            // 
            // nudPostProcessingTab_ExecuteTo
            // 
            this.nudPostProcessingTab_ExecuteTo.Enabled = false;
            this.nudPostProcessingTab_ExecuteTo.Location = new System.Drawing.Point(142, 50);
            this.nudPostProcessingTab_ExecuteTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPostProcessingTab_ExecuteTo.Name = "nudPostProcessingTab_ExecuteTo";
            this.nudPostProcessingTab_ExecuteTo.Size = new System.Drawing.Size(49, 20);
            this.nudPostProcessingTab_ExecuteTo.TabIndex = 81;
            this.nudPostProcessingTab_ExecuteTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPostProcessingTab_ExecuteTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudPostProcessingTab_ExecuteFrom
            // 
            this.nudPostProcessingTab_ExecuteFrom.Enabled = false;
            this.nudPostProcessingTab_ExecuteFrom.Location = new System.Drawing.Point(66, 50);
            this.nudPostProcessingTab_ExecuteFrom.Name = "nudPostProcessingTab_ExecuteFrom";
            this.nudPostProcessingTab_ExecuteFrom.Size = new System.Drawing.Size(49, 20);
            this.nudPostProcessingTab_ExecuteFrom.TabIndex = 80;
            this.nudPostProcessingTab_ExecuteFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPostProcessingTab_From
            // 
            this.lblPostProcessingTab_From.AutoSize = true;
            this.lblPostProcessingTab_From.Enabled = false;
            this.lblPostProcessingTab_From.Location = new System.Drawing.Point(30, 53);
            this.lblPostProcessingTab_From.Name = "lblPostProcessingTab_From";
            this.lblPostProcessingTab_From.Size = new System.Drawing.Size(33, 13);
            this.lblPostProcessingTab_From.TabIndex = 19;
            this.lblPostProcessingTab_From.Text = "From:";
            // 
            // btnPostProcessingTab_RunSubset
            // 
            this.btnPostProcessingTab_RunSubset.Enabled = false;
            this.btnPostProcessingTab_RunSubset.Location = new System.Drawing.Point(233, 47);
            this.btnPostProcessingTab_RunSubset.Name = "btnPostProcessingTab_RunSubset";
            this.btnPostProcessingTab_RunSubset.Size = new System.Drawing.Size(76, 23);
            this.btnPostProcessingTab_RunSubset.TabIndex = 82;
            this.btnPostProcessingTab_RunSubset.Text = "Run Subset";
            this.btnPostProcessingTab_RunSubset.UseVisualStyleBackColor = true;
            this.btnPostProcessingTab_RunSubset.Click += new System.EventHandler(this.btnPostProcessingTab_RunSubset_Click);
            // 
            // gbxPostProcessingTab_Preview
            // 
            this.gbxPostProcessingTab_Preview.Controls.Add(this.btnPostProcessingTab_Preview);
            this.gbxPostProcessingTab_Preview.Controls.Add(this.nudPostProcessingTab_PreviewSlice);
            this.gbxPostProcessingTab_Preview.Controls.Add(this.label39);
            this.gbxPostProcessingTab_Preview.Enabled = false;
            this.gbxPostProcessingTab_Preview.Location = new System.Drawing.Point(16, 342);
            this.gbxPostProcessingTab_Preview.Name = "gbxPostProcessingTab_Preview";
            this.gbxPostProcessingTab_Preview.Size = new System.Drawing.Size(404, 50);
            this.gbxPostProcessingTab_Preview.TabIndex = 25;
            this.gbxPostProcessingTab_Preview.TabStop = false;
            this.gbxPostProcessingTab_Preview.Text = "Preview";
            // 
            // btnPostProcessingTab_Preview
            // 
            this.btnPostProcessingTab_Preview.Location = new System.Drawing.Point(316, 18);
            this.btnPostProcessingTab_Preview.Name = "btnPostProcessingTab_Preview";
            this.btnPostProcessingTab_Preview.Size = new System.Drawing.Size(75, 23);
            this.btnPostProcessingTab_Preview.TabIndex = 78;
            this.btnPostProcessingTab_Preview.Text = "Preview";
            this.btnPostProcessingTab_Preview.UseVisualStyleBackColor = true;
            this.btnPostProcessingTab_Preview.Click += new System.EventHandler(this.btnPostProcessingTab_Preview_Click);
            // 
            // nudPostProcessingTab_PreviewSlice
            // 
            this.nudPostProcessingTab_PreviewSlice.Location = new System.Drawing.Point(66, 19);
            this.nudPostProcessingTab_PreviewSlice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPostProcessingTab_PreviewSlice.Name = "nudPostProcessingTab_PreviewSlice";
            this.nudPostProcessingTab_PreviewSlice.Size = new System.Drawing.Size(50, 20);
            this.nudPostProcessingTab_PreviewSlice.TabIndex = 77;
            this.nudPostProcessingTab_PreviewSlice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(30, 23);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(33, 13);
            this.label39.TabIndex = 22;
            this.label39.Text = "Slice:";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.txbPostProcessingTab_InputFolder);
            this.groupBox22.Controls.Add(this.btnPostProcessingTab_BrowseInput);
            this.groupBox22.Controls.Add(this.label22);
            this.groupBox22.Location = new System.Drawing.Point(15, 20);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(404, 58);
            this.groupBox22.TabIndex = 23;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Dataset";
            // 
            // txbPostProcessingTab_InputFolder
            // 
            this.txbPostProcessingTab_InputFolder.Location = new System.Drawing.Point(67, 22);
            this.txbPostProcessingTab_InputFolder.Name = "txbPostProcessingTab_InputFolder";
            this.txbPostProcessingTab_InputFolder.Size = new System.Drawing.Size(243, 20);
            this.txbPostProcessingTab_InputFolder.TabIndex = 67;
            this.txbPostProcessingTab_InputFolder.TextChanged += new System.EventHandler(this.txbPostProcessingTab_InputFolder_TextChanged);
            // 
            // btnPostProcessingTab_BrowseInput
            // 
            this.btnPostProcessingTab_BrowseInput.Location = new System.Drawing.Point(316, 20);
            this.btnPostProcessingTab_BrowseInput.Name = "btnPostProcessingTab_BrowseInput";
            this.btnPostProcessingTab_BrowseInput.Size = new System.Drawing.Size(75, 23);
            this.btnPostProcessingTab_BrowseInput.TabIndex = 68;
            this.btnPostProcessingTab_BrowseInput.Text = "Browse...";
            this.btnPostProcessingTab_BrowseInput.UseVisualStyleBackColor = true;
            this.btnPostProcessingTab_BrowseInput.Click += new System.EventHandler(this.btnPostProcessingTab_BrowseInput_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 13);
            this.label22.TabIndex = 4;
            this.label22.Text = "TIFF folder:";
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.groupBox31);
            this.groupBox33.Controls.Add(this.label2);
            this.groupBox33.Controls.Add(this.gbxPostProcessingTab_MethodSettings);
            this.groupBox33.Controls.Add(this.cbxDegradationMethods);
            this.groupBox33.Controls.Add(this.label82);
            this.groupBox33.Location = new System.Drawing.Point(15, 194);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(404, 142);
            this.groupBox33.TabIndex = 24;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Degrade / Crop";
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.nudConvertToTDF_CropRight);
            this.groupBox31.Controls.Add(this.label4);
            this.groupBox31.Controls.Add(this.nudConvertToTDF_CropLeft);
            this.groupBox31.Controls.Add(this.label70);
            this.groupBox31.Controls.Add(this.nudConvertToTDF_CropBottom);
            this.groupBox31.Controls.Add(this.nudConvertToTDF_CropTop);
            this.groupBox31.Controls.Add(this.label32);
            this.groupBox31.Controls.Add(this.label30);
            this.groupBox31.Location = new System.Drawing.Point(13, 53);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(194, 77);
            this.groupBox31.TabIndex = 40;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Crop";
            // 
            // nudConvertToTDF_CropRight
            // 
            this.nudConvertToTDF_CropRight.Location = new System.Drawing.Point(134, 45);
            this.nudConvertToTDF_CropRight.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropRight.Name = "nudConvertToTDF_CropRight";
            this.nudConvertToTDF_CropRight.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropRight.TabIndex = 73;
            this.nudConvertToTDF_CropRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudConvertToTDF_CropRight.ValueChanged += new System.EventHandler(this.nudConvertToTDF_CropRight_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Right:";
            // 
            // nudConvertToTDF_CropLeft
            // 
            this.nudConvertToTDF_CropLeft.Location = new System.Drawing.Point(134, 19);
            this.nudConvertToTDF_CropLeft.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropLeft.Name = "nudConvertToTDF_CropLeft";
            this.nudConvertToTDF_CropLeft.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropLeft.TabIndex = 72;
            this.nudConvertToTDF_CropLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudConvertToTDF_CropLeft.ValueChanged += new System.EventHandler(this.nudConvertToTDF_CropLeft_ValueChanged);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(107, 22);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(28, 13);
            this.label70.TabIndex = 11;
            this.label70.Text = "Left:";
            // 
            // nudConvertToTDF_CropBottom
            // 
            this.nudConvertToTDF_CropBottom.Location = new System.Drawing.Point(46, 46);
            this.nudConvertToTDF_CropBottom.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropBottom.Name = "nudConvertToTDF_CropBottom";
            this.nudConvertToTDF_CropBottom.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropBottom.TabIndex = 71;
            this.nudConvertToTDF_CropBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudConvertToTDF_CropBottom.ValueChanged += new System.EventHandler(this.nudConvertToTDF_CropBottom_ValueChanged);
            // 
            // nudConvertToTDF_CropTop
            // 
            this.nudConvertToTDF_CropTop.Location = new System.Drawing.Point(46, 19);
            this.nudConvertToTDF_CropTop.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudConvertToTDF_CropTop.Name = "nudConvertToTDF_CropTop";
            this.nudConvertToTDF_CropTop.Size = new System.Drawing.Size(50, 20);
            this.nudConvertToTDF_CropTop.TabIndex = 70;
            this.nudConvertToTDF_CropTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudConvertToTDF_CropTop.ValueChanged += new System.EventHandler(this.nudConvertToTDF_CropTop_ValueChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(17, 22);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 13);
            this.label32.TabIndex = 7;
            this.label32.Text = "Top:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(4, 48);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(43, 13);
            this.label30.TabIndex = 10;
            this.label30.Text = "Bottom:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Method:";
            // 
            // gbxPostProcessingTab_MethodSettings
            // 
            this.gbxPostProcessingTab_MethodSettings.Controls.Add(this.btnPostProcessingTab_AutoLimit);
            this.gbxPostProcessingTab_MethodSettings.Controls.Add(this.txbPostProcessingTab_LinearRescaleMin);
            this.gbxPostProcessingTab_MethodSettings.Controls.Add(this.txbPostProcessingTab_LinearRescaleMax);
            this.gbxPostProcessingTab_MethodSettings.Controls.Add(this.lblPostProcessingTab_LinearRescaleMax);
            this.gbxPostProcessingTab_MethodSettings.Controls.Add(this.lblPostProcessingTab_LinearRescaleMin);
            this.gbxPostProcessingTab_MethodSettings.Enabled = false;
            this.gbxPostProcessingTab_MethodSettings.Location = new System.Drawing.Point(213, 53);
            this.gbxPostProcessingTab_MethodSettings.Name = "gbxPostProcessingTab_MethodSettings";
            this.gbxPostProcessingTab_MethodSettings.Size = new System.Drawing.Size(178, 77);
            this.gbxPostProcessingTab_MethodSettings.TabIndex = 38;
            this.gbxPostProcessingTab_MethodSettings.TabStop = false;
            this.gbxPostProcessingTab_MethodSettings.Text = "Method settings";
            this.gbxPostProcessingTab_MethodSettings.UseCompatibleTextRendering = true;
            // 
            // btnPostProcessingTab_AutoLimit
            // 
            this.btnPostProcessingTab_AutoLimit.Location = new System.Drawing.Point(97, 29);
            this.btnPostProcessingTab_AutoLimit.Name = "btnPostProcessingTab_AutoLimit";
            this.btnPostProcessingTab_AutoLimit.Size = new System.Drawing.Size(73, 23);
            this.btnPostProcessingTab_AutoLimit.TabIndex = 76;
            this.btnPostProcessingTab_AutoLimit.Text = "Auto";
            this.btnPostProcessingTab_AutoLimit.UseVisualStyleBackColor = true;
            this.btnPostProcessingTab_AutoLimit.Click += new System.EventHandler(this.btnPostProcessingTab_AutoLimit_Click);
            // 
            // txbPostProcessingTab_LinearRescaleMin
            // 
            this.txbPostProcessingTab_LinearRescaleMin.Location = new System.Drawing.Point(38, 19);
            this.txbPostProcessingTab_LinearRescaleMin.Name = "txbPostProcessingTab_LinearRescaleMin";
            this.txbPostProcessingTab_LinearRescaleMin.Size = new System.Drawing.Size(50, 20);
            this.txbPostProcessingTab_LinearRescaleMin.TabIndex = 74;
            this.txbPostProcessingTab_LinearRescaleMin.Text = "-0.010";
            this.txbPostProcessingTab_LinearRescaleMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbPostProcessingTab_LinearRescaleMax
            // 
            this.txbPostProcessingTab_LinearRescaleMax.Location = new System.Drawing.Point(38, 46);
            this.txbPostProcessingTab_LinearRescaleMax.Name = "txbPostProcessingTab_LinearRescaleMax";
            this.txbPostProcessingTab_LinearRescaleMax.Size = new System.Drawing.Size(50, 20);
            this.txbPostProcessingTab_LinearRescaleMax.TabIndex = 75;
            this.txbPostProcessingTab_LinearRescaleMax.Text = "0.010";
            this.txbPostProcessingTab_LinearRescaleMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPostProcessingTab_LinearRescaleMax
            // 
            this.lblPostProcessingTab_LinearRescaleMax.AutoSize = true;
            this.lblPostProcessingTab_LinearRescaleMax.Location = new System.Drawing.Point(7, 49);
            this.lblPostProcessingTab_LinearRescaleMax.Name = "lblPostProcessingTab_LinearRescaleMax";
            this.lblPostProcessingTab_LinearRescaleMax.Size = new System.Drawing.Size(30, 13);
            this.lblPostProcessingTab_LinearRescaleMax.TabIndex = 28;
            this.lblPostProcessingTab_LinearRescaleMax.Text = "Max:";
            // 
            // lblPostProcessingTab_LinearRescaleMin
            // 
            this.lblPostProcessingTab_LinearRescaleMin.AutoSize = true;
            this.lblPostProcessingTab_LinearRescaleMin.Location = new System.Drawing.Point(10, 22);
            this.lblPostProcessingTab_LinearRescaleMin.Name = "lblPostProcessingTab_LinearRescaleMin";
            this.lblPostProcessingTab_LinearRescaleMin.Size = new System.Drawing.Size(27, 13);
            this.lblPostProcessingTab_LinearRescaleMin.TabIndex = 26;
            this.lblPostProcessingTab_LinearRescaleMin.Text = "Min:";
            // 
            // cbxDegradationMethods
            // 
            this.cbxDegradationMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDegradationMethods.DropDownWidth = 338;
            this.cbxDegradationMethods.FormattingEnabled = true;
            this.cbxDegradationMethods.Location = new System.Drawing.Point(67, 22);
            this.cbxDegradationMethods.Name = "cbxDegradationMethods";
            this.cbxDegradationMethods.Size = new System.Drawing.Size(323, 21);
            this.cbxDegradationMethods.TabIndex = 69;
            this.cbxDegradationMethods.SelectedIndexChanged += new System.EventHandler(this.cbxDegradationMethods_SelectedIndexChanged);
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(240, 23);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(10, 13);
            this.label82.TabIndex = 10;
            this.label82.Text = ",";
            // 
            // gbxPostProc_PolarFiltr
            // 
            //this.gbxPostProc_PolarFiltr.Controls.Add(this.chkPostProc_PolarLock);
            //this.gbxPostProc_PolarFiltr.Controls.Add(this.nudPostProc_PolarFilt_OverSampl);
            //this.gbxPostProc_PolarFiltr.Controls.Add(this.label16);
            //this.gbxPostProc_PolarFiltr.Controls.Add(this.nudPostProc_PolarCenterY);
            this.gbxPostProc_PolarFiltr.Controls.Add(this.groupBox6);
            //this.gbxPostProc_PolarFiltr.Controls.Add(this.nudPostProc_PolarCenterX);
            this.gbxPostProc_PolarFiltr.Controls.Add(this.cbxPostProc_PolarFilt_Method);
            //this.gbxPostProc_PolarFiltr.Controls.Add(this.lblPostProc_PolarCenterX);
            //this.gbxPostProc_PolarFiltr.Controls.Add(this.lblPostProc_PolarCenterY);
            this.gbxPostProc_PolarFiltr.Controls.Add(this.label8);
            this.gbxPostProc_PolarFiltr.Enabled = true;
            this.gbxPostProc_PolarFiltr.Location = new System.Drawing.Point(15, 84);
            this.gbxPostProc_PolarFiltr.Name = "gbxPostProc_PolarFiltr";
            this.gbxPostProc_PolarFiltr.Size = new System.Drawing.Size(404, 105);
            this.gbxPostProc_PolarFiltr.TabIndex = 27;
            this.gbxPostProc_PolarFiltr.TabStop = false;
            this.gbxPostProc_PolarFiltr.Text = "Polar transformed filtering";
            // 
            // chkPostProc_PolarLock
            // 
            this.chkPostProc_PolarLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPostProc_PolarLock.AutoSize = true;
            this.chkPostProc_PolarLock.Checked = true;
            this.chkPostProc_PolarLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPostProc_PolarLock.Image = ((System.Drawing.Image)(resources.GetObject("chkPostProc_PolarLock.Image")));
            this.chkPostProc_PolarLock.Location = new System.Drawing.Point(117, 60);
            this.chkPostProc_PolarLock.Name = "chkPostProc_PolarLock";
            this.chkPostProc_PolarLock.Size = new System.Drawing.Size(22, 22);
            this.chkPostProc_PolarLock.TabIndex = 44;
            this.chkPostProc_PolarLock.UseVisualStyleBackColor = true;
            // 
            // nudPostProc_PolarFilt_OverSampl
            // 
            this.nudPostProc_PolarFilt_OverSampl.DecimalPlaces = 1;
            this.nudPostProc_PolarFilt_OverSampl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPostProc_PolarFilt_OverSampl.Location = new System.Drawing.Point(223, 47);
            this.nudPostProc_PolarFilt_OverSampl.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            65536});
            this.nudPostProc_PolarFilt_OverSampl.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudPostProc_PolarFilt_OverSampl.Name = "nudPostProc_PolarFilt_OverSampl";
            this.nudPostProc_PolarFilt_OverSampl.Size = new System.Drawing.Size(40, 20);
            this.nudPostProc_PolarFilt_OverSampl.TabIndex = 31;
            this.nudPostProc_PolarFilt_OverSampl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPostProc_PolarFilt_OverSampl.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(140, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 20);
            this.label16.TabIndex = 32;
            this.label16.Text = "Oversampling:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPostProc_PolarCenterY
            // 
            this.nudPostProc_PolarCenterY.Enabled = false;
            this.nudPostProc_PolarCenterY.Location = new System.Drawing.Point(62, 74);
            this.nudPostProc_PolarCenterY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPostProc_PolarCenterY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPostProc_PolarCenterY.Name = "nudPostProc_PolarCenterY";
            this.nudPostProc_PolarCenterY.Size = new System.Drawing.Size(50, 20);
            this.nudPostProc_PolarCenterY.TabIndex = 28;
            this.nudPostProc_PolarCenterY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPostProc_PolarCenterY.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudPostProc_PolarFilter_Param2);
            this.groupBox6.Controls.Add(this.nudPostProc_PolarFilter_Param1);
            this.groupBox6.Controls.Add(this.lblPostProc_PolarFilt_Param1);
            this.groupBox6.Controls.Add(this.lblPostProc_PolarFilt_Param2);
            this.groupBox6.Location = new System.Drawing.Point(271, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(122, 81);
            this.groupBox6.TabIndex = 29;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Parameters";
            // 
            // nudPostProc_PolarFilter_Param2
            // 
            this.nudPostProc_PolarFilter_Param2.Location = new System.Drawing.Point(65, 48);
            this.nudPostProc_PolarFilter_Param2.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudPostProc_PolarFilter_Param2.Name = "nudPostProc_PolarFilter_Param2";
            this.nudPostProc_PolarFilter_Param2.Size = new System.Drawing.Size(50, 20);
            this.nudPostProc_PolarFilter_Param2.TabIndex = 24;
            this.nudPostProc_PolarFilter_Param2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudPostProc_PolarFilter_Param1
            // 
            this.nudPostProc_PolarFilter_Param1.Location = new System.Drawing.Point(65, 22);
            this.nudPostProc_PolarFilter_Param1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudPostProc_PolarFilter_Param1.Name = "nudPostProc_PolarFilter_Param1";
            this.nudPostProc_PolarFilter_Param1.Size = new System.Drawing.Size(50, 20);
            this.nudPostProc_PolarFilter_Param1.TabIndex = 23;
            this.nudPostProc_PolarFilter_Param1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPostProc_PolarFilt_Param1
            // 
            this.lblPostProc_PolarFilt_Param1.Location = new System.Drawing.Point(2, 25);
            this.lblPostProc_PolarFilt_Param1.Name = "lblPostProc_PolarFilt_Param1";
            this.lblPostProc_PolarFilt_Param1.Size = new System.Drawing.Size(63, 13);
            this.lblPostProc_PolarFilt_Param1.TabIndex = 25;
            this.lblPostProc_PolarFilt_Param1.Text = "Width:";
            this.lblPostProc_PolarFilt_Param1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostProc_PolarFilt_Param2
            // 
            this.lblPostProc_PolarFilt_Param2.Location = new System.Drawing.Point(2, 51);
            this.lblPostProc_PolarFilt_Param2.Name = "lblPostProc_PolarFilt_Param2";
            this.lblPostProc_PolarFilt_Param2.Size = new System.Drawing.Size(63, 13);
            this.lblPostProc_PolarFilt_Param2.TabIndex = 26;
            this.lblPostProc_PolarFilt_Param2.Text = "Sigma:";
            this.lblPostProc_PolarFilt_Param2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudPostProc_PolarCenterX
            // 
            this.nudPostProc_PolarCenterX.Enabled = false;
            this.nudPostProc_PolarCenterX.Location = new System.Drawing.Point(62, 47);
            this.nudPostProc_PolarCenterX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudPostProc_PolarCenterX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPostProc_PolarCenterX.Name = "nudPostProc_PolarCenterX";
            this.nudPostProc_PolarCenterX.Size = new System.Drawing.Size(50, 20);
            this.nudPostProc_PolarCenterX.TabIndex = 27;
            this.nudPostProc_PolarCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPostProc_PolarCenterX.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // cbxPostProc_PolarFilt_Method
            // 
            this.cbxPostProc_PolarFilt_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPostProc_PolarFilt_Method.FormattingEnabled = true;
            this.cbxPostProc_PolarFilt_Method.Items.AddRange(new object[] {
            "Flat fielding with air normalization"});
            this.cbxPostProc_PolarFilt_Method.Location = new System.Drawing.Point(62, 19);
            this.cbxPostProc_PolarFilt_Method.Name = "cbxPostProc_PolarFilt_Method";
            this.cbxPostProc_PolarFilt_Method.Size = new System.Drawing.Size(201, 21);
            this.cbxPostProc_PolarFilt_Method.TabIndex = 22;
            this.cbxPostProc_PolarFilt_Method.SelectedIndexChanged += new System.EventHandler(this.cbxPostProc_PolarFilt_Method_SelectedIndexChanged);
            // 
            // lblPostProc_PolarCenterX
            // 
            this.lblPostProc_PolarCenterX.Enabled = false;
            this.lblPostProc_PolarCenterX.Location = new System.Drawing.Point(5, 48);
            this.lblPostProc_PolarCenterX.Name = "lblPostProc_PolarCenterX";
            this.lblPostProc_PolarCenterX.Size = new System.Drawing.Size(54, 19);
            this.lblPostProc_PolarCenterX.TabIndex = 29;
            this.lblPostProc_PolarCenterX.Text = "Center X:";
            this.lblPostProc_PolarCenterX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPostProc_PolarCenterY
            // 
            this.lblPostProc_PolarCenterY.Enabled = false;
            this.lblPostProc_PolarCenterY.Location = new System.Drawing.Point(4, 76);
            this.lblPostProc_PolarCenterY.Name = "lblPostProc_PolarCenterY";
            this.lblPostProc_PolarCenterY.Size = new System.Drawing.Size(56, 16);
            this.lblPostProc_PolarCenterY.TabIndex = 30;
            this.lblPostProc_PolarCenterY.Text = "Center Y:";
            this.lblPostProc_PolarCenterY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Method:";
            // 
            // zInputTIFFsBrowserDialog
            // 
            this.zInputTIFFsBrowserDialog.Description = "Browse for TIFF sequence:";
            this.zInputTIFFsBrowserDialog.ShowNewFolderButton = false;
            // 
            // zInputTDFFileDialog
            // 
            this.zInputTDFFileDialog.Filter = "SYRMEP Tomo Data Format|*.tdf|All files|*.*";
            this.zInputTDFFileDialog.Title = "Browse for TDF file";
            // 
            // zOutputPathBrowserDialog
            // 
            this.zOutputPathBrowserDialog.Description = "Select output folder:";
            // 
            // mJobMonitorBgw
            // 
            this.mJobMonitorBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.mJobMonitorBgw_DoWork);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vNavPaneImage);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.vLogNavPane);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(731, 687);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 0;
            // 
            // vNavPaneImage
            // 
            this.vNavPaneImage.Controls.Add(this.vNavPaneItem2);
            this.vNavPaneImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vNavPaneImage.Items.Add(this.vNavPaneItem2);
            this.vNavPaneImage.Location = new System.Drawing.Point(0, 0);
            this.vNavPaneImage.Name = "vNavPaneImage";
            this.vNavPaneImage.Size = new System.Drawing.Size(731, 481);
            this.vNavPaneImage.TabIndex = 0;
            this.vNavPaneImage.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // vNavPaneItem2
            // 
            this.vNavPaneItem2.BackColor = System.Drawing.Color.White;
            this.vNavPaneItem2.HeaderText = "Image Viewer";
            // 
            // vNavPaneItem2.ItemPanel
            // 
            this.vNavPaneItem2.ItemPanel.AutoScroll = true;
            this.vNavPaneItem2.ItemPanel.Controls.Add(this.kpImageViewer1);
            this.vNavPaneItem2.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItem2.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItem2.ItemPanel.Size = new System.Drawing.Size(729, 450);
            this.vNavPaneItem2.ItemPanel.TabIndex = 1;
            this.vNavPaneItem2.Location = new System.Drawing.Point(0, 0);
            this.vNavPaneItem2.Name = "vNavPaneItem2";
            this.vNavPaneItem2.Size = new System.Drawing.Size(731, 481);
            this.vNavPaneItem2.TabIndex = 0;
            this.vNavPaneItem2.Text = "vNavPaneImage_ItemViewer";
            this.vNavPaneItem2.TooltipText = "Image Viewer";
            // 
            // kpImageViewer1
            // 
            this.kpImageViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.kpImageViewer1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.kpImageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpImageViewer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kpImageViewer1.Image = null;
            this.kpImageViewer1.Location = new System.Drawing.Point(0, 0);
            this.kpImageViewer1.MenuColor = System.Drawing.Color.Transparent;
            this.kpImageViewer1.MenuPanelColor = System.Drawing.Color.Transparent;
            this.kpImageViewer1.MinimumSize = new System.Drawing.Size(454, 157);
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
            this.kpImageViewer1.Size = new System.Drawing.Size(729, 450);
            this.kpImageViewer1.TabIndex = 0;
            this.kpImageViewer1.TextColor = System.Drawing.SystemColors.MenuText;
            this.kpImageViewer1.Zoom = 100D;
            // 
            // vLogNavPane
            // 
            this.vLogNavPane.Controls.Add(this.vNavPaneItem6);
            this.vLogNavPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vLogNavPane.Items.Add(this.vNavPaneItem6);
            this.vLogNavPane.Location = new System.Drawing.Point(0, 0);
            this.vLogNavPane.Name = "vLogNavPane";
            this.vLogNavPane.Size = new System.Drawing.Size(731, 202);
            this.vLogNavPane.TabIndex = 5;
            this.vLogNavPane.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // vNavPaneItem6
            // 
            this.vNavPaneItem6.BackColor = System.Drawing.Color.White;
            this.vNavPaneItem6.HeaderText = "Log";
            // 
            // vNavPaneItem6.ItemPanel
            // 
            this.vNavPaneItem6.ItemPanel.AutoScroll = true;
            this.vNavPaneItem6.ItemPanel.Controls.Add(this.zLogTxb);
            this.vNavPaneItem6.ItemPanel.Location = new System.Drawing.Point(1, 30);
            this.vNavPaneItem6.ItemPanel.Name = "ItemPanel";
            this.vNavPaneItem6.ItemPanel.Padding = new System.Windows.Forms.Padding(10);
            this.vNavPaneItem6.ItemPanel.Size = new System.Drawing.Size(729, 171);
            this.vNavPaneItem6.ItemPanel.TabIndex = 1;
            this.vNavPaneItem6.Location = new System.Drawing.Point(0, 0);
            this.vNavPaneItem6.Name = "vNavPaneItem6";
            this.vNavPaneItem6.Size = new System.Drawing.Size(731, 202);
            this.vNavPaneItem6.TabIndex = 0;
            this.vNavPaneItem6.Text = "Log";
            this.vNavPaneItem6.TooltipText = "Log";
            // 
            // zLogTxb
            // 
            this.zLogTxb.BackColor = System.Drawing.Color.White;
            this.zLogTxb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zLogTxb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLogTxb.Location = new System.Drawing.Point(10, 10);
            this.zLogTxb.Multiline = true;
            this.zLogTxb.Name = "zLogTxb";
            this.zLogTxb.ReadOnly = true;
            this.zLogTxb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.zLogTxb.Size = new System.Drawing.Size(709, 151);
            this.zLogTxb.TabIndex = 0;
            // 
            // vImageNavPane
            // 
            this.vImageNavPane.Controls.Add(this.splitContainer1);
            this.vImageNavPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vImageNavPane.Location = new System.Drawing.Point(454, 24);
            this.vImageNavPane.Name = "vImageNavPane";
            this.vImageNavPane.Size = new System.Drawing.Size(731, 687);
            this.vImageNavPane.TabIndex = 5;
            this.vImageNavPane.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.VISTABLUE;
            // 
            // bgwGuessOffset
            // 
            this.bgwGuessOffset.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGuessOffset_DoWork);
            this.bgwGuessOffset.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGuessOffset_RunWorkerCompleted);
            // 
            // bgwGuessOverlap
            // 
            this.bgwGuessOverlap.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGuessOverlap_DoWork);
            this.bgwGuessOverlap.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGuessOverlap_RunWorkerCompleted);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "<none>",
            "shepp-logan (default)",
            "ram-lak",
            "cosine",
            "hamming",
            "hann",
            "tukey",
            "lanczos",
            "triangular",
            "gaussian",
            "barlett-hann",
            "blackman",
            "nuttall ",
            "blackman-harris",
            "blackman-nuttall",
            "flat-top",
            "kaiser",
            "parzen"});
            this.comboBox2.Location = new System.Drawing.Point(213, 229);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(189, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // mBgwPreview
            // 
            this.mBgwPreview.DoWork += new System.ComponentModel.DoWorkEventHandler(this.mBgwPreview_DoWork);
            this.mBgwPreview.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.mBgwPreview_RunWorkerCompleted);
            // 
            // bgwAutoLimit
            // 
            this.bgwAutoLimit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAutoLimit_DoWork);
            this.bgwAutoLimit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAutoLimit_RunWorkerCompleted);
            // 
            // mBgwPostProcessingPreview
            // 
            this.mBgwPostProcessingPreview.DoWork += new System.ComponentModel.DoWorkEventHandler(this.mBgwPreview_DoWork);
            this.mBgwPostProcessingPreview.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.mBgwPostProcessingPreview_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 733);
            this.Controls.Add(this.vImageNavPane);
            this.Controls.Add(this.vNavPane1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "SYRMEP Tomo Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.Form1_Layout);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.vNavPane1.ResumeLayout(false);
            this.vNavPaneItem1.ItemPanel.ResumeLayout(false);
            this.vNavPaneItem1.ResumeLayout(false);
            this.gbxDatasetInfo_Preview.ResumeLayout(false);
            this.gbxDatasetInfo_Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Dark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Flat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Sinogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDatasetTab_Projection)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbxDatasetInfo_Metadata.ResumeLayout(false);
            this.gbxDatasetInfo_Metadata.PerformLayout();
            this.vNavPaneItem3.ItemPanel.ResumeLayout(false);
            this.vNavPaneItem3.ResumeLayout(false);
            this.gbxPreProcessing_Execute.ResumeLayout(false);
            this.gbxPreProcessing_Execute.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExtendedFOVOverlap)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRingRemParam2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRingRemParam1)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHalfHalfMode)).EndInit();
            this.groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudNormSx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormDx)).EndInit();
            this.gbxPreProcessing_Preview.ResumeLayout(false);
            this.gbxPreProcessing_Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPreprocessingTab_Preview)).EndInit();
            this.vNavPaneItem7.ItemPanel.ResumeLayout(false);
            this.vNavPaneItem7.ResumeLayout(false);
            this.gbxPhaseRetrieval_Preview.ResumeLayout(false);
            this.gbxPhaseRetrieval_Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseretrievalTab_ProjectionPreview)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.gbxPhaseRetrieval_Execution.ResumeLayout(false);
            this.gbxPhaseRetrieval_Execution.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_BetaExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_DeltaExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Beta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Delta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_PixelSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Distance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPhaseRetrievalTab_Energy)).EndInit();
            this.vNavPaneItem4.ItemPanel.ResumeLayout(false);
            this.vNavPaneItem4.ResumeLayout(false);
            this.gbxRolling.ResumeLayout(false);
            this.gbxRolling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRollShift)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnglesProjTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnglesProjFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngles)).EndInit();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_Slice)).EndInit();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_Downscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_Decimate)).EndInit();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenter_Middle)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCorrectionOffset)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLambdaExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLambdaBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFISTAReconIter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFISTAFGPIter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlgorithmParameterIterations)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_ExecuteTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconstructionTab_ExecuteFrom)).EndInit();
            this.vNavPaneItem8.ItemPanel.ResumeLayout(false);
            this.vNavPaneItem8.ResumeLayout(false);
            this.gbxPostProcessingTab_Execute.ResumeLayout(false);
            this.gbxPostProcessingTab_Execute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProcessingTab_ExecuteTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProcessingTab_ExecuteFrom)).EndInit();
            this.gbxPostProcessingTab_Preview.ResumeLayout(false);
            this.gbxPostProcessingTab_Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProcessingTab_PreviewSlice)).EndInit();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConvertToTDF_CropTop)).EndInit();
            this.gbxPostProcessingTab_MethodSettings.ResumeLayout(false);
            this.gbxPostProcessingTab_MethodSettings.PerformLayout();
            this.gbxPostProc_PolarFiltr.ResumeLayout(false);
            this.gbxPostProc_PolarFiltr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarFilt_OverSampl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarCenterY)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarFilter_Param2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarFilter_Param1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPostProc_PolarCenterX)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.vNavPaneImage.ResumeLayout(false);
            this.vNavPaneItem2.ItemPanel.ResumeLayout(false);
            this.vNavPaneItem2.ResumeLayout(false);
            this.vLogNavPane.ResumeLayout(false);
            this.vNavPaneItem6.ItemPanel.ResumeLayout(false);
            this.vNavPaneItem6.ItemPanel.PerformLayout();
            this.vNavPaneItem6.ResumeLayout(false);
            this.vImageNavPane.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private VIBlend.WinForms.Controls.vNavPane vNavPane1;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItem1;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItem3;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItem4;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTIFF2TDF;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox gbxPreProcessing_Preview;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cbxAlgorithm;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnReconstructionTab_ExecuteRunSubset;
        private System.Windows.Forms.Label lblReconstructionTab_ExecuteTo;
        private System.Windows.Forms.NumericUpDown nudReconstructionTab_ExecuteTo;
        private System.Windows.Forms.NumericUpDown nudReconstructionTab_ExecuteFrom;
        private System.Windows.Forms.Label lblReconstructionTab_ExecuteFrom;
        private System.Windows.Forms.FolderBrowserDialog zInputTIFFsBrowserDialog;
        private System.Windows.Forms.OpenFileDialog zInputTDFFileDialog;
        private System.Windows.Forms.ComboBox tbxDatasetName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.FolderBrowserDialog zOutputPathBrowserDialog;
        private System.Windows.Forms.Button btnReconstructionTab_ExecuteRunAll;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.NumericUpDown nudCenter_Middle;
        private System.Windows.Forms.ToolStripStatusLabel zTiming_ToolStripLbl;
        private System.Windows.Forms.ToolStripProgressBar mStatusBarProgressBar;
        private System.ComponentModel.BackgroundWorker mJobMonitorBgw;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.NumericUpDown nudAngles;
        private System.Windows.Forms.CheckBox chkCircleMask;
        private System.Windows.Forms.CheckBox chkOverPadding;
        private System.Windows.Forms.CheckBox chkLogTransform;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private VIBlend.WinForms.Controls.vNavPane vNavPaneImage;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItem2;
        private VIBlend.WinForms.Controls.vNavPane vLogNavPane;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItem6;
        private System.Windows.Forms.TextBox zLogTxb;
        private VIBlend.WinForms.Controls.vNavPane vImageNavPane;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.ComponentModel.BackgroundWorker bgwGuessOffset;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItem7;
        private System.Windows.Forms.GroupBox gbxPhaseRetrieval_Execution;
        private System.Windows.Forms.Button btnPhaseRetrieval_ExecuteRun;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudPhaseRetrievalTab_Delta;
        private System.Windows.Forms.NumericUpDown nudPhaseRetrievalTab_PixelSize;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbxPhaseRetrievalTab_Algorithms;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown nudPhaseRetrievalTab_Distance;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown nudPhaseRetrievalTab_Energy;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.NumericUpDown nudRingRemParam1;
        private System.Windows.Forms.Label lblRingRemParam2;
        private System.Windows.Forms.Label lblRingRemParam1;
        private System.Windows.Forms.NumericUpDown nudRingRemParam2;
        private System.Windows.Forms.ComboBox cbxRingRem;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox chkDarkFlatEnd;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.NumericUpDown nudNormSx;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown nudNormDx;
        private System.Windows.Forms.ComboBox cbxFlatField;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label lblPhaseRetrieval_Output;
        private System.Windows.Forms.Label lblPhaseRetrieval_ExecuteOutput;
        private System.Windows.Forms.ComboBox cbxPhaseRetrieval_Input;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.CheckBox chkApplyPreProcessing;
        private System.Windows.Forms.Label lblReconstructionOutputPath;
        private System.Windows.Forms.Label lblExecutionOutput;
        private System.Windows.Forms.CheckBox chkHalfHalfMode;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.NumericUpDown nudExtendedFOVOverlap;
        private System.Windows.Forms.CheckBox chkExtendedFOV;
        private System.Windows.Forms.NumericUpDown nudPreprocessingTab_Preview;
        private System.Windows.Forms.Label lblPreprocessingTab_Preview;
        private System.Windows.Forms.CheckBox chkExtFOV_AirRight;
        private System.Windows.Forms.Button btnPreProcess_GuessOverlap;
        private System.ComponentModel.BackgroundWorker bgwGuessOverlap;
        private System.Windows.Forms.ToolStripMenuItem menuTDF2TIFF;
        private System.Windows.Forms.CheckBox chkZeroneMode;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label lblAlgorithmParameter;
        private System.Windows.Forms.Button btnReconstructionGuess;
        private System.Windows.Forms.NumericUpDown nudAlgorithmParameterIterations;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox cbxAlgorithmParameterFilter;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbxDatasetInfo_Input;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudHalfHalfMode;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown nudReconstructionTab_Downscale;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown nudReconstructionTab_Decimate;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.CheckBox chkReconstructionTab_PostProcess;
        private VIBlend.WinForms.Controls.vNavPaneItem vNavPaneItem8;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Button btnPostProcessingTab_BrowseInput;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.Label label82;
        private KaiwaProjects.KpImageViewer kpImageViewer1;
        private System.Windows.Forms.GroupBox gbxDatasetInfo_Preview;
        private System.Windows.Forms.Button btnDatasetTabPreviewProjection;
        private System.Windows.Forms.NumericUpDown nudDatasetTab_Sinogram;
        private System.Windows.Forms.Label lblDatasetTab_Sinogram;
        private System.Windows.Forms.Button btnDatasetTabPreviewSinogram;
        private System.Windows.Forms.NumericUpDown nudDatasetTab_Projection;
        private System.Windows.Forms.Label lblDatasetTab_Projection;
        private System.Windows.Forms.Button btnPreprocessingTab_Preview;
        private System.Windows.Forms.GroupBox gbxPhaseRetrieval_Preview;
        private System.Windows.Forms.Button btnPhaseretrievalTab_Preview;
        private System.Windows.Forms.NumericUpDown nudPhaseretrievalTab_ProjectionPreview;
        private System.Windows.Forms.Label lblPhaseRetrievalTab_Projection;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.Button btnReconstructionTab_Preview;
        private System.Windows.Forms.NumericUpDown nudReconstructionTab_Slice;
        private System.Windows.Forms.Label lblReconstructionTab_Slice;
        private System.Windows.Forms.GroupBox gbxPreProcessing_Execute;
        private System.Windows.Forms.Label lblPreProcessing_Output;
        private System.Windows.Forms.Label lblPreProcessing_ExecuteOutput;
        private System.Windows.Forms.Button btnPreProcessing_ExecuteRun;
        private System.ComponentModel.BackgroundWorker mBgwPreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbxPostProcessingTab_MethodSettings;
        private System.Windows.Forms.Label lblPostProcessingTab_LinearRescaleMin;
        private System.Windows.Forms.ComboBox cbxDegradationMethods;
        private System.Windows.Forms.GroupBox gbxPostProcessingTab_Execute;
        private System.Windows.Forms.Button btnPostProcessingTab_RunAll;
        private System.Windows.Forms.Label lblPostProcessingTab_To;
        private System.Windows.Forms.NumericUpDown nudPostProcessingTab_ExecuteTo;
        private System.Windows.Forms.NumericUpDown nudPostProcessingTab_ExecuteFrom;
        private System.Windows.Forms.Label lblPostProcessingTab_From;
        private System.Windows.Forms.Button btnPostProcessingTab_RunSubset;
        private System.Windows.Forms.GroupBox gbxPostProcessingTab_Preview;
        private System.Windows.Forms.Button btnPostProcessingTab_Preview;
        private System.Windows.Forms.NumericUpDown nudPostProcessingTab_PreviewSlice;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.GroupBox groupBox31;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropLeft;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropBottom;
        private System.Windows.Forms.NumericUpDown nudConvertToTDF_CropTop;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnPostProcessinTab_BrowseOutput;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txbPostProcessingTab_OutputPath;
        private System.Windows.Forms.TextBox txbPostProcessingTab_InputFolder;
        private System.Windows.Forms.Label lblPostProcessingTab_LinearRescaleMax;
        private System.Windows.Forms.TextBox txbPostProcessingTab_LinearRescaleMax;
        private System.Windows.Forms.TextBox txbPostProcessingTab_LinearRescaleMin;
        private System.Windows.Forms.ComboBox cbxPreProcessing_Input;
        private System.Windows.Forms.Button btnPostProcessingTab_AutoLimit;
        private System.Windows.Forms.NumericUpDown nudCorrectionOffset;
        private System.Windows.Forms.CheckBox chkCorrectionOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudPhaseRetrievalTab_BetaExp;
        private System.Windows.Forms.NumericUpDown nudPhaseRetrievalTab_DeltaExp;
        private System.Windows.Forms.NumericUpDown nudPhaseRetrievalTab_Beta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem convertHISToTDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Label lblDeltaBetaRatio;
        private System.Windows.Forms.CheckBox chkPhrtOnTheFly;
        private System.Windows.Forms.NumericUpDown nudGridRec;
        private System.ComponentModel.BackgroundWorker bgwAutoLimit;
        private System.Windows.Forms.CheckBox chkPhaseRetrievalTab_OverPadding;
        private System.ComponentModel.BackgroundWorker mBgwPostProcessingPreview;
        private System.Windows.Forms.NumericUpDown nudDatasetTab_Dark;
        private System.Windows.Forms.Label lblDatasetTab_Dark;
        private System.Windows.Forms.Button btnDatasetTabPreviewDark;
        private System.Windows.Forms.NumericUpDown nudDatasetTab_Flat;
        private System.Windows.Forms.Label lblDatasetTab_Flat;
        private System.Windows.Forms.Button btnDatasetTabPreviewFlat;
        private System.Windows.Forms.ToolStripMenuItem convertEDFsToEDFToolStripMenuItem;
        private System.Windows.Forms.Button btnMultipleCenters;
        private System.Windows.Forms.GroupBox gbxDatasetInfo_Metadata;
        private System.Windows.Forms.Label lblMetadata_PixelSize;
        private System.Windows.Forms.Label lblMetadata_NrProjections;
        private System.Windows.Forms.Label lblMetadata_FOV;
        private System.Windows.Forms.Label lblMetadata_Dataset;
        private System.Windows.Forms.Label lblMetadata_Experiment;
        private System.Windows.Forms.Label lblMetadata_Distance;
        private System.Windows.Forms.Label lblMetadata_Energy;
        private System.Windows.Forms.ToolStripMenuItem openSourceLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAnglesProjTo;
        private System.Windows.Forms.NumericUpDown nudAnglesProjFrom;
        private System.Windows.Forms.Button btnMultipleAngles;
        private System.Windows.Forms.GroupBox gbxRolling;
        private System.Windows.Forms.Label lblRollShift;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudRollShift;
        private System.Windows.Forms.CheckBox chkExtFOVAverage;
        private System.Windows.Forms.CheckBox chkExtFOVNormalize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.NumericUpDown nudFISTAReconIter;
        private System.Windows.Forms.NumericUpDown nudFISTAFGPIter;
        private System.Windows.Forms.Label lblFISTAReconIter;
        private System.Windows.Forms.Label lblFISTAFGPIter;
        private System.Windows.Forms.NumericUpDown nudLambdaBase;
        private System.Windows.Forms.NumericUpDown nudLambdaExp;
        private System.Windows.Forms.Label lblLambdaTenTo;
        private System.Windows.Forms.GroupBox gbxPostProc_PolarFiltr;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown nudPostProc_PolarFilter_Param2;
        private System.Windows.Forms.NumericUpDown nudPostProc_PolarFilter_Param1;
        private System.Windows.Forms.Label lblPostProc_PolarFilt_Param1;
        private System.Windows.Forms.Label lblPostProc_PolarFilt_Param2;
        private System.Windows.Forms.ComboBox cbxPostProc_PolarFilt_Method;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudPostProc_PolarFilt_OverSampl;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudPostProc_PolarCenterY;
        private System.Windows.Forms.NumericUpDown nudPostProc_PolarCenterX;
        private System.Windows.Forms.Label lblPostProc_PolarCenterX;
        private System.Windows.Forms.Label lblPostProc_PolarCenterY;
        private System.Windows.Forms.CheckBox chkPostProc_PolarLock;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionPreprocessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalizedDEIToolStripMenuItem;
    }
}

