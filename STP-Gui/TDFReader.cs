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
