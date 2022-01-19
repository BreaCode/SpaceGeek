using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekSpace
{
    internal class EnemyShootController : IExecute, IShootController
    {
        private TimerSystem _timerSystem;
        private ObjectPool _enemyPool;
        private Transform _startPosition;

        GameObject _player;
        RaycastHit2D _hit;
        LayerMask _mask;
        public EnemyShootController(TimerSystem timerSystem, ObjectPool enemyPool, Transform startPosition, GameObject player, string layer)
        {
            _startPosition = startPosition;
            _timerSystem = timerSystem;
            _enemyPool = enemyPool;
            _player = player;
            _mask = LayerMask.GetMask(layer);
        }

        public void GetShoot()
        {
            if (_player.activeSelf == false) return;
            _hit = Physics2D.Raycast(_player.transform.position, -_player.transform.up, 100.0f, _mask);
            if (_timerSystem.CheckEvent() && _hit)
            {
                var startpos = new Vector2(_startPosition.transform.position.x, _startPosition.transform.position.y - 1);
                var a = _enemyPool.Pop(startpos, _startPosition.rotation);
                a.GetComponent<Rigidbody2D>().AddForce(-_startPosition.transform.up * 3);
                return;
            }
        }

        public void Execute(float deltaTime)
        {
            GetShoot();
        }
    }
}