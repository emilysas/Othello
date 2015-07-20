
using System.Security;

namespace ClassLibrary
{
    public class Player<T> : INamedThing where T: IPieceType, new()
    {
        private IBoard _board;

        public Player(string name, IBoard board)
        {
            Name = name;
            _board = board;
        }

        public string Name { get; set; }

        public string PlayingColour { get; set; }

        public void Play(string gridRef)
        {
            var piece = new T {Colour = PlayingColour};
            _board.MakePlay(gridRef, piece);
        }
    }
}
