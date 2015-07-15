using ClassLibrary;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class PlayerTest
    {
        private Mock<IBoard<Counter>> mockBoard;
        private Player<Counter> player;

        [SetUp]
        public void Init()
        {
            mockBoard = new Mock<IBoard<Counter>>();
            player = new Player<Counter>("Emily", mockBoard.Object) {PlayingColour = "black"};
        }

        [Test]
        public void APlayerCanChooseWhichColourCountersToPlay()
        {
            Assert.That("black", Is.EqualTo(player.PlayingColour));
        }

//        [Test]
//        public void APlayerCanPlaceACounterOnTheBoard()
//        {
//            player.PlaceCounter("A3");
//            mockBoard.VerifyGet(board => board.ReceiveCounter("A3", "black"), Times.Once);
//        }

    }
}
