using System;
using System.Collections.Generic;
using ClassLibrary;

namespace ClassLibrary
{
    public class OthelloRuleBook : IRuleBook<Counter>
    {
        private OthelloBoard _board;
        private GridRefFinder<Counter> _gridRefFinder; 

        public OthelloRuleBook(OthelloBoard board)
        {
            _board = board;
            _gridRefFinder = new GridRefFinder<Counter>(_board);
        } 

        public bool CheckPlayIsLegitimate(string gridRef, Counter pieceToPlay)
        {
            bool PlayIsLegitimate = false;

            try
            {
                List<Directions> locationOfOpposingCounters = CheckAtLeastOneNeighbourOfOppositeColour(gridRef,
                    pieceToPlay);
                if (locationOfOpposingCounters.Count < 0)
                    PlayIsLegitimate = CheckForCounterOfOppositeColour(gridRef, locationOfOpposingCounters, pieceToPlay);

            }
            catch
            {
                PlayIsLegitimate = false;
            }
            return PlayIsLegitimate;
        }

        private bool CheckForCounterOfOppositeColour(string gridRef, List<Directions> locations, Counter pieceToPlay )
        {
            int total = 0;
            foreach (var direction in locations)
            {
                string neighbouringSquareGridRef = _gridRefFinder.FindGridRef(direction, gridRef);
                Counter neighbouringCounter = _gridRefFinder.NeighbouringSquare(direction, neighbouringSquareGridRef);
                total = (neighbouringCounter.Colour != pieceToPlay.Colour) ? total += 1 : total;
            }
            return total < 0;
        }


        private List<Directions> CheckAtLeastOneNeighbourOfOppositeColour(string gridRef, Counter pieceToPlay)
        {
            List<Directions> locationOfOpposingCounters = new List<Directions>();
            var compasspoints = Enum.GetValues(typeof(Directions));

            foreach (Directions direction in compasspoints)
            {
                try
                {
                    Counter neighbouringCounter = _gridRefFinder.NeighbouringSquare(direction, gridRef);
                    if (neighbouringCounter.Colour != pieceToPlay.Colour)
                    {
                        locationOfOpposingCounters.Add(direction);
                    }
                }
                catch(Exception)
                {
                    break;
                }
                
            }
            return locationOfOpposingCounters;
        }
    }
}
