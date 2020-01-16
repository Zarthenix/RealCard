using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts.Interfaces
{
    public interface IDeckContext
    {
        List<Deck> GetAllByPlayerId(int id);
        Deck Read(int id);
        void Save(int[] ids, int deckId, string name);
        void Create(int[] ids, string name, int userid);
    }
}
