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

            string name = result.Tables[0].Rows[0]["Name"].ToString();
            DateTime created = Convert.ToDateTime(result.Tables[0].Rows[0]["Created_At"]);
            int wins = (int) result.Tables[0].Rows[0]["Wins"];

            Deck deck = new Deck(id, name, created, wins);
            
            foreach (DataRow dr in result.Tables[0].Rows)
            {
                Card c = new Card((int)dr["Card_Id"]);
                deck.Cards.Add(c);
            }

            return deck;
        }

        public void Save(Deck d)
        {
            string query = "DELETE FROM [Card_Deck] WHERE [Deck_Id] = @deckid; UPDATE [Deck] SET [Name] = @name WHERE [Id] = @did";

            ExecuteSql(query, new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("deckid", d.Id.ToString()),
                new KeyValuePair<string, string>("did", d.Id.ToString()),
                new KeyValuePair<string, string>("name", d.Name)
            });

            InsertCardIdsIntoSql(d.Cards, d.Id);
        }

        public void Create(Deck d)
        {
            string query = "INSERT INTO [Deck] ([User_Id], [Name]) VALUES (@id, @name); SELECT SCOPE_IDENTITY();";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id", d.Player.Id.ToString()),
                new KeyValuePair<string, string>("name", d.Name)
            };
            var result = ExecuteSql(query, parameters);
            d.Id = Convert.ToInt32(result.Tables[0].Rows[0][0]);

            InsertCardIdsIntoSql(d.Cards, d.Id);
            
        }

        private void InsertCardIdsIntoSql(List<Card> cards, int deckId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [Card_Deck] ([Card_Id], [Deck_Id]) VALUES  ");

            foreach (Card c in cards)
            {
                string id = c.Id.ToString();
                string dId = deckId.ToString();
                sb.AppendFormat("({0}, {1}), ", id, dId);
            }
            string query = sb.ToString();
            query = query.Remove(query.Length - 2);
            ExecuteSql(query, new List<KeyValuePair<string, string>>());
        }
    }
}
