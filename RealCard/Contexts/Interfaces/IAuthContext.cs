using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models;

namespace RealCard.Contexts
{
    public interface IAuthContext
    {
        bool Login(User user);
        bool Register(User user);

    }
}
