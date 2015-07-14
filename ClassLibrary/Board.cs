using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
	
   public class Board : IBoard
        {
       private Dictionary<string, Square<Counter>> _board;
       private readonly int _boardWidth;
       private readonly int _boardLength;

       public enum Directions
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

		public Board (int width, int length)
		{
		    _boardWidth = width;
		    _boardLength = length;
			_board = new Dictionary<string, Square<Counter>>();
            MakeBoard();
		}

       public void MakeBoard()
       {
           for (var i = 0; i < _boardLength; i++)
           {
               for (var j = 1; j <= _boardWidth; j++)
               {
                   string letters = CalculateLetter(i);
                   string number = j.ToString();
                   string boardKey = letters + number;
                   _board.Add(boardKey, new Square<Counter>(boardKey));
               }
           }
       }

       public Square<Counter> FindNeighbouringSquare(Directions direction, string gridRefOfCurrentSquare)
       {
           string neighbourGridRef = FindGridRef(direction, gridRefOfCurrentSquare);
           Square<Counter> neighbour = _board[neighbourGridRef];
           return neighbour;
       }

       private string CalculateLetter(int num)
       {
           var timesThroughAlphabet = num/26;
           var positionInAlphabet = num%26;
           var currentCharacter = Convert.ToChar(positionInAlphabet + 65);
           return timesThroughAlphabet > 0 
               ? CalculateLetter(timesThroughAlphabet - 1) + currentCharacter 
               : currentCharacter.ToString();
       }


       private string FindGridRef(Directions direction, string gridRef)
       {
           string xCoord = Regex.Matches(gridRef, @"[a-zA-Z]").ToString();
           int yCoord = Int32.Parse(Regex.Matches(gridRef, @"[0-9]").ToString());
           string newGridRef = SeachCompassPoints(direction, xCoord, yCoord);
           return newGridRef;
       }

       // what if it's on the edge of the board?
       public string SeachCompassPoints(Directions direction, string xCoord, int yCoord)
       {
           string newGridRef;

           switch (direction)
           {
               case Directions.North:
                   newGridRef = xCoord + yCoord--;
                   break;
               case Directions.NorthEast:
                   East(xCoord);
                   newGridRef = East(xCoord) + yCoord--;
                   break;
               case Directions.East:
                   newGridRef = East(xCoord) + yCoord;
                   break;
               case Directions.SouthEast:
                   newGridRef = East(xCoord) + yCoord++;
                   break;
               case Directions.South:
                   newGridRef = xCoord + yCoord++;
                   break;
               case Directions.SouthWest:
                   newGridRef = West(xCoord) + yCoord++;
                   break;
               case Directions.West:
                   newGridRef = West(xCoord) + yCoord;
                   break;
               case Directions.NorthWest:
                   newGridRef = West(xCoord) + yCoord++;
                   break;
               default :
                   newGridRef = xCoord + yCoord;
                   break;
           }
           return newGridRef;
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



    }
}
