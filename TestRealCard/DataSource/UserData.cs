using RealCard.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RealCard.Core.DAL.Contexts;

namespace TestRealCard.DataSource
{
    public class UserData
    {
        public static void FillData(TestUserContext context)
        {
            User user1 = new User()
            {
                Id = 22,
                CreatedAt = DateTime.Parse("2019-01-01 10:20"),
                CanChat = true,
                Email = "test1@test.nl",
                Password = "AQAAAAEAACcQAAAAEOpoAXHMX87CMbdw6iChqeEoDLb6YLJgPfZ4sqMMAi8KjkC/rDauM/7l9Ar423tqBw=="
            };
            User user2 = new User()
            {
                Id = 27,
                CreatedAt = DateTime.Parse("2019-02-02 11:24"),
                CanChat = false,
                Email = "test2@test.nl",
                Password = "AQAAAAEAACcQAAAAEDLuBbbjqS7vkbjqZY5SgsZqU8LvzUwr6V1CAWfshOCoJJFbjxe0YIXgWeXdx1HIng=="
            };
            User user3 = new User()
            {
                Id = 3,
                CreatedAt = DateTime.Parse("2019-03-03 20:40"),
                CanChat = true,
                Email = "test3@test.nl",
                Password = "AQAAAAEAACcQAAAAEObXeK6iVuXBNz2p9oG7viaL6gXjIlNVgg0dSA06KB2Hnx5dOH5tMlB3cyBOPQ1RaA===="
            };

            context.users.Add(user1);
            context.users.Add(user2);
            context.users.Add(user3);
        }
       
    }
}
