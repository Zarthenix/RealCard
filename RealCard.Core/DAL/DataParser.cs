using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RealCard.Core.DAL.Models;
using RealCard.Core.DAL.Models.Enums;

namespace RealCard.Core.DAL
{
    class DataParser
    {
        public static List<User> ConvertToUserList(DataSet ds)
        {
            List<User> users = new List<User>();
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                User acc = ConvertToUser(dr);   
                users.Add(acc);
            } 
            return users;
        }

        public static User ConvertToUser(DataRow dr)
        {
            User user = new User()
            {
                Id = (int) dr["Id"],
                Username = dr["Username"].ToString(),
                Email = dr["Email"].ToString(),
                CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                CanChat = Convert.ToBoolean(dr["CanChat"]),
                Status = (UserStatus) dr["Status"]
            };
            try
            {
                user.Role = new Role(dr["RoleName"].ToString(), (int) dr["RoleId"]);
            }
            catch (Exception)
            {
                return user;
            }
            return user;
        }
    }
}
