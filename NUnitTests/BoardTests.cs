using System;
using System.CodeDom;
using System.Linq;
using NUnit.Framework;
using ClassLibrary;

namespace UnitTests
{
    [TestFixture]
    public class BoardTests
    {
//       [TestCase("A1", "empty")]
//       [TestCase("A2", "black")]
//       [TestCase("A3", "white")]
//        public void TheBoardShouldDisplayTheContentsOfTheCell(string cell, string contents)
//        {
//           var board = new Board();
//           board.ReceiveCounter("A2", "black");
//           board.ReceiveCounter("A3", "white"); 
//           Assert.That(contents, board.DisplayContentsOfCell(cell));
//        }

        [TestCase(4, 4, "D4")]
        [TestCase(8, 10, "J8")]
        [TestCase(27, 28, "AB27")]
        [TestCase(99, 27, "AA99")]
        [TestCase(99, 247, "IM99")]
        [TestCase(8, 703, "AAA8")]
        [TestCase(8, 1119, "AQA8")]
        public void ABoardContainsAlphaNumericKeys(int width, int length, string result)
        {
            var board = new Board(width, length);
            string last = board._board.Keys.Last();
            Assert.That(last, Is.EqualTo(result));
        }





    }
}
