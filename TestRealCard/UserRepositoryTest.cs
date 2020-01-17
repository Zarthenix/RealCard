using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;
using TestRealCard.DataSource;

namespace TestRealCard
{
    [TestClass]
    public class UserRepositoryTest
    {
        private UserRepo _userRepo;
        private TestUserContext _context;

        [TestInitialize]
        public void TestInit()
        {
            _context = new TestUserContext();
            UserData.FillData(_context);
            _userRepo = new UserRepo(_context);
        }

        [TestMethod]
        public void Should_Return_All_Users()
        {
            List<User> users = _userRepo.GetAll();
            Assert.AreEqual(3, users.Count);
        }

        [TestMethod]
        public void Should_Toggle_ChatPermission()
        {
            _userRepo.ToggleChatPermission(false, 27);
            Assert.AreEqual(true, _context.users[1].CanChat);
        }

        [TestMethod]
        public void Should_Get_User_By_Id()
        {
            User user = _userRepo.GetById(22);
            Assert.AreEqual(user, _context.users[0]);
        }

        [TestMethod]
        public void Should_Delete_User_By_Id()
        {
            _userRepo.Delete(22);
            Assert.AreEqual(2, _context.users.Count);
            Assert.AreEqual(27, _context.users[0].Id);
        }
    }
}
