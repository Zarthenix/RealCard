using Microsoft.Extensions.Configuration;
using RealCard.Contexts.Interfaces;
using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Models.Enums;

namespace RealCard.Contexts
{
    public class MSSQLAccountContext : BaseMSSQLContext, IUserContext
    {

        public MSSQLAccountContext(IHandler handler) : base(handler)
        { }
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM dbo.[GetAllUsers]";
            var sqlDataSet = handler.ExecuteSelect(query) as DataTable;

            try
            {
                foreach (DataRow dr in sqlDataSet.Rows)
                {
                    User acc = new User()
                    {
                        Id = (int) dr["Id"],
                        Username = dr["Username"].ToString(),
                        Email = dr["Email"].ToString(),
                        CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                        Status = (UserStatus) dr["Status"]
                    };
                    users.Add(acc);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return users;
        }

        public List<User> GetAllWithRoles()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM dbo.[GetAllUsersWithRoles]";
            var sqlDataSet = handler.ExecuteSelect(query) as DataTable;

            try
            {
                foreach (DataRow dr in sqlDataSet.Rows)
                {
                    User acc = new User()
                    {
                        Id = (int)dr["Id"],
                        Username = dr["Username"].ToString(),
                        Email = dr["Email"].ToString(),
                        Status = (UserStatus)dr["Status"],
                        CanChat = Convert.ToBoolean(dr["CanChat"]),
                        Role = new Role(dr["RoleName"].ToString())
                    };
                    users.Add(acc);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return users;
        }

        public void Edit(User user)
        {
            string query = "UPDATE [User] SET [Email] = @email, [Username] = @user WHERE [Id] = @id";
            var paramsList = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("@email", user.Email),
                new KeyValuePair<string, object>("@user", user.Username),
                new KeyValuePair<string, object>("@id", user.Id)
            };
            handler.ExecuteCommand(query, paramsList);
        }

        public User GetById(int id)
        {
            User acc;
            string query = "SELECT [Username], [Email], [Status], [CreatedAt] FROM [User] WHERE [Id] = @id";

            var data = handler.ExecuteSelect(query, id) as DataTable;

            try
            {
                DataRow dr = data.Rows[0];
                acc = new User()
                {
                    Id = id,
                    Username = dr["Username"].ToString(),
                    Email = dr["Email"].ToString(),
                    Status = (UserStatus)dr["Status"],
                    CreatedAt = (DateTime)dr["CreatedAt"]
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return acc;
        }

        public void ToggleChatPermission(bool currentPermission, int userId)
        {
            string query = "";
            if (currentPermission)
            {
                query = "UPDATE [User] SET CanChat = 0 WHERE [Id] = @id";
            }
            else
            {
                query = "UPDATE [User] SET CanChat = 1 WHERE [Id] = @id";
            }

            handler.ExecuteCommand(query, new KeyValuePair<string, object>("@id", userId));
        }

        public User GetByIdWithRole(int id)
        {
            User acc;
            string query = "SELECT u.[Id], u.[Username], u.[Status], u.[Email], r.[Name] AS RoleName FROM [User] u INNER JOIN [User_Roles] ur on u.Id = ur.[User_Id] INNER JOIN [Roles] r on ur.[Role_Id] = r.[Id] ";

            var data = handler.ExecuteSelect(query, id) as DataTable;

            try
            {
                DataRow dr = data.Rows[0];
                acc = new User()
                {
                    Id = id,
                    Username = dr["Username"].ToString(),
                    Email = dr["Email"].ToString(),
                    Status = (UserStatus)dr["Status"],
                    CreatedAt = (DateTime)dr["CreatedAt"],
                    Role = new Role(dr["RoleName"].ToString())
                };
            }
            catch (Exception e)
            {
                throw e;
            }
            return acc;
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM [User_Roles] WHERE [User_Id] = @id; DELETE FROM [User] WHERE Id = @id;";
            handler.ExecuteCommand(query, new KeyValuePair<string, object>("@id", id));
        }
    }
}
