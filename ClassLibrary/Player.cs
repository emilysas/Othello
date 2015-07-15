
namespace ClassLibrary
{
    public class Player<T> : INamedThing
    {
        private IBoard<T> _board;

        public Player(string name, IBoard<T> board)
        {
            Name = name;
            _board = board;
        }

        public string Name { get; set; }

        public string PlayingColour { get; set; }

        public void Play(string cell)
        {

        }
    }
}
