using UnityEngine;

namespace GeekSpace
{
    internal class MultiplayerGameFactory : IAbstractGameFactory
    {
        private IInputInitialisation _inputInitialisation;
        private IInputInitialisationTwo _inputInitialisationTwo;

        Camera camera = Camera.main;
        System.Random random = new System.Random();
        private IPool gunBulletPool;
        private IPool gunBulletPoolTwo;
        private Player player;
        private Player playerTwo;
        private Controllers _controllers;

        public MultiplayerGameFactory(Controllers controllers)
        {
            _controllers = controllers;
        }

        public void CreateEnemy()
        {
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
            _controllers.Add(enemyAsteroidController);
            _controllers.Add(enemyShipController);
            _controllers.Add(enemyShootController);
        }

        public void CreatePlayer()
        {
            var startPositionOne = Vector2.left;
            var startPositionTwo = Vector2.right;

            var inputController = new InputController(_inputInitialisation);
            var inputControllerTwo = new InputController(_inputInitialisation);

            var playerWeaponModelOne = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModelOne = new PlayerModel(PathsManager.PLAYER_PREFAB, WeaponType.ChainGunMk1, playerWeaponModelOne, startPositionOne, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble playerMoveOne = new MoveTransform(playerModelOne, _inputInitialisation);

            var playerWeaponModelTwo = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModelTwo = new PlayerModel(PathsManager.PLAYER_PREFAB_TWO, WeaponType.ChainGunMk1, playerWeaponModelTwo, startPositionTwo, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble playerMoveTwo = new MoveTransform(playerModelTwo, _inputInitialisation);

            player = new Player(playerMoveOne, playerModelOne);
            var playerMoveControllerOne = new PlayerMoveController(player);
            gunBulletPool = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModel = new BulletModel(gunBulletPool, player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(gunBulletPool, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldown = player.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimer = new TimerSystem(true, true, playerReloadCooldown);
            IShootController playerShootControllerOne = new ShootControllerWithAutoShoot(shootTimer, gunBulletPool, player.PlayerProvider.transform, player.PlayerProvider.gameObject, PlayerParametrsManager.TARGET_LAYER);

            playerTwo = new Player(playerMoveTwo, playerModelTwo);
            var playerMoveControllerTwo = new PlayerMoveController(player);
            gunBulletPoolTwo = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModelTwo = new BulletModel(gunBulletPoolTwo, playerTwo.PlayerProvider.transform.position, 2);
            var bulletPoolOperatorTwo = new BulletPoolOperator(gunBulletPoolTwo, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldownTwo = playerTwo.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimerTwo = new TimerSystem(true, true, playerReloadCooldownTwo);
            IShootController playerShootControllerTwo = new ShootControllerWithAutoShoot(shootTimer, gunBulletPoolTwo, playerTwo.PlayerProvider.transform, playerTwo.PlayerProvider.gameObject, PlayerParametrsManager.TARGET_LAYER);

            _controllers.Add(inputController);
            _controllers.Add(playerMoveControllerOne);
            _controllers.Add(playerShootControllerOne);

            _controllers.Add(playerMoveControllerTwo);
            _controllers.Add(playerShootControllerTwo);
        }

        public IInputInitialisation SetInput(IInputInitialisation inputInitialisation)
        {
            _inputInitialisation = inputInitialisation;

            return _inputInitialisation;
        }

        public IInputInitialisationTwo SetInputTwo(IInputInitialisationTwo inputInitialisationTwo)
        {
            _inputInitialisationTwo = inputInitialisationTwo;

            return _inputInitialisationTwo;
        }
    }
}
