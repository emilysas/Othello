
namespace ClassLibrary
{
    public class Player : IPlayer
    {
        private IBoard _board;

        public Player(string name, IBoard board)
        {
            Name = name;
            _board = board;
        }

        public string Name { get; private set; }

        public string PlayingColour { get; set; }

        public void PlaceCounter(string cell)
        {
            try
            {
             //   _board.ReceiveCounter(cell);
            }
            catch
            {
            }
        }
    }
}
