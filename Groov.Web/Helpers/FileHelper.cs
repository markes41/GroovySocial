using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Groov.Web.Helpers
{
    public class FileHelper
    {
        public async static Task<byte[]> ConvertFileToByteArray(IFormFileCollection file, string filePath)
        {
            // Travel through all the files in the request
            foreach (var formFile in file)
            {
                if (formFile.Length > 0)
                {
                    using (var inputStream = new FileStream(filePath, FileMode.Create))
                    {
                        // read file to stream
                        await formFile.CopyToAsync(inputStream);
                        // stream to byte array
                        byte[] array = new byte[inputStream.Length];
                        inputStream.Seek(0, SeekOrigin.Begin);
                        inputStream.Read(array, 0, array.Length);
                        return array;
                    }
                }
            }

            return null;
        }
    }
}
