﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SYRMEPTomoProject.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("WinPython-64bit-2.7.10.3\\python-2.7.10.amd64\\python.exe")]
        public string PythonExe {
            get {
                return ((string)(this["PythonExe"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("120")]
        public int TimeOutWaitForLogInSeconds {
            get {
                return ((int)(this["TimeOutWaitForLogInSeconds"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_phaseretrieval.py")]
        public string PhaseRetrievalJob {
            get {
                return ((string)(this["PhaseRetrievalJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("stp-core")]
        public string PythonPath {
            get {
                return ((string)(this["PythonPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SYRMEP Tomo Project")]
        public string ProgramName {
            get {
                return ((string)(this["ProgramName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".tif")]
        public string TIFFFileFormatExtension {
            get {
                return ((string)(this["TIFFFileFormatExtension"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.03")]
        public double EstimatedRemaingTimeThresh {
            get {
                return ((double)(this["EstimatedRemaingTimeThresh"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_reconstruct.py")]
        public string ReconstructionJob {
            get {
                return ((string)(this["ReconstructionJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".tdf")]
        public string TomoDataFormatExtension {
            get {
                return ((string)(this["TomoDataFormatExtension"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("recalgs.xml")]
        public string RecAlgsXmlFile {
            get {
                return ((string)(this["RecAlgsXmlFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("phrtalgs.xml")]
        public string PhrtAlgsXmlFile {
            get {
                return ((string)(this["PhrtAlgsXmlFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tools_guesscenter.py")]
        public string GuessCenterJob {
            get {
                return ((string)(this["GuessCenterJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("remring.xml")]
        public string RingRemAlgsXmlFile {
            get {
                return ((string)(this["RingRemAlgsXmlFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("flatfield.xml")]
        public string FlatFieldAlgsXmlFile {
            get {
                return ((string)(this["FlatFieldAlgsXmlFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_tiff2tdf.py")]
        public string ConvertToTDFJob {
            get {
                return ((string)(this["ConvertToTDFJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_preprocessing.py")]
        public string PreProcessingJob {
            get {
                return ((string)(this["PreProcessingJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.1.29")]
        public string Version {
            get {
                return ((string)(this["Version"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tools_guessoverlap.py")]
        public string GuessOverlapJob {
            get {
                return ((string)(this["GuessOverlapJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("fbpfilters.xml")]
        public string FbpFiltersXmlFile {
            get {
                return ((string)(this["FbpFiltersXmlFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_tdf2tiff.py")]
        public string ConvertToTIFFJob {
            get {
                return ((string)(this["ConvertToTIFFJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tools_extractdata.py")]
        public string ExtractImage {
            get {
                return ((string)(this["ExtractImage"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("degradecrop.xml")]
        public string DegradationMethodsXmlFile {
            get {
                return ((string)(this["DegradationMethodsXmlFile"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("S:\\STP")]
        public string FormSettings_WorkingPath {
            get {
                return ((string)(this["FormSettings_WorkingPath"]));
            }
            set {
                this["FormSettings_WorkingPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("R:\\STP")]
        public string FormSettings_TemporaryPath {
            get {
                return ((string)(this["FormSettings_TemporaryPath"]));
            }
            set {
                this["FormSettings_TemporaryPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("S:\\STP")]
        public string FormSettings_OutputPath {
            get {
                return ((string)(this["FormSettings_OutputPath"]));
            }
            set {
                this["FormSettings_OutputPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("slice")]
        public string FormSettings_OutputPrefix {
            get {
                return ((string)(this["FormSettings_OutputPrefix"]));
            }
            set {
                this["FormSettings_OutputPrefix"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_postprocessing.py")]
        public string PostProcessJob {
            get {
                return ((string)(this["PostProcessJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".his")]
        public string HISFileFormatExtension {
            get {
                return ((string)(this["HISFileFormatExtension"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_his2tdf.py")]
        public string ConvertHIS2TDFJob {
            get {
                return ((string)(this["ConvertHIS2TDFJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("depend")]
        public string DependenciesPath {
            get {
                return ((string)(this["DependenciesPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("vcredist_x64.exe")]
        public string VC2010Redistributable_x64 {
            get {
                return ((string)(this["VC2010Redistributable_x64"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal HIS2TDF_CropTop {
            get {
                return ((decimal)(this["HIS2TDF_CropTop"]));
            }
            set {
                this["HIS2TDF_CropTop"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal HIS2TDF_CropBottom {
            get {
                return ((decimal)(this["HIS2TDF_CropBottom"]));
            }
            set {
                this["HIS2TDF_CropBottom"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal HIS2TDF_CropLeft {
            get {
                return ((decimal)(this["HIS2TDF_CropLeft"]));
            }
            set {
                this["HIS2TDF_CropLeft"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal HIS2TDF_CropRight {
            get {
                return ((decimal)(this["HIS2TDF_CropRight"]));
            }
            set {
                this["HIS2TDF_CropRight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal HIS2TDF_gZipCompression {
            get {
                return ((decimal)(this["HIS2TDF_gZipCompression"]));
            }
            set {
                this["HIS2TDF_gZipCompression"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal TIFF2TDF_CropTop {
            get {
                return ((decimal)(this["TIFF2TDF_CropTop"]));
            }
            set {
                this["TIFF2TDF_CropTop"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal TIFF2TDF_CropBottom {
            get {
                return ((decimal)(this["TIFF2TDF_CropBottom"]));
            }
            set {
                this["TIFF2TDF_CropBottom"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal TIFF2TDF_CropLeft {
            get {
                return ((decimal)(this["TIFF2TDF_CropLeft"]));
            }
            set {
                this["TIFF2TDF_CropLeft"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal TIFF2TDF_CropRight {
            get {
                return ((decimal)(this["TIFF2TDF_CropRight"]));
            }
            set {
                this["TIFF2TDF_CropRight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal TIFF2TDF_gZipCompression {
            get {
                return ((decimal)(this["TIFF2TDF_gZipCompression"]));
            }
            set {
                this["TIFF2TDF_gZipCompression"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TIFF2TDF_TiffProjectionChecked {
            get {
                return ((bool)(this["TIFF2TDF_TiffProjectionChecked"]));
            }
            set {
                this["TIFF2TDF_TiffProjectionChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tomo")]
        public string TIFF2TDF_FilePrefixProjection {
            get {
                return ((string)(this["TIFF2TDF_FilePrefixProjection"]));
            }
            set {
                this["TIFF2TDF_FilePrefixProjection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("flat")]
        public string TIFF2TDF_FilePrefixFlat {
            get {
                return ((string)(this["TIFF2TDF_FilePrefixFlat"]));
            }
            set {
                this["TIFF2TDF_FilePrefixFlat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dark")]
        public string TIFF2TDF_FilePrefixDark {
            get {
                return ((string)(this["TIFF2TDF_FilePrefixDark"]));
            }
            set {
                this["TIFF2TDF_FilePrefixDark"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tomo")]
        public string TDF2TIFF_FilePrefixProjection {
            get {
                return ((string)(this["TDF2TIFF_FilePrefixProjection"]));
            }
            set {
                this["TDF2TIFF_FilePrefixProjection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("flat")]
        public string TDF2TIFF_FilePrefixFlat {
            get {
                return ((string)(this["TDF2TIFF_FilePrefixFlat"]));
            }
            set {
                this["TDF2TIFF_FilePrefixFlat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dark")]
        public string TDF2TIFF_FilePrefixDark {
            get {
                return ((string)(this["TDF2TIFF_FilePrefixDark"]));
            }
            set {
                this["TDF2TIFF_FilePrefixDark"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TDF2TIFF_FormatTIFFChecked {
            get {
                return ((bool)(this["TDF2TIFF_FormatTIFFChecked"]));
            }
            set {
                this["TDF2TIFF_FormatTIFFChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TDF2TIFF_ProjectionOrderChecked {
            get {
                return ((bool)(this["TDF2TIFF_ProjectionOrderChecked"]));
            }
            set {
                this["TDF2TIFF_ProjectionOrderChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TDF2TIFF_DatasetToExportTomo {
            get {
                return ((bool)(this["TDF2TIFF_DatasetToExportTomo"]));
            }
            set {
                this["TDF2TIFF_DatasetToExportTomo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TDF2TIFF_DatasetToExportFlat {
            get {
                return ((bool)(this["TDF2TIFF_DatasetToExportFlat"]));
            }
            set {
                this["TDF2TIFF_DatasetToExportFlat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TDF2TIFF_DatasetToExportDark {
            get {
                return ((bool)(this["TDF2TIFF_DatasetToExportDark"]));
            }
            set {
                this["TDF2TIFF_DatasetToExportDark"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("sino")]
        public string FormSettings_SinoPrefix {
            get {
                return ((string)(this["FormSettings_SinoPrefix"]));
            }
            set {
                this["FormSettings_SinoPrefix"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tomo")]
        public string FormSettings_ProjectionPrefix {
            get {
                return ((string)(this["FormSettings_ProjectionPrefix"]));
            }
            set {
                this["FormSettings_ProjectionPrefix"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public decimal FormSettings_NrOfProcesses {
            get {
                return ((decimal)(this["FormSettings_NrOfProcesses"]));
            }
            set {
                this["FormSettings_NrOfProcesses"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool PerformGPUCheck {
            get {
                return ((bool)(this["PerformGPUCheck"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("preview_phaseretrieval.py")]
        public string PhaseRetrievalPreviewJob {
            get {
                return ((string)(this["PhaseRetrievalPreviewJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("preview_preprocessing.py")]
        public string PreProcessingPreviewJob {
            get {
                return ((string)(this["PreProcessingPreviewJob"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("32")]
        public decimal FormSettings_ChunkSize {
            get {
                return ((decimal)(this["FormSettings_ChunkSize"]));
            }
            set {
                this["FormSettings_ChunkSize"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("preview_reconstruct.py")]
        public string ReconstructPreviewJob {
            get {
                return ((string)(this["ReconstructPreviewJob"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SessionID {
            get {
                return ((string)(this["SessionID"]));
            }
            set {
                this["SessionID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("preview_postprocessing.py")]
        public string PostProcessingPreviewJob {
            get {
                return ((string)(this["PostProcessingPreviewJob"]));
            }
            set {
                this["PostProcessingPreviewJob"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tools_autolimit.py")]
        public string AutoLimitJob {
            get {
                return ((string)(this["AutoLimitJob"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("exec_edf2tdf.py")]
        public string ConvertEDFToTDF {
            get {
                return ((string)(this["ConvertEDFToTDF"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".edf")]
        public string EDFFileFormatExtension {
            get {
                return ((string)(this["EDFFileFormatExtension"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal EDF2TDF_CropTop {
            get {
                return ((decimal)(this["EDF2TDF_CropTop"]));
            }
            set {
                this["EDF2TDF_CropTop"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal EDF2TDF_CropBottom {
            get {
                return ((decimal)(this["EDF2TDF_CropBottom"]));
            }
            set {
                this["EDF2TDF_CropBottom"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal EDF2TDF_CropLeft {
            get {
                return ((decimal)(this["EDF2TDF_CropLeft"]));
            }
            set {
                this["EDF2TDF_CropLeft"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal EDF2TDF_CropRight {
            get {
                return ((decimal)(this["EDF2TDF_CropRight"]));
            }
            set {
                this["EDF2TDF_CropRight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal EDF2TDF_gZipCompression {
            get {
                return ((decimal)(this["EDF2TDF_gZipCompression"]));
            }
            set {
                this["EDF2TDF_gZipCompression"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dark")]
        public string EDF2TDF_FilePrefixDark {
            get {
                return ((string)(this["EDF2TDF_FilePrefixDark"]));
            }
            set {
                this["EDF2TDF_FilePrefixDark"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ref")]
        public string EDF2TDF_FilePrefixFlat {
            get {
                return ((string)(this["EDF2TDF_FilePrefixFlat"]));
            }
            set {
                this["EDF2TDF_FilePrefixFlat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool EDF2TDF_InputProjectionsChecked {
            get {
                return ((bool)(this["EDF2TDF_InputProjectionsChecked"]));
            }
            set {
                this["EDF2TDF_InputProjectionsChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal PhaseRetrievalTab_Delta {
            get {
                return ((decimal)(this["PhaseRetrievalTab_Delta"]));
            }
            set {
                this["PhaseRetrievalTab_Delta"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-7")]
        public decimal PhaseRetrievalTab_DeltaExp {
            get {
                return ((decimal)(this["PhaseRetrievalTab_DeltaExp"]));
            }
            set {
                this["PhaseRetrievalTab_DeltaExp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal PhaseRetrievalTab_Beta {
            get {
                return ((decimal)(this["PhaseRetrievalTab_Beta"]));
            }
            set {
                this["PhaseRetrievalTab_Beta"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-10")]
        public decimal PhaseRetrievalTab_BetaExp {
            get {
                return ((decimal)(this["PhaseRetrievalTab_BetaExp"]));
            }
            set {
                this["PhaseRetrievalTab_BetaExp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9")]
        public decimal PhaseRetrievalTab_PixelSize {
            get {
                return ((decimal)(this["PhaseRetrievalTab_PixelSize"]));
            }
            set {
                this["PhaseRetrievalTab_PixelSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("22")]
        public decimal PhaseRetrievalTab_Energy {
            get {
                return ((decimal)(this["PhaseRetrievalTab_Energy"]));
            }
            set {
                this["PhaseRetrievalTab_Energy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public decimal PhaseRetrievalTab_Distance {
            get {
                return ((decimal)(this["PhaseRetrievalTab_Distance"]));
            }
            set {
                this["PhaseRetrievalTab_Distance"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PhaseRetrievalTab_OverpadChecked {
            get {
                return ((bool)(this["PhaseRetrievalTab_OverpadChecked"]));
            }
            set {
                this["PhaseRetrievalTab_OverpadChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int PhaseRetrievalTab_MethodIndex {
            get {
                return ((int)(this["PhaseRetrievalTab_MethodIndex"]));
            }
            set {
                this["PhaseRetrievalTab_MethodIndex"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("tools_multioffset.py")]
        public string MultiOffsetJob {
            get {
                return ((string)(this["MultiOffsetJob"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-40")]
        public decimal MultiOffset_From {
            get {
                return ((decimal)(this["MultiOffset_From"]));
            }
            set {
                this["MultiOffset_From"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("40")]
        public decimal MultiOffset_To {
            get {
                return ((decimal)(this["MultiOffset_To"]));
            }
            set {
                this["MultiOffset_To"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MultiOffset_Path {
            get {
                return ((string)(this["MultiOffset_Path"]));
            }
            set {
                this["MultiOffset_Path"] = value;
            }
        }
    }
}
