namespace ClassLibrary
{
    public interface ISquare<T>
    {
        T Contents();
        void PlacePiece(T piece);
    }
}