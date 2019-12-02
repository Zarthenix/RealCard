using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Contexts
{
    public class MSSQLAuthContext : IAuthContext
    {
        private IAuthContext _context;

        public MSSQLAuthContext(IAuthContext context)
        {
            _context = context;
        }

        public async Task<bool> Register(BaseAccount user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(BaseAccount user)
        {
            throw new NotImplementedException();
        }
    }
}
