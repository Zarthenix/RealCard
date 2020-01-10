using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using File = RealCard.Core.DAL.Models.File;

namespace RealCard.Models.Converters
{
    public class FileVMConverter
    {
        public File ConvertToModel(ImageUploadViewModel iuvm)
        {
            File file = new File();
            using (var memoryStream = new MemoryStream())
            {
                iuvm.File.CopyToAsync(memoryStream);
                file.ImageByteArray = memoryStream.ToArray();
            }

            return file;
        }

        public ImageUploadViewModel ConvertToViewModel(File file)
        {
            ImageUploadViewModel iuvm = new ImageUploadViewModel();

            //iuvm.ImageRawString = converten naar string
        }
    }
}
