using UnityEngine;

namespace GeekSpace
{
    internal class PlayerTwo
    {
        private readonly IMoveble _playerMoveTwo;
        private readonly PlayerModel _playerModelTwo;
        internal PlayerProvider PlayerProvider { get; }

        internal PlayerTwo(IMoveble playerMoveTwo, PlayerModel playerModelTwo)
        {
            _playerMoveTwo = playerMoveTwo;
            _playerModelTwo = playerModelTwo;
            var player = GameObject.Instantiate(Resources.Load<PlayerProvider>("Prefabs/Ship/PlayerShip"));
            PlayerProvider = player.GetComponent<PlayerProvider>();
            PlayerProvider.PlayerModel = _playerModelTwo;
            player.transform.position = _playerModelTwo.Position;
        }

        internal void Move(float timeDelta)
        {
            _playerMoveTwo.Move(PlayerProvider.transform);
        }
    }
}