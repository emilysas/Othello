using ClassLibrary;
using NUnit.Framework;

namespace NUnitTests
{

    [TestFixture]
    public class GameTests
    {
       
        private Player<Counter> player1;
        private Player<Counter> player2;
        private OthelloBoard board;
        private Game game;

        [SetUp]
        public void Init()
        {
            board = new OthelloBoard();
            player1 = new Player<Counter>("Emily", board, "black");
            player2 = new Player<Counter>("Berry", board, "white");
            game = new Game(player1, player2);
        }

        [Test]
        public void PlayersTakeTurnsToPlay()
        {
            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player1));
            game.Play("C4");
            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player2));
        }

        [Test]
        public void IfAPlayerPassesThenTheySkipTheirTurn()
        {
            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player1));
            game.Pass();
            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player2));
        }

        [Test]
        public void IfBothPlayersPassTheGameWillEnd()
        {
            Assert.That(game.IsFinished(), Is.EqualTo(false));
            game.Pass();
            game.Pass();
            Assert.That(game.IsFinished(), Is.EqualTo(true));
        }
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
