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
            int id = (int) dr["Id"];
            Card c = new Card(id)
            {
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
            int id = (int) dr["Id"];
            string username = dr["Username"].ToString();
            string email = dr["Email"].ToString();

            User user = new User(id, username, email)
            {
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
            int id = (int) dr["Id"];
            string name = dr["Name"].ToString();
            Deck deck = new Deck(id, name)
            {
                CreatedAt = Convert.ToDateTime(dr["Created_At"]),
                Wins = (int)dr["Wins"],
            };
            
            return deck;
        }
    }
}
