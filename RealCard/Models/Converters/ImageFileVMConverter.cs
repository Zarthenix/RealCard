using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models;

namespace RealCard.Models.Converters
{
    public class ImageFileVMConverter
    {
        public ImageFile ConvertToModel(ImageFileViewModel ifvm)
        {
            ImageFile img = new ImageFile()
            {
                ImageByteArray = ImageFile.ConvertFormFileToByteArray(ifvm.FileRaw),
                Id = ifvm.Id
            };
            return img;
        }

        public ImageFileViewModel ConvertToViewModel(ImageFile img)
        {
            ImageFileViewModel ifvm;
            try
            {
                ifvm = new ImageFileViewModel()
                {
                    Id = img.Id,
                    CreatedAt = img.CreatedAt,
                    ImageBase64String = Convert.ToBase64String(img.ImageByteArray)
                };
            }
            catch (Exception)
            {
                return new ImageFileViewModel();
            }
            return ifvm;
        }
    }
}
