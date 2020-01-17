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

        public void Save(Deck dc)
        {
             _context.Save(dc);
        }

        public void Create(Deck dc)
        {
            _context.Create(dc);
        }
    }
}
