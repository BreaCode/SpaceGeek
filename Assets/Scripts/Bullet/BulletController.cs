using UnityEngine;
namespace GeekSpace
{
    internal class BulletController:IExecute
    {
        private TimerSystem _timerSystem;
        private ObjectPool _enemyPool;
        private Transform _startPosition;

        IUserInputFire _fire;
        float _onClickFire;
        public BulletController(TimerSystem timerSystem, ObjectPool enemyPool,Transform startPosition,IUserInputFire fire)
        {
            this._startPosition = startPosition;
            this._timerSystem = timerSystem;
            this._enemyPool = enemyPool;
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
                Debug.Log(_onClickFire);
                var a = _enemyPool.Pop(_startPosition.position,_startPosition.rotation);
                a.GetComponent<Rigidbody2D>().AddForce(_startPosition.transform.up * 1);

                return;
            }
               
            
        }
    }
}