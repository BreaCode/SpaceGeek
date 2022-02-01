using UnityEngine;

namespace GeekSpace
{
    internal class Player
    {
        private readonly IMoveble _playerMove;
        private readonly IMoveble _playerMoveTwo;
        private readonly PlayerModel _playerModel;
        private readonly PlayerModel _playerModelTwo;
        internal PlayerProvider PlayerProvider { get; }

        internal Player (IMoveble playerMove, IMoveble playerMoveTwo, PlayerModel playerModel, PlayerModel playerModelTwo)
        {
            _playerMove = playerMove;
            _playerMoveTwo = playerMoveTwo;
            _playerModel = playerModel;
            _playerModelTwo = playerModelTwo;
            var player = GameObject.Instantiate(Resources.Load<PlayerProvider>("Prefabs/Ship/PlayerShip"));
            var playerTwo = GameObject.Instantiate(Resources.Load<PlayerProvider>("Prefabs/Ship/PlayerShip"));
            PlayerProvider = player.GetComponent<PlayerProvider>();
            PlayerProvider = playerTwo.GetComponent<PlayerProvider>();
            PlayerProvider.PlayerModel = _playerModel;
            PlayerProvider.PlayerModel = _playerModelTwo;
            player.transform.position = _playerModel.Position;
            playerTwo.transform.position = _playerModelTwo.Position;
        }

        internal void Move(float timeDelta)
        {
            _playerMove.Move(PlayerProvider.transform);
        }
    }
}

