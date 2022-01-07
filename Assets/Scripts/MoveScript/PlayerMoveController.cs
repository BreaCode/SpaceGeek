namespace GeekSpace
{
    internal class PlayerMoveController : IExecute 
    {
        player2 _player;

        internal PlayerMoveController(player2 player)
        {
            _player = player;
        }

        public void Execute(float delteTime)
        {
            _player.Move(delteTime);
        }
    }
}
