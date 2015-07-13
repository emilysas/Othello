using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
	
   public class Board : IBoard
        {
       public Dictionary<string, string> _board;
       private int _size;
       private int _boardWidth;
       private int _boardLength;

		public Board (int width, int length)
		{
		    _boardWidth = width;
		    _boardLength = length;
		    _size = width*length;
			_board = new Dictionary<string, string>(_size);
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
                   _board.Add(boardKey, "empty");
               }
           }
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





//        public bool ReceiveCounter(string cell, string colour)
//        {
//            var cellContents = QueryContentsOfCell(cell);
//            if (cellContents != "empty") return false;
//            try
//            {
//                ApplyRules(cell, colour);
//                return true;
//            }
//            catch 
//            {
//                return false;
//            }
//            return false;
//        }

        //this shouldn't be the responsibility of the board but of the game!
//        private void ApplyRules(string cell, string colour)
//        {
            //if one of the neighbouring cells is of the opposite colour
            //AND one of the counters in the same direction is of the same colour
//            //then return true
//        }

//        public string DisplayContentsOfCell(string cell)
//        {
//            throw new NotImplementedException();
//        }
//
//        public string QueryContentsOfCell(string cell)
//        {
//            throw new NotImplementedException();
//        }
//
//        public string QueryNeighbouringCells(string cell)
//        {
//            throw new NotImplementedException();
//        }
//
//        public bool IsFull()
//        {
//            throw new NotImplementedException();
//        }
    }
}
