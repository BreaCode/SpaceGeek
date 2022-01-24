using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekSpace
{
    public class Pause : SceneManagment
    {
        public GameObject _menuPausedUI;
        public Button _buttonPause;
        public static bool gameIsPaused;
        public Button _buttonSettings;
        public GameObject _menuSettingsUI;

        private void Start()
        {
            _buttonPause.onClick.AddListener(Paused);
            _buttonSettings.onClick.AddListener(Settings);
        }

        public void Resume()
        {
            _menuPausedUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        void Paused()
        {
            _menuPausedUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenuScene");
        }

        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void Settings()
        {
            _menuSettingsUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }
}
