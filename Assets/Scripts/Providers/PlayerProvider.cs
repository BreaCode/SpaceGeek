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
            set 
            { 
                _playerModel = value;
                _playerModel.Object = gameObject;
            }
        }

        void OnBecameInvisible()
        {
            GameEventSystem.current.GoingBeyondScreen(_playerModel);
        }

        void OnTriggerEnter2D()
        {
            var sceneManagment = FindObjectOfType<Pause>();
            sceneManagment.ShowLooseMenu();
            Destroy(this.gameObject);
        }


    }
}

