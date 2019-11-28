using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models.Enums;

namespace RealCard.Models
{
    public class User : BaseAccount
    {
        public UserStatus Status { get; set; }
        public List<User> Friends { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deck> Decks { get; set; }

        public User()
        {
 
        }
    }
}
