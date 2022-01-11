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
        }
        void OnBecameInvisible()
        {
            GameEventSystem.current.GoingBeyondScreen(_enemyModel);
        }
        private void OnBecameVisible()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }

        void OnTriggerEnter()
        {

        }

        void ReturnToPool()
        {

        }

    }
}

