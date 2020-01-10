using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealCard.Core.DAL.Contexts.Interfaces;

namespace RealCard.Core.BLL
{
    public class FileRepo
    {
        private readonly IFileContext _context;
        public FileRepo(IFileContext context)
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

        public string Load(int fileId)
        {
            return _context.Load(fileId);
        }
    }
}
