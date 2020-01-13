using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts
{
    public class MSSQLFileContext : IFileContext
    {
        private string _connectionString = "Server=mssql.fhict.local;Database=dbi418918_realcard;User Id=dbi418918_realcard;Password=michael1;";
        public int Upload(byte[] file)
        {
            int result;
            string query = "INSERT INTO [Images] ([ImageData]) VALUES (@fileData); SELECT SCOPE_IDENTITY()";
            using (var connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.Parameters.Add("@fileData", SqlDbType.VarBinary).Value = file;
                    cmd.CommandText = query;
                    connection.Open();
                    try
                    {
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        result = -1;
                    }
                }
            }
            return result;
        }

        public void Delete(int fileId)
        {
            string query = "DELETE FROM [Images] WHERE [Id] = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("@id", fileId);
                    cmd.CommandText = query;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ImageFile Read(int fileId)
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM [Images] WHERE [Id] = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("@id", fileId);
                    cmd.CommandText = query;
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        connection.Open();
                        da.Fill(ds);
                    }
                }
            }

            DataRow dr = ds.Tables[0].Rows[0];
            ImageFile img = new ImageFile()
            {
                Id = fileId,
                CreatedAt = (DateTime) dr["UploadDate"],
                ImageByteArray = (byte[]) dr["ImageData"]
            };
            return img;
        }
    }
}
