using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;

namespace TestRealCard.DataSource
{
    public class DeckData
    {
        public static void FillData(TestDeckContext context)
        {
            context.decks = new List<Deck>();
            Deck d1 = new Deck(1, "Test1")
            {
                Wins = 1,
                Player = new User(22)
                {
                    CreatedAt = DateTime.Parse("2019-01-01 10:20"),
                    CanChat = true,
                    Email = "test1@test.nl",
                    Password = "AQAAAAEAACcQAAAAEOpoAXHMX87CMbdw6iChqeEoDLb6YLJgPfZ4sqMMAi8KjkC/rDauM/7l9Ar423tqBw=="

                },
                Cards = new List<Card>()
                {
                    new Card(1)
                    {
                        Attack = 100,
                        Health = 100,
                        Description = "First test card",
                        ImageId = 3,
                        Name = "Tester1",
                        Type = CardType.Air,
                        Value = 200
                    },
                    new Card(2)
                    {
                        Attack = 150,
                        Health = 75,
                        Description = "Second test card",
                        ImageId = 1,
                        Name = "Tester2",
                        Type = CardType.Fire,
                        Value = 100
                    },
                    new Card(3)
                    {
                        Attack = 500,
                        Health = 444,
                        Description = "Third test card",
                        ImageId = 2,
                        Name = "Tester3",
                        Type = CardType.Water,
                        Value = 666
                    }
                },

            };
            Deck d2 = new Deck(2, "Test2")
            {
                Wins = 33,
                Player = new User(23)
                {
                    CreatedAt = DateTime.Parse("2012-01-01 10:20"),
                    CanChat = false,
                    Email = "test2@test.nl",
                    Password = "AQAAAAEAACcQAAAAEOpoAXHMX87CMbdw6iChqeEoDLb6YLJgPfZ4sqMMAi8KjkC/rDauM/7l9Ar423tqBw=="

                },
                Cards = new List<Card>()
                {
                    new Card(4)
                    {
                        Attack = 100,
                        Health = 100,
                        Description = "Fourth test card",
                        ImageId = 3,
                        Name = "Tester4",
                        Type = CardType.Air,
                        Value = 200
                    },
                    new Card(5)
                    {
                        Attack = 150,
                        Health = 75,
                        Description = "Fifth test card",
                        ImageId = 1,
                        Name = "Tester5",
                        Type = CardType.Fire,
                        Value = 100
                    },
                    new Card(6)
                    {
                        Attack = 500,
                        Health = 444,
                        Description = "Sixth test card",
                        ImageId = 2,
                        Name = "Tester6",
                        Type = CardType.Water,
                        Value = 666
                    }
                },
            };
            Deck d3 = new Deck(3, "Test3")
            {
                Wins = 33,
                Player = new User(22)
                {
                    CreatedAt = DateTime.Parse("2011-01-01 10:20"),
                    CanChat = false,
                    Email = "test2@test.nl",
                    Password = "AQAAAAEAACcQAAAAEOpoAXHMX87CMbdw6iChqeEoDLb6YLJgPfZ4sqMMAi8KjkC/rDauM/7l9Ar423tqBw=="

                },
                Cards = new List<Card>()
                {
                    new Card(4)
                    {
                        Attack = 100,
                        Health = 100,
                        Description = "Fourth test card",
                        ImageId = 3,
                        Name = "Tester4",
                        Type = CardType.Air,
                        Value = 200
                    },
                    new Card(5)
                    {
                        Attack = 150,
                        Health = 75,
                        Description = "Fifth test card",
                        ImageId = 1,
                        Name = "Tester5",
                        Type = CardType.Fire,
                        Value = 100
                    },
                    new Card(6)
                    {
                        Attack = 500,
                        Health = 444,
                        Description = "Sixth test card",
                        ImageId = 2,
                        Name = "Tester6",
                        Type = CardType.Water,
                        Value = 666
                    }
                },
            };
            context.decks.Add(d1);
            context.decks.Add(d2);
            context.decks.Add(d3);
        }
    }
}
