using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using RealCard.Core.DAL.Contexts.Interfaces;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;

namespace RealCard.Core.DAL.Contexts
{
    public class MSSQLCardContext : BaseMSSQLContext, ICardContext
    {
        public int Create(Card card)
        {
            string query = "INSERT INTO [Card] (Name, Type, Attack, Health, Description, Cost, Image_Id) VALUES (@name, @type, @attack, @health, @description, @cost, @imgid); SELECT SCOPE_IDENTITY()";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("name", card.Name),
                new KeyValuePair<string, string>("type", ((int) card.Type).ToString()),
                new KeyValuePair<string, string>("attack", card.Attack.ToString()),
                new KeyValuePair<string, string>("health", card.Health.ToString()),
                new KeyValuePair<string, string>("description", card.Description),
                new KeyValuePair<string, string>("cost", card.Value.ToString()),
                new KeyValuePair<string, string>("imgid", card.ImageId.ToString())

            };
            var result = ExecuteSql(query, parameters);
            if (result != null)
            {
                return Convert.ToInt32(result.Tables[0].Rows[0][0]);
            }
            else return -1;
        }

        public Card Read(int cardId)
        {
            string query = "SELECT * FROM [Card] WHERE [Id] = @id";
            var parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id", cardId.ToString())
            };
            var result = ExecuteSql(query, parameters);
            if (result != null)
            {
                return DataParser.ConvertToCard(result.Tables[0].Rows[0]);
            }
            return null;
        }

        public void Update(Card card)
        {
            string query =
                "UPDATE [Card] SET [Name] = @name, [Type] = @type, [Attack] = @attack, [Health] = @health, [Description] = @description, [Cost] = @cost, [Image_Id] = @imgid WHERE [Id] = @cardid";
            var parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("name", card.Name),
                new KeyValuePair<string, string>("type", ((int) card.Type).ToString()),
                new KeyValuePair<string, string>("attack", card.Attack.ToString()),
                new KeyValuePair<string, string>("health", card.Health.ToString()),
                new KeyValuePair<string, string>("description", card.Description),
                new KeyValuePair<string, string>("cost", card.Value.ToString()),
                new KeyValuePair<string, string>("imgid", card.ImageId.ToString()),
                new KeyValuePair<string, string>("cardid", card.Id.ToString()),
            };
            ExecuteSql(query, parameters);
        }

        public void Delete(int cardId)
        {
            string query = "DELETE FROM [Card] WHERE [Id] = @id";
            var parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id", cardId.ToString())
            };

            ExecuteSql(query, parameters);
        }

        public List<Card> GetAll()
        {
            string query = "SELECT * FROM [Card] ORDER BY [Name]";
            var result = ExecuteSql(query, new List<KeyValuePair<string, string>>());

            if (result != null)
            {
                return DataParser.ConvertToCardList(result);
            }

            return null;
        }

        public List<Card> GetAllByPlayerId(int playerId)
        {
            string query =
                "SELECT * FROM [Card] c INNER JOIN [User_Card] uc ON c.[Id] = uc.[Card_Id] WHERE uc.[User_Id] = @id ORDER BY c.[Name]";
            var parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("id", playerId.ToString())
            };
            var result = ExecuteSql(query, parameters);

            if (result != null)
            {
                return DataParser.ConvertToCardList(result);
            }
            return new List<Card>();
        }

        public void AddCardToPlayer(int cardId, int playerId)
        {
            string query = "INSERT INTO [User_Role] (User_Id, Card_Id) VALUES (@cardid, @playerid)";
            var parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("playerid", playerId.ToString()),
                new KeyValuePair<string, string>("cardid", cardId.ToString())
            };
            ExecuteSql(query, parameters);
        }

        public void RemoveCardFromPlayer(int cardId, int playerId)
        {
            string query = "DELETE FROM [User_Role] WHERE [Card_Id] = @cardid AND [User_Id] = @playerid";
            var parameters = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("playerid", playerId.ToString()),
                new KeyValuePair<string, string>("cardid", cardId.ToString())
            };
            ExecuteSql(query, parameters);
        }
    }
}
