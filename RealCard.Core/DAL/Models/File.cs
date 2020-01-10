using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace RealCard.Core.DAL.Models
{
    public class File
    {
        public IFormFile RawFile { get; set; }

        public byte[] FileData
        {
            get
            {
                byte[] convertedData = null;
                using (var memoryStream = new MemoryStream())
                {
                    RawFile.CopyToAsync(memoryStream);
                    convertedData = memoryStream.ToArray();
                }

                return convertedData;
            }
        }
    }
}
