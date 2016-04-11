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
    public partial class SART_CUDA_Settings : Form
    {
        public SART_CUDA_Settings()
        {
            InitializeComponent();
        }

        private void SART_CUDA_Settings_Load(object sender, EventArgs e)
        {
            decimal value;

            if (Decimal.TryParse(BTPSettings.ReconParam1, out value))
                this.nudIterations.Value = value;
            else
                this.nudIterations.Value = 20; // default;           
        }

        private void mButtonOk_Click(object sender, EventArgs e)
        {
            BTPSettings.ReconParam1 = this.nudIterations.Value.ToString();

            this.Close();
        }
    }
}
