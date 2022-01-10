using UnityEngine;

namespace GeekSpace
{
    internal sealed class PlayerModel : IModel
    {
        private string _pathToPrefab;
        private WeaponType _weaponType;
        private Vector3 _transform;
        private int _healthPoitns;
        private float _speed;

        public WeaponType WeaponType
        {
            get { return _weaponType; }
        }
        public Vector3 Position
        {
            get { return _transform; }
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
            _transform = position;
            _healthPoitns = healthPoitns;
            _speed = speed;
        }
    }
}

