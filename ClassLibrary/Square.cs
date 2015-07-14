using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class Square : INamedThing
    {
        private string _gridRef;
        private Board _board;

        private enum Directions
        {
            North,
            NorthEast,
            East,
            SouthEast,
            South,
            SouthWest,
            West,
            NorthWest
        };

        private Dictionary<Directions, Square> _neighbouringSquares;

        public Square(Board board)
        {
            _board = board;
            _neighbouringSquares = new Dictionary<Directions, Square>();
            AddNeighhbours();
        }

        private void AddNeighhbours()
        {
            var directions = Enum.GetValues(typeof (Directions)).Cast<Directions>();

            foreach( var direction in directions)
            {
                Square neighbouringSquare = FindNeighbour(direction);
                _neighbouringSquares.Add(direction, neighbouringSquare);
            }
        }

        private Square FindNeighbour(Directions direction)
        {
            string _neighbourGridRef = FindGridRef(direction);
            Square neighbour = _board.Contents(_neighbourGridRef);
            return neighbour;
        }

        private string FindGridRef(Directions direction)
        {
            string xCoord = Regex.Matches(_gridRef, @"[a-zA-Z]").ToString();
            int yCoord = Int32.Parse(Regex.Matches(_gridRef, @"[0-9]").ToString());
            string newLetter;

            switch (direction)
            {
                case Directions.North :
                    yCoord--;
                    return xCoord + yCoord;
                case Directions.NorthEast :
                    yCoord--;
                    newLetter = East(xCoord);
                    return newLetter + yCoord;
                case Directions.East :
                    newLetter = East(xCoord);
                    return newLetter + yCoord;
                case Directions.SouthEast :
                    yCoord++;
                    newLetter = East(xCoord);
                    return newLetter + yCoord;
                case Directions.South :
                    yCoord++;
                    return xCoord + yCoord;
                case Directions.SouthWest :
                    yCoord++;
                    newLetter = West(xCoord);
                    return newLetter + yCoord;
                case Directions.West :
                    newLetter = West(xCoord);
                    return newLetter + yCoord;
                case Directions.NorthWest :
                    yCoord++;
                    newLetter = West(xCoord);
                    return newLetter + yCoord;
            }
       
        }

        private string East(string xCoord)
        {
            char letter = Convert.ToChar(xCoord);
            int ord = Convert.ToInt32(letter);
            string newCoord = Convert.ToChar(ord++).ToString();
            return newCoord;
        }

        private string West(string xCoord)
        {
            char letter = Convert.ToChar(xCoord);
            int ord = Convert.ToInt32(letter);
            string newCoord = Convert.ToChar(ord--).ToString();
            return newCoord;
        }

        public string Name
        {
            get;
            set{ _gridRef = value; } 
        }
    }
}
