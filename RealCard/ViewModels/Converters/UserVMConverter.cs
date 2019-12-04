using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.ViewModels.Converters
{
    public class UserVMConverter
    {
        public UserViewModel ConvertToViewModel(BaseAccount user)
        {
            UserViewModel uvm = new UserViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
            return uvm;
        }
    }
}
