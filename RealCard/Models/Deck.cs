using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public User Player { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Wins { get; set; }
        public string Name { get; set; }
    }
}
