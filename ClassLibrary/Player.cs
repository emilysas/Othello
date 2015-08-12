
using System.Security;
using System.Xml.Schema;

namespace ClassLibrary
{
    public class Player
    {
        private IBoard _board;

        public Player(string name, string colour)
        {
            Name = name;
            PlayingColour = colour;
            Score = 0;
        }

        public string Name { get; set; }

        public string PlayingColour { get; set; }

        public int Score { get; set; }

        public void Play(IBoard board, string gridRef, IPieceType piece)
        {
            board.AcceptPlay(gridRef, piece);
        }
    }
}
