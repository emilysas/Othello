using ClassLibrary;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class PlayerTest
    {
        private OthelloBoard board;
        private RuleBook<Counter> rules;
        private Player<Counter> player;

        [SetUp]
        public void Init()
        {
            rules = new RuleBook<Counter>();
            board = new OthelloBoard();
            player = new Player<Counter>("Emily", board, rules) {PlayingColour = "black"};
        }

        [Test]
        public void APlayerCanChooseWhichColourCountersToPlay()
        {
            Assert.That("black", Is.EqualTo(player.PlayingColour));
        }

//        [Test]
//        public void APlayerCanPlaceACounterOnTheBoard()
//        {
//            player.Play("A3")
//            Assert.That();
//        }

    }
}
