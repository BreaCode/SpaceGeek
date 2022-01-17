using UnityEngine;

namespace GeekSpace
{
    public sealed class GameInitialisation
    {
        #region ClassLifeCycles
        public GameInitialisation(Controllers _controllers)
        {
            Camera camera = Camera.main;
            System.Random random = new System.Random();

            var startPosition = Extention.GetCentrAccordingCamera(camera);
            var input = new InputInitialization();
            var inputController = new InputController(input.GetInput());

            var _playerModel = new PlayerModel(PathsManager.PLAYER_PREFAB , WeaponType.ChainGunMk1, startPosition, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble _playerMove = new MoveTransform(_playerModel, (input.GetInput().inputHorizontal, input.GetInput().inputVertical));
            var _player = new Player(_playerMove, _playerModel);
            var moveController = new PlayerMoveController(_player);
            var enemyPoolAsteroid = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Asteroid);
            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPoolAsteroid, MaximumsManager.ASTEROIDS_MAXIMUM, EnemyType.Asteroid);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 30);
            
            var enemyController = new EnemyController(timerSystemAsteroidSpawn, enemyPoolAsteroid, random);

            var bulletPoolRoot = new Vector3(0, 0, 0);
            var bulletPrefab = (Resources.Load<BulletProvider>(PathsManager.BULLET_PREFAB));        
            var bulletPool = new ObjectPool(bulletPrefab.gameObject, bulletPoolRoot);
            var bulletModel = new BulletModel(bulletPool, _player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(bulletPool,bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var shootTimer = new TimerSystem(true, true, 3);
            var weaponPoolLazer = WeaponPoolFactory.WeaponPoolCreate(WeaponType.LaserGunMk1);
            var weaponPoolGun = WeaponPoolFactory.WeaponPoolCreate(WeaponType.ChainGunMk1);

            // var bulletController = new ShootControllerWithInput(shootTimer,bulletPool,_player.PlayerProvider.transform,input.GetInput().pcIinputFire);
            IShootController shootController =new ShootControllerWithAutoShoot(shootTimer, bulletPool, _player.PlayerProvider.transform,_player.PlayerProvider.gameObject);
            var beyondScreenActer = new BeyondScreenActer();

            _controllers.Add(inputController);
            _controllers.Add(enemyController);
            _controllers.Add(moveController);
            _controllers.Add(shootController);

        }
        #endregion
    }
}