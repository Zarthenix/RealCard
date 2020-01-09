using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Models
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }

    }
}
