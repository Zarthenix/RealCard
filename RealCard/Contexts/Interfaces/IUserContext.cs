using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Contexts.Interfaces
{
    public interface IUserContext
    {
        List<User> GetAll();
        List<User> GetAllWithRoles();
        User GetById(int id);
        User GetByIdWithRole(int id);
        void Edit(User user);
        void Delete(int id);
        void ToggleChatPermission(bool currentPermission, int userId);
    }
}
