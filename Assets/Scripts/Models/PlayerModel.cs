using UnityEngine;

namespace GeekSpace
{
    internal sealed class PlayerModel : IModel, IDynamicModel
    {
        private string _pathToPrefab;
        private WeaponType _weaponType;
        private Vector3 _position;
        private GameObject _playerObject;
        private int _healthPoitns;
        private float _speed;

        public WeaponType WeaponType
        {
            get { return _weaponType; }
        }
        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public GameObject Object
        {
            get { return _playerObject; }
            set { _playerObject = value; }
        }
        public int HealthPoitns
        {
            get { return _healthPoitns; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public PlayerModel(string pathToPrefab, WeaponType weaponType, Vector3 position, int healthPoitns, float speed)
        {
            _pathToPrefab = pathToPrefab;
            _weaponType = weaponType;
            _position = position;
            _healthPoitns = healthPoitns;
            _speed = speed;
        }
    }
}

