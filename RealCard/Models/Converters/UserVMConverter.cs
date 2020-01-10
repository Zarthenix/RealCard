using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Models;

namespace RealCard.Models.Converters
{
    public class UserVMConverter
    {
        public UserViewModel ConvertToViewModel(User user)
        {
            UserViewModel uvm = new UserViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
                CanChat = user.CanChat,
                Role = user.Role
            };
            return uvm;
        }

        public User ConvertToModel(UserViewModel uvm)
        {
            User user = new User()
            {
                Id = uvm.Id,
                Username = uvm.Username,
                Email = uvm.Email
            };
            return user;
        }
    }
}
