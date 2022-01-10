using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransform : IMoveble
    {
        private PlayerModel playerModel;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        private float horizontal;
        private float vertical;

        public MoveTransform(PlayerModel playerModel, (IUserInputProxy horizontalInputProxy, IUserInputProxy verticalInputProxy) GetInput)
        {
            this.playerModel = playerModel;
            _horizontalInputProxy = GetInput.horizontalInputProxy;
            _verticalInputProxy = GetInput.verticalInputProxy;
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
            var _shipSpeed = Mathf.Lerp(playerModel.Speed, Mathf.Max(vertical, 0), 0.1f);
            transform.position += transform.up * _shipSpeed * playerModel.Speed * Time.deltaTime;

            var rot = horizontal;
            transform.rotation *= Quaternion.Euler(0, 0, rot);
        }
    }
}
