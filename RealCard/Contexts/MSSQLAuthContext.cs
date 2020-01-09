using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace RealCard.Contexts
{
    public class MSSQLAuthContext : IAuthContext
    {

        private readonly string _connectionString;
        private readonly SignInManager<BaseAccount> _signInManager;
        private readonly UserManager<BaseAccount> _userManager;

        public MSSQLAuthContext(IConfiguration config, SignInManager<BaseAccount> signInManager, UserManager<BaseAccount> userManager)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public async Task<bool> Register(BaseAccount user)
        {
            var result = await _userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                await using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[User_Roles] ([User_Id], [Role_Id]) VALUES ((SELECT [Id] FROM [User] WHERE [Username] = @username), 1);", connection);
                cmd.Parameters.AddWithValue("@username", user.Username);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return result.Succeeded;
        }

        public async Task<bool> Login(BaseAccount user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }


    }
}
