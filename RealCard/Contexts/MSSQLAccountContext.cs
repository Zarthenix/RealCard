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
        public List<BaseAccount> GetAll()
        {
            List<BaseAccount> users = new List<BaseAccount>();
            string query = "SELECT * FROM dbo.[GetAllUsers]";
            var sqlDataSet = handler.ExecuteSelect(query) as DataTable;

            foreach (DataRow dr in sqlDataSet.Rows)
            {
                BaseAccount acc = new BaseAccount()
                {
                    Id = (int) dr["Id"],
                    Username = dr["Username"].ToString(),
                    Email = dr["Email"].ToString(),
                    CreatedAt =  Convert.ToDateTime(dr["CreatedAt"]),
                    Status = (UserStatus)dr["Status"]
                };
                users.Add(acc);
            }
            return users;
        }

        public BaseAccount GetById(int id)
        {
            string query = "SELECT [Username], [Email] FROM [User] WHERE [Id] = @id";

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
              new KeyValuePair<string, object>("id", id)
            };

            var data = handler.ExecuteSelect(query, parameters) as DataTable;
            foreach(DataRow dr in data.Rows)
            {

            }

            BaseAccount user = default(BaseAccount);
            if (sqlDataReader.Read())
            {
                user = new BaseAccount(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString());

            }
            connection.Close();
            return user;
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM [User] WHERE Id = @id";
            handler.ExecuteCommand(query);
        }
    }
}
