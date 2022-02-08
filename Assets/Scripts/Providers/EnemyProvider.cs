using System;
using UnityEngine;

namespace GeekSpace
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(MeshRenderer))]
    public class EnemyProvider : MonoBehaviour
    {
        private EnemyModel _enemyModel;
        private Rigidbody2D _rigidbody2D;
        private Camera _camera;

        internal EnemyModel EnemyModel
        {
            get { return _enemyModel; }
            set
            {
                _enemyModel = value;
                _enemyModel.Object = gameObject;
            }
        }
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
        }
        void OnBecameInvisible()
        {
            GameEventSystem.current.GoingBeyondScreen(_enemyModel);
        }
        private void OnBecameVisible()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

        void OnTriggerEnter2D()
        {
            GameEventSystem.current.GoingBeyondScreen(_enemyModel);
            Extention.GetOrAddComponent<AudioSource>(_camera.gameObject).PlayOneShot(_enemyModel.ExplosionClip);
        }

        void ReturnToPool()
        {

        }

    }
}

