using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Models
{
    public class CardViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "Maximal number of characters is 100.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Type is required.")]
        [Display(Name = "Card type")]
        public CardType Type { get; set; }
       
        [Required(ErrorMessage = "Attack value is required")]
        [Range(0, int.MaxValue)]
        [Display(Name ="Attack")]
        public int Attack { get; set; }
        
        [Required(ErrorMessage = "Health value is required.")]
        [Range(0, int.MaxValue)]
        [Display(Name = "Health")]
        public int Health { get; set; }
        
        [Display(Name="File Upload")]
        public ImageFileViewModel Uploader { get; set; } = new ImageFileViewModel();
        
        public int ImageId { get; set; }
        
        [Required(ErrorMessage = "Please give the card a description.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Please enter a card cost")]
        [Display(Name = "Cost")]
        [Range(0, int.MaxValue, ErrorMessage = "Please select a positive number")]
        public int Value { get; set; }

    }
}
