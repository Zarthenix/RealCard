﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;

namespace RealCard.Core.DAL.Models
{
    public class ImageFile
    {
        public int Id { get; set; }

        public byte[] ImageByteArray { get; set; }

        public string ImageBase64String { get; set; }

        public DateTime CreatedAt { get; set; }

       
        public static byte[] ConvertFormFileToByteArray(IFormFile formFile)
        {
            byte[] byteArray;
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                byteArray = memoryStream.ToArray();
            }

            return byteArray;
        }

    }
}