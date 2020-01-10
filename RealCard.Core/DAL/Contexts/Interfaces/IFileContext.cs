using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts.Interfaces
{
    public interface IFileContext
    {
        int Upload(byte[] file);
        void Delete(int fileId);
        File Load(int fileId);
    }
}
