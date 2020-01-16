using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;
using TestRealCard.DataSource;

namespace TestRealCard
{
    [TestClass]
    class UserRepositoryTest
    {
        private UserRepo _userRepo;
        private TestUserContext context;
        [TestInitialize()]
        public void TestInit()
        {
            context = new TestUserContext();
            UserData.FillData(context);
            _userRepo = new UserRepo(context);
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
            Assert.AreEqual(true, context.users[1].CanChat);
        }

        [TestMethod]
        public void Should_Get_User_By_Id()
        {
            User user = _userRepo.GetById(22);
            Assert.AreEqual(user, context.users[0]);
        }

        [TestMethod]
        public void Should_Delete_User_By_Id()
        {
            int id = 22;
            _userRepo.Delete(id);
            Assert.AreEqual(2, context.users.Count);
            Assert.AreEqual(27, context.users[0].Id);
        }
    }
}
