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
   
    }
}
