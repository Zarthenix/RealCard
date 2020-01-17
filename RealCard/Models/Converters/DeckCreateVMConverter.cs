using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models;

namespace RealCard.Models.Converters
{
    public class DeckCreateVMConverter
    {
        public Deck ConvertToModel(DeckCreateViewModel dcvm)
        {
            List<Card> cards = new List<Card>();
            foreach (int x in dcvm.CardIds)
            {
                Card c = new Card(x);
                cards.Add(c);
            }

            Deck d = new Deck(dcvm.DeckName, cards)
            {
                Id = dcvm.Id,
                Player = new User(dcvm.UserId)
            };

            return d;
        }
    }
}
