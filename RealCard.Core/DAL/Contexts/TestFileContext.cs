using System;
using System.Collections.Generic;
using System.Linq;
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
            int id = files.Count == 0 ? 1 : files[files.Count - 1].Id + 1;
            ImageFile file = new ImageFile(id, data);
            files.Add(file);

            return files.IndexOf(file);
        }

        public ImageFile Read(int id)
        {
            return files.FirstOrDefault(n => n.Id == id);
        }

        public void Delete(int id)
        {
            files.Remove(files.FirstOrDefault(n => n.Id == id));
        }
    }
}
