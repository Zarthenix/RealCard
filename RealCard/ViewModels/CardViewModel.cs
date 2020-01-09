using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models.Enums;

namespace RealCard.ViewModels
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CardType Type { get; set; }

    }
}
