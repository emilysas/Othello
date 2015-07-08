using System;
using NUnit.Framework;
using ClassLibrary;

namespace UnitTests
{
    [TestFixture]
    public class CounterTests
    {
        [Test]
        public void CountersShouldHaveAColour()
        {
            var counter = new Counter("black");
            Assert.That("black", Is.EqualTo(counter.Colour));
        }

        [Test]
        public void ACounterCanChangeColour()
        {
            var counter = new Counter("black");
            counter.Colour = "white";
            Assert.That("white", Is.EqualTo(counter.Colour));

        }
    }
}
