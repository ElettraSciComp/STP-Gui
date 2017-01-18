namespace SYRMEPTomoProject
{
    partial class UIWaitDialog
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
            this.mLblMessage = new System.Windows.Forms.Label();
            this.mProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // mLblMessage
            // 
            this.mLblMessage.AutoSize = true;
            this.mLblMessage.Location = new System.Drawing.Point(11, 17);
            this.mLblMessage.Name = "mLblMessage";
            this.mLblMessage.Size = new System.Drawing.Size(59, 13);
            this.mLblMessage.TabIndex = 1;
            this.mLblMessage.Text = "Message...";
            // 
            // mProgressBar
            // 
            this.mProgressBar.Location = new System.Drawing.Point(14, 43);
            this.mProgressBar.MarqueeAnimationSpeed = 10;
            this.mProgressBar.Name = "mProgressBar";
            this.mProgressBar.Size = new System.Drawing.Size(366, 15);
            this.mProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.mProgressBar.TabIndex = 2;
            // 
            // UIWaitDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 73);
            this.ControlBox = false;
            this.Controls.Add(this.mProgressBar);
            this.Controls.Add(this.mLblMessage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UIWaitDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mLblMessage;
        private System.Windows.Forms.ProgressBar mProgressBar;
    }
}