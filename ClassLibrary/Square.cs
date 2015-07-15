using System;

namespace ClassLibrary
{
    public class Square<T> : ISquare<T> where T : IPieceType
    {
        private T _contents;

        public T Contents()
        {
            if (IsEmpty())
            {
                throw new Exception("this square is empty");
            }
                return _contents;
        }

        public void PlacePiece(T piece)
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
