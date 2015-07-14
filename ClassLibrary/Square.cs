using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class Square<T>
    {
        private string _gridRef;
        private T _contents;

        public Square(string gridRef)
        {
            _gridRef = gridRef;
        }

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
            _contents = piece;
        }

        public bool IsEmpty()
        {
            return _contents == null;
        }
    }
}
