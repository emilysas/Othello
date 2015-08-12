namespace ClassLibrary
{
    public class Game
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private OthelloBoard _board;
        public Player PlayerToPlayNext { get; set; }
        private int _passCount;
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public Game(OthelloBoard board, Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _board = board; 
            PlayerToPlayNext = _player1;
            _passCount = 0;
        }

        public bool IsFinished()
        {
            return _passCount == 2 || Player1Score + Player2Score == 64;
        }

        public void Play(OthelloBoard board, Player player1, Player player2, string gridRef, IPieceType piece)
        {
            PlayerToPlayNext.Play(board, gridRef, piece);
            _passCount = 0;
            UpdateScores(player1, player2);
            NextPlayersTurn();
        }

        private void UpdateScores(Player player1, Player player2)
        {
            player1.Score = _board.BlackCounters;
            player2.Score = _board.WhiteCounters;
        }

        public void Pass()
        {
            NextPlayersTurn();
            _passCount += 1;
        }

        public string Winner()
        {
            return Player1Score == Player2Score
                ? "Draw"
                : Player1Score > Player2Score
                    ? _player1.Name
                    : _player2.Name;
        } 

        private void NextPlayersTurn()
        {
            PlayerToPlayNext = (PlayerToPlayNext == _player1) ? _player2 : _player1;
        }
    }
}
