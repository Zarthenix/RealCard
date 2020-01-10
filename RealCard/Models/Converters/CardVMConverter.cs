using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models;

namespace RealCard.Models.Converters
{
    public class CardVMConverter
    {
        public Card ConvertToModel(CardViewModel cvm)
        {
            Card card = new Card()
            {
                Id = cvm.Id,
                Name = cvm.Name,
                Description = cvm.Description,
                Attack = cvm.Attack,
                Health = cvm.Health,
                Value = cvm.Value
            };

            return card;
        }
    }
}
