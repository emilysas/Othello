using System.Collections.Generic;
using System.Security;
using System.Security.Authentication;

namespace ClassLibrary
{
    public class OthelloBoard : Board
    {
        private OthelloRuleBook _rules;
        public int BlackCounters { get; set; }
        public int WhiteCounters { get; set; }

        public OthelloBoard() : base(8, 8)
        {
            PlaceInitialPieces();
            _rules = new OthelloRuleBook(this);
            BlackCounters = 2;
            WhiteCounters = 2;
        }

        private void PlaceInitialPieces()
        {
            var whitePiece = new Counter() {Colour = "white"};
            var whitePiece2 = new Counter() {Colour = "white"};
            var blackPiece = new Counter() {Colour = "black"};
            var blackPiece2 = new Counter() {Colour = "black"};

            SetUp("D4", whitePiece);
            SetUp("E5", whitePiece2);
            SetUp("D5", blackPiece);
            SetUp("E4", blackPiece2);
        }

        private void PlacePiece(string gridRef, Counter pieceType)
        {
            Square square = _board[gridRef];
            square.PlacePiece(pieceType);
        }

        public override void MakePlay(string gridRef, IPieceType pieceToPlay)
        {
            List<Directions> locationOfOpposingCounters = _rules.CheckAtLeastOneNeighbourOfOppositeColour(gridRef,
                pieceToPlay);
            if (locationOfOpposingCounters.Count > 0)
            {
                Dictionary<Directions, List<IPieceType>> countersAlongLine = _rules.CheckAlongCompassPoints(gridRef,
                    locationOfOpposingCounters, pieceToPlay);
                if (countersAlongLine.Count > 0)
                {
                    PlacePiece(gridRef, (Counter)pieceToPlay);
                    IncrememtOwnScore(pieceToPlay.Colour);
                    FlipCounters(countersAlongLine);
                }
            }
        }

        private void FlipCounters(Dictionary<Directions, List<IPieceType>> countersAlongLine)
        {
            foreach (List<IPieceType> countersToTurn in countersAlongLine.Values)
            {
                foreach (IPieceType counter in countersToTurn)
                {
                    ((Counter) counter).Flip();
                    IncrememtOwnScore(counter.Colour);
                    DecreaseOpponentsScore(counter.Colour);
                }
            }
        }

        private void IncrememtOwnScore(string counterColour)
        {
            if (counterColour == "black")
            {
                BlackCounters += 1;
            }
            else
            {
                WhiteCounters += 1;
            }
        }

        private void DecreaseOpponentsScore(string counterColour)
        {
            if (counterColour == "black")
            {
                WhiteCounters -= 1;
            }
            else
            {
                BlackCounters -= 1;
            }
        }
    }
}
