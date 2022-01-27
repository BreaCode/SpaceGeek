using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransform : IMoveble
    {
        readonly private PlayerModel _playerModel;
        readonly private IUserInputProxy _horizontalInputProxy;
        readonly private IUserInputProxy _verticalInputProxy;
        private float _horizontal;
        private float _vertical;

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
            _vertical = value;
        }

        void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Move(Transform transform)
        {
            var shipSpeed = _playerModel.Speed;
            var movement = new Vector3(_horizontal, _vertical, 0);
            transform.position = transform.position + movement * shipSpeed * Time.deltaTime;
        }
    }
}
