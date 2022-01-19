using UnityEngine;

namespace GeekSpace
{
    internal class EnemyModelFactory
    {
        internal static EnemyModel EnemyModelCreate(IPool pool, EnemyType enemyType)
        {
            WeaponModel DEFAULT_WEAPON_MODEL = new WeaponModel(0, 2);
            WeaponModel weaponModel = DEFAULT_WEAPON_MODEL;
            var startPosition = new Vector3(0, 0, 0);
            var enemyHealth = EnemyParametrsManager.DEFAULT_HEALTH;
            var enemySpeed = EnemyParametrsManager.DEFAULT_SPEED;
            var enemyArmor = EnemyParametrsManager.DEFAULT_ARMOR;
            int enemySize = 2;

            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    //—юда фабрику оружи€
                    Camera camera = Camera.main;
                    startPosition = Extention.GetRandomVectorAccordingCamera(camera, ConstManager.OFFSET_ASTEROID);
                    enemyHealth = EnemyParametrsManager.ASTEROID_HEALTH;
                    enemySpeed = EnemyParametrsManager.ASTEROID_SPEED;
                    enemySize = 6;
                    break;
                case EnemyType.Ship:
                    //—юда фабрику оружи€
                    startPosition = new Vector3(0, ScreenBordersManager.UPPER_SIDE, 0);
                    enemyHealth = EnemyParametrsManager.SHIP_HEALTH;
                    enemySpeed = EnemyParametrsManager.SHIP_SPEED;
                    enemyArmor = EnemyParametrsManager.SHIP_ARMOR;
                    enemySize = 2;
                    break;
            }



            var enemyModel = new EnemyModel(pool, enemyType, weaponModel, startPosition, enemyHealth, enemySpeed, enemyArmor, enemySize);

            return enemyModel;
        }
    }
}

