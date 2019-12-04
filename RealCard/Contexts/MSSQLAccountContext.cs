using Microsoft.Extensions.Configuration;
using RealCard.Contexts.Interfaces;
using RealCard.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Contexts
{
    public class MSSQLAccountContext : IUserContext
    {
        private readonly string _connectionString;

        public MSSQLAccountContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public List<BaseAccount> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.[GetAllUsers]", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

            }

            return new List<BaseAccount>();
        }

        public BaseAccount GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT [Username], [Email], WHERE [Id] = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                using (SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    BaseAccount user = default(BaseAccount);
                    if (sqlDataReader.Read())
                    {
                        user = new BaseAccount(Convert.ToInt32(sqlDataReader["id"].ToString()), sqlDataReader["username"].ToString(), sqlDataReader["email"].ToString());

                    }
                    connection.Close();
                    return user;
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE Id = @id", connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
