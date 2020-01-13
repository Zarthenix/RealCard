using RealCard.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts;

namespace TestRealCard.DataSource
{
    class UserData
    {
        public static void FillData(TestUserContext context)
        {
            User user1 = new User()
            {
                Id = 1,
                CreatedAt = DateTime.Parse("2019-01-01 10:20"),
                CanChat = true,
                Email = "test1@test.nl",
                Password = ""
            };
            User user2 = new User()
            {
                Id = 2,
                CreatedAt = DateTime.Parse("2019-02-02 11:24"),
                CanChat = false,
                Email = "test2@test.nl",
                Password = ""
            };
            User user3 = new User()
            {
                Id = 3,
                CreatedAt = DateTime.Parse("2019-03-03 20:40"),
                CanChat = true,
                Email = "test3@test.nl",
                Password = ""
            };

            context.users.Add(user1);
            context.users.Add(user2);
            context.users.Add(user3);
        }
       
    }
}
