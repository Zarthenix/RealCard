using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts
{
    public class TestUserContext :IUserContext
    {
        public List<User> users = new List<User>();

        public List<User> GetAll()
        {
            return users;
        }

        public void ToggleChatPermission(bool canChat, int id)
        {
            int index = users.FindIndex(n => n.Id == id);
            users[index].CanChat = canChat;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(n => n.Id == id);
        }

        public void Edit(User user)
        {
            users[users.FindIndex(n => n.Id == user.Id)] = user;
        }

        public void Delete(int id)
        {
            users.Remove(users.FirstOrDefault(n => n.Id == id));
        }
    }
}
