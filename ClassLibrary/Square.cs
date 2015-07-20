using System;

namespace ClassLibrary
{
    public class Square : ISquare
    {
        private IPieceType _contents;

        public IPieceType Contents()
        {
            return _contents;
        }

        public void PlacePiece(IPieceType piece)
        {
           if (IsEmpty())
                _contents = piece;
           else
               throw new Exception("This square is occupied");
        }

        private bool IsEmpty()
        {
            return _contents == null;
        }
    }
}
