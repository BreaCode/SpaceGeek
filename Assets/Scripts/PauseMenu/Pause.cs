using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekSpace
{
    public class Pause : MonoBehaviour
    {
        public GameObject _menuPausedUI;
        public Button _buttonPause;
        public static bool gameIsPaused;

        private void Start()
        {
            _buttonPause.onClick.AddListener(Paused);
            _menuPausedUI.SetActive(false);

        }

        public void Resume()
        {
            _menuPausedUI.SetActive(false);

            gameIsPaused = false;

            Time.timeScale = 1f;
        }

        public void Paused()
        {

            if (_menuPausedUI.activeSelf == true)
            {
                _menuPausedUI.SetActive(false);
            }
            else
            {
                _menuPausedUI.SetActive(true);
            }

            gameIsPaused = true;

            //var menu = FindObjectOfType<SceneManagment>();
            //menu.ShowMenu();

            ////_menuPausedUI.SetActive(true);
            Time.timeScale = 0f;
            ////gameIsPaused = true;
        }

        public void LoadMenu()
        {


            var menu = FindObjectOfType<SceneManagment>();
            menu.ShowMenu();
        }

        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void Exit()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
