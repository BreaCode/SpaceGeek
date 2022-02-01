namespace GeekSpace
{
    internal class PlayerMoveController : IExecute 
    {
        Player _player;
        Player _playerTwo;

        internal PlayerMoveController(Player player, Player playerTwo)
        {
            _player = player;
            _playerTwo = playerTwo;
        }

        public void Execute(float deltaTime)
        {
            _player.Move(deltaTime);
            _playerTwo.Move(deltaTime);
        }
    }
}
