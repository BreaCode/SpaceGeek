
using UnityEngine;

namespace GeekSpace
{
    public class BulletPoolOperator 
    {
        private IPool _pool;
        private Transform _startPosition;
        private int _poolSize;

        public BulletPoolOperator(IPool pool, Transform startPosition, int poolSize)
        {
            _pool = pool;
            _startPosition = startPosition;
            _poolSize = poolSize;
            InitiatePool();
        }

        private void InitiatePool()
        {
            GameObject[] objects = new GameObject[_poolSize];

            for (int i = 0; i < _poolSize; i++)
            {
               
                var bulletModel = new BulletModel(_pool,_startPosition.position, 10);

                objects[i] = _pool.Pop(_startPosition.position, _startPosition.rotation);

                var BulletProvider = objects[i].GetComponent<BulletProvider>();
                BulletProvider.BulletModel = bulletModel;
            }
            for (int i = 0; i < _poolSize; i++)
            {
                _pool.Push(objects[i]);
            }

        }
    }
}