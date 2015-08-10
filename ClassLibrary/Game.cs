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

        public Game(Player<Counter> player1, Player<Counter> player2)
        {
            _player1 = player1;
            _player2 = player2;            
            _playerWhosTurnItIs = _player1;
            _passCount = 0;
            _moveCount = 0;
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

        private void NextPlayersTurn()
        {
            _playerWhosTurnItIs = (_playerWhosTurnItIs == _player1) ? _player2 : _player1;
        }
    }
}
