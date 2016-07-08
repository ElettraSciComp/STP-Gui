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

//
// Author: Francesco Brun
// Last modified: July, 8th 2016
//


using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SYRMEPTomoProject
{
	// The SplashScreen class definition.  AKO Form
    public partial class AboutForm : PerPixelAlphaForm
	{
		#region Member Variables
		// Threading
        private static AboutForm ms_frmSplash = null;
		private static Thread ms_oThread = null;

		// Fade in and out.
		private double m_dblOpacityIncrement = .05;
		private double m_dblOpacityDecrement = .08;
		private const int TIMER_INTERVAL = 50;

		// Status and progress bar
		private string m_sStatus;
		private double m_dblCompletionFraction = 0.0;

		// Progress smoothing
		private double m_dblLastCompletionFraction = 0.0;
		private double m_dblPBIncrementPerTimerInterval = .015;

		// Self-calibration support
		private int m_iIndex = 1;
		private int m_iActualTicks = 0;
		private ArrayList m_alPreviousCompletionFraction;
		private ArrayList m_alActualTimes = new ArrayList();
		private DateTime m_dtStart;
		private bool m_bDTSet = false;
      
		#endregion Member Variables

		/// <summary>
		/// Constructor
		/// </summary>
        public AboutForm()
		{
            // This form should not have a border or else Windows will clip it.            
            //this.StartPosition = FormStartPosition.CenterScreen;    
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Width, Screen.PrimaryScreen.Bounds.Height / 2 - this.Height);

			InitializeComponent();
			//this.Opacity = 0.0;
			UpdateTimer.Interval = TIMER_INTERVAL;
			UpdateTimer.Start();
            SetBitmap(Properties.Resources.About);
            this.ClientSize = Properties.Resources.About.Size;                        
		}

		#region Public Static Methods
		// A static method to create the thread and 
		// launch the SplashScreen.
		public void ShowSplashScreen()
		{
			// Make sure it's only launched once.
			if (ms_frmSplash != null)
				return;
            ms_oThread = new Thread(new ThreadStart(AboutForm.ShowForm));
			ms_oThread.IsBackground = true;
			ms_oThread.SetApartmentState(ApartmentState.STA);
			ms_oThread.Start();
			while (ms_frmSplash == null || ms_frmSplash.IsHandleCreated == false)
			{
				System.Threading.Thread.Sleep(TIMER_INTERVAL);
			}
		}

		// Close the form without setting the parent.
		static public void CloseForm()
		{
			if (ms_frmSplash != null && ms_frmSplash.IsDisposed == false)
			{
				// Make it start going away.
				ms_frmSplash.m_dblOpacityIncrement = -ms_frmSplash.m_dblOpacityDecrement;
			}
			ms_oThread = null;	// we don't need these any more.
			ms_frmSplash = null;
		}

		// A static method to set the status and update the reference.
		public void SetStatus(Bitmap bitmap, string newStatus)
		{
			SetStatus(bitmap, newStatus, true);            
		}

		// A static method to set the status and optionally update the reference.
		// This is useful if you are in a section of code that has a variable
		// set of status string updates.  In that case, don't set the reference.
		public void SetStatus(Bitmap bitmap, string newStatus, bool setReference)
		{
			if (ms_frmSplash == null)
				return;

			ms_frmSplash.m_sStatus = newStatus;
            this.Invoke((MethodInvoker)delegate
            {
                ms_frmSplash.SetBitmap(bitmap);     
            });               

			if (setReference)
				ms_frmSplash.SetReferenceInternal();
		}

		// Static method called from the initializing application to 
		// give the splash screen reference points.  Not needed if
		// you are using a lot of status strings.
		static public void SetReferencePoint()
		{
			if (ms_frmSplash == null)
				return;
			ms_frmSplash.SetReferenceInternal();

		}
		#endregion Public Static Methods

		#region Private Methods

		// A private entry point for the thread.
		static private void ShowForm()
		{
            ms_frmSplash = new AboutForm();
			Application.Run(ms_frmSplash);
		}

		// Internal method for setting reference points.
		private void SetReferenceInternal()
		{
			if (m_bDTSet == false)
			{
				m_bDTSet = true;
				m_dtStart = DateTime.Now;
				ReadIncrements();
			}
			double dblMilliseconds = ElapsedMilliSeconds();
			m_alActualTimes.Add(dblMilliseconds);
			m_dblLastCompletionFraction = m_dblCompletionFraction;
			if (m_alPreviousCompletionFraction != null && m_iIndex < m_alPreviousCompletionFraction.Count)
				m_dblCompletionFraction = (double)m_alPreviousCompletionFraction[m_iIndex++];
			else
				m_dblCompletionFraction = (m_iIndex > 0) ? 1 : 0;
		}

		// Utility function to return elapsed Milliseconds since the 
		// SplashScreen was launched.
		private double ElapsedMilliSeconds()
		{
			TimeSpan ts = DateTime.Now - m_dtStart;
			return ts.TotalMilliseconds;
		}

		// Function to read the checkpoint intervals from the previous invocation of the
		// splashscreen from the XML file.
		private void ReadIncrements()
		{
			string sPBIncrementPerTimerInterval = SplashScreenXMLStorage.Interval;
			double dblResult;

			if (Double.TryParse(sPBIncrementPerTimerInterval, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out dblResult) == true)
				m_dblPBIncrementPerTimerInterval = dblResult;
			else
				m_dblPBIncrementPerTimerInterval = .0015;

			string sPBPreviousPctComplete = SplashScreenXMLStorage.Percents;

			if (sPBPreviousPctComplete != "")
			{
				string[] aTimes = sPBPreviousPctComplete.Split(null);
				m_alPreviousCompletionFraction = new ArrayList();

				for (int i = 0; i < aTimes.Length; i++)
				{
					double dblVal;
					if (Double.TryParse(aTimes[i], System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out dblVal) == true)
						m_alPreviousCompletionFraction.Add(dblVal);
					else
						m_alPreviousCompletionFraction.Add(1.0);
				}
			}
			else
			{
				/*m_bFirstLaunch = true;
				m_sTimeRemaining = "";*/
			}
		}

		// Method to store the intervals (in percent complete) from the current invocation of
		// the splash screen to XML storage.
		private void StoreIncrements()
		{
			string sPercent = "";
			double dblElapsedMilliseconds = ElapsedMilliSeconds();
			for (int i = 0; i < m_alActualTimes.Count; i++)
				sPercent += ((double)m_alActualTimes[i] / dblElapsedMilliseconds).ToString("0.####", System.Globalization.NumberFormatInfo.InvariantInfo) + " ";

            AboutFormXMLStorage.Percents = sPercent;

			m_dblPBIncrementPerTimerInterval = 1.0 / (double)m_iActualTicks;

            AboutFormXMLStorage.Interval = m_dblPBIncrementPerTimerInterval.ToString("#.000000", System.Globalization.NumberFormatInfo.InvariantInfo);
		}

        public static AboutForm GetSplashScreen()
		{
			return ms_frmSplash;
		}

		#endregion Private Methods

		#region Event Handlers
		// Tick Event handler for the Timer control.  Handle fade in and fade out and paint progress bar. 
		private void UpdateTimer_Tick(object sender, System.EventArgs e)
		{
			//lblStatus.Text = m_sStatus;

			// Calculate opacity
			if (m_dblOpacityIncrement > 0)		// Starting up splash screen
			{
				m_iActualTicks++;
				if (this.Opacity < 1)
					this.Opacity += m_dblOpacityIncrement;
			}
			else // Closing down splash screen
			{
				if (this.Opacity > 0)
					this.Opacity += m_dblOpacityIncrement;
				else
				{
					StoreIncrements();
					UpdateTimer.Stop();
					this.Close();
				}
			}

			// Paint progress bar
			/*if (m_bFirstLaunch == false && m_dblLastCompletionFraction < m_dblCompletionFraction)
			{
				m_dblLastCompletionFraction += m_dblPBIncrementPerTimerInterval;
				int width = (int)Math.Floor(pnlStatus.ClientRectangle.Width * m_dblLastCompletionFraction);
				int height = pnlStatus.ClientRectangle.Height;
				int x = pnlStatus.ClientRectangle.X;
				int y = pnlStatus.ClientRectangle.Y;
				if (width > 0 && height > 0)
				{
					m_rProgress = new Rectangle(x, y, width, height);
					if (!pnlStatus.IsDisposed)
					{
						Graphics g = pnlStatus.CreateGraphics();
						LinearGradientBrush brBackground = new LinearGradientBrush(m_rProgress, Color.FromArgb(58, 96, 151), Color.FromArgb(181, 237, 254), LinearGradientMode.Horizontal);
						g.FillRectangle(brBackground, m_rProgress);
						g.Dispose();
					}
					int iSecondsLeft = 1 + (int)(TIMER_INTERVAL * ((1.0 - m_dblLastCompletionFraction) / m_dblPBIncrementPerTimerInterval)) / 1000;
					m_sTimeRemaining = (iSecondsLeft == 1) ? string.Format("1 second remaining") : string.Format("{0} seconds remaining", iSecondsLeft);
				}
			}*/
			//lblTimeRemaining.Text = m_sTimeRemaining;
		}

        /*protected override void OnClick(PaintEventArgs e)
        {
            CloseForm();
        }*/

		// Close the form if they double click on it.
		/*private void SplashScreen_DoubleClick(object sender, System.EventArgs e)
		{
			// Use the overload that doesn't set the parent form to this very window.
			CloseForm();
		}*/

        /*protected override void OnPaint(PaintEventArgs e)
        {
            //  Do nothing here!
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;

            gfx.DrawImage(Properties.Resources.Splash, new Rectangle(0, 0, this.Width, this.Height));

        }*/

        // Let Windows drag this form for us
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0084 /*WM_NCHITTEST*/)
            {
                m.Result = (IntPtr)2;	// HTCLIENT
                return;
            }
            /*if (m.Msg == 0x46)
	        {
	            WindowPos pos = (WindowPos)Marshal.PtrToStructure(m.LParam, typeof(WindowPos));
	 
	            // Reset the new location to the same as the current location.
	            pos.x = ms_frmSplash.Left;
	            pos.y = ms_frmSplash.Top;
	 
	            Marshal.StructureToPtr(pos, m.LParam, true);
	        }*/


            if (m.Msg == 0x00A3)
            {
                return;
            }
            switch (m.Msg)
            {

                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            
            base.WndProc(ref m);
        }

		#endregion Event Handlers
	}

	#region Auxiliary Classes 
	/// <summary>
	/// A specialized class for managing XML storage for the splash screen.
	/// </summary>
    internal class AboutFormXMLStorage
	{
        private static string ms_StoredValues = "AboutForm.xml";
		private static string ms_DefaultPercents = "";
		private static string ms_DefaultIncrement = ".015";


		// Get or set the string storing the percentage complete at each checkpoint.
		static public string Percents
		{
			get { return GetValue("Percents", ms_DefaultPercents); }
			set { SetValue("Percents", value); }
		}
		// Get or set how much time passes between updates.
		static public string Interval
		{
			get { return GetValue("Interval", ms_DefaultIncrement); }
			set { SetValue("Interval", value); }
		}

		// Store the file in a location where it can be written with only User rights. (Don't use install directory).
		static private string StoragePath
		{
			get {return Path.Combine(Application.UserAppDataPath, ms_StoredValues);}
		}

		// Helper method for getting inner text of named element.
		static private string GetValue(string name, string defaultValue)
		{
			if (!File.Exists(StoragePath))
				return defaultValue;

			try
			{
				XmlDocument docXML = new XmlDocument();
				docXML.Load(StoragePath);
				XmlElement elValue = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
				return (elValue == null) ? defaultValue : elValue.InnerText;
			}
			catch
			{
				return defaultValue;
			}
		}

		// Helper method for setting inner text of named element.  Creates document if it doesn't exist.
		static public void SetValue(string name,
			 string stringValue)
		{
			XmlDocument docXML = new XmlDocument();
			XmlElement elRoot = null;
			if (!File.Exists(StoragePath))
			{
				elRoot = docXML.CreateElement("root");
				docXML.AppendChild(elRoot);
			}
			else
			{
				docXML.Load(StoragePath);
				elRoot = docXML.DocumentElement;
			}
			XmlElement value = docXML.DocumentElement.SelectSingleNode(name) as XmlElement;
			if (value == null)
			{
				value = docXML.CreateElement(name);
				elRoot.AppendChild(value);
			}
			value.InnerText = stringValue;
			docXML.Save(StoragePath);
		}
	}
	#endregion Auxiliary Classes
}

