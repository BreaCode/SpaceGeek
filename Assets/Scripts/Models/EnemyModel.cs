using UnityEngine;
namespace GeekSpace
{
    internal sealed class EnemyModel : IModel, IDynamicModel
    {
        private string _pathToPrefab;
        private EnemyType _enemyType;
        private Vector3 _position;
        private GameObject _enemyObject;
        private int _healthPoitns;
        private float _speed;
        public string PathToPrefab
        {
            get { return _pathToPrefab; }
        }
        public EnemyType EnemyType
        {
            get { return _enemyType; }
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
        public int HealthPoitns
        {
            get { return _healthPoitns; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public EnemyModel(string pathToPrefab, EnemyType enemyType, Vector3 position, int healthPoitns, float speed)
        {
            _pathToPrefab = pathToPrefab;
            _enemyType = enemyType;
            _position = position;
            _healthPoitns = healthPoitns;
            _speed = speed;
        }
    }
}

