using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts
{
    public class MSSQLDeckContext : BaseMSSQLContext, IDeckContext
    {
        public List<Deck> GetAllByPlayerId(int id)
        {
            List<Deck> decks = new List<Deck>();
            string query = "SELECT * FROM [Deck] WHERE [User_Id] = @id";

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id", id.ToString())
            };
            var result = ExecuteSql(query, parameters);
            try
            {
                decks = DataParser.ConvertToDeckList(result);
            }
            catch (Exception)
            {
                return decks;
            }

            return decks;
        }

        public Deck Read(int id)
        {
            string query =
                "SELECT d.Wins, d.[Name], d.Created_At, cd.[Card_Id] FROM [Deck] d INNER JOIN [Card_Deck] cd on d.[Id] = cd.[Deck_Id] INNER JOIN [Card] c on c.[Id] = cd.[Card_Id] WHERE d.[Id] = @id";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id", id.ToString())
            };
            var result = ExecuteSql(query, parameters);
            Deck deck = new Deck()
            {
                Name = result.Tables[0].Rows[0]["Name"].ToString(),
                CreatedAt = Convert.ToDateTime(result.Tables[0].Rows[0]["Created_At"]),
                Wins = (int)result.Tables[0].Rows[0]["Wins"],
                Cards = new List<Card>()
            };
            foreach (DataRow dr in result.Tables[0].Rows)
            {
                Card c = new Card();
                c.Id = (int) dr["Card_Id"];
                deck.Cards.Add(c);
            }

            return deck;
        }

        public void Save(int[] ids, int deckId, string name)
        {
            if (name == "")
            {
                name = "Nameless";
            }
            string query = "DELETE FROM [Card_Deck] WHERE [Deck_Id] = @deckid; UPDATE [Deck] SET [Name] = @name WHERE [Id] = @did";

            
            ExecuteSql(query, new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("deckid", deckId.ToString()),
                new KeyValuePair<string, string>("did", deckId.ToString()),
                new KeyValuePair<string, string>("name", name)
            });

            InsertArrayIntoSql(ids, deckId);
        }

        public void Create(int[] ids, string name, int userid)
        {
            if (name == "")
            {
                name = "Nameless";
            }
            string query = "INSERT INTO [Deck] ([User_Id], [Name]) VALUES (@id, @name); SELECT SCOPE_IDENTITY();";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id", userid.ToString()),
                new KeyValuePair<string, string>("name", name)
            };
            var result = ExecuteSql(query, parameters);
            int deckId = Convert.ToInt32(result.Tables[0].Rows[0][0]);

            InsertArrayIntoSql(ids, deckId);
            
        }

        private void InsertArrayIntoSql(int[] ids, int deckId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Card_Deck] ([Card_Id], [Deck_Id]) VALUES  ");
            foreach (int x in ids)
            {
                string id = x.ToString();
                string dId = deckId.ToString();
                sb.AppendFormat("({0}, {1}), ", id, dId);
            }

            string query = sb.ToString();
            query = query.Remove(query.Length - 2);
            ExecuteSql(query, new List<KeyValuePair<string, string>>());
        }
    }
}
