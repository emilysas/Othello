﻿using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class OthelloRuleBook
    {
        private OthelloBoard _board;
        private GridRefFinder _gridRefFinder; 

        public OthelloRuleBook(OthelloBoard board)
        {
            _board = board;
            _gridRefFinder = new GridRefFinder();
        } 

        public Dictionary<Directions, List<IPieceType>> CheckAlongCompassPoints(string originalGridRef, List<Directions> locations, IPieceType pieceToPlay )
        {
            var countersAlongLine = new Dictionary<Directions, List<IPieceType>>();
            
            foreach (Directions direction in locations)
            {
                var listOfStuffToTurnOver = new List<IPieceType>();
                var gridRef = originalGridRef;
                do
                {
                    var neighbouringCounter = _gridRefFinder.NeighbouringSquare(direction, gridRef, _board);
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


        public List<Directions> CheckAtLeastOneNeighbourOfOppositeColour(string gridRef, IPieceType pieceToPlay)
        {
            var locationOfOpposingCounters = new List<Directions>();
            var compasspoints = Enum.GetValues(typeof(Directions));

            foreach (Directions direction in compasspoints)
            {

                    var neighbouringCounter = _gridRefFinder.NeighbouringSquare(direction, gridRef, _board);
                    if (neighbouringCounter != null && neighbouringCounter.Colour != pieceToPlay.Colour)
                    {
                        locationOfOpposingCounters.Add(direction);
                    }

                
            }
            return locationOfOpposingCounters;
        }
    }
}
