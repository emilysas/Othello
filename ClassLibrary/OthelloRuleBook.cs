using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            {
                Dictionary<Directions, List<IPieceType>> countersAlongLine = CheckAlongCompassPoints(gridRef,
                    locationOfOpposingCounters, pieceToPlay);
                playIsLegitimate = countersAlongLine.Count > 0;
                FlipCounters(countersAlongLine);
            }
            return playIsLegitimate;
        }

        private void FlipCounters(Dictionary<Directions, List<IPieceType>> countersAlongLine)
        {
            foreach (List<IPieceType> countersToTurn in countersAlongLine.Values)
            {
                foreach(IPieceType counter in countersToTurn)
                {
                    ((Counter)counter).Flip();
                }
            }
        }

        private Dictionary<Directions, List<IPieceType>> CheckAlongCompassPoints(string gridRef, List<Directions> locations, IPieceType pieceToPlay )
        {
            var countersAlongLine = new Dictionary<Directions, List<IPieceType>>();
            
            foreach (Directions direction in locations)
            {
                var listOfStuffToTurnOver = new List<IPieceType>();
                do
                {
                    var neighbouringCounter = _gridRefFinder.NeighbouringSquare(direction, gridRef);
                    if (neighbouringCounter == null)
                        break;
                    if (neighbouringCounter.Colour != pieceToPlay.Colour)
                        listOfStuffToTurnOver.Add(neighbouringCounter);
                    else
                    {
                        countersAlongLine.Add(direction, listOfStuffToTurnOver);
                        break;
                    }

                    gridRef = _gridRefFinder.FindGridRef(direction, gridRef);
                } while (true);
            }
            return countersAlongLine;
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
