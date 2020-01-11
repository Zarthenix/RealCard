using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.BLL
{
    public class ImageFileRepo
    {
        private readonly IFileContext _context;
        public ImageFileRepo(IFileContext context)
        {
            _context = context;
        }

        public int UploadFile(byte[] fileData)
        {
            
            return _context.Upload(fileData);
        }

        public void Delete(int fileId)
        {
            _context.Delete(fileId);
        }

        public ImageFile Read(int fileId)
        {
            return _context.Read(fileId);
        }
    }
}
