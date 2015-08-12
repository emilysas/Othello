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
            var playerOne = new Player(playerOneName, "black");
            var playerTwo = new Player(playerTwoName, "white");
            var newGame = new Game(gameBoard, playerOne, playerTwo);

            var gameModel = new GameModel
            {
                board = gameBoard,
                player1 = playerOne,
                player2 = playerTwo,
                game = newGame
            };
            Session["currentGame"] = gameModel;
            return View(gameModel);
        }

        [HttpPost]
        public ActionResult Play(string gridRef)
        {
            var gameModel = (GameModel)Session["currentGame"];
            var counterColour = gameModel.game.PlayerToPlayNext.PlayingColour;
            gameModel.game.Play(gameModel.board, gameModel.player1, gameModel.player2, gridRef, new Counter(){Colour = counterColour});
            Session["currentGame"] = gameModel;
            return PartialView("_board", gameModel);
        }

        [HttpPost]
        public ActionResult GetScores(int player)
        {
            var gameModel = Session["currentGame"];
            return PartialView("_player" + player, gameModel);
        }

    }
}