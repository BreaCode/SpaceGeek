using UnityEngine;

namespace GeekSpace
{
    public sealed class GameInitialisation
    {
        private PlayerModel _playerModel;
        private Player _player;
        IMoveble _playerMove;
        #region ClassLifeCycles
        public GameInitialisation(Controllers _controllers/*, InputData inputData*/)
        {
            var startPosition = GameObject.Find("Start").transform;
            _playerModel = new PlayerModel("Prefabs/Ship/PlayerShip", WeaponType.ChainGunMk1, startPosition, 10,1);
            IMoveble _playerMove = new MoveTransform(_playerModel);
            _player = new Player(_playerMove, _playerModel);
            var moveController = new PlayerMoveController(_player);
            _controllers.Add(moveController);
        }

        #endregion
    }
}