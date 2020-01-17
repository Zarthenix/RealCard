using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;
using TestRealCard.DataSource;

namespace TestRealCard
{
    [TestClass]
    public class DeckRepositoryTest
    {
        private TestDeckContext _context;
        private DeckRepo _deckRepo;

        [TestInitialize]
        public void TestInit()
        {
            _context = new TestDeckContext();
            DeckData.FillData(_context);
            _deckRepo = new DeckRepo(_context);
        }

        [TestMethod]
        public void Should_Get_All_By_Player_Id()
        {
            int playerid = _context.decks[0].Player.Id;

            List<Deck> decks = _deckRepo.GetAllByPlayerId(playerid);

            Assert.AreEqual(2, decks.Count);
        }

        [TestMethod]
        public void Should_Get_Deck_By_Id()
        {
            int id = _context.decks[1].Id;
            Deck d = _deckRepo.Read(id);
            Assert.AreEqual(_context.decks[1], d);
        }
    }
}
