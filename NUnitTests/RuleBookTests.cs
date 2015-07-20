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
            var rules = new OthelloRuleBook(board);
            var counter = new Counter {Colour = "black"};
            Assert.That(rules.CheckPlayIsLegitimate(gridRef, counter), Is.EqualTo(result));
        }

        [Test]
        public void APieceCanOnlyBePlacedIfALineEndsInAPieceOfTheSameColour()
        {
            var board = new OthelloBoard();
            var rules = new OthelloRuleBook(board);
            var counter1 = new Counter {Colour = "black"};
            var counter2 = new Counter {Colour = "white"};
            var counter3 = new Counter {Colour = "black"};
            var counter4 = new Counter {Colour = "white"};
            Assert.That(rules.CheckPlayIsLegitimate("E3", counter1), Is.EqualTo(false));
            Assert.That(rules.CheckPlayIsLegitimate("D3", counter1), Is.EqualTo(true));
            board.PlacePiece("D3", counter1);
            Assert.That(rules.CheckPlayIsLegitimate("D2", counter1), Is.EqualTo(false));
            Assert.That(rules.CheckPlayIsLegitimate("C3", counter1), Is.EqualTo(true));
            board.PlacePiece("C3", counter2);
            Assert.That(rules.CheckPlayIsLegitimate("C4", counter1), Is.EqualTo(true));
            board.PlacePiece("C4", counter3);
            Assert.That(rules.CheckPlayIsLegitimate("E3", counter1), Is.EqualTo(true));
            board.PlacePiece("E3", counter4);
        }
    }
}
