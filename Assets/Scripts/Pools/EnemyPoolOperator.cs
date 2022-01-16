using UnityEngine;

namespace GeekSpace
{
    internal sealed class EnemyPoolOperator 
    {
        private readonly IPool _pool;
        private readonly int _poolSize;
        private readonly EnemyType _enemyType;


        internal EnemyPoolOperator(IPool pool, int poolSize, EnemyType enemyType)    
        {
            _pool = pool;
            _poolSize = poolSize;
            _enemyType = enemyType;
            InitiatePool();
        }

        private void InitiatePool()
        {
            Camera camera = Camera.main;
            GameObject[] objects = new GameObject[_poolSize];

            for (int i = 0; i < _poolSize; i++)
            {
                var enemyModel = EnemyModelFactory.EnemyModelCreate(_pool, _enemyType);

                objects[i] = _pool.Pop(enemyModel.Position, Quaternion.identity);

                var EnemyProvider = objects[i].GetComponent<EnemyProvider>();
                EnemyProvider.EnemyModel = enemyModel;
            }
            for (int i = 0; i < _poolSize; i++)
            {
                _pool.Push(objects[i]);
            }

        }
        

    }

}
