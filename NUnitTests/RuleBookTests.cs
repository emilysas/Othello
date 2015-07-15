﻿using ClassLibrary;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class OthelloRuleBookTests
    {
        [TestCase("D3", true)]
        [TestCase("D2", false)]
        [TestCase("C3", false)]
        public void APieceCanOnlyBePlacedNextToAPieceOfTheOppositeColour(string gridRef, bool result)
        {
            var board = new OthelloBoard();
            var rules = new OthelloRuleBook(board);
            var counter = new Counter {Colour = "black"};
            Assert.That(result, Is.EqualTo(rules.CheckPlayIsLegitimate(gridRef, counter)));
        }
    }
}
