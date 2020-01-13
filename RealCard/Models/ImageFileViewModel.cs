using System;
using System.Collections.Generic;
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

        public IFormFile FileRaw { get; set; }

        public string ImageBase64String { get; set; }
    }
}
