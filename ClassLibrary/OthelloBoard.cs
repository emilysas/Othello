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

            SetUp("D4", whitePiece);
            SetUp("E5", whitePiece2);
            SetUp("D5", blackPiece);
            SetUp("E4", blackPiece2);
        }

        public void PlacePiece(string gridRef, Counter pieceType)
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
