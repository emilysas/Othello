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

        // Need to find a way to test this without having to make _moveCount public
        [Test]
        public void TheGameWillEndWhenTheBoardIsFull()
        {
            game._moveCount = 63;
            Assert.That(game.IsFinished(), Is.EqualTo(false));
            game.Play("C4");
            Assert.That(game.IsFinished(), Is.EqualTo(true));
        }

        [TestCase(20, 44, "Berry")]
        [TestCase(50, 14, "Emily")]
        [TestCase(32, 32, "Draw")]
        public void ThePlayerWithTheMostCountersAtTheEndWillWin(int player1Score, int player2Score, string result)
        {
            game._player1Score = player1Score;
            game._player2Score = player2Score;
            Assert.That(game.Winner(), Is.EqualTo(result));
        }
    }
}