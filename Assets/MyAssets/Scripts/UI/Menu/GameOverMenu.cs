using Assets.MyAssets.Scripts.Gameplay;
using Assets.MyAssets.Scripts.UI.Audio;
using Assets.MyAssets.Scripts.UI.Menu.Animations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.MyAssets.Scripts.UI.Menu
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _scoreBest;
        [SerializeField] private TextMeshProUGUI _time;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private MainMenuAnimations _mainAnimations;
        [SerializeField] private AudioEffects _audioEffects;

        private bool _isOpened = false;
        private int _previousHighScore;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
        }

        private void FinalScore()
        {
            _score.text = $"Your score: {_scoreCounter.Counter}";
        }

        private void TotalTime()
        {
            int seconds = Mathf.FloorToInt(_timerController.GameTime % 60);
            int minutes = Mathf.FloorToInt(_timerController.GameTime / 60);

            string min = (minutes < 10) ? "" + minutes.ToString() : minutes.ToString();
            string sec = (seconds < 59) ? "" + seconds.ToString() : seconds.ToString();

            _time.text = string.Format($"Total time: {min} min {sec} sec");
        }

        private void BestScore()
        {   
            _scoreBest.enabled = false;
            if (_previousHighScore < _scoreCounter.HighScore)
            {
                _scoreBest.enabled = true;
                _scoreBest.text = $"New Best Score: {_scoreCounter.HighScore}";
                _audioEffects.PlayOnBestScore();
                _previousHighScore = _scoreCounter.HighScore;
            }
        }

        private void RestartGame()
        {
            _gameOverPanel.SetActive(_isOpened);
            _mainPanel.SetActive(!_isOpened);
            _gameplayController.Restart();
            _mainAnimations.ForRestart();
        }

        private void ExitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            _mainAnimations.KillAnimations();
        }

        public void End()
        {
            _mainPanel.SetActive(_isOpened);
            _gameOverPanel.SetActive(!_isOpened);
            _mainAnimations.ForOver(); 
            _gameplayController.Over();
            BestScore();
            TotalTime();
            FinalScore();
        }
    }
}
