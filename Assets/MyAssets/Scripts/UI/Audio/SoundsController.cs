using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.MyAssets.Scripts.UI.Audio
{
    public class SoundsController : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _masterGroup;
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Toggle _muteToggle;

        private void OnEnable()
        {
            _muteToggle.onValueChanged.AddListener(ToggleMute);
            _volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        private void OnDisable()
        {
            _muteToggle.onValueChanged.RemoveListener(ToggleMute);
            _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey("MasterVolume"))
            {
                PlayerPrefs.SetFloat("MasterVolume", 1);
                Load();
            }
            else
                Load();

        }

        private void ChangeVolume(float volume)
        {
            AudioListener.volume = _volumeSlider.value;
            Save();
        }

        private void Load()
        {
            _volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("MasterVolume", _volumeSlider.value);
        }

        private void ToggleMute(bool mute)
        {
            mute = _muteToggle.isOn;
            if(mute == true)
                _masterGroup.audioMixer.SetFloat("MasterVolume", -80);
            else 
                _masterGroup.audioMixer.SetFloat("MasterVolume", 0);
        }
    }
}
