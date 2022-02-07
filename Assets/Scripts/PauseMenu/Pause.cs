using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekSpace
{
    public class Pause : MonoBehaviour
    {
        public GameObject _menuPausedUI;
        public GameObject _LooseMenu;

        public Button _buttonPause;
        public static bool gameIsPaused;

        private void Start()
        {
            _buttonPause.onClick.AddListener(Paused);
            _menuPausedUI.SetActive(false);
            _LooseMenu.SetActive(false);
        }
        public void ShowLooseMenu()
        {
            _LooseMenu.SetActive(true);
            Time.timeScale = 0f;
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

            Time.timeScale = 0f;
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
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
