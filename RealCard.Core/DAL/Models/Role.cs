using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Core.DAL.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(string roleName, int id)
        {
            this.Name = roleName;
            this.Id = id;
        }

        public Role()
        {
            
        }
    }
}
