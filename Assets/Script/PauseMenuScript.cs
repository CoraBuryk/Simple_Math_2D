using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class PauseMenuScript : MonoBehaviour
    {
        [SerializeField] private Button _continue;
        [SerializeField] private Button _exit;
        [SerializeField] private Canvas _main;
        [SerializeField] private Canvas _startCanvas;
        [SerializeField] private Canvas _pauseCanvas;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private GameplayController _controller;
        [SerializeField] private MainMenuScript _mainScript;

        public bool IsOpened { get; private set; } = false;
        public bool buttonContinueIsPress { get; set; } = false;
        public bool buttonExitIsPress { get; set; } = false;

        private void Awake()
        {
            _continue.onClick.AddListener(() => ContinueGame());
            _exit.onClick.AddListener(() => ExitGame());
            _main.GetComponent<Canvas>().enabled = IsOpened;
        }

        public void ContinueGame()
        {
            _pauseCanvas.GetComponent<Canvas>().enabled = IsOpened;
            _main.GetComponent<Canvas>().enabled = !IsOpened;
            _timerController.StopTimer(1);
            buttonContinueIsPress = true;
            _mainScript.GetComponent<MainMenuScript>().ForContinue();
        }

        public void ExitGame()
        {
            _startCanvas.GetComponent<Canvas>().enabled = !IsOpened;
            _pauseCanvas.GetComponent<Canvas>().enabled = IsOpened;
            _controller.ForExit();
            buttonExitIsPress = true;
            _mainScript.GetComponent<MainMenuScript>().ForExit();
        }
    }
}
