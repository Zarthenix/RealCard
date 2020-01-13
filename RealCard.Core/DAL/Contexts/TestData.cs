using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Core.DAL.Contexts
{
    class TestData
    {
        public List<User> Users { get; set; }
        public List<Card> Cards { get; set; }
        public List<ImageFile> Files { get; set; }

        public TestData()
        {
            Users = new List<User>();
            Cards = new List<Card>();
            Files = new List<ImageFile>();

            User user1 = new User()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2019-01-01 10:20"),
                CanChat = true,
                Email = "test1@test.nl",
                Password = ""
            };
            User user2 = new User()
            {
                Id = 2,
                CreatedAt = DateTime.Parse("2019-02-02 11:24"),
                CanChat = false,
                Email = "test2@test.nl",
                Password = ""
            };
            User user3 = new User()
            {
                Id = 3,
                CreatedAt = DateTime.Parse("2019-03-03 20:40"),
                CanChat = true,
                Email = "test3@test.nl",
                Password = ""
            };
            Card card1 = new Card()
            {
                Id = 1,
                Attack = 100,
                Health = 100,
                Description = "First test card",
                ImageId = 3,
                Name = "Tester1",
                Type = CardType.Air,
                Value = 200
            };
            Card card2 = new Card()
            {
                Id = 2,
                Attack = 150,
                Health = 75,
                Description = "Second test card",
                ImageId = 1,
                Name = "Tester2",
                Type = CardType.Fire,
                Value = 100
            };
            Card card3 = new Card()
            {
                Id = 3,
                Attack = 500,
                Health = 444,
                Description = "Third test card",
                ImageId = 2,
                Name = "Tester3",
                Type = CardType.Water,
                Value = 666
            };
            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);

        }
    }
}
