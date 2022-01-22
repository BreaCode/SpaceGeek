using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekSpace
{
    public class SceneManagment : MonoBehaviour
    {

        public UnityEngine.Audio.AudioMixer _audioMixer;
        Resolution[] resolutionsList;
        List<string> resolutions;
        public Dropdown ResolutionDropDown;
        public Dropdown QualityDropDown;
        public Slider sliderAudio;
        public Animator _animator;
        public void Awake()
        {
            resolutions = new List<string>();
            resolutionsList = Screen.resolutions;
            foreach (var i in resolutionsList)
            {
                resolutions.Add(i.width + "x" + i.height);
            }
            ResolutionDropDown.ClearOptions();
            ResolutionDropDown.AddOptions(resolutions);
        }

        public void ShowMenu()
        {
            var menuOpen = _animator.GetBool("IsOpenMenu");
            if (menuOpen) _animator.SetBool("IsOpenMenu", false);
            else _animator.SetBool("IsOpenMenu", true);
            _animator.gameObject.transform.SetAsLastSibling();
        }

        public void AudioVolume()
        {
            _audioMixer.SetFloat("Volume", sliderAudio.value);
        }

        public void Resolution()
        {

            Screen.SetResolution(resolutionsList[ResolutionDropDown.value].width, resolutionsList[ResolutionDropDown.value].height, true);
        }
        public void Quality()
        {
            QualitySettings.SetQualityLevel(QualityDropDown.value, true);
        }

        public void PlayPressed()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void ExitPressed()
        {
            Application.Quit();
        }
    }
}