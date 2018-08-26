using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POCWebApp.Models
{
    public class AllMatchesAndDates
    {
        public string TeamName { get; set; }
        public string Stadium { get; set;}
        public string City { get; set; }
        public DateTime MatchDateTime { get; set; }
    }
}