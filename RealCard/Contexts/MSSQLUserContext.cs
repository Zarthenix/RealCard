using Microsoft.AspNetCore.Identity;
using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace RealCard.Contexts
{
    public class MSSQLUserContext : IUserStore<BaseAccount>, IUserPasswordStore<BaseAccount>, IUserEmailStore<BaseAccount>, IUserRoleStore<BaseAccount>
    {
        private readonly string _connectionString;
        public MSSQLUserContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Create a user in de DB. The userId (in de database) must be set to auto increment. 
        /// The password is hashed automatically.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> CreateAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("dbo.RegisterUser", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@username", user.Username);
                sqlCommand.Parameters.AddWithValue("@password", user.Password);
                sqlCommand.Parameters.AddWithValue("@email", user.Email);
                sqlCommand.Parameters.AddWithValue("@status", 0);
                user.Id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (user.Id == -1)
                {
                    throw new Exception("Database error.");
                }

                connection.Close();
                return Task.FromResult<IdentityResult>(IdentityResult.Success);
            }
            catch (Exception)
            {

                throw;
            }
        }




        /// <summary>
        ///Delete the user from the database (or make the user obsolete)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> DeleteAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //nothing to do.
        }


        /// <summary>
        /// Finding a user by Email in the database
        /// </summary>
        /// <param name="normalizedEmail"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseAccount> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT [Id], [username], [email] FROM [User] WHERE [email]=@email", connection);
            sqlCommand.Parameters.AddWithValue("@email", normalizedEmail);
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            BaseAccount user = default(BaseAccount);
            if (sqlDataReader.Read())
            {
                user = new BaseAccount(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString());

            }
            connection.Close();
            return Task.FromResult(user);
        }

        /// <summary>
        /// Finding a user by id in the database
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<BaseAccount> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT Id, username, email FROM [User] WHERE Id=@id", connection);
                sqlCommand.Parameters.AddWithValue("@id", userId);
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BaseAccount user = default(BaseAccount);
                if (sqlDataReader.Read())
                {
                    user = new BaseAccount(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString());

                }
                connection.Close();
                return Task.FromResult(user);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<BaseAccount> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT [Id], [Username], [Email], [Password] FROM [User] WHERE username=@username", connection);
                sqlCommand.Parameters.AddWithValue("@username", normalizedUserName);
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BaseAccount user = default(BaseAccount);
                if (sqlDataReader.Read())
                {
                    user = new BaseAccount(Convert.ToInt32(sqlDataReader["id"]), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString(), sqlDataReader["password"].ToString());
                }
                connection.Close();
                return Task.FromResult(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> GetEmailAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string> GetNormalizedUserNameAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUsername);
        }

        public Task<string> GetPasswordHashAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<IList<string>> GetRolesAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            try
            {


                cancellationToken.ThrowIfCancellationRequested();

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT r.[Name], r.[Id] FROM [Roles] r INNER JOIN [User_Roles] ur ON ur.[Role_Id] = r.[Id] WHERE ur.UserId = @userId", connection);
                sqlCommand.Parameters.AddWithValue("@userId", user.Id);
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                IList<string> roles = new List<string>();
                while (sqlDataReader.Read())
                {
                    roles.Add(sqlDataReader["Name"].ToString());
                }
                connection.Close();
                return Task.FromResult(roles);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> GetUserIdAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public Task<IList<BaseAccount>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        public Task<bool> IsInRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            try
            {

                cancellationToken.ThrowIfCancellationRequested();

                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                SqlCommand sqlCommandUserRole = new SqlCommand("SELECT COUNT(*) FROM [User_Roles] WHERE [User_Id] = @userId AND [Role_Id] = (SELECT [Id] FROM [Roles] WHERE [Name] = @RoleName)", connection);
                sqlCommandUserRole.Parameters.AddWithValue("@userId", user.Id);
                sqlCommandUserRole.Parameters.AddWithValue("@RoleName", roleName);

                int? roleCount = sqlCommandUserRole.ExecuteScalar() as int?;
                connection.Close();
                return Task.FromResult(roleCount > 0);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task RemoveFromRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(BaseAccount user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(BaseAccount user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task SetEmailConfirmedAsync(BaseAccount user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(BaseAccount user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetNormalizedUserNameAsync(BaseAccount user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUsername = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(BaseAccount user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetUserNameAsync(BaseAccount user, string userName, CancellationToken cancellationToken)
        {
            user.Username = userName;
            return Task.FromResult(0);
        }
        /// <summary>
        /// Update user in database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IdentityResult> UpdateAsync(BaseAccount user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
