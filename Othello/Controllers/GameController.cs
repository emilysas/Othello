using System.Web.Mvc;
using ClassLibrary;
using Othello.Models;

namespace Othello.Controllers
{
    public class GameController : Controller
    {
        [HttpPost]
        public ActionResult StartGame(string playerOneName, string playerTwoName)
        {
            var gameBoard = new OthelloBoard();
            var playerOne = new Player<Counter>(playerOneName, gameBoard, "black");
            var playerTwo = new Player<Counter>(playerTwoName, gameBoard, "white");
            var newGame = new Game(gameBoard, playerOne, playerTwo);

            var gameModel = new GameModel
            {
                board = gameBoard,
                player1 = playerOne,
                player2 = playerTwo,
                game = newGame
            };

            return View(gameModel);
        }
//        [HttpPost]
//        public JsonResult Play(Player<Counter> player, string gridRef)
//        {
//            Json();
//        }
    }
}