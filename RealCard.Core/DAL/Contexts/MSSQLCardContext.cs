using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts
{
    public class MSSQLCardContext : ICardContext
    {
        public int Create(Card card)
        {
            throw new NotImplementedException();
        }

        public Card Read(int cardId)
        {
            throw new NotImplementedException();
        }

        public void Update(Card card)
        {
            throw new NotImplementedException();
        }

        public void Delete(int cardId)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAllByPlayerId(int playerId)
        {
            throw new NotImplementedException();
        }

        public void AddCardToPlayer(int cardId, int playerId)
        {
            throw new NotImplementedException();
        }
    }
}
