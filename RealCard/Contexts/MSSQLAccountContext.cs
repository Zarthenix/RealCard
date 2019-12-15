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

        public User GetById(int id)
        {
            User acc;
            string query = "SELECT [Username], [Email] FROM [User] WHERE [Id] = @id";

            var data = handler.ExecuteSelect(query, id) as DataTable;

            try
            {
                DataRow dr = data.Rows[0];
                acc = new User()
                {
                    Id = (int)dr["Id"],
                    Username = dr["Username"].ToString(),
                    Email = dr["Email"].ToString(),
                    Status = (UserStatus)dr["Status"]
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
            string query = "DELETE FROM [User] WHERE Id = @id";
            handler.ExecuteCommand(query, new KeyValuePair<string, object>("@id", id));
        }
    }
}
