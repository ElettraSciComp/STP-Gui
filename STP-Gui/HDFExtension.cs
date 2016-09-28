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
// Last modified: July, 8th 2016
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HDF5DotNet;

namespace SYRMEPTomoProject
{
    public static class HDFExtensions
    {
        // thank you http://stackoverflow.com/questions/4133377/splitting-a-string-number-every-nth-character-number
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        public static T ReadScalar<T>(H5FileId fileId, string datasetName)
        {
            H5DataSetId dataset = null;
            H5DataSpaceId space = null;
            H5DataTypeId dataType = null;
            long[] dims;
            T data = default(T);

            try
            {
                dataset = H5D.open(fileId, datasetName);
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);
                dataType = H5D.getType(dataset);
                
                H5D.readScalar<T>(dataset, dataType, ref data);
                if (typeof(T) == typeof(string))
                {
                    int stringLength = H5T.getSize(dataType);
                    byte[] buffer = new byte[ 2*stringLength ];
                    H5D.read(dataset, dataType, new H5Array<byte>(buffer));
                    string stuff = System.Text.ASCIIEncoding.ASCII.GetString(buffer);
                    return (T) (stuff.SplitInParts(stringLength).Select(ss => (T)(object)ss));
                }
                return data;
            }
            catch
            {
                return default(T);
            }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
            }
        }

        public static T[] Read1DArray<T>(H5FileId fileId, string dataSetName)
        {
            H5DataSetId dataset = null;
            H5DataSpaceId space = null;
            H5DataTypeId dataType = null;
            long[] dims;

            try
            {
                dataset = H5D.open(fileId, dataSetName);
                space = H5D.getSpace(dataset);
                dims = H5S.getSimpleExtentDims(space);
                dataType = H5D.getType(dataset);
                if (typeof(T) == typeof(string))
                {
                    int stringLength = H5T.getSize(dataType);
                    int a = (int)dims[0];
                    byte[] buffer = new byte[ (int) (dims[0]) * stringLength];
                    H5D.read(dataset, dataType, new H5Array<byte>(buffer));
                    string stuff = System.Text.ASCIIEncoding.ASCII.GetString(buffer);
                    return stuff.SplitInParts(stringLength).Select(ss => (T)(object)ss).ToArray();
                }
                T[] dataArray = new T[dims[0]];
                var wrapArray = new H5Array<T>(dataArray);
                H5D.read(dataset, dataType, wrapArray);
                return dataArray;
            }
            catch {
                return null;
            }
            finally
            {
                if (space != null) H5S.close(space);
                if (dataset != null) H5D.close(dataset);
            }
        }

        public static T[,] Read2DArray<T>(H5FileId fileId, string dataSetName)
        {
            var dataset = H5D.open(fileId, dataSetName);
            var space = H5D.getSpace(dataset);
            var dims = H5S.getSimpleExtentDims(space);
            var dataType = H5D.getType(dataset);
            if (typeof(T) == typeof(string))
            {
                // this will also need a string hack...
            }
            T[,] dataArray = new T[dims[0], dims[1]];
            var wrapArray = new H5Array<T>(dataArray);
            H5D.read(dataset, dataType, wrapArray);
            return dataArray;
        }
    }
}
