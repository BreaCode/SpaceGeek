using UnityEngine;
using System;
using System.Collections.Generic;

namespace GeekSpace
{
    internal sealed class EnemyController : IExecute
    {
        private readonly TimerSystem _respawnTimer;
        private readonly IPool _objectPool;
        private readonly System.Random _random;
        private readonly IMoveble _moveble;
        private List<GameObject> _enemies;

        internal EnemyController(TimerSystem respawnTimer, IPool objectPool, System.Random random, IMoveble moveble)
        {
            if (respawnTimer == null) throw new Exception("TimerSystem is null");
            if (objectPool == null) throw new Exception("ObjectPool is null");

            _respawnTimer = respawnTimer;
            _objectPool = objectPool;       
            _random = random;
            _moveble = moveble;
            _enemies = new List<GameObject>();
        }

        public void Execute(float deltaTime)
        {

            if (_respawnTimer.CheckEvent())
            {
                var enemyObject = _objectPool.Pop(Extention.GetRandomVectorAccordingCamera(Camera.main, ConstManager.OFFSET_ASTEROID), Quaternion.identity);
                var enemyModel = enemyObject.gameObject.GetOrAddComponent<EnemyProvider>().EnemyModel;
                var enemySize = _random.Next(1, enemyModel.Size) / 2f;
                Vector3 scale = new Vector3(enemySize, enemySize, 0);
                enemyObject.transform.localScale = scale;
                _enemies.Add(enemyObject.gameObject);
            }

            foreach (var item in _enemies)
            {
                if (item.activeSelf)
                {
                    if (_moveble is MoveTransformEnemy move) move.Move(item.transform);
                }
            }
        }
    }
}