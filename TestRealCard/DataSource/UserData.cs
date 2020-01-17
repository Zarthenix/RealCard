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
            context.users = new List<User>();
            User user1 = new User(22, "Test1", "test1@test.nl", "AQAAAAEAACcQAAAAEOpoAXHMX87CMbdw6iChqeEoDLb6YLJgPfZ4sqMMAi8KjkC/rDauM/7l9Ar423tqBw==", DateTime.Parse("2019-01-01 10:20"))
            {
                CanChat = true,
            };
            User user2 = new User(27, "Test2", "test2@test.nl", "AQAAAAEAACcQAAAAEDLuBbbjqS7vkbjqZY5SgsZqU8LvzUwr6V1CAWfshOCoJJFbjxe0YIXgWeXdx1HIng==", DateTime.Parse("2019-02-02 11:24"))
            {
                CanChat = false,
            };
            User user3 = new User(3, "Test3", "test3@test.nl", "AQAAAAEAACcQAAAAEObXeK6iVuXBNz2p9oG7viaL6gXjIlNVgg0dSA06KB2Hnx5dOH5tMlB3cyBOPQ1RaA====", DateTime.Parse("2019-03-03 20:40"))
            {
                CanChat = true,
            };

            context.users.Add(user1);
            context.users.Add(user2);
            context.users.Add(user3);
        }
       
    }
}
