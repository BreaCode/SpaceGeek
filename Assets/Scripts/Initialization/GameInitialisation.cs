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
            var playerWeaponModel = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModel = new PlayerModel(PathsManager.PLAYER_PREFAB , WeaponType.ChainGunMk1, playerWeaponModel, startPosition, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);

            IMoveble playerMove = new MoveTransform(playerModel, (input.GetInput().inputHorizontal, input.GetInput().inputVertical));
            var player = new Player(playerMove, playerModel);
            var gunBulletPool = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModel = new BulletModel(gunBulletPool, player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(gunBulletPool, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldown = player.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimer = new TimerSystem(true, true, playerReloadCooldown);

            IShootController shootController = new ShootControllerWithAutoShoot(shootTimer, gunBulletPool, player.PlayerProvider.transform, player.PlayerProvider.gameObject);

            var moveController = new PlayerMoveController(player);

            #region Create enemy
            var enemyPoolAsteroid = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Asteroid);
            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPoolAsteroid, MaximumsManager.ASTEROIDS_MAXIMUM, EnemyType.Asteroid);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 30);
            IMoveble nullMove = new MoveNOTHING();
            var enemyController = new EnemyController(timerSystemAsteroidSpawn,null, enemyPoolAsteroid,null, random,nullMove);

            var enemyPoolShip = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Ship);
            var enemyShipPoolOperator = new EnemyPoolOperator(enemyPoolShip, MaximumsManager.SHIP_MAXIMUM, EnemyType.Ship);
            var timerSystemShipSpawn = new TimerSystem(true, true, 50);
            var timerSystemShipShooting = new TimerSystem(true, true, enemyShipPoolOperator.CurrentModel.WeaponModel.Cooldown);
            IMoveble shipMove = new MoveTransformEnemy(enemyShipPoolOperator.CurrentModel,player.PlayerProvider.gameObject);
            var shipController = new EnemyController(timerSystemShipSpawn, timerSystemShipShooting, enemyPoolShip, gunBulletPool, random, shipMove);

            #endregion
            var beyondScreenActer = new BeyondScreenActer();

            _controllers.Add(inputController);
            _controllers.Add(enemyController);
            _controllers.Add(moveController);
            _controllers.Add(shipController);
            _controllers.Add(shootController);

        }
        #endregion
    }
}
