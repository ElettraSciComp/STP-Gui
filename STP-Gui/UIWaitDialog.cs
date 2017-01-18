using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SYRMEPTomoProject
{
    /// <summary>
    /// Shows a modal form with a progress bar in order to inform the user that the 
    /// application is working. With this modal form all the controls of the main form
    /// will actually result disabled.
    /// </summary>
    public partial class UIWaitDialog : Form
    {          

        public UIWaitDialog(string title, string message)
        {
            InitializeComponent();

            this.mLblMessage.Text = message;
            this.Text = title;
        }
       
    }
}
