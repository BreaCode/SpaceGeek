using UnityEngine;
using System;

namespace GeekSpace
{
    internal sealed class EnemyController : IExecute
    {
        private readonly TimerSystem _timerSystem;
        private readonly ObjectPool _objectPool;
        private readonly System.Random _random;
        internal EnemyController(TimerSystem timerSystem, ObjectPool objectPool, System.Random random)
        {
            if (timerSystem == null) throw new Exception("TimerSystem is null");
            if (objectPool == null) throw new Exception("ObjectPool is null");

            _timerSystem = timerSystem;
            _objectPool = objectPool;
            _random = random;
        }
        public void Execute(float deltaTime)
        {
            if (_timerSystem.CheckEvent())
            {
                var enemyObject = _objectPool.Pop(Extention.GetRandomVectorAccordingCamera(Camera.main, ConstManager.OFFSET_ASTEROID),Quaternion.identity);
                var enemyModel = enemyObject.GetOrAddComponent<EnemyProvider>().EnemyModel;
                var enemySize = _random.Next(1, enemyModel.Size) / 2f;
                Vector3 scale = new Vector3(enemySize, enemySize, 0);
                enemyObject.transform.localScale = scale;
            }
        }
    }
}