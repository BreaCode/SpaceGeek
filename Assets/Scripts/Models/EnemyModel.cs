using UnityEngine;
namespace GeekSpace
{
    internal sealed class EnemyModel : IDynamicModel
    {
        private EnemyType _enemyType;
        private WeaponModel _weaponModel;
        private Vector3 _position;
        private GameObject _enemyObject;
        private IPool _pool;
        private int _healthPoitns;
        private int _armor;
        private int _size;
        private float _speed;

        public EnemyType EnemyType
        {
            get { return _enemyType; }
        }
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
        public int Armor
        {
            get { return _armor; }
        }
        public int Size
        {
            get { return _size; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public EnemyModel(IPool pool, EnemyType enemyType, WeaponModel weaponModel, Vector3 position, int healthPoitns, float speed, int armor, int size = 1)
        {
            _pool = pool;
            _enemyType = enemyType;
            _weaponModel = weaponModel;
            _position = position;
            _healthPoitns = healthPoitns * size;
            _armor = armor;
            _speed = speed;
            _size = size;
        }
    }
}

