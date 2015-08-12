using ClassLibrary;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class PlayerTest
    {
        private Player player;

        [SetUp]
        public void Init()
        {
            player = new Player("Emily", "black");
        }

//        [Test]
//        public void APlayerCanChooseWhichColourCountersToPlay()
//        {
//            Assert.That("black", Is.EqualTo(player.PlayingColour));
//        }

//        [Test]
//        public void APlayerCanPlaceACounterOnTheBoard()
//        {
//            player.Play("A3")
//            Assert.That();
//        }

    }
}
