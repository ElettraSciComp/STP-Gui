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
// Last modified: May, 4th 2016
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
