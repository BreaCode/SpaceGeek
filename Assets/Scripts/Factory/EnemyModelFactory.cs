using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekSpace
{
    internal class EnemyModelFactory
    {
        internal EnemyModelFactory(Vector3 startPosition, int poolSize, int coolDown)
        {
            var enemyPrefab = (Resources.Load<EnemyProvider>(PathsManager.ASTEROID_PREFAB));

            var poolRoot = new Vector3(0, 0, 0);
            var enemyPool = new ObjectPool(enemyPrefab.gameObject, poolRoot);

            var poolMaximumSize = MaximumsManager.ASTEROIDS_MAXIMUM;

            var enemyAsteroidPoolOperator = new EnemyPoolOperator(enemyPool, poolMaximumSize);
            var timerSystemAsteroidSpawn = new TimerSystem(true, true, coolDown);

        }
    }
}

