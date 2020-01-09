using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealCard.Core.DAL.Models
{
    public class PlayerMatchStats : Match
    {
        public User Player { get; set; }
        public int EnemiesKilled { get; set; }
        public int GoldEarned { get; set; }
        public bool Winner { get; set; }
    }
}
