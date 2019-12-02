using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Contexts;

namespace RealCard.Models.Repositories
{
    public class AuthRepo
    {
        private readonly IAuthContext _context;

        public AuthRepo(IAuthContext context)
        {
            _context = context;
        }

        public async Task<bool> Login(BaseAccount user)
        {
            return await _context.Login(user);
        }

        public async Task<bool> Register(BaseAccount user)
        {
            return await _context.Register(user);
        }
    }
}
