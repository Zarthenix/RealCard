using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;

namespace RealCard.Core.DAL.Contexts.Interfaces
{
    public interface IFileContext
    {
        int Upload(byte[] file);
        void Delete(int fileId);
        string Load(int fileId);
    }
}
