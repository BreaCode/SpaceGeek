using UnityEngine;

namespace GeekSpace
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PlayerProvider : MonoBehaviour
    {
        private PlayerModel _playerModel;

        internal PlayerModel PlayerModel
        {
            get { return _playerModel; }
            set { _playerModel = value; }
        }


        void OnBecameInvisible()
        {
            Debug.Log("�� ���������");
            GameEventSystem.current.GoingBeyondScreen(_playerModel);
        }

        void OnTriggerEnter()
        {

        }


    }
}

