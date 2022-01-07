using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransform : IMoveble
    {
        private PlayerModel playerModel;

        public MoveTransform(PlayerModel playerModel)
        {
            this.playerModel = playerModel;
        }

        public void Move(Transform transform)
        {
            float moveVertical = Input.GetAxis("Vertical");
            float moveHorizontal = Input.GetAxis("Horizontal");

            var _shipSpeed = Mathf.Lerp(playerModel.Speed, Mathf.Max(moveVertical, 0), 0.1f);
            transform.position += transform.up * _shipSpeed * playerModel.Speed * Time.deltaTime;

            var rot = moveHorizontal;
            transform.rotation *= Quaternion.Euler(0, 0, rot);
        }
    }
}
