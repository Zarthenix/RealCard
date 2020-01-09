using RealCard.Contexts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Models.Repositories
{
    public class UserRepo
    {
        private IUserContext _context;

        public UserRepo(IUserContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.GetAll();
        }

        public void ToggleChatPermission(bool current, int user)
        {
            _context.ToggleChatPermission(current, user);
        }

        public void Edit(User user)
        {
            _context.Edit(user);
        }

        public List<User> GetAllWithRoles()
        {
            return _context.GetAllWithRoles();
        }

        public User GetById(int id)
        {
            return _context.GetById(id);
        }

        public User GetByIdWithRole(int id)
        {
            return _context.GetByIdWithRole(id);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}
