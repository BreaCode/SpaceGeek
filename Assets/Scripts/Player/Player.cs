using UnityEngine;

namespace GeekSpace
{
    public class Player
    {
        IMoveble _playerMove;
        PlayerModel _playerModel;
        PlayerProvider PlayerProvider;

        internal Player (IMoveble playerMove, PlayerModel playerModel)
        {
            _playerMove = playerMove;
            _playerModel = playerModel;
            var player = GameObject.Instantiate(Resources.Load<PlayerProvider>("Prefabs/Ship/PlayerShip"));
            PlayerProvider = player.GetComponent<PlayerProvider>();
            player.transform.position = _playerModel.Transform.position;
        }

        public void Move(float timeDelta)
        {
            _playerMove.Move(PlayerProvider.transform);
        }
    }
}

