using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransform : IMoveble
    {
        readonly private PlayerModel _playerModel;
        readonly private IUserInputProxy _horizontalInputProxy;
        readonly private IUserInputProxy _verticalInputProxy;
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
            var shipSpeed = Mathf.Lerp(_playerModel.Speed, Mathf.Max(vertical, horizontal), 0);
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position = transform.position + movement * shipSpeed * Time.deltaTime;
        }
    }
}
