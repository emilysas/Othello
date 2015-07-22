
using System.Security;

namespace ClassLibrary
{
    public class Player<T> : INamedThing where T: IPieceType, new()
    {
        private IBoard _board;

        public Player(string name, IBoard board, string colour)
        {
            Name = name;
            _board = board;
            PlayingColour = colour;
        }

        public string Name { get; set; }

        private string PlayingColour { get; set; }

        public void Play(string gridRef)
        {
            var piece = new T {Colour = PlayingColour};
            _board.MakePlay(gridRef, piece);
        }
    }
}
