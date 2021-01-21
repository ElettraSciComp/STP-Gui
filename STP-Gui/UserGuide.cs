using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace SYRMEPTomoProject
{
    public partial class UserGuide : Form
    {
        public UserGuide()
        {
            InitializeComponent();
        }

        private void UserGuide_Load(object sender, EventArgs e)
        {
            // Load Index.html from the HTML user's guide:
            string zIndexHTML = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + 
                Path.DirectorySeparatorChar + Properties.Settings.Default.UserGuideIndex + 
                Path.DirectorySeparatorChar + "Index.html";

            if (File.Exists(zIndexHTML))
            {
                mWebBrowser.Url = new Uri(zIndexHTML);
            }
        }
    }
}
