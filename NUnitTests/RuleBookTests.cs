using ClassLibrary;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class OthelloRuleBookTests
    {
        [TestCase("D3", true)]
        [TestCase("A1", false)]
        [TestCase("F3", false)]
        public void APieceCanOnlyBePlacedNextToAPieceOfTheOppositeColour(string gridRef, bool result)
        {
            var board = new OthelloBoard();

            var counter = new Counter {Colour = "black"};
            board.AcceptPlay(gridRef, counter);
            Assert.That(board.ViewBoardSquare(gridRef) == counter, Is.EqualTo(result));
        }

        [Test]
        public void APieceCanOnlyBePlacedIfALineEndsInAPieceOfTheSameColour()
        {
            var board = new OthelloBoard();
            var counter1 = new Counter {Colour = "black"};
            var counter2 = new Counter {Colour = "white"};
            var counter3 = new Counter {Colour = "black"};
            var counter4 = new Counter {Colour = "white"};
            board.AcceptPlay("E3", counter1);
            Assert.That(board.ViewBoardSquare("E3"), Is.Not.EqualTo(counter1));
            board.AcceptPlay("D3", counter1);
            Assert.That(board.ViewBoardSquare("D3"), Is.EqualTo(counter1));
            board.AcceptPlay("D2", counter2);
            Assert.That(board.ViewBoardSquare("D2"), Is.Not.EqualTo(counter2));
            board.AcceptPlay("C3", counter2);
            Assert.That(board.ViewBoardSquare("C3"), Is.EqualTo(counter2));
            board.AcceptPlay("C4", counter3);
            Assert.That(board.ViewBoardSquare("C4"), Is.EqualTo(counter3));
            board.AcceptPlay("E3", counter4);
            Assert.That(board.ViewBoardSquare("E3"), Is.EqualTo(counter4));
        }
    }
}
