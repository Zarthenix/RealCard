using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts.Interfaces
{
    public interface IFileContext
    {
        int Upload(byte[] file);
        void Delete(int fileId);
        ImageFile Read(int fileId);
    }
}
