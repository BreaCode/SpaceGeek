using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransform : IMoveble
    {
        private PlayerModel _playerModel;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private float horizontal;
        private float vertical;

        public MoveTransform(PlayerModel playerModel, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _playerModel = playerModel;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        void VerticalOnAxisOnChange(float value)
        {
            vertical = value;
        }

        void HorizontalOnAxisOnChange(float value)
        {
            horizontal = value;
        }

        public void Move(Transform transform)
        {
            var shipSpeed = Mathf.Lerp(_playerModel.Speed, Mathf.Max(vertical, 0), 0.7f);
            transform.position += transform.up * shipSpeed * _playerModel.Speed * Time.deltaTime;

            var rot = -horizontal;
            transform.rotation *= Quaternion.Euler(0, 0, 0.3f * rot);
        }
    }
}
