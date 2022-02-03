﻿using UnityEngine;

namespace GeekSpace
{
    internal class SinglGameFactory : IAbstractGameFactory
    {
        Camera camera = Camera.main;
        System.Random random = new System.Random();
        private IPool gunBulletPool;
        private Player player;
        private Controllers _controllers;

        public SinglGameFactory(Controllers controllers)
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
            var startPosition = camera.GetCentrAccordingCamera();
            var input = new InputInitialization();
            var inputController = new InputController(input.GetInput());
            #region Create player  
            var playerWeaponModelTwo = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModelTwo = new PlayerModel(PathsManager.PLAYER_PREFAB_TWO, WeaponType.ChainGunMk1, playerWeaponModelTwo, startPosition, PlayerParametrsManager.PLAYER_HEALTH_TWO, PlayerParametrsManager.PLAYER_SPEED_TWO);
            var playerWeaponModel = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var playerModel = new PlayerModel(PathsManager.PLAYER_PREFAB, WeaponType.ChainGunMk1, playerWeaponModel, startPosition, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble playerMove = new MoveTransform(playerModel, (input.GetInput().inputHorizontal, input.GetInput().inputVertical));
            IMoveble playerMoveTwo = new MoveTransformTwo(playerModelTwo, (input.GetInput().inputHorizontalTwo, input.GetInput().inputVertical));
            var player = new Player(playerMove, playerMoveTwo, playerModel, playerModelTwo);
            var playerTwo = new Player(playerMove, playerMoveTwo, playerModel, playerModelTwo);
            var playerMoveControllerTwo = new PlayerMoveController(player, playerTwo);
            var playerMoveController = new PlayerMoveController(player, playerTwo);
            var gunBulletPool = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);

            var _playerWeaponModel = WeaponModelFactory.WeaponModelCreate(WeaponType.ChainGunMk1);
            var _playerModel = new PlayerModel(PathsManager.PLAYER_PREFAB, WeaponType.ChainGunMk1, playerWeaponModel, startPosition, PlayerParametrsManager.PLAYER_HEALTH, PlayerParametrsManager.PLAYER_SPEED);
            IMoveble _playerMove = new MoveTransform(_playerModel, (input.GetInput().inputHorizontal, input.GetInput().inputVertical));

            player = new Player(_playerMove, _playerModel);
            var _playerMoveController = new PlayerMoveController(player);
            gunBulletPool = BulletPoolFactory.BulletPoolCreate(WeaponType.ChainGunMk1);
            var bulletModel = new BulletModel(gunBulletPool, player.PlayerProvider.transform.position, 2);
            var bulletPoolOperator = new BulletPoolOperator(gunBulletPool, bulletModel, MaximumsManager.BULLETS_MAXIMUM);
            var playerReloadCooldown = player.PlayerProvider.PlayerModel.WeaponModel.Cooldown;
            var shootTimer = new TimerSystem(true, true, playerReloadCooldown);
            IShootController playerShootController = new ShootControllerWithAutoShoot(shootTimer, gunBulletPool, player.PlayerProvider.transform, player.PlayerProvider.gameObject, PlayerParametrsManager.TARGET_LAYER);
            #endregion
            #region Create enemy
            var enemyPoolAsteroid = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Asteroid);
            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPoolAsteroid, MaximumsManager.ASTEROIDS_MAXIMUM, EnemyType.Asteroid);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, 30);
            IMoveble nullMove = new MoveNOTHING();
            var enemyAsteroidController = new EnemyController(timerSystemAsteroidSpawn, enemyPoolAsteroid, random, nullMove);
            var enemyPoolShip = EnemyPoolFactory.EnemyPoolCreate(EnemyType.Ship);
            var enemyShipPoolOperator = new EnemyPoolOperator(enemyPoolShip, MaximumsManager.SHIP_MAXIMUM, EnemyType.Ship);
            var timerSystemShipSpawn = new TimerSystem(true, true, 50);
            var timerSystemShipShooting = new TimerSystem(true, true, enemyShipPoolOperator.CurrentModel.WeaponModel.Cooldown);
            IMoveble shipMove = new MoveTransformEnemy(enemyShipPoolOperator.CurrentModel, player.PlayerProvider.gameObject, playerTwo.PlayerProvider.gameObject);
            var enemyShipController = new EnemyController(timerSystemShipSpawn, enemyPoolShip, random, shipMove);
            IShootController enemyShootController = new EnemyShootController(timerSystemShipShooting, gunBulletPool, enemyShipPoolOperator.CurrentModel.Object.transform, enemyShipPoolOperator.CurrentModel.Object, EnemyParametrsManager.TARGET_LAYER);
            #endregion
            #region Composition
            var beyondScreenActer = new BeyondScreenActer();

            _controllers.Add(inputController);
            _controllers.Add(playerMoveController);
            _controllers.Add(playerShootController);
            #endregion
        }

        public InputInitialization SetInput()
        {
            var input = new InputInitialization();
            return input;
        }

    }
}