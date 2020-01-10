using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;

namespace RealCard.Core.DAL.Models
{
    public class File
    {
        public byte[] ImageByteArray { get; set; }

        public string ImageBase64String { get; set; }


        public File(IFormFile file)
        {
            ImageByteArray = ConvertFormFileToByteArray(file);
        }

        public File(byte[] imageByteArray)
        {
            ImageByteArray = imageByteArray;
            ImageBase64String = ConvertByteArrayToBase64(imageByteArray);
        }

        public File(string base64Image)
        {
            ImageBase64String = base64Image;
            ImageByteArray = ConvertBase64ToByteArray(base64Image);
        }

        public static byte[] ConvertFormFileToByteArray(IFormFile formFile)
        {
            byte[] byteArray;
            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyToAsync(memoryStream);
                byteArray = memoryStream.ToArray();
            }

            return byteArray;
        }

        public static string ConvertByteArrayToBase64(byte[] byteArray)
        {
            string base64String = "";

            return base64String;
        }

        public static byte[] ConvertBase64ToByteArray(string base64String)
        {
            byte[] byteArray = null;


            return byteArray;
        }
    }
}
