using UnityEngine;

namespace GeekSpace
{
    public class EnemyPoolOperator 
    {
        readonly private IPool _pool;
        readonly private int _poolSize;
        

        public EnemyPoolOperator(IPool pool, int poolSize)    
        {
            _pool = pool;
            _poolSize = poolSize;
            InitiatePool();
        }

        private void InitiatePool()
        {
            Camera camera = Camera.main;
            GameObject[] objects = new GameObject[_poolSize];

            for (int i = 0; i < _poolSize; i++)
            {
                var asteroidStartPosition = Extention.GetRandomVectorAccordingCamera(camera, ConstManager.OFFSET_ASTEROID);
                WeaponModel weaponModel = null;
                var asteroidModel = new EnemyModel(_pool, weaponModel, asteroidStartPosition, 10, 10);

                objects[i] = _pool.Pop(asteroidStartPosition, Quaternion.identity);

                var EnemyProvider = objects[i].GetComponent<EnemyProvider>();
                EnemyProvider.EnemyModel = asteroidModel;
            }
            for (int i = 0; i < _poolSize; i++)
            {
                _pool.Push(objects[i]);
            }

        }
        

    }

}
