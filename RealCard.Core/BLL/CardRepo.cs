using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.BLL
{
    public class CardRepo
    {
        private readonly ICardContext _context;

        public CardRepo(ICardContext context)
        {
            _context = context;
        }
        public int Create(Card card)
        {
            return _context.Create(card);
        }

        public Card Read(int cardId)
        {
            return _context.Read(cardId);
        }

        public void Update(Card card)
        {
            _context.Update(card);
        }

        public void Delete(int cardId)
        {
            _context.Delete(cardId);
        }

        public List<Card> GetAll()
        {
            return _context.GetAll();
        }

        public List<Card> GetAllByPlayerId(int playerId)
        {
            return _context.GetAllByPlayerId(playerId);
        }

        public void AddCardToPlayer(int cardId, int playerId)
        { 
            _context.AddCardToPlayer(cardId, playerId);
        }
    }
}
