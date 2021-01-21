namespace SYRMEPTomoProject
{
    partial class UserGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGuide));
            this.mWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // mWebBrowser
            // 
            this.mWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.mWebBrowser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mWebBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.mWebBrowser.Name = "mWebBrowser";
            this.mWebBrowser.Size = new System.Drawing.Size(1322, 897);
            this.mWebBrowser.TabIndex = 0;
            // 
            // UserGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 897);
            this.Controls.Add(this.mWebBrowser);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SYRMEP Tomo Project - User\'s Guide";
            this.Load += new System.EventHandler(this.UserGuide_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser mWebBrowser;
    }
}