using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekSpace
{
    public class SceneManagment : MonoBehaviour
    {

        public AudioMixer _audioMixer;
        Resolution[] _resolutionsArray;
        List<string> _resolutionsStringList;
        public Dropdown _resolutionDropDown;
        public Dropdown _qualityDropDown;
        public Slider _sliderAudio;
        public Animator _animator;
        public void Awake()
        {
            _resolutionsStringList = new List<string>();
            _resolutionsArray = Screen.resolutions;
            foreach (var i in _resolutionsArray)
            {
                _resolutionsStringList.Add(i.width + "x" + i.height);
            }
            _resolutionDropDown.ClearOptions();
            _resolutionDropDown.AddOptions(_resolutionsStringList);
        }

        public void ShowMenu()
        {
            var menuOpen = _animator.GetBool(SceeneConstManager.SETTING_MENU_TRIGGER);
            if (menuOpen)
            {
                _animator.SetBool(SceeneConstManager.SETTING_MENU_TRIGGER, false);
              
            }


            else
            {
                _animator.SetBool(SceeneConstManager.SETTING_MENU_TRIGGER, true);
                
            }

            _animator.gameObject.transform.SetAsLastSibling();
        }

        public void AudioVolume()
        {
            _audioMixer.SetFloat(SceeneConstManager.AUDIO_MIXER_VOLUME_LABEL, _sliderAudio.value);
        }

        public void Resolution()
        {

            Screen.SetResolution(_resolutionsArray[_resolutionDropDown.value].width, _resolutionsArray[_resolutionDropDown.value].height, true);
        }
        public void Quality()
        {
            QualitySettings.SetQualityLevel(_qualityDropDown.value, true);
        }

        public void PlayPressed()
        {
            SceneManager.LoadScene(SceeneConstManager.MAIN_SCENE_NAME);
        }

        public void ExitPressed()
        {
            Application.Quit();
        }
    }
}