using UnityEngine;

namespace GeekSpace
{
    internal class player2
    {
        IMoveble _playerMove;
        PlayerModel _playerModel;
        PlayerProvider PlayerProvider;
        internal player2(IMoveble playerMove, PlayerModel playerModel)
        {
            _playerMove = playerMove;
            _playerModel = playerModel;
            var player = GameObject.Instantiate(Resources.Load<PlayerProvider>("Prefabs/Ship/PlayerShip"));
            PlayerProvider = player.GetComponent<PlayerProvider>();
        }

        public void Move( float timeDelta)
        {
            _playerMove.Move(PlayerProvider.transform);
        }

    }
}