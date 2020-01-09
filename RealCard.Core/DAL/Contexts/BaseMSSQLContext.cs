using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace RealCard.Core.DAL.Contexts
{
    public class BaseMSSQLContext
    { 
        private readonly string _connectionString;
        public BaseMSSQLContext()
        {
            _connectionString = "Server=mssql.fhict.local;Database=dbi418918_realcard;User Id=dbi418918_realcard;Password=michael1;";
        }
        
        public DataSet ExecuteSql(string query, List<KeyValuePair<string, string>> parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_connectionString);
                SqlCommand cmd = sqlConnection.CreateCommand();
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    SqlParameter param = new SqlParameter()
                    {
                        ParameterName = "@" + parameter.Key,
                        Value = parameter.Value
                    };
                    cmd.Parameters.Add(param);
                }
                cmd.CommandText = query;
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    sqlConnection.Open();
                    da.Fill(ds);
                    sqlConnection.Close();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return ds;
        }
    }
}
