using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekSpace
{
    internal class EnemyPoolFactory
    {
        internal static ObjectPool EnemyPoolCreate(EnemyType enemyType)
        {
            var enemyPrefab = (Resources.Load<EnemyProvider>(PathsManager.ASTEROID_PREFAB));
            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    enemyPrefab = (Resources.Load<EnemyProvider>(PathsManager.ASTEROID_PREFAB));
                    break;
                case EnemyType.Ship:
                    enemyPrefab = (Resources.Load<EnemyProvider>(PathsManager.ENEMY_SHIP_PREFAB));
                    break;
            }


            var poolRoot = new Vector3(0, 0, 0);
            var enemyPool = new ObjectPool(enemyPrefab.gameObject, poolRoot);

            return enemyPool;
        }

    }
}

