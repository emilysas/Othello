using System;
using System.Collections.Generic;


namespace ClassLibrary
{

    public class Board
    {
        private readonly Dictionary<string, Square<Counter>> _board;
        private readonly int _boardWidth;
        private readonly int _boardLength;

        public Board(int width, int length)
        {
            _boardWidth = width;
            _boardLength = length;
            _board = new Dictionary<string, Square<Counter>>();
            MakeBoard();
        }

        public void PlacePiece(string gridRef, string colour)
        {
            Square<Counter> square = _board[gridRef];
            if (square.IsEmpty())
            {
                square.PlacePiece(new Counter(colour));
            }
            else
            {
                throw new Exception("This square is occupied");
            }
        }

        private void MakeBoard()
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

        private string CalculateLetter(int num)
        {
            var timesThroughAlphabet = num / 26;
            var positionInAlphabet = num % 26;
            var currentCharacter = Convert.ToChar(positionInAlphabet + 65);
            return timesThroughAlphabet > 0
                ? CalculateLetter(timesThroughAlphabet - 1) + currentCharacter
                : currentCharacter.ToString();
        }
    }
}
