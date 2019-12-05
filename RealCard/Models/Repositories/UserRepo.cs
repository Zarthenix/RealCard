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

        public List<BaseAccount> GetAll()
        {
            return _context.GetAll();
        }

        public BaseAccount GetById(int id)
        {
            return _context.GetById(id);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}
