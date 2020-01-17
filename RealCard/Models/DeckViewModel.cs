using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Models
{
    public class DeckViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Wins { get; set; }
        public string Name { get; set; }
        public List<CardViewModel> Cards { get; set; } = new List<CardViewModel>();
    }
}
