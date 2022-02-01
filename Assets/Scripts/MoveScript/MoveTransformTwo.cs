using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransformTwo : IMoveble
    {
        readonly private PlayerModel _playerModelTwo;
        readonly private IUserInputProxy _horizontalTwoInputProxy;
        readonly private IUserInputProxy _verticalInputProxy;
        private float _horizontalTwo;
        private float _vertical;

        public MoveTransformTwo(PlayerModel playerModelTwo, (IUserInputProxy inputHorizontalTwo, IUserInputProxy inputVertical) input)
        {
            _playerModelTwo = playerModelTwo;
            _horizontalTwoInputProxy = input.inputHorizontalTwo;
            _verticalInputProxy = input.inputVertical;
            _horizontalTwoInputProxy.AxisOnChange += HorizontalTwoOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        void HorizontalTwoOnAxisOnChange(float value)
        {
            _horizontalTwo = value;
        }

        public void Move(Transform transform)
        {
            var shipSpeed = _playerModelTwo.Speed;
            var movement = new Vector3(_horizontalTwo, _vertical, 0);
            transform.position = transform.position + movement * shipSpeed * Time.deltaTime;
        }
    }
}