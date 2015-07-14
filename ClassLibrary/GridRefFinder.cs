﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ClassLibrary;

namespace ClassLibrary
{
    class GridRefFinder
    {
        private Dictionary<string, Square<Counter>> _board;

        public GridRefFinder(Dictionary<string, Square<Counter>> board)
        {
            _board = board;
        }

       public Square<Counter> NeighbouringSquares(Directions direction, string gridRefOfCurrentSquare)
       {
           string neighbourGridRef = FindGridRef(direction, gridRefOfCurrentSquare);

           if (_board.ContainsKey(neighbourGridRef))
           {
               return FindSquare(neighbourGridRef);
           }
           throw new Exception("This square is at the edge of the board");
       }

       public Square<Counter> FindSquare(string gridRef)
       {
               Square<Counter> square = _board[gridRef];
               return square;
       }

       private string FindGridRef(Directions direction, string gridRef)
       {
           string xCoord = Regex.Matches(gridRef, @"[a-zA-Z]").ToString();
           int yCoord = Int32.Parse(Regex.Matches(gridRef, @"[0-9]").ToString());
           string newGridRef = SearchCompassPoints(direction, xCoord, yCoord);
           return newGridRef;
       }

       public string CalculateLetter(int num)
       {
           var timesThroughAlphabet = num/26;
           var positionInAlphabet = num%26;
           var currentCharacter = Convert.ToChar(positionInAlphabet + 65);
           return timesThroughAlphabet > 0 
               ? CalculateLetter(timesThroughAlphabet - 1) + currentCharacter 
               : currentCharacter.ToString();
       }

       private int CalculateNumber(string letters)
       {
           var total = 0;
           var reversedLetters = letters.Reverse().ToList();
           for (var i = 0; i < letters.Length; i++)
           {
               int currentLetter = Convert.ToInt32(reversedLetters[i]) - 64;
               total += currentLetter*((int)Math.Pow(26, i));
           }
           return total;
       }

       private string SearchCompassPoints(Directions direction, string xCoord, int yCoord)
       {
           string newGridRef;

           switch (direction)
           {
               case Directions.North:
                   newGridRef = xCoord + (yCoord -1);
                   break;
               case Directions.NorthEast:
                   East(xCoord);
                   newGridRef = East(xCoord) + (yCoord - 1);
                   break;
               case Directions.East:
                   newGridRef = East(xCoord) + yCoord;
                   break;
               case Directions.SouthEast:
                   newGridRef = East(xCoord) + (yCoord + 1);
                   break;
               case Directions.South:
                   newGridRef = xCoord + (yCoord + 1);
                   break;
               case Directions.SouthWest:
                   newGridRef = West(xCoord) + (yCoord + 1);
                   break;
               case Directions.West:
                   newGridRef = West(xCoord) + yCoord;
                   break;
               case Directions.NorthWest:
                   newGridRef = West(xCoord) + (yCoord + 1);
                   break;
               default :
                   newGridRef = xCoord + yCoord;
                   break;
           }
           return newGridRef;
       }

       private string East(string xCoord)
       {
           int ord = CalculateNumber(xCoord);
           return Convert.ToChar(ord + 1).ToString();
       }

       private string West(string xCoord)
       {
           int ord = CalculateNumber(xCoord);
           return Convert.ToChar(ord - 1).ToString();
       }

    }
    }
}