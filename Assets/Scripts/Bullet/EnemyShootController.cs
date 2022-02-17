using UnityEngine;

namespace GeekSpace
{
    internal class EnemyShootController : ShootControllerWithAutoShoot
    {
        internal TimerSystem _timerSystemEnemy;
        internal EnemyShootController(TimerSystem timerSystem, IPool enemyBulletPool, Transform startPosition, GameObject player, string enemyLayerMask,AudioClip shootAudioClip) : base(timerSystem, enemyBulletPool, startPosition, player, enemyLayerMask,shootAudioClip)
        {

        }

        public override void GetShoot()
        {
            if (_player.activeSelf == false) return;
            _timerSystemEnemy = _timerSystem;
#if UNITY_EDITOR
            _timerSystemEnemy.SetNewTimer(4 / EntityData._Ship._speedFire);
#endif
            _hit = Physics2D.Raycast(_player.transform.position, -_player.transform.up, 100.0f, _enemyLayerMask);
            Debug.DrawLine(_player.transform.position, -_player.transform.up,Color.red);
            if (_timerSystemEnemy.CheckEvent() && _hit && EntityData._Ship._shootBlocked==0)
            {
                Extention.GetOrAddComponent<AudioSource>(_camera.gameObject).PlayOneShot(_shootAudioClip);
                var startpos = new Vector2(_startPosition.transform.position.x, _startPosition.transform.position.y - 1);
                var a = _bullets.Pop(startpos, _startPosition.rotation);
                a.GetComponent<Rigidbody2D>().AddForce(-_startPosition.transform.up * 3);
                return;
            }
        }
    }
}