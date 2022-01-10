using UnityEngine;

namespace GeekSpace
{
    public class PlayerProvider : MonoBehaviour
    {
        private IModel _playerModel;

        internal IModel PlayerModel
        {
            get { return _playerModel; }
            set { value = _playerModel; }
        }

        private void Awake()
        {

        }

        void OnBecameInvisible()
        {

        }

        void OnTriggerEnter()
        {

        }

        private void OnDisable()
        {
            
        }

    }
}

