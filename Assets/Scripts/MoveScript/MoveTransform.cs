using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransform : IMoveble
    {
        private float speed = 5;
        private float rotationSpeed = 90;
        private PlayerModel _playerModel;

        private Quaternion _shipDefaultRotation;

        private float _shipRotation = 0;
        private float _shipSpeed = 0;

        public MoveTransform(float speed, float rotationSpeed, PlayerModel playerModel, Quaternion shipDefaultRotation, float shipRotation, float shipSpeed)
        {
            this.speed = speed;
            this.rotationSpeed = rotationSpeed;
            _playerModel = playerModel;
            _shipDefaultRotation = shipDefaultRotation;
            _shipRotation = shipRotation;
            _shipSpeed = shipSpeed;
        }

        public void Move(float _shipSpeed, Transform transform, float speed, float _shipRotation, PlayerModel _playerModel, Quaternion _shipDefaultRotation)
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
