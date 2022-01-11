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

            var _playerModel = new PlayerModel("Prefabs/Ship/PlayerShip", WeaponType.ChainGunMk1, startPosition, 10, 3);
            IMoveble _playerMove = new MoveTransform(_playerModel, (input.GetInput().inputHorizontal, input.GetInput().inputVertical));
            var _player = new Player(_playerMove, _playerModel);
            var moveController = new PlayerMoveController(_player);
            var asteroidPrefab = (Resources.Load<EnemyProvider>(PathsManager.ASTEROID_PREFAB));
            var poolRoot = new Vector3(0, 0, 0);
            var enemyPoolAsteroid = new ObjectPool(asteroidPrefab.gameObject, poolRoot);
            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPoolAsteroid, MaximumsManager.ASTEROIDS_MAXIMUM);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 30);
            var enemyController = new EnemyController(timerSystemAsteroidSpawn, enemyPoolAsteroid);


            var bulletdPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));        
            var bulletPool = new ObjectPool(bulletdPrefab.gameObject, poolRoot);
            var bulletModel = new BulletModel(bulletPool, _player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(bulletPool,bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var shootTimer = new TimerSystem(true, true, 1);
            
            var bulletController = new BulletController(shootTimer,bulletPool,_player.PlayerProvider.transform,input.GetInput().pcIinputFire);

            var beyondScreenActer = new BeyondScreenActer();

            _controllers.Add(inputController);
            _controllers.Add(enemyController);
            _controllers.Add(moveController);
            _controllers.Add(bulletController);

        }
        #endregion
    }
}