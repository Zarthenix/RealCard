using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Core.DAL.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public User Player { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Wins { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();

        public Deck(string name, List<Card> cards)
        {
            this.Name = name;
            this.Cards = cards;
        }

        public Deck(int id, string name, DateTime createdAt, int wins)
        {
            this.Id = id;
            this.Name = name;
            this.CreatedAt = createdAt;
            this.Wins = wins;
        }

        public Deck(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Deck(string name, List<Card> cards, User player)
        {
            this.Cards = cards;
            this.Name = name;
            this.Player = player;
        }
    }
}
