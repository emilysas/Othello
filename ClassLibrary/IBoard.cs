namespace ClassLibrary
{
    public interface IBoard
    {
        void SetUp(string gridRef, IPieceType pieceType);
        void MakePlay(string gridRef, IPieceType pieceType);
    }
}
