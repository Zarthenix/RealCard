using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts.Interfaces
{
    public interface IUserContext
    {
        List<User> GetAll();
        User GetById(int id);
        void Edit(User user);
        void Delete(int id);
        void ToggleChatPermission(bool currentPermission, int userId);
    }
}
