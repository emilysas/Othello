using System;
using System.Collections.Generic;


namespace ClassLibrary
{

    public class Board<T> : IBoard<T> where T : IPieceType, new()
    {
        protected readonly Dictionary<string, Square<T>> _board;
        private readonly int _boardWidth;
        private readonly int _boardLength;

        public Board(int width, int length)
        {
            _boardWidth = width;
            _boardLength = length;
            _board = new Dictionary<string, Square<T>>();
            MakeBoard();
        }

        public virtual void PlacePiece(string gridRef, T pieceType)
        {
            Square<T> square = _board[gridRef];
            square.PlacePiece(pieceType);
        }

        public T ViewBoardSquare(string gridRef)
        {
            return _board[gridRef].Contents();
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
                    _board.Add(boardKey, new Square<T>());
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
