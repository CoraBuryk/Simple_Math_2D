using SimpleMath_2D.Scripts.UI.Audio;
using SimpleMath_2D.Scripts.UI.Menu;
using UnityEngine;

namespace SimpleMath_2D.Scripts.Gameplay
{
    public class PlayerPref : MonoBehaviour
    {
        [SerializeField] private SoundsController _soundController;
        [SerializeField] private BestScoreMenu _bestScoreMenu;
        [SerializeField] private ScoreCounter _scoreCounter;

        public void LoadAudio()
        {
            _soundController.volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }

        public void SaveAudio()
        {
            PlayerPrefs.SetFloat("MasterVolume", _soundController.volumeSlider.value);
        }

        public void ChangeVolume(float volume)
        {
            AudioListener.volume = _soundController.volumeSlider.value;
            SaveAudio();
        }

        public void LoadScore()
        {
            if (PlayerPrefs.HasKey("HighScore"))
                _bestScoreMenu._bestScore.text = "Score:" + PlayerPrefs.GetInt("HighScore");
        }

        public void SaveHighScore()
        {
            if (_scoreCounter.Counter > _scoreCounter.HighScore)
            {
                _scoreCounter.HighScore = _scoreCounter.Counter;
            }
            PlayerPrefs.SetInt("HighScore", _scoreCounter.HighScore);
        }
    }
}
