using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models;

namespace RealCard.Contexts
{
    public interface IAuthContext
    {
        Task<bool> Login(BaseAccount user);
        Task<bool> Register(BaseAccount user);

    }
}
