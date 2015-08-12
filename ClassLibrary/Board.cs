using System;
using System.Collections.Generic;


namespace ClassLibrary
{

    public class Board : IBoard
    {
        protected readonly Dictionary<string, Square> _board;
        private readonly int _boardWidth;
        private readonly int _boardLength;

        public Board(int width, int length)
        {
            _boardWidth = width;
            _boardLength = length;
            _board = new Dictionary<string, Square>();
            MakeBoard();
        }

        public void SetUp(string gridRef, IPieceType pieceType)
        {
            Square square = _board[gridRef];
            square.PlacePiece(pieceType);
        }

        public virtual void AcceptPlay(string gridRef, IPieceType pieceToPlay)
        {
            
        }

        public IPieceType ViewBoardSquare(string gridRef)
        {
            Square square;
            IPieceType contents = null;
            if (_board.TryGetValue(gridRef, out square))
               contents = square.Contents();
            return contents;
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
                    _board.Add(boardKey, new Square());
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
