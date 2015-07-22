using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

namespace Othello.Controllers
{
    public class GameController : Controller
    {
        [HttpPost]
        public ActionResult StartGame(string player1Name, string player2Name)
        {
            ViewBag.player1Name = player1Name;
            ViewBag.player2Name = player2Name;
            var board = new OthelloBoard();
            var player1 = new Player<Counter>(player1Name, board, "black");
            var player2 = new Player<Counter>(player2Name, board, "white");
            return View();
        }
        [HttpPost]
        public JsonResult Play(Player<Counter> player, string gridRef)
        {
             Json()
        }
    }
}