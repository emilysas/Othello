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
            TempData["currentGame"] = gameModel;

            return View(gameModel);
        }

        [HttpPost]
        public ActionResult Play(string gridRef)
        {
        // post the gridRef that has been clicked on - client - done
        // ask the backend if the play is valid
            var gameModel = ((GameModel)TempData["currentGame"]);
            gameModel.game.Play(gridRef);
        // if yes, update model (server) and return as json so javascript can rerender the grid (client)
       
        // if no, alert that this is not a valid move
            return View("_board", gameModel);
        }
    }
}