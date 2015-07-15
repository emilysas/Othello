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
            try
            {
                List<Directions> locationOfOpposingCounters = CheckAtLeastOneNeighbourOfOppositeColour(gridRef,
                    pieceToPlay);
                if (locationOfOpposingCounters.Count < 0)
                    return CheckForCounterOfSameColour(gridRef, locationOfOpposingCounters);

            }
            catch
            {
                return false;
            }
        }

        private bool CheckForCounterOfSameColour(string gridRef, List<Directions> locations )
        {

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
