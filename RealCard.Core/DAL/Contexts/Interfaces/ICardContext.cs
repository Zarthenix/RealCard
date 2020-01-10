using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts.Interfaces
{
    public interface ICardContext
    {
        int Create(Card card);
        Card Read(int cardId);
        void Update(Card card);
        void Delete(int cardId);

        List<Card> GetAll();
        List<Card> GetAllByPlayerId(int playerId);

        void AddCardToPlayer(int cardId, int playerId);
    }
}
