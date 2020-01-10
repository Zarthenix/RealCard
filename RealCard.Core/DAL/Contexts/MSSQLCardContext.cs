using System;
using System.Collections.Generic;
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
            string query = "INSERT INTO [Card] () VALUES (); SELECT SCOPE_IDENTITY()";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<String,String>>();
            var result = ExecuteSql(query, parameters);
            if (result != null)
            {
                return (int) result.Tables[0].Rows[0][0];
            }
            else return -1;
        }

        public Card Read(int cardId)
        {
            throw new NotImplementedException();
        }

        public void Update(Card card)
        {
            throw new NotImplementedException();
        }

        public void Delete(int cardId)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAllByPlayerId(int playerId)
        {
            throw new NotImplementedException();
        }

        public void AddCardToPlayer(int cardId, int playerId)
        {
            throw new NotImplementedException();
        }
    }
}
