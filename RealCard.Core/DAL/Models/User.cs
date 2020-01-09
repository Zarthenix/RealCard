using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Core.DAL.Models
{
    public class User : BaseAccount
    {
        public bool CanChat { get; set; }

        public List<User> Friends { get; set; }
        public List<Card> Cards { get; set; }
        public List<Deck> Decks { get; set; }

        public User()
        {
 
        }
    }
}
