namespace ClassLibrary
{
    public interface IOthelloBoard : IBoard
    {
        int BlackCounters { get; set; }
        int WhiteCounters { get; set; }
    }
}
