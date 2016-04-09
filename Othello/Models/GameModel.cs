using ClassLibrary;

namespace Othello.Models
{
    public class GameModel
    {
        public OthelloBoard Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Game Game { get; set; } 
    }
}