
using System;
using System.CodeDom;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using ClassLibrary;

namespace UnitTests
{
    [TestFixture]
    public class BoardTests
    {

        [Test]
        public void ABoardCannotRecieveAPieceIntoAnOccupiedSquare()
        {
            var board = new Board<Counter>(8, 8);
            board.PlacePiece("A1", new Counter());
            Assert.Throws<Exception>(() => board.PlacePiece("A1", new Counter()));
        }



    }
}
