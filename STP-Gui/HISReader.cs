/***************************************************************************/
/* (C) 2016 Elettra - Sincrotrone Trieste S.C.p.A.. All rights reserved.   */
/*                                                                         */
/* Copyright 2016. Elettra - Sincrotrone Trieste S.C.p.A. THE COMPANY      */
/* ELETTRA - SINCROTRONE TRIESTE S.C.P.A. IS NOT REPONSIBLE FOR THE USE    */
/* OF THIS SOFTWARE. If software is modified to produce derivative works,  */
/* such modified software should be clearly marked, so as not to confuse   */
/* it with the version available from Elettra Sincrotrone Trieste S.C.p.A. */
/*                                                                         */
/* Additionally, redistribution and use in source and binary forms, with   */
/* or without modification, are permitted provided that the following      */
/* conditions are met:                                                     */
/*                                                                         */
/*     * Redistributions of source code must retain the above copyright    */
/*       notice, this list of conditions and the following disclaimer.     */
/*                                                                         */
/*     * Redistributions in binary form must reproduce the above copyright */
/*       notice, this list of conditions and the following disclaimer in   */
/*       the documentation and/or other materials provided with the        */
/*       distribution.                                                     */
/*                                                                         */
/*     * Neither the name of Elettra - Sincotrone Trieste S.C.p.A nor      */
/*       the names of its contributors may be used to endorse or promote   */
/*       products derived from this software without specific prior        */
/*       written permission.                                               */
/*                                                                         */
/* THIS SOFTWARE IS PROVIDED BY ELETTRA - SINCROTRONE TRIESTE S.C.P.A. AND */
/* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  */
/* BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND       */
/* FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL      */
/* ELETTRA - SINCROTRONE TRIESTE S.C.P.A. OR CONTRIBUTORS BE LIABLE FOR    */
/* ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL  */
/* DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE       */
/* GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS           */
/* INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER    */
/* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR         */
/* OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF  */
/* ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.                              */
/***************************************************************************/

//
// Author: Francesco Brun
// Last modified: April, 11th 2016
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
