using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class GameOverScript : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;
        [SerializeField] private Canvas _main;
        [SerializeField] private Canvas _startCanvas;
        [SerializeField] private Canvas _gameOverCanvas;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private GameplayController _controller;
        [SerializeField] private MainMenuScript _mainScript;

        public bool IsOpened { get; private set; } = false;
        public bool buttonRestartIsPress { get; set; } = false;
        public bool buttonExitIsPress { get; set; } = false;

        private void Awake()
        {
            _restart.onClick.AddListener(() => RestartGame());
            _exit.onClick.AddListener(() => ExitGame());
            _main.GetComponent<Canvas>().enabled = IsOpened;
        }

        private void OnEnable()
        {
            _scoreCounter.ScoreChange += FinalScore;
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreChange -= FinalScore;
        }

        public void FinalScore()
        {
            _score.text = $"Your score: {_scoreCounter.Counter}";
        }

        public void RestartGame()
        {
            _gameOverCanvas.GetComponent<Canvas>().enabled = IsOpened;
            _main.GetComponent<Canvas>().enabled = !IsOpened;
            _controller.Restart();
            buttonRestartIsPress = true;
            _mainScript.GetComponent<MainMenuScript>().ForRestart();
        }

        public void ExitGame()
        {
            _startCanvas.GetComponent<Canvas>().enabled = !IsOpened;
            _gameOverCanvas.GetComponent<Canvas>().enabled = IsOpened;
            _controller.ForExit();
            buttonExitIsPress = true;
            _mainScript.GetComponent<MainMenuScript>().ForExit();
        }

        public void End()
        {
            _main.GetComponent<Canvas>().enabled = IsOpened;
            _gameOverCanvas.GetComponent<Canvas>().enabled = !IsOpened;
            _mainScript.GetComponent<MainMenuScript>().ForOver();
        }
    }
}
