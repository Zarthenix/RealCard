using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Core.DAL.Models
{
    public class BaseAccount
    {
        

        public int Id { get; set; }
        public string Username { get; set; }
        public string NormalizedUsername { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserStatus Status { get; set; }

        public Role Role { get; set; }

        public BaseAccount(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public BaseAccount(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

        public BaseAccount(int id, string username, string email, string password, DateTime createdAt)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
        }

        public BaseAccount(int id)
        {
            this.Id = id;
        }
    }
}