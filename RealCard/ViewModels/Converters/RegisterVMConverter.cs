using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models;

namespace RealCard.ViewModels.Converters
{
    public class RegisterVMConverter
    {
        public BaseAccount ConvertToModel(RegisterViewModel rvm)
        {
            return new BaseAccount()
            {
                Username = rvm.Username,
                Password = rvm.Password,
                Email = rvm.Email
            };
        }

        public RegisterViewModel ConvertToViewModel(BaseAccount acc)
        {
            return new RegisterViewModel()
            {
                Username = acc.Username,
                Password = acc.Password,
                Email = acc.Email
            };
        }
    }
}
