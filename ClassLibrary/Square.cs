using System;
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
            return _contents;
        }

        public void placePiece(T piece)
        {
            _contents = piece;
        }
    }
}
