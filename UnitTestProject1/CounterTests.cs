using System;
using NUnit.Framework;
using ClassLibrary;

namespace UnitTests
{
    [TestFixture]
    public class CounterTests
    {
        [TestCase( "white", "black")]
        [TestCase( "black", "white")]
        public void ACounterCanFlipBetweenColours(string originalColour, string newColour)
        {
            var counter = new Counter(originalColour);
            Assert.That(originalColour, Is.EqualTo(counter.ColourDisplayed));
            counter.Flip();
            Assert.That(newColour, Is.EqualTo(counter.ColourDisplayed));
        }
    }
}
