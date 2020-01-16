using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models;

namespace RealCard.Models.Converters
{
    public class DeckVMConverter
    {
        public DeckViewModel ConvertToViewModel(Deck d)
        {
            DeckViewModel dv = new DeckViewModel()
            {
                CreatedAt = d.CreatedAt,
                Id = d.Id,
                Name = d.Name,
                Wins = d.Wins
            };
            return dv;
        }
        
    }
}
