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
            GameEventSystem.current.onGoingBeyondScreen += GoingBeyondScreen;
        }

        void OnBecameInvisible()
        {
            GameEventSystem.current.GoingBeyondScreen();
        }

        void OnTriggerEnter()
        {

        }

        private void OnDisable()
        {
            GameEventSystem.current.onGoingBeyondScreen -= GoingBeyondScreen;
        }

        private void GoingBeyondScreen()
        {

        }

    }
}

