using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekSpace
{
    internal class EnemyModelFactory
    {
        internal static EnemyModel EnemyModelCreate(IPool pool, EnemyType enemyType)
        {
            Camera camera = Camera.main;
            var startPosition = Extention.GetRandomVectorAccordingCamera(camera, ConstManager.OFFSET_ASTEROID);

            WeaponModel weaponModel = null; //—юда фабрику оружи€
            int enemySize = 2;
            if (enemyType == EnemyType.Asteroid)
            {
                enemySize = 6;
            }

            var enemyModel = new EnemyModel(pool, enemyType, weaponModel, startPosition, 10, 10, enemySize);

            return enemyModel;
        }
    }
}

