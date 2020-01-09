using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;


namespace RealCard.Core.DAL.Contexts
{
    public class MSSQLAccountContext : BaseMSSQLContext, IUserContext
    {
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            string query = "SELECT * FROM dbo.[GetAllUsersWithRoles]";
            DataSet sqlDataSet = ExecuteSql(query, new List<KeyValuePair<string, string>>());
            if (sqlDataSet != null)
            {
                users = DataParser.ConvertToUserList(sqlDataSet);
            }
            return users;
        }


        public void Edit(User user)
        {
            string query = "UPDATE [User] SET [Email] = @email, [Username] = @user WHERE [Id] = @id";
            var paramsList = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("email", user.Email),
                new KeyValuePair<string, string>("user", user.Username),
                new KeyValuePair<string, string>("id", user.Id.ToString())
            };
            ExecuteSql(query, paramsList);
        }

        public User GetById(int id)
        {
            string query = "SELECT [Id], [Username], [Email], [Status], [CreatedAt], [CanChat] FROM [User] WHERE [Id] = @id";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("id", id.ToString()));

            DataSet data = ExecuteSql(query, parameters);
            User acc = null;
            if (data != null && data.Tables[0].Rows.Count > 0)
            {
                acc = DataParser.ConvertToUser(data.Tables[0].Rows[0]);
            }
            return acc;
        }

        public void ToggleChatPermission(bool currentPermission, int userId)
        {
            string query = currentPermission
                ? "UPDATE [User] SET CanChat = 0 WHERE [Id] = @id"
                : "UPDATE [User] SET CanChat = 1 WHERE [Id] = @id";
     
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("id", userId.ToString()));

            ExecuteSql(query, parameters);
        }


        public void Delete(int id)
        {
            string query = "DELETE FROM [User_Roles] WHERE [User_Id] = @id; DELETE FROM [User] WHERE Id = @id;";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("id", id.ToString()));

            ExecuteSql(query, parameters);
        }
    }
}
