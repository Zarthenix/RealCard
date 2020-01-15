using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts
{
    public class TestFileContext : IFileContext
    {
        public List<ImageFile> files = new List<ImageFile>();

        public int Upload(byte[] data)
        {
            throw new NotImplementedException();
        }

        public ImageFile Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
