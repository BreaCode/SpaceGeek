using UnityEngine;
namespace GeekSpace
{
    internal sealed class BulletModel : IModel, IDynamicModel
    {
        private string _pathToPrefab;
        private Vector3 _position;
        private GameObject _bulletObject;
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
        public float Speed
        {
            get { return _speed; }
        }

        public BulletModel(string pathToPrefab, Vector3 position, float speed)
        {
            _pathToPrefab = pathToPrefab;
            _position = position;
            _speed = speed;
        }
    }
}

