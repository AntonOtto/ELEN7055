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
            var sql = "select * from TournamentRound1Results where Tournament='"+ Tournament +"' order by GroupName, Points desc";

            if (GroupName != string.Empty)
            {
                sql = "select * from TournamentRound1Results where Tournament='" + Tournament + "' and GroupName = '" + GroupName + "' order by Points desc";
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


        public List<TournamentMatchSchedule> GetTournamentMatchSchedule(string Tournament)
        {
            var results = new List<TournamentMatchSchedule>();
            var sql = "select * from TournamentMatchSchedule where Tournament='" + Tournament + "' order by DateTime desc";

            var allResults = _db.ExecuteSQL(sql);

            for (var i = 0; i <= allResults.Tables[0].Rows.Count - 1; i++)
            {
                var result = new TournamentMatchSchedule
                { 
                    Tournament = allResults.Tables[0].Rows[i][0].ToString(),
                    GroupName = allResults.Tables[0].Rows[i][1].ToString(),
                    VenueName = allResults.Tables[0].Rows[i][2].ToString(),
                    City = allResults.Tables[0].Rows[i][3].ToString(),
                    MatchDateTime = Convert.ToDateTime(allResults.Tables[0].Rows[i][4].ToString()),
                    Team1 = allResults.Tables[0].Rows[i][5].ToString(),
                    Team2 = allResults.Tables[0].Rows[i][6].ToString()
                };
                results.Add(result);
            }

            return results;
        }


        public List<TournamentGoalsPerPlayer> GetTournamentGoalsPerPlayer(string Tournament)
        {
            var results = new List<TournamentGoalsPerPlayer>();
            var sql = "select * from TournamentGoalsPerPlayer where Tournament='" + Tournament + "' order by [Number of Goals] desc";

            var allResults = _db.ExecuteSQL(sql);

            for (var i = 0; i <= allResults.Tables[0].Rows.Count - 1; i++)
            {
                var result = new TournamentGoalsPerPlayer
                {
                    Tournament = allResults.Tables[0].Rows[i][0].ToString(),
                    PlayerName = allResults.Tables[0].Rows[i][1].ToString(),
                    PlayerLastName = allResults.Tables[0].Rows[i][2].ToString(),
                    CountryName = allResults.Tables[0].Rows[i][3].ToString(),
                    NumberOfGoals = Convert.ToInt32(allResults.Tables[0].Rows[i][4].ToString())
                };
                results.Add(result);
            }

            return results;
        }
    }
}