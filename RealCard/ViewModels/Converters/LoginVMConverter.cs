using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models;

namespace RealCard.ViewModels.Converters
{
    public class LoginVMConverter
    {
        public BaseAccount ConvertToModel(LoginViewModel lvm)
        {
            return new BaseAccount()
            {
                Username = lvm.Username,
                Password = lvm.Password

            };
        }

        public LoginViewModel ConvertToViewModel(BaseAccount acc)
        {
            return new LoginViewModel()
            {
                Username = acc.Username,
                Password = acc.Password
            };
        }
    }
}
