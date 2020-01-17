using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Core.DAL.Contexts
{
    public class TestDeckContext : IDeckContext
    {
        public List<Deck> decks = new List<Deck>();


        public void Create(Deck dc)
        {
            throw new NotImplementedException();
        }

        public List<Deck> GetAllByPlayerId(int id)
        {
            return decks.Where(n => n.Player.Id == id).ToList();
        }

        public Deck Read(int id)
        {
            return decks.FirstOrDefault(n => n.Id == id);
        }

        public void Save(Deck dc)
        {
            throw new NotImplementedException();
        }


    }
}
