using UnityEngine;
namespace GeekSpace
{
    internal sealed class BulletModel : IModel
    {
        private string _pathToPrefab;
        private Transform _transform;
        private float _speed;

        public Transform Transform
        {
            get { return _transform; }
        }
        public float Speed
        {
            get { return _speed; }
        }

        public BulletModel(string pathToPrefab, Transform transform, float speed)
        {
            _pathToPrefab = pathToPrefab;
            _transform = transform;
            _speed = speed;
        }
    }
}

