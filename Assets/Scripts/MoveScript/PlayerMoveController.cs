using UnityEngine;

namespace GeekSpace
{
    public class PlayerMoveController : IExecute
    {
        public float speed = 5;
        public float rotationSpeed = 90;
        private PlayerModel _playerModel;

        private Quaternion _shipDefaultRotation;

        private float _shipRotation = 0;
        private float _shipSpeed = 0;

        public void Start()
        {
            _shipDefaultRotation = _playerModel.localRotation;
        }

        public void Move(Transform transform)
        {
            float moveVertical = Input.GetAxis("Vertical");
            float moveHorizontal = Input.GetAxis("Horizontal");

            _shipSpeed = Mathf.Lerp(_shipSpeed, Mathf.Max(moveVertical, 0), 0.1f);
            transform.position += transform.up * _shipSpeed * speed * Time.deltaTime;

            var rot = moveHorizontal;
            transform.rotation *= Quaternion.Euler(0, 0, rot);

            _shipRotation = Mathf.Lerp(_shipRotation, -rot * 30, 0.1f);
            _playerModel.localRotation = _shipDefaultRotation * Quaternion.AngleAxis(_shipRotation, Vector3.left);
        }
    }
}