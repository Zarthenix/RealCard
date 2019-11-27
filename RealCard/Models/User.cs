using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models.Enums;

namespace RealCard.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string NormalizedUsername { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserStatus Status { get; set; }
        public List<User> Friends { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deck> Decks { get; set; }

        public User()
        {
 
        }
    }
}
