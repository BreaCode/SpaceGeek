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

            var poolRoot = new Vector3(0, 0, 0);
            var enemyPool = new ObjectPool(enemyPrefab.gameObject, poolRoot);

            return enemyPool;
        }

    }
}

