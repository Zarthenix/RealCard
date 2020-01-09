using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;


namespace RealCard.Core.BLL
{
    public class UserRepo
    {
        private readonly IUserContext _context;

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
        
        public User GetById(int id)
        {
            return _context.GetById(id);
        }
        
        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}
