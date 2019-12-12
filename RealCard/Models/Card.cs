using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models.Enums;

namespace RealCard.Models
{
    public class Card
    {
        public string Table { get; } = "dbo.[Card]";

        public int Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

    }
}
