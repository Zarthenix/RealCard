using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.BLL
{
    public class DeckRepo
    {
        private IDeckContext _context;

        public DeckRepo(IDeckContext context)
        {
            _context = context;
        }

        public List<Deck> GetAllByPlayerId(int id)
        {
            return _context.GetAllByPlayerId(id);
        }

        public Deck Read(int id)
        {
            return _context.Read(id);
        }

        public void Save(int[] ids, int deckId, string name)
        {
             _context.Save(ids, deckId, name);
        }

        public void Create(int[] ids, string deckName, int userid)
        {
            _context.Create(ids, deckName, userid);
        }
    }
}
