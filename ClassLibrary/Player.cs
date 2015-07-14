
namespace ClassLibrary
{
    public class Player : INamedThing
    {
        private IBoard _board;

        public Player(string name, IBoard board)
        {
            Name = name;
            _board = board;
        }

        public string Name { get; set; }

        public string PlayingColour { get; set; }

        public void PlaceCounter(string cell)
        {

        }
    }
}
