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
        private float _health;
        private float _maxHealth;
        private float _damage;
        MaterialPropertyBlock _healtBarmatBlock;
        MeshRenderer _healtBarMeshRenderer;


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
            _healtBarMeshRenderer = gameObject.transform.GetChild(1).transform.gameObject.GetComponent<MeshRenderer>();
            _healtBarmatBlock = new MaterialPropertyBlock();
            _camera = Camera.main;

        }
        private void Start()
        {
            _health = _enemyModel.HealthPoitns;
            _maxHealth = _health;
            _damage = FindObjectOfType<PlayerProvider>().PlayerModel.WeaponModel.Damage;

        }
        void OnBecameInvisible()
        {
            GameEventSystem.current.GoingBeyondScreen(_enemyModel);
            _healtBarMeshRenderer.enabled = false;
        }
        private void OnBecameVisible()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _healtBarMeshRenderer.enabled = true;
            _health = _maxHealth;
            UpdateHealthBar();
        }

        void OnTriggerEnter2D(Collider2D collider2)
        {
            _health -= _damage;
             UpdateHealthBar();       
            if (_health <= 0)
            {
                GameEventSystem.current.GoingBeyondScreenEnemy(_enemyModel);
                Extention.GetOrAddComponent<AudioSource>(_camera.gameObject).PlayOneShot(_enemyModel.ExplosionClip);            
            }
        }

        void ReturnToPool()
        {

        }

        private void UpdateHealthBar()
        {
            _healtBarMeshRenderer.GetPropertyBlock(_healtBarmatBlock);
            _healtBarmatBlock.SetFloat("_Fill", _health / _maxHealth);
            _healtBarMeshRenderer.SetPropertyBlock(_healtBarmatBlock);
        }
    }
}

