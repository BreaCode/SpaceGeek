namespace GeekSpace
{
    internal class PlayerMoveController : IExecute 
    {
        Player _player;

        internal PlayerMoveController(Player player)
        {
            _player = player;
        }

        public void Execute(float delteTime)
        {
            _player.Move(delteTime);
        }
    }
}
