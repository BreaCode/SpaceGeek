using UnityEngine;

namespace GeekSpace
{
    internal class Player
    {
        private readonly IMoveble _playerMove;
        private readonly IMoveble _playerMoveTwo;
        private readonly PlayerModel _playerModel;
        internal PlayerProvider PlayerProvider { get; }

        internal Player (IMoveble playerMove, PlayerModel playerModel)
        {
            _playerMove = playerMove;
            _playerModel = playerModel;
            var player = GameObject.Instantiate(Resources.Load<PlayerProvider>("Prefabs/Ship/PlayerShip"));
            PlayerProvider = player.GetComponent<PlayerProvider>();
            PlayerProvider.PlayerModel = _playerModel;
            player.transform.position = _playerModel.Position;
        }

        internal void Move(float timeDelta)
        {
            _playerMove.Move(PlayerProvider.transform);
        }
    }
}

