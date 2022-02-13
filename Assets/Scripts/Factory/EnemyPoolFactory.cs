using UnityEngine;

namespace GeekSpace
{
    internal class EnemyPoolFactory
    {
        internal static ObjectPool EnemyPoolCreate(EnemyType enemyType)
        {
            string _name = "";
            var enemyPrefab = (Resources.Load<EnemyProvider>(PathsManager.ASTEROID_PREFAB));
            var poolRoot = new Vector3(0, 0, 0);
            switch (enemyType)
            {
                case EnemyType.Asteroid:
                    enemyPrefab = (Resources.Load<EnemyProvider>(PathsManager.ASTEROID_PREFAB));
                    _name = NameManager.POOL_ENEMY_ASTEROID;
                    break;
                case EnemyType.Ship:
                    enemyPrefab = (Resources.Load<EnemyProvider>(PathsManager.ENEMY_SHIP_PREFAB));
                    _name = NameManager.POOL_ENEMY_SHIP;
                    break;
            }
            var root = new ParrentStruct(Vector2.zero, _name);
            var enemyPool = new ObjectPool(enemyPrefab.gameObject, root);
            return enemyPool;
        }
    }
}

