using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;
using TestRealCard.DataSource;

namespace TestRealCard
{
    [TestClass]
    class CardRepositoryTest
    {

        private CardRepo _cardRepo;
        private TestCardContext _context;

        [TestInitialize()]
        public void TestInit()
        {
            _context = new TestCardContext();
            CardData.FillData(_context);
            _cardRepo = new CardRepo(_context);
        }

        [TestMethod]
        public void Should_Create_Card_To_List()
        {
            Card c = new Card()
            {
                Id = 55
            };
            int index = _cardRepo.Create(c);
            Assert.AreEqual(4, _context.cards.Count);
            Assert.AreEqual(3, _context.cards[_context.cards.IndexOf(c)]);
        }

        [TestMethod]
        public void Should_Get_Card_By_Id()
        {
            int id = 27;
            Card c = _cardRepo.Read(27);
            Assert.AreEqual(id, c.Id);
        }

        [TestMethod]
        public void Should_Update_Card()
        {
            Card c = _context.cards[0];
            c.Name = "Testing";
            c.Attack = "1337";
            c.Health = "7331";
            _cardRepo.Update(c);

            Assert.AreEqual(c, _context.cards[0]);
        }
    }
}
