namespace ClassLibrary
{
    public class Game
    {
        private readonly Player<Counter> _player1;
        private readonly Player<Counter> _player2;
        private Player<Counter> _playerWhosTurnItIs;
        private bool _isFinished;
        private int _passCount;
        public int _moveCount;
        public int _player1Score;
        public int _player2Score;

        public Game(Player<Counter> player1, Player<Counter> player2)
        {
            _player1 = player1;
            _player2 = player2;            
            _playerWhosTurnItIs = _player1;
            _passCount = 0;
            _moveCount = 0;
            _player1Score = 2;
            _player2Score = 2;
        }

        public Player<Counter> PlayerToPlayNext()
        {
            return _playerWhosTurnItIs;
        }

        public bool IsFinished()
        {
            return _passCount == 2 || _moveCount == 64;
        }

        public void Play(string gridRef)
        {
            _playerWhosTurnItIs.Play(gridRef);
            _moveCount += 1;
            _passCount = 0;
            NextPlayersTurn();
        }

        public void Pass()
        {
            NextPlayersTurn();
            _passCount += 1;
        }

        public string Winner()
        {
            return _player1Score == _player2Score
                ? "Draw"
                : _player1Score > _player2Score
                    ? _player1.Name
                    : _player2.Name;
        } 

        private void NextPlayersTurn()
        {
            _playerWhosTurnItIs = (_playerWhosTurnItIs == _player1) ? _player2 : _player1;
        }
    }
}
