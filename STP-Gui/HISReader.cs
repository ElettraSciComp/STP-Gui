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
using System.Linq;
using System.IO;
using System.Text;

namespace SYRMEPTomoProject
{
    /// <summary>
    /// Reader for the Hamamatsu HIS format.
    /// </summary>
    static class HISReader
    {
        /// <summary>
        /// Return the number of projections in the specified HIS file.
        /// </summary>
        /// <param name="filename">Absolute path of the HIS file.</param>
        /// <returns>An integer with the number of projections.</returns>
        public static int GetNumberOfProjections(string filename)
        {
            int dimz = 0;

            try
            {
                FileInfo zFileInfo = new FileInfo(filename);
                long tot_bytes = zFileInfo.Length;

                using (BinaryReader b = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    ushort foo = b.ReadUInt16();
                    int Comment_len = (int)b.ReadUInt16();

                    int dim1 = (int)b.ReadUInt16();
                    int dim2 = (int)b.ReadUInt16();
                    foo = b.ReadUInt16();
                    foo = b.ReadUInt16();
                    foo = b.ReadUInt16();

                    b.ReadBytes(50);
                    b.ReadBytes(Comment_len);

                    //Set total number of bytes read so far:
                    int bytes_read = 64 + Comment_len;

                    //Define chunk size:
                    int chunksize = dim1 * dim2 * 2;

                    //Determine number of expected projections:
                    dimz = (int)(((long)(tot_bytes - (long)bytes_read)) / (long)(chunksize + 64) + 1);
                }
            }
            catch
            {
            }
             
            return dimz;            
        }
    }
}
