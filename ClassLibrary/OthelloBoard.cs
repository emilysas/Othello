namespace ClassLibrary
{
    public class OthelloBoard : Board<Counter>
    {
        public OthelloBoard() : base(8,8)
        {
            PlaceInitialPieces();
        }

        private void PlaceInitialPieces()
        {
            var whitePiece = new Counter() {Colour = "white"};
            var whitePiece2 = new Counter() { Colour = "white"};
            var blackPiece = new Counter() { Colour = "black"};
            var blackPiece2 = new Counter() { Colour = "black"};

            PlacePiece("D4", whitePiece);
            PlacePiece("E5", whitePiece2);
            PlacePiece("D5", blackPiece);
            PlacePiece("E4", blackPiece2);
        }

        public override void PlacePiece(string gridRef, Counter pieceType)
        {
            Square<Counter> square = _board[gridRef];
            square.PlacePiece(pieceType);
        }

        private void FlipCounter(string gridRef)
        {
            ViewBoardSquare(gridRef).Flip();
        }


    }
}
