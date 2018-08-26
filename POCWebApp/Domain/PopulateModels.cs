using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POCWebApp.Models;

namespace POCWebApp.Domain
{
    public class PopulateModels
    {
        Database _db;

        public PopulateModels()
        {
            _db = new Database();
        }

        public List<AllMatchesAndDates> GetAllMatchesAndDates()
        {
            var matchesAndDates = new List<AllMatchesAndDates>();

            var allMatches = _db.ExecuteSQL("select * from AllMatchesAndDates");

            for (var i = 0; i <= allMatches.Tables[0].Rows.Count - 1; i++)
            {
                var match = new AllMatchesAndDates
                {
                    TeamName = allMatches.Tables[0].Rows[i][0].ToString(),
                    Stadium = allMatches.Tables[0].Rows[i][2].ToString(),
                    City = allMatches.Tables[0].Rows[i][3].ToString(),
                    MatchDateTime = Convert.ToDateTime(allMatches.Tables[0].Rows[i][4].ToString())
                };
                matchesAndDates.Add(match);
            }

            return matchesAndDates;
        }

        public List<Round1Results> GetRound1Results(string Tournament)
        {
            return GetRound1Results(Tournament,string.Empty);
        }

        public List<Round1Results> GetRound1Results(string Tournament, string GroupName)
        {
            var round1Results = new List<Round1Results>();
            var sql = "select * from Round1Results where Tournament='"+ Tournament +"' order by GroupName, Points desc";

            if (GroupName != string.Empty)
            {
                sql = "select * from Round1Results where Tournament='" + Tournament + "' and GroupName = '" + GroupName + "' order by Points desc";
            }

            var allResults = _db.ExecuteSQL(sql);

            for (var i = 0; i <= allResults.Tables[0].Rows.Count - 1; i++)
            {
                var result = new Round1Results
                {
                    Tournament = allResults.Tables[0].Rows[i][0].ToString(),
                    Group = allResults.Tables[0].Rows[i][1].ToString(),
                    Team = allResults.Tables[0].Rows[i][3].ToString(),
                    GamesPlayed = Convert.ToInt32(allResults.Tables[0].Rows[i][4].ToString()),
                    GamesWon = Convert.ToInt32(allResults.Tables[0].Rows[i][5].ToString()),
                    GamesLost = Convert.ToInt32(allResults.Tables[0].Rows[i][6].ToString()),
                    GamesDrawn = Convert.ToInt32(allResults.Tables[0].Rows[i][7].ToString()),
                    GoalsFor = Convert.ToInt32(allResults.Tables[0].Rows[i][8].ToString()),
                    GoalsAgainst = Convert.ToInt32(allResults.Tables[0].Rows[i][9].ToString()),
                    Points = Convert.ToInt32(allResults.Tables[0].Rows[i][10].ToString())
                };
                round1Results.Add(result);
            }

            return round1Results;
        }
    }
}