using UnityEngine;
namespace GeekSpace
{
    internal sealed class EnemyModel : IModel, IDynamicModel
    {
        private WeaponModel _weaponModel;
        private Vector3 _position;
        private GameObject _enemyObject;
        private IPool _pool;
        private int _healthPoitns;
        private float _speed;

        public WeaponModel WeaponModel
        {
            get { return _weaponModel; }
        }
        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public GameObject Object
        {
            get { return _enemyObject; }
            set { _enemyObject = value; }
        }
        public IPool Pool
        {
            get { return _pool; }
            set { _pool = value; }
        }
        public int HealthPoitns
        {
            get { return _healthPoitns; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public EnemyModel(IPool pool, WeaponModel weaponModel, Vector3 position, int healthPoitns, float speed)
        {
            _pool = pool;
            _weaponModel = weaponModel;
            _position = position;
            _healthPoitns = healthPoitns;
            _speed = speed;
        }
    }
}

