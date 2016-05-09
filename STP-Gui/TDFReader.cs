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
using System.Windows.Forms;
using HDF5DotNet;

namespace SYRMEPTomoProject
{
    static class TDFReader
    {
        private static int GetDim(string filename, int dim)
        {
            H5FileId zFile = null;
            H5DataSetId dataset = null;
            H5DataSpaceId space = null;
            long[] dims;

            if (!File.Exists(filename))
                throw new Exception("File not found.");

            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/tomo");
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);

                H5S.close(space);
                space = null;
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return (int)dims[dim];
            }
            catch { }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }

            zFile = null;
            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/exchange/data");
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);

                H5S.close(space);
                space = null;
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return (int)dims[dim];
            }
            catch
            {
                throw new Exception("Not a valid HDF5 file.");
            }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }
        }

        public static int GetNumberOfSlices(string filename)
        {
            return GetDim(filename, 0);
        }    

        public static int GetNumberOfProjections(string filename)
        {
            return GetDim(filename, 1);
        }    

        public static int GetDetectorSize(string filename)
        {
            return GetDim(filename, 2);
        }

        public static bool HasFlats(string filename)
        {
            H5FileId zFile = null;
            H5DataSetId dataset = null;

            if (!File.Exists(filename))
                throw new Exception("File not found.");

            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/flat");
            
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return true;
            }
            catch {}
            finally
            {             
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }

            zFile = null;
            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/exchange/data_white");
            
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }
        }

        public static int GetNumberOfFlats(string filename)
        {
            H5FileId zFile = null;
            H5DataSetId dataset = null;
            H5DataSpaceId space = null;
            long[] dims;

            if (!File.Exists(filename))
                throw new Exception("File not found.");

            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/flat");
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);

                H5S.close(space);
                space = null;
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return (int)dims[1];
            }
            catch { }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }

            zFile = null;
            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/exchange/data_white");
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);

                H5S.close(space);
                space = null;
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return (int)dims[1];
            }
            catch 
            {
                return 0;
            }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }
        }

        public static bool HasDarks(string filename)
        {
            H5FileId zFile = null;
            H5DataSetId dataset = null;

            if (!File.Exists(filename))
                throw new Exception("File not found.");

            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/dark");

                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return true;
            }
            catch { }
            finally
            {
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }

            zFile = null;
            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/exchange/data_dark");
             
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }
        }

        public static int GetNumberOfDarks(string filename)
        {
            H5FileId zFile = null;
            H5DataSetId dataset = null;
            H5DataSpaceId space = null;
            long[] dims;

            if (!File.Exists(filename))
                throw new Exception("File not found.");

            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/dark");
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);

                H5S.close(space);
                space = null;
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return (int)dims[1];
            }
            catch { }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }

            zFile = null;
            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);
                dataset = H5D.open(zFile, "/exchange/data_dark");
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);

                H5S.close(space);
                space = null;
                H5D.close(dataset);
                dataset = null;
                H5F.close(zFile);
                zFile = null;

                return (int)dims[1];
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
                if (zFile != null) H5F.close(zFile);
            }
        }

        public static T GetMetadata<T>(string filename, string path)
        {
            H5FileId zFile = null;

            if (!File.Exists(filename))
                throw new Exception("File not found.");

            try
            {
                zFile = H5F.open(filename, H5F.OpenMode.ACC_RDONLY);

                return (T)HDFExtensions.ReadScalar<T>(zFile, path);
            }
            catch             
            {
                throw new Exception("Path not found");
            }
            finally
            {
                if (zFile != null) H5F.close(zFile);
            }
        }
    }
}
