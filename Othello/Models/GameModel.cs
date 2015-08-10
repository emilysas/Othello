using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;

namespace Othello.Models
{
    public class GameModel
    {
        public OthelloBoard board { get; set; }
        public Player<Counter> player1 { get; set; }
        public Player<Counter> player2 { get; set; }
        public Game game { get; set; } 

    }
}