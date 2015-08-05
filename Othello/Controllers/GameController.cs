using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using Othello.Models;

namespace Othello.Controllers
{
    public class GameController : Controller
    {
        public ActionResult StartGame(BoardModel boardModel)
        {
            var board = new OthelloBoard();
            var player1 = new Player<Counter>(boardModel.player1Name, board, "black");
            var player2 = new Player<Counter>(boardModel.player2Name, board, "white");
            return View(boardModel);
        }
//        [HttpPost]
//        public JsonResult Play(Player<Counter> player, string gridRef)
//        {
//            Json();
//        }
    }
}