using System;
using System.Collections.Generic;
using ClassLibrary;

namespace ClassLibrary
{
    public class OthelloRuleBook : IRuleBook
    {
        private OthelloBoard _board;
        private GridRefFinder _gridRefFinder; 

        public OthelloRuleBook(OthelloBoard board)
        {
            _board = board;
            _gridRefFinder = new GridRefFinder(_board);
        } 

        public bool CheckPlayIsLegitimate(string gridRef, IPieceType pieceToPlay)
        {
            bool playIsLegitimate = false;
            List<Directions> locationOfOpposingCounters = CheckAtLeastOneNeighbourOfOppositeColour(gridRef, pieceToPlay);
            if (locationOfOpposingCounters.Count > 0)
               playIsLegitimate = CheckForCounterOfOppositeColour(gridRef, locationOfOpposingCounters, pieceToPlay);
            return playIsLegitimate;
        }

        private bool CheckForCounterOfOppositeColour(string gridRef, List<Directions> locations, IPieceType pieceToPlay )
        {
            int total = 0;
            foreach (var direction in locations)
            {
//                string neighbouringSquareGridRef = _gridRefFinder.FindGridRef(direction, gridRef);
                var neighbouringCounter = _gridRefFinder.NeighbouringSquare(direction, gridRef);
                total = (neighbouringCounter.Colour != pieceToPlay.Colour) ? ++total : total;
            }
            return total > 0;
        }


        private List<Directions> CheckAtLeastOneNeighbourOfOppositeColour(string gridRef, IPieceType pieceToPlay)
        {
            var locationOfOpposingCounters = new List<Directions>();
            var compasspoints = Enum.GetValues(typeof(Directions));

            foreach (Directions direction in compasspoints)
            {

                    var neighbouringCounter = _gridRefFinder.NeighbouringSquare(direction, gridRef);
                    if (neighbouringCounter != null && neighbouringCounter.Colour != pieceToPlay.Colour)
                    {
                        locationOfOpposingCounters.Add(direction);
                    }

                
            }
            return locationOfOpposingCounters;
        }
    }
}
