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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace SYRMEPTomoProject
{
    /// <summary>
    /// Hour glass mouse cursor.
    /// </summary>
    public class HourGlass : IDisposable
    {
        public HourGlass()
        {
            Enabled = true;
        }
        public void Dispose()
        {
            Enabled = false;
        }
        public static bool Enabled
        {
            get { return Application.UseWaitCursor; }
            set
            {
                if (value == Application.UseWaitCursor) return;
                Application.UseWaitCursor = value;
                Form f = Form.ActiveForm;
                if (f != null && f.Handle != IntPtr.Zero)   // Send WM_SETCURSOR
                    SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1);
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
