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
    public class MSSQLAccountContext : IUserContext
    {
        private readonly string _connectionString;

        public MSSQLAccountContext(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        public List<BaseAccount> GetAll()
        {
            List<BaseAccount> users = new List<BaseAccount>();
            DataSet sqlDataSet = new DataSet();

            using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.[GetAllUsers]", connection);
            using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            connection.Open();
            sqlDataAdapter.SelectCommand = cmd;
            sqlDataAdapter.Fill(sqlDataSet);

            foreach (DataRow dr in sqlDataSet.Tables[0].Rows)
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
            connection.Close();
            return users;
        }

        public BaseAccount GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT [Username], [Email], WHERE [Id] = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();
            using SqlDataReader sqlDataReader = cmd.ExecuteReader();
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
            using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE Id = @id", connection);
            cmd.ExecuteNonQuery();
        }
    }
}
