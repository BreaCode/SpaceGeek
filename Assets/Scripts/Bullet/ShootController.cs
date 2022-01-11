using UnityEngine;
namespace GeekSpace
{
    internal class ShootController : IExecute
    {
        private TimerSystem _timerSystem;
        private ObjectPool _enemyPool;
        private Transform _startPosition;

        IUserInputFire _fire;
        float _onClickFire;
        public ShootController(TimerSystem timerSystem, ObjectPool enemyPool,Transform startPosition,IUserInputFire fire)
        {
            _startPosition = startPosition;
            _timerSystem = timerSystem;
            _enemyPool = enemyPool;
            _fire = fire;
            _fire.AxisOnChange += GetFire;
        }

        private void GetFire(float value)
        {
            _onClickFire = value;
        }

        public void Execute(float deltaTime)
        {
            if (_onClickFire>0 && _timerSystem.CheckEvent())
            {
                _onClickFire = 0;
                var a = _enemyPool.Pop(_startPosition.position,_startPosition.rotation);
                a.GetComponent<Rigidbody2D>().AddForce(_startPosition.transform.up * 3);

                return;
            }
               
            
        }
    }
}