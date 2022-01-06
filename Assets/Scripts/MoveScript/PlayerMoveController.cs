using UnityEngine;

namespace GeekSpace
{
    public class PlayerMoveController : IExecute
    {
        private Quaternion _shipDefaultRotation;
        private PlayerModel _playerModel;

        public void Start()
        {
            _shipDefaultRotation = _playerModel.localRotation;
        }

        public void Move() { }
    }
}