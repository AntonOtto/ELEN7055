using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCWebApp.Models
{
    public class TournamentGoalsPerPlayer
    {
        public string Tournament { get; set; }
        public string PlayerName { get; set; }
        public string PlayerLastName { get; set; }
        public string CountryName { get; set; }
        public int NumberOfGoals { get; set; }
    }
}