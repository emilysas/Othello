namespace ClassLibrary
{
    public interface IBoard
    {
        void SetUp(string gridRef, IPieceType pieceType);
        void AcceptPlay(string gridRef, IPieceType pieceToPlay);
        IPieceType ViewBoardSquare(string gridRef);
    }
}
