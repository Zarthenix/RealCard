using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;
using TestRealCard.DataSource;

namespace TestRealCard
{
    [TestClass]
    public class CardRepositoryTest
    {
        private CardRepo _cardRepo;
        private TestCardContext _context;

        [TestInitialize]
        public void TestInit()
        {
            _context = new TestCardContext();
            _cardRepo = new CardRepo(_context);
            CardData.FillData(_context);
        }

        [TestMethod]
        public void Should_Create_Card_To_List()
        {
            Card c = new Card(55);
            int index = _cardRepo.Create(c);
            Assert.AreEqual(4, _context.cards.Count);
            Assert.AreEqual(55, index);
        }

        [TestMethod]
        public void Should_Delete_Card()
        {
            int id = _context.cards[0].Id;

            _cardRepo.Delete(id);

            Assert.AreEqual(2, _context.cards.Count);
        }

        [TestMethod]
        public void Should_Get_All_Cards()
        {
            List <Card> cards = _cardRepo.GetAll();
            Assert.AreEqual(cards, _context.cards);
        }

        [TestMethod]
        public void Should_Get_Card_By_Id()
        {
            int id = _context.cards[0].Id;
            Card c = _cardRepo.Read(id);
            Assert.AreEqual(_context.cards[0], c);
        }

        [TestMethod]
        public void Should_Update_Card()
        {
            Card c = _context.cards[0];
            c.Name = "Testing";
            c.Attack = 1337;
            c.Health = 7331;
            _cardRepo.Update(c);

            Assert.AreEqual(c, _context.cards[0]);
        }

      
    }
}
