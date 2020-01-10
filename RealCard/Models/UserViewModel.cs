using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Username is required.")]
        [StringLength(15, ErrorMessage = "Username can only be max 15 characters long")]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "An e-mail is required.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "E-mail cannot be over 50 characters long.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool CanChat { get; set; }
        public Role Role { get; set; }

    }
}
