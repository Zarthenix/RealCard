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
        User GetById(int id);
        void Delete(int id);
    }
}
