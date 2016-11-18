namespace BrunTomoProject.AlgorithmSettings
{
    partial class FBP_CUDA_Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.mButtonOk = new System.Windows.Forms.Button();
            this.mButtonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxFilter);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter:";
            // 
            // cbxFilter
            // 
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
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
            this.cbxFilter.Location = new System.Drawing.Point(86, 30);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(189, 21);
            this.cbxFilter.TabIndex = 0;
            // 
            // mButtonOk
            // 
            this.mButtonOk.Location = new System.Drawing.Point(147, 93);
            this.mButtonOk.Name = "mButtonOk";
            this.mButtonOk.Size = new System.Drawing.Size(75, 23);
            this.mButtonOk.TabIndex = 15;
            this.mButtonOk.Text = "OK";
            this.mButtonOk.UseVisualStyleBackColor = true;
            this.mButtonOk.Click += new System.EventHandler(this.mButtonOk_Click);
            // 
            // mButtonCancel
            // 
            this.mButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mButtonCancel.Location = new System.Drawing.Point(228, 93);
            this.mButtonCancel.Name = "mButtonCancel";
            this.mButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.mButtonCancel.TabIndex = 16;
            this.mButtonCancel.Text = "Cancel";
            this.mButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ASTRA_FBP_Settings
            // 
            this.AcceptButton = this.mButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.mButtonCancel;
            this.ClientSize = new System.Drawing.Size(318, 128);
            this.Controls.Add(this.mButtonOk);
            this.Controls.Add(this.mButtonCancel);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ASTRA_FBP_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FBP - Filtered Back Projection Setttings";
            this.Load += new System.EventHandler(this.FBP_CUDA_Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Button mButtonOk;
        private System.Windows.Forms.Button mButtonCancel;
    }
}