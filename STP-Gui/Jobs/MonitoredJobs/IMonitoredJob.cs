/***************************************************************************/
/* (C) 2016 Elettra - Sincrotrone Trieste S.C.p.A.. All rights reserved.   */
/*                                                                         */
/*                                                                         */
/* This file is part of STP-Gui, the .NET Graphical User Interface of      */
/* SYRMEP Tomo Project, a software tool for the reconstruction of          */
/* experimental CT datasets.                                               */
/*                                                                         */
/* STP-Gui is free software: you can redistribute it and/or modify it      */
/* under the terms of the GNU General Public License as published by the   */
/* Free Software Foundation, either version 3 of the License, or (at your  */
/* option) any later version.                                              */
/*                                                                         */
/* STP-Gui is distributed in the hope that it will be useful, but WITHOUT  */
/* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or   */
/* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License    */
/* for more details.                                                       */
/*                                                                         */
/* You should have received a copy of the GNU General Public License       */
/* along with STP-Gui. If not, see <http://www.gnu.org/licenses/>.         */
/*                                                                         */
/***************************************************************************/

//
// Author: Francesco Brun
// Last modified: April, 11th 2016
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYRMEPTomoProject.Jobs
{
    public interface IMonitoredJob : IJob
    {
        /// <summary>
        /// An implementation of IJob operates on a specified range of images. The From property defines the initial image to process.
        /// </summary>
        int From { get; set; }

        /// <summary>
        /// An implementation of IJob operates on a specified range of images. The To property defines the last image to process.
        /// </summary>
        int To { get; set; }
    }
}
