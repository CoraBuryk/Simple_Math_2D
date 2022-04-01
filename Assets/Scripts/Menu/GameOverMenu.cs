using Assets.Scripts.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _mainObj;
        [SerializeField] private GameObject _gameOverObj;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _time;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private GameplayController _controller;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private MenuAnimator _mainScript;
        [SerializeField] private GeneralTimeController _generalTimeController;

        public bool IsOpened { get; private set; } = false;
        public bool buttonRestartIsPress { get; set; } = false;
        public bool buttonExitIsPress { get; set; } = false;

        private void Awake()
        {
            _restartButton.onClick.AddListener(() => RestartGame());
            _exitButton.onClick.AddListener(() => ExitGame());
        }

        private void OnEnable()
        {
            _scoreCounter.ScoreChange += FinalScore;
            _generalTimeController.TimerChange += TotalTime;
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreChange -= FinalScore;
            _generalTimeController.TimerChange -= TotalTime;
        }

        public void FinalScore()
        {
            _score.text = $"Your score: {_scoreCounter.Counter}";
        }

        public void TotalTime()
        {
            int seconds = Mathf.FloorToInt(_generalTimeController.TotalTime % 60);
            int minutes = Mathf.FloorToInt(_generalTimeController.TotalTime / 60);

            string min = (minutes < 10) ? "0" + minutes.ToString() : minutes.ToString();
            string sec = (seconds < 59) ? " " + seconds.ToString() : seconds.ToString();

                _time.text = string.Format($"Total time: {min}:{sec}");

        }

        public void RestartGame()
        {
            _gameOverObj.SetActive(IsOpened);
            _mainObj.SetActive(!IsOpened);
            _controller.Restart();
            buttonRestartIsPress = true;
            _mainScript.ForRestart();
            _generalTimeController.DeltaController(1);
            _generalTimeController.SwitchToZero();
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void End()
        {
            _mainObj.SetActive(IsOpened);
            _gameOverObj.SetActive(!IsOpened);
            _mainScript.ForOver();
            _generalTimeController.DeltaController(0);
            TotalTime();
            FinalScore();
        }
    }
}
