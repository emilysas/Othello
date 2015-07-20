namespace ClassLibrary
{
    public interface ISquare
    {
        IPieceType Contents();
        void PlacePiece(IPieceType piece);
    }
}