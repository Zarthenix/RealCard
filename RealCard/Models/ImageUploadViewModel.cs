using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RealCard.Models
{
    public class ImageUploadViewModel
    {
        [Required(ErrorMessage = "Please select an image.")]
        [FileExtensions(Extensions = "jpg,gif,png,jpeg", ErrorMessage = "Please only select jpg, gif, png or jpeg-files")]
        public IFormFile File { get; set; }
    }
}
