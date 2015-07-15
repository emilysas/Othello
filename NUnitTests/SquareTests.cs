using NUnit.Framework;
using ClassLibrary;

namespace UnitTests
{
    [TestFixture]
    public class SquareTests
    {

        [TestCase("black", "white")]
        [TestCase("white", "black")]
        [TestCase("empty", "empty")]
        public void ASquareKnowsItsContents(string newContents, string originalContents)
        {
            var square = new Square<Counter>();
            var counter = new Counter();
            counter.Colour = originalContents;
            square.PlacePiece(counter);
            counter.Flip();
            Assert.That(square.Contents().Colour, Is.EqualTo(newContents));
        }

    }
}
