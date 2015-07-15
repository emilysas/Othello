namespace ClassLibrary
{
    public interface IBoard<T>
    {
        void SetUp(string gridRef, T pieceType);
    }
}
