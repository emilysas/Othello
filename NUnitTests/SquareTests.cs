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
            var square = new Square<Counter>("A1");
            var counter = new Counter(originalContents);
            square.PlacePiece(counter);
            counter.Flip();
            Assert.That(square.Contents().ColourDisplayed, Is.EqualTo(newContents));
        }

    }
}
