﻿using ClassLibrary;
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
            game = new Game(board, player1, player2);
        }

//        [Test]
//        public void PlayersTakeTurnsToPlay()
//        {
//            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player1));
//            game.Play("C4");
//            Assert.That(game.PlayerToPlayNext(), Is.EqualTo(player2));
//        }

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

        [Test]
        public void TheGameWillEndWhenTheBoardIsFull()
        {
            game.Player1Score = 31;
            game.Player2Score = 32;
            Assert.That(game.IsFinished(), Is.EqualTo(false));
            game.Player1Score = 32;
            game.Player2Score = 32;
            Assert.That(game.IsFinished(), Is.EqualTo(true));
        }

        [Test]
        public void TheGameWillKeepScore()
        {
            game.Play("C4");
            Assert.That(game.Player1Score, Is.EqualTo(4));
            Assert.That(game.Player2Score, Is.EqualTo(1));
            game.Play("E3");
            Assert.That(game.Player1Score, Is.EqualTo(3));
            Assert.That(game.Player2Score, Is.EqualTo(3));
        }

        [TestCase(20, 44, "Berry")]
        [TestCase(50, 14, "Emily")]
        [TestCase(32, 32, "Draw")]
        public void ThePlayerWithTheMostCountersAtTheEndWillWin(int player1Score, int player2Score, string result)
        {
            game.Player1Score = player1Score;
            game.Player2Score = player2Score;
            Assert.That(game.Winner(), Is.EqualTo(result));
        }
    }
}
