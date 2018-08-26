using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POCWebApp.Domain;
using POCWebApp.Models;

namespace POCWebApp.Controllers
{
    public class HomeController : Controller
    {
        PopulateModels _models;
        public HomeController()
        {
            _models = new PopulateModels();
        }
        public ActionResult Index()
        {
            var db = new Database();
            var players = db.ExecuteSQL("select * from ListOfPlayersPerTeam");
            var playerTeams = new List<PlayersPerTeam>();

            for (var i = 0; i <= players.Tables[0].Rows.Count - 1; i++)
            {
                var playerteam = new PlayersPerTeam();
                playerteam.Team = players.Tables[0].Rows[i][0].ToString();
                playerteam.PlayerName = players.Tables[0].Rows[i][1].ToString();
                playerteam.PlayerLastName = players.Tables[0].Rows[i][2].ToString();
                playerteam.PlayerDOB = players.Tables[0].Rows[i][3].ToString();
                playerTeams.Add(playerteam);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AllMatches()
        {
            var matches = _models.GetAllMatchesAndDates();

            return View(matches);
        }

        public ActionResult Round1Results()
        {
            var round1Results = _models.GetRound1Results();

            return View(round1Results);
        }
    }
}