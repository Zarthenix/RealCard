using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;

namespace TestRealCard.DataSource
{
    public class FileData
    {
        public static void FillData(TestFileContext context)
        {
            ImageFile file1 = new ImageFile()
            {
                Id = 1,
                ImageByteArray = null,
                ImageBase64String = null,
                CreatedAt = DateTime.Now
            };

            ImageFile file2 = new ImageFile()
            {
                Id = 2,
                ImageByteArray = null,
                ImageBase64String = null,
                CreatedAt = DateTime.Parse("2019-01-01 14:14")
            };

            ImageFile file3 = new ImageFile()
            {
                Id = 3,
                ImageByteArray = null,
                ImageBase64String = null,
                CreatedAt = DateTime.Parse("2017-03-12 18:12")
            };

            context.files.Add(file1);
            context.files.Add(file2);
            context.files.Add(file3);
        }
    }
}
