namespace ClassLibrary
{
    public class Game
    {
        private readonly Player<Counter> _player1;
        private readonly Player<Counter> _player2;
        private Player<Counter> _playerWhosTurnItIs; 

        public Game(Player<Counter> player1, Player<Counter> player2)
        {
            _player1 = player1;
            _player2 = player2;            
            _playerWhosTurnItIs = _player1;
        }

        public Player<Counter> PlayerToPlayNext()
        {
            return _playerWhosTurnItIs;
        }

        public void Play(string gridRef)
        {
            _playerWhosTurnItIs.Play(gridRef);
            NextPlayersTurn();
        }

        private void NextPlayersTurn()
        {
            _playerWhosTurnItIs = (_playerWhosTurnItIs == _player1) ? _player2 : _player1;
        }
    }
}
