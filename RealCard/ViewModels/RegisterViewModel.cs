using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace RealCard.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(15, ErrorMessage = "Username can only be max 15 characters long")]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(25, ErrorMessage = "No more than 25 characters for your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The passwords don't match. Try again.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "An e-mail is required.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "E-mail cannot be over 50 characters long.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
