using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Contexts.Interfaces
{
    public interface IUserContext
    {
        public List<BaseAccount> GetAll();
        public BaseAccount GetById(int id);
        public void Delete(int id);
    }
}
