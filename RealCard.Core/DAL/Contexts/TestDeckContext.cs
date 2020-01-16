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


        public void Create(int[] ids, string name, int userId)
        {
            Deck d = new Deck();
            List<Card> cards = new List<Card>();
            d.Name = name;
            d.Player = new User()
            {
                Id = userId
            };
            foreach (int x in ids)
            {
                Card c = new Card()
                {
                    Id = x,
                };
                cards.Add(c);
            }

            d.Cards = cards;
            decks.Add(d);
        }

        public List<Deck> GetAllByPlayerId(int id)
        {
            return decks.Where(n => n.Id == id).ToList();
        }

        public Deck Read(int id)
        {
            return decks[decks.FindIndex(n => n.Id == id)];
        }

        public void Save(int[] ids, int deckId, string name)
        {
            Deck d = decks[decks.FindIndex(n => n.Id == deckId)];
            d.Name = name;
            List<Card> tempList = new List<Card>();
            foreach (int x in ids)
            {
                Card c = new Card()
                {
                    Id = x
                };
                tempList.Add(c);
            }

            d.Cards = tempList;
        }


    }
}
