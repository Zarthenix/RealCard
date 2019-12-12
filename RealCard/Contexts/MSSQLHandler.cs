using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using RealCard.Models;
using System.Data;
using RealCard.Contexts.Interfaces;
using System.Text.RegularExpressions;

namespace RealCard.Contexts
{
    public class MSSQLHandler : IHandler
    { 
        private readonly string _connectionString;
        public MSSQLHandler(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public object ExecuteCommand(string query, List<KeyValuePair<string, object>> parameters = null)
        {
            object value = null;
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    SqlParameter param;

                    foreach (KeyValuePair<string, object> p in parameters)
                    {
                        param = new SqlParameter
                        {
                            ParameterName = "@" + p.Key,
                            Value = p.Value.ToString()
                        };
                        cmd.Parameters.Add(param);
                    }

                    cmd.Connection.Open();
                    value = cmd.ExecuteScalar();
                    sqlConnection.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return value;
        }

        public object ExecuteSelect(string query, List<KeyValuePair<string, object>> parameters)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection sqlConnection = new SqlConnection(_connectionString);

                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    query = ReplaceParameter(query, parameter.Key, parameter.Value);
                }

                using (SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection))
                {
                    da.Fill(ds);
                }
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object ExecuteSelect(string query, object parameter = null)
        {
            try
            {
                if (parameter != null)
                {
                    int[] indexes = FindParameter(query);
                    int length = indexes[1] - indexes[0];
                    string param = query.Substring(indexes[0], length);
                    query = ReplaceParameter(query, param, parameter);
                }

                DataSet ds = new DataSet();
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                

                using (SqlDataAdapter da = new SqlDataAdapter(query, sqlConnection))
                {
                    da.Fill(ds);
                }
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private int[] FindParameter(string query)
        {
            if (!query.Contains("@"))
                return new int[2] { -1, -1 };

            int begin = query.IndexOf('@') + 1;
            Regex reg = new Regex(@"^[a-zA-Z]+$");

            int end = 0;
            for (int i = begin + 1; i < query.Length; i++)
            {
                if (!reg.IsMatch(query[i].ToString()))
                {
                    end = i;

                    return new int[2] { begin, end };
                }
            }

            return new int[2] { begin, query.Length };
        }

        private string ReplaceParameter(string query, string name, object value)
        {
            return query = query.Replace($"@{name}", $"'{value.ToString()}'");
        }
    }
}
