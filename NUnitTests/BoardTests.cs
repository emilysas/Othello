
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
        public void ABoardCanFindNeighbouringSquares()
        {
            var board = new Board(8, 8);
            board.PlacePiece("A1", "black");
            Assert.Throws<Exception>(() => board.PlacePiece("A1", "white"));
        }



    }
}
