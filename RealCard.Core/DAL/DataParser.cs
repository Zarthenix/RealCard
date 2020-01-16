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
        public static List<Card> ConvertToCardList(DataSet ds)
        {
            List<Card> cards = new List<Card>();
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                Card c = ConvertToCard(dr);
                cards.Add(c);
            }

            return cards;
        }

        public static Card ConvertToCard(DataRow dr)
        {
            Card c = new Card()
            {
                Id = (int)dr["Id"],
                Name = dr["Name"].ToString(),
                Type = (CardType)dr["Type"],
                Attack = (int)dr["Attack"],
                Health = (int)dr["Health"],
                Description = dr["Description"].ToString(),
                Value = (int)dr["Cost"]
            };
            if (dr["Image_Id"] != DBNull.Value)
            {
                c.ImageId = (int) dr["Image_Id"];
            }
            return c;
        }

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

        public static List<Deck> ConvertToDeckList(DataSet ds)
        {
            List<Deck> decks = new List<Deck>();
            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                Deck deck = ConvertToDeck(dr);
                decks.Add(deck);
            }
            return decks;
        }

        public static Deck ConvertToDeck(DataRow dr)
        {
            Deck deck = new Deck()
            {
                Id = (int)dr["Id"],
                CreatedAt = Convert.ToDateTime(dr["Created_At"]),
                Wins = (int)dr["Wins"],
                Name = dr["Name"].ToString()
            };
            
            return deck;
        }
    }
}
