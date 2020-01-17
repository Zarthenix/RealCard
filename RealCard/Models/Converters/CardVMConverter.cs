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
            Card card = new Card(cvm.Id)
            {
                Name = cvm.Name,
                Description = cvm.Description,
                Attack = cvm.Attack,
                Health = cvm.Health,
                Value = cvm.Value,
                ImageId = cvm.ImageId,
                Type = cvm.Type
            };

            return card;
        }

        public CardViewModel ConvertToViewModel(Card card)
        {
            CardViewModel cvm = new CardViewModel()
            {
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
                Attack = card.Attack,
                Health = card.Health,
                Value = card.Value,
                ImageId = card.ImageId,
                Type = card.Type
            };
            return cvm;
        }
    }
}
