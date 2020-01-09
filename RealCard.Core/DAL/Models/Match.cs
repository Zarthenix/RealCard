using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Core.DAL.Models
{
    public class Match
    {
        public int Id { get; set; }
        public List<PlayerMatchStats> PlayerStats  { get; set; }
        public int Rounds { get; set; }
        public int Time { get; set; }
    }
}
