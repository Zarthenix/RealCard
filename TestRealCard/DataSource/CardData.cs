﻿using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;

namespace TestRealCard.DataSource
{
    class CardData
    {
        public static void FillData(TestCardContext context)
        {
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

            context.cards.Add(card1);
            context.cards.Add(card2);
            context.cards.Add(card3);
        }
    }
}