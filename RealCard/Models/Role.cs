using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Role(string rolename)
        {
            this.Name = rolename;
        }

        public Role()
        {
            
        }
    }
}
