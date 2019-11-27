using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Contexts;

namespace RealCard.Models.Repositories
{
    public class AuthRepo
    {
        private IAuthContext _context;

        public AuthRepo(IAuthContext context)
        {
            _context = context;
        }

        public bool Login(User user)
        {
            return _context.Login(user);
        }

        public bool Register(User user)
        {
            return _context.Register(user);
        }
    }
}
