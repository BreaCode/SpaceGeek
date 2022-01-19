using UnityEngine;
using System;
using System.Collections.Generic;

namespace GeekSpace
{
    internal sealed class EnemyController : IExecute
    {
        private readonly TimerSystem _timerSystem;
        private readonly IPool _objectPool;
        private readonly IPool _bulletPool;
        private readonly System.Random _random;
        private readonly IMoveble _moveble;
        private List<GameObject> _enemies;
        private RaycastHit2D _hit;
        private LayerMask _mask;
        internal EnemyController(TimerSystem timerSystem, IPool objectPool, IPool bulletPool, System.Random random, IMoveble moveble)
        {
            if (timerSystem == null) throw new Exception("TimerSystem is null");
            if (objectPool == null) throw new Exception("ObjectPool is null");

            _timerSystem = timerSystem;
            _objectPool = objectPool;
            _bulletPool = bulletPool;
            _random = random;
            _moveble = moveble;
            _enemies = new List<GameObject>();
            _mask = LayerMask.GetMask("player");
        }

        public void GetShoot(GameObject enemy)
        {
            if (enemy.activeSelf == false) return;
            if (_bulletPool is null) return;

            _hit = Physics2D.Raycast(enemy.transform.position, -enemy.transform.up, 100.0f, _mask);

            if (_timerSystem.CheckEvent() && _hit)
            {
                var startpos = new Vector2(enemy.transform.position.x, enemy.transform.position.y - 1);
                var a = _bulletPool.Pop(startpos, enemy.transform.rotation);
                a.GetComponent<Rigidbody2D>().AddForce(-enemy.transform.up * 1);
                return;
            }
        }

        public void Execute(float deltaTime)
        {

            if (_timerSystem.CheckEvent())
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
                    GetShoot(item);
                }
            }
        }
    }
}