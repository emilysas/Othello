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
            var counter = new Counter {Colour = originalColour};
            Assert.That(originalColour, Is.EqualTo(counter.Colour));
            counter.Flip();
            Assert.That(newColour, Is.EqualTo(counter.Colour));
        }
    }
}
