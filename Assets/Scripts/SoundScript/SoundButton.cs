using UnityEngine;

public class SoundButton// : MonoBehaviour
{
    private GameObject _soundTarget;
    private GameObject _soundClick;
    private AudioSource _soundClickAudio;
    private AudioSource _soundTargetAudio;

    public SoundButton ()
    {
        _soundTarget= GameObject.Find("SoundTarget");
        _soundClick= GameObject.Find("SoundClic");
        _soundClickAudio = _soundClick.GetComponent<AudioSource>();
        _soundTargetAudio = _soundTarget.GetComponent<AudioSource>();
    }
    public void SoundTarget()
    {
        _soundTargetAudio.Play();
    }
    public void SoundClick()
    {
        _soundClickAudio.Play();
    }
}
