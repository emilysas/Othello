using ClassLibrary;
using NUnit.Framework;

namespace NUnitTests
{

    [TestFixture]
    public class GameTests
    {
       
        [Test]
        public void PlayersTakeTurnsToPlay()
        {
            var board = new OthelloBoard();
            var player1 = new Player<Counter>("Emily", board, "black");
            var player2 = new Player<Counter>("Berry", board, "white");
            var game = new Game(player1, player2);

            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player1));
            game.Play("C4");
            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player2));
        }

//        [Test]
//        public void IfAPlayerPassesThenTheySkipTheirTurn()
//        {
//
//        }
//
//        [Test]
//        public void IfBothPlayersPassTheGameWillEnd()
//        {
//
//        }
//
//        [Test]
//        public void TheGameWillEndWhenTheBoardIsFull()
//        {
//
//        }
//
//        [Test]
//        public void ThePlayerWithTheMostCountersAtTheEndWillWin()
//        {
//
//        }
    }
}
