using ClassLibrary;
using Newtonsoft.Json;

namespace Othello.Models
{
    public class GameModel
    {
        [JsonProperty("board")]
        public OthelloBoard board { get; set; }
        [JsonProperty("player1")]
        public Player player1 { get; set; }
        [JsonProperty("player2")]
        public Player player2 { get; set; }
        [JsonProperty("game")]
        public Game game { get; set; } 

    }
}