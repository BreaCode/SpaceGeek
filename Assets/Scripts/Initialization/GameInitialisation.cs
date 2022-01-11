using UnityEngine;

namespace GeekSpace
{
    public sealed class GameInitialisation
    {
        #region ClassLifeCycles
        public GameInitialisation(Controllers _controllers)
        {
            Camera camera = Camera.main;
            var startPosition = Extention.GetCentrAccordingCamera(camera);


            var input = new InputInitialization();
            var inputController = new InputController(input.GetInput());

            var _playerModel = new PlayerModel("Prefabs/Ship/PlayerShip", WeaponType.ChainGunMk1, startPosition, 10, 1);
            IMoveble _playerMove = new MoveTransform(_playerModel,input.GetInput());
            var _player = new Player(_playerMove, _playerModel);
            var moveController = new PlayerMoveController(_player);
            var asteroidPrefab = (Resources.Load<EnemyProvider>(PathsManager.ASTEROID_PREFAB));
            var poolRoot = new Vector3(0, 0, 0);
            var enemyPoolAsteroid = new ObjectPool(asteroidPrefab.gameObject, poolRoot);
            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPoolAsteroid, MaximumsManager.ASTEROIDS_MAXIMUM);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 30);
            var enemyController = new EnemyController(timerSystemAsteroidSpawn, enemyPoolAsteroid);

            var beyondScreenActer = new BeyondScreenActer();

            _controllers.Add(input);
            _controllers.Add(inputController);
            _controllers.Add(enemyController);
            _controllers.Add(moveController);
        }
        #endregion
    }
}