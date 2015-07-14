using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class OthelloBoard : Board
    {
        public OthelloBoard() : base(8,8)
        {
            PlaceInitialPieces();
        }

        private void PlaceInitialPieces()
        {
            PlacePiece("D4", "white");
            PlacePiece("E5", "white");
            PlacePiece("D5", "black");
            PlacePiece("E4", "black");
        }


    }
}
