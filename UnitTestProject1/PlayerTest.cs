using System;
using NUnit.Framework;
using ClassLibrary;

namespace UnitTests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void APlayerCanChooseWhichColourCountersToPlay()
        {
            var player = new Player("Emily");
            player.PlayingColour = "black";
            Assert.That("black", Is.EqualTo(player.PlayingColour));
        }
    }
}
