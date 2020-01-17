using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts
{
    public class TestCardContext : ICardContext
    {
        public List<Card> cards = new List<Card>();

        public int Create(Card c)
        {
            cards.Add(c);
            return cards[cards.Count - 1].Id;
        }

        public void Delete(int id)
        {
            cards.Remove(cards.FirstOrDefault(n => n.Id == id));
        }

        public List<Card> GetAll()
        {
            return cards;
        }

        public Card Read(int id)
        {
            return cards.FirstOrDefault(n => n.Id == id);
        }

        public void Update(Card c)
        {
            cards[cards.FindIndex(n => n.Id == c.Id)] = c;
        }

        public void AddCardToPlayer(int cardId, int playerId)
        {
            throw new NotImplementedException();
        }
        public List<Card> GetAllByPlayerId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
