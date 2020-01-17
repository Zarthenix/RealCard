using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Core.DAL.Models
{
    public class User : BaseAccount
    {
        public bool CanChat { get; set; }

        public List<Card> Cards { get; set; }


        public User(int id) : base(id)
        {
            this.Id = id;
        }

        public User(int id, string username, string email, string password, DateTime createdAt) : base(id, username, email, password, createdAt)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.CreatedAt = createdAt;
        }

        public User(int id, string username, string email) : base(id, username, email)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
        }
    }
}
