using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using RealCard.Models;
using RealCard.Models.Enums;

namespace RealCard.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool CanChat { get; set; }
        public Role Role { get; set; }

    }
}
