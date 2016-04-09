namespace ClassLibrary
{
    public interface IPlayer
    {
        string Name { get; set; }
        
        string PlayingColour { get; set; }

        int Score { get; set; }

        void Play(IBoard board, string gridRef, IPieceType piece);
    }
}
