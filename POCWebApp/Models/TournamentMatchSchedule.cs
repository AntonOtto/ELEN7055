using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCWebApp.Models
{
    public class TournamentMatchSchedule
    {
        public string Tournament { get; set; }
        public string GroupName { get; set; }
        public string VenueName { get; set; }
        public string City { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
    }
}