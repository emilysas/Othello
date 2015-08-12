using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class GridRefFinder
    {

       public IPieceType NeighbouringSquare(Directions direction, string gridRefOfCurrentSquare, IBoard board)
       {
           string neighbourGridRef = FindGridRef(direction, gridRefOfCurrentSquare);

           if (board.ViewBoardSquare(neighbourGridRef) != null)
           {
               return board.ViewBoardSquare(neighbourGridRef);
           }
           return null;
       }


       public string FindGridRef(Directions direction, string gridRef)
       {
           var letters = new Regex(@"[a-zA-Z]");
           var numbers =  new Regex(@"[0-9]");
           string xCoord = letters.Match(gridRef).ToString();
           int yCoord;
           string digits = numbers.Match(gridRef).ToString();
           Int32.TryParse(digits, out yCoord);
           string newGridRef = SearchCompassPoints(direction, xCoord, yCoord);
           return newGridRef;
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
           int ord = CalculateNumber(xCoord)+64;
           return Convert.ToChar(ord + 1).ToString();
       }

       private string West(string xCoord)
       {
           int ord = CalculateNumber(xCoord)+64;
           return Convert.ToChar(ord - 1).ToString();
       }

    }
 
}
