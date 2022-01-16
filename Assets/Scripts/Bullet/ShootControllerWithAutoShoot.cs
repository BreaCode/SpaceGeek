using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekSpace
{
    internal class ShootControllerWithAutoShoot : IExecute, IShootController
    {
        private TimerSystem _timerSystem;
        private ObjectPool _enemyPool;
        private Transform _startPosition;

        GameObject _player;
        RaycastHit2D _hit;
        public ShootControllerWithAutoShoot(TimerSystem timerSystem, ObjectPool enemyPool, Transform startPosition, GameObject player)
        {
            _startPosition = startPosition;
            _timerSystem = timerSystem;
            _enemyPool = enemyPool;
            _player = player;
        }

        public void GetShoot()
        {
            _hit = Physics2D.Raycast(_player.transform.position, _player.transform.up);
            if (_timerSystem.CheckEvent() && _hit)
            {
                var a = _enemyPool.Pop(_startPosition.position, _startPosition.rotation);
                a.GetComponent<Rigidbody2D>().AddForce(_startPosition.transform.up * 3);
                return;
            }
        }

        public void Execute(float deltaTime)
        {
            GetShoot();
        }
    }
}