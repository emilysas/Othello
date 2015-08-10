namespace ClassLibrary
{
    public class Game
    {
        private readonly Player<Counter> _player1;
        private readonly Player<Counter> _player2;
        private OthelloBoard _board;
        private Player<Counter> _playerWhosTurnItIs;
        private int _passCount;
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public Game(OthelloBoard board, Player<Counter> player1, Player<Counter> player2)
        {
            _player1 = player1;
            _player2 = player2;
            _board = board; 
            _playerWhosTurnItIs = _player1;
            _passCount = 0;
            Player1Score = 2;
            Player2Score = 2;
        }

        public Player<Counter> PlayerToPlayNext()
        {
            return _playerWhosTurnItIs;
        }

        public bool IsFinished()
        {
            return _passCount == 2 || Player1Score + Player2Score == 64;
        }

        public void Play(string gridRef)
        {
            _playerWhosTurnItIs.Play(gridRef);
            _passCount = 0;
            Player1Score = _board.BlackCounters;
            Player2Score = _board.WhiteCounters;
            NextPlayersTurn();
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
            _playerWhosTurnItIs = (_playerWhosTurnItIs == _player1) ? _player2 : _player1;
        }
    }
}
