using UnityEngine;

namespace GeekSpace
{
    internal class GameInitialisationMultiplayer : IGameStrategy
    {
        private Controllers _controllers;
        private GameData _gameData;

        public GameInitialisationMultiplayer(Controllers controllers, GameData gameData)
        {
            this._controllers = controllers;
            this._gameData = gameData;
            GameInit();
        }

        public void GameInit()
        {
            Camera camera = Camera.main;
            System.Random random = new System.Random();

            var startPositionPlayerOne = Extention.GetCentrAccordingCamera(camera);
            var startPositionPlayerTwo = Extention.GetRandomVectorAccordingCamera(camera, 1);

            var inputPlayerOne = new InputInitialisationBtns(_gameData);
            var inputPlayerTwo = new InputInitialisationBtns(_gameData);
            var inputControllerPlayerOne = new InputController(inputPlayerOne);
            var inputControllerPlayerTwo = new InputController(inputPlayerTwo);


            var playerWeaponModel = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModel = new PlayerModel(PathsManager.PLAYER_PREFAB, WeaponType.ChainGunMk1, playerWeaponModel, startPositionPlayerOne, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            var playerModel2 = new PlayerModel(PathsManager.PLAYER_PREFAB, WeaponType.ChainGunMk1, playerWeaponModel, startPositionPlayerTwo, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);

            IMoveble playerMove = new MoveTransform(playerModel, inputPlayerOne);
            IMoveble playerMove2 = new MoveTransform(playerModel2, inputPlayerTwo);

            var player = new Player(playerMove, playerModel);
            var player2 = new Player(playerMove2, playerModel2);
            var playerMoveController = new PlayerMoveController(player);
            var playerMoveController2 = new PlayerMoveController(player2);

            var gunBulletPool = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModel = new BulletModel(gunBulletPool, player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(gunBulletPool, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldown = player.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimer = new TimerSystem(true, true, playerReloadCooldown);
            IShootController playerShootController = new ShootControllerWithAutoShoot(shootTimer, gunBulletPool, player.PlayerProvider.transform, player.PlayerProvider.gameObject, PlayerParametrsManager.TARGET_LAYER);

            var enemyPoolAsteroid = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Asteroid);
            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPoolAsteroid, MaximumsManager.ASTEROIDS_MAXIMUM, EnemyType.Asteroid);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 15);
            IMoveble nullMove = new MoveNOTHING();
            var enemyAsteroidController = new EnemyController(timerSystemAsteroidSpawn, enemyPoolAsteroid, random, nullMove);
            var enemyPoolShip = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Ship);
            var enemyShipPoolOperator = new EnemyPoolOperator(enemyPoolShip, MaximumsManager.SHIP_MAXIMUM, EnemyType.Ship);
            var timerSystemShipSpawn = new TimerSystem(true, true, 35);
            var timerSystemShipShooting = new TimerSystem(true, true, enemyShipPoolOperator.CurrentModel.WeaponModel.Cooldown);
            IMoveble shipMove = new MoveTransformEnemy(enemyShipPoolOperator.CurrentModel, player.PlayerProvider.gameObject);
            var enemyShipController = new EnemyController(timerSystemShipSpawn, enemyPoolShip, random, shipMove);
            IShootController enemyShootController = new EnemyShootController(timerSystemShipShooting, gunBulletPool, enemyShipPoolOperator.CurrentModel.Object.transform, enemyShipPoolOperator.CurrentModel.Object, EnemyParametrsManager.TARGET_LAYER);

            var beyondScreenActer = new BeyondScreenActer();
            _controllers.Add(inputControllerPlayerOne);
            _controllers.Add(inputControllerPlayerTwo);

            _controllers.Add(enemyAsteroidController);
            _controllers.Add(playerMoveController);
            _controllers.Add(playerMoveController2);

            _controllers.Add(enemyShipController);
            _controllers.Add(playerShootController);
            _controllers.Add(enemyShootController);
        }
    }
}