using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RealCard.Core.DAL.Models;

namespace RealCard.Models
{
    public class ImageFileViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        [FileExtensions(Extensions = "jpg,gif,png,jpeg", ErrorMessage = "Please only select jpg, gif, png or jpeg-files")]
        public IFormFile FileRaw { get; set; }

        public string ImageBase64String { get; set; }
    }
}
