using UnityEngine;

namespace GeekSpace
{
    public sealed class GameInitialisation
    {
        #region ClassLifeCycles
        public GameInitialisation(Controllers _controllers/*, InputData inputData*/)
        {
            var startPosition = GameObject.Find("Start").transform;
            var asteroidStartPosition = GameObject.Find("Spawn").transform;

            var input = new InputInitialization();
            var inputController = new InputController(input.GetInput());

            var _playerModel = new PlayerModel("Prefabs/Ship/PlayerShip", WeaponType.ChainGunMk1, startPosition, 10, 1);
            IMoveble _playerMove = new MoveTransform(_playerModel);
            var _player = new Player(_playerMove, _playerModel);
            var moveController = new PlayerMoveController(_player);

            var asteriodModel = new EnemyModel("Prefabs/Enemy/EnemyAsteroid",EnemyType.Asteroid, asteroidStartPosition,10,10);
            var asteroidPrefab = (Resources.Load<EnemyProvider>(asteriodModel.PathToPrefab));
            var enemyPoolAsteroid = new ObjectPool(asteroidPrefab.gameObject, asteroidStartPosition);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 5);
            var enemyController = new EnemyController(timerSystemAsteroidSpawn, enemyPoolAsteroid);


            _controllers.Add(input);
            _controllers.Add(enemyController);
            _controllers.Add(moveController);
        }

        #endregion
    }
}