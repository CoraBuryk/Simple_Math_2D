using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class StartMenuScript : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _exit;
        [SerializeField] private Canvas _main;
        [SerializeField] private Canvas _startCanvas;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private MainMenuScript _mainScript;

        public bool buttonIsPress { get; set; } = false;
        public bool IsOpened { get; private set; } = false;

        private void Awake()
        {
            _start.onClick.AddListener(() => StartGame());
            _exit.onClick.AddListener(() => ExitGame());
            _main.GetComponent<Canvas>().enabled = IsOpened;
        }

        public void StartGame()
        {
            _startCanvas.GetComponent<Canvas>().enabled = IsOpened;
            _main.GetComponent<Canvas>().enabled = !IsOpened;
            _timerController.StopTimer(1);
            buttonIsPress = true;
            _mainScript.GetComponent<MainMenuScript>().ForStart();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
