using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCWebApp.Models
{
    public class Round1Results
    {
        public string Tournament { get; set; }
        public string Group { get; set; }
        public string Team { get; set;}
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int GamesDrawn { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int Points { get; set; }
    }
}