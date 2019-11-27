using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Models
{
    public class Match
    {
        public int Id { get; set; }
        public List<PlayerMatchStats> Player_Stats  { get; set; }
        public int Rounds { get; set; }
        public int Time { get; set; }
    }
}
