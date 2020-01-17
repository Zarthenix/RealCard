using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Models
{
    public class DeckCreateViewModel
    {
        public int Id { get; set; }
        public int[] CardIds { get; set; }
        public string DeckName { get; set; }
        public int UserId { get; set; }
    }
}
