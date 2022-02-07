using UnityEngine;

namespace GeekSpace
{
    internal class ShootControllerWithInputBtn : IShootController,IExecute
    {
        private TimerSystem _timerSystem;
        private IPool _enemyPool;
        private Transform _startPosition;
        InputInitialisationBtns _getShoot;
        float _onClickFire;
        public ShootControllerWithInputBtn(TimerSystem timerSystem, IPool enemyPool, Transform startPosition, InputInitialisationBtns getShoot)
        {
            _startPosition = startPosition;
            _timerSystem = timerSystem;
            _enemyPool = enemyPool;
            _getShoot = getShoot;
        }


        public void GetShoot()
        {
            if (_timerSystem.CheckEvent())
            {
                _onClickFire = 0;
                var a = _enemyPool.Pop(_startPosition.localPosition, _startPosition.localRotation);
                a.GetComponent<Rigidbody2D>().AddForce(_startPosition.transform.up * 3);
                return;
            }
        }

        public void Execute(float deltaTime)
        {
            if (_getShoot.GetFire())
             GetShoot();
        }

    }
}
