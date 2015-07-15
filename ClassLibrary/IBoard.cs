namespace ClassLibrary
{
    public interface IBoard<T>
    {
        void PlacePiece(string gridRef, T pieceType);
    }
}
