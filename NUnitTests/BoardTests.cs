
using System;
using ClassLibrary;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class BoardTests
    {

        [Test]
        public void ABoardCannotRecieveAPieceIntoAnOccupiedSquare()
        {
            var board = new Board<Counter>(8, 8);
            board.SetUp("A1", new Counter());
            Assert.Throws<Exception>(() => board.SetUp("A1", new Counter()));
        }



    }
}
