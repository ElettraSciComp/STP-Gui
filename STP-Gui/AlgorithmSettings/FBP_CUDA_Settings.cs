using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BrunTomoProject.AlgorithmSettings
{
    public partial class FBP_CUDA_Settings : Form
    {
        public FBP_CUDA_Settings()
        {
            InitializeComponent();
        }

        private void FBP_CUDA_Settings_Load(object sender, EventArgs e)
        {
            // Find current settings:
            if (BTPSettings.ReconParam1 == "none")
                this.cbxFilter.Text = "<none>";
            else if (BTPSettings.ReconParam1 == "shepp-logan")
                this.cbxFilter.Text = "shepp-logan (default)";
            else
                this.cbxFilter.Text = BTPSettings.ReconParam1;
        }

        private void mButtonOk_Click(object sender, EventArgs e)
        {
            string zString;

            zString = this.cbxFilter.Text;
            zString = zString.Replace("<", "");
            zString = zString.Replace(">", "");
            zString = zString.Replace(" (default)", "");
            zString = zString.ToLower();

            BTPSettings.ReconParam1 = zString;

            this.Close();
        }
    }
}
