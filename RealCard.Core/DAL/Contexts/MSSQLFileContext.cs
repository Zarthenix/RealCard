using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;

namespace RealCard.Core.DAL.Contexts
{
    public class MSSQLFileContext : IFileContext
    {
        public int Upload(byte[] file)
        { 
            throw new NotImplementedException();
        }

        public void Delete(int fileId)
        {
            throw new NotImplementedException();
        }

        public string Load(int fileId)
        {
            throw new NotImplementedException();
        }
    }
}
