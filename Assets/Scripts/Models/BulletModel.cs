using UnityEngine;
namespace GeekSpace
{
    internal sealed class BulletModel : IDynamicModelBullet//IDynamicModel
    {
        private Vector3 _position;
        private GameObject _bulletObject;
        private IPoolBullet _pool;
        private float _speed;

        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public GameObject Object
        {
            get { return _bulletObject; }
            set { _bulletObject = value; }
        }
        public IPoolBullet Pool
        {
            get { return _pool; }
            set { _pool = value; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public BulletModel(IPoolBullet pool, Vector3 position,float speed)
        {
            _pool = pool;         
            _position = position;
            _speed = speed;
        }
    }
}

