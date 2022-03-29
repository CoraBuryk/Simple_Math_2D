using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class OpenPauseMenuScript : MonoBehaviour
    {
        [SerializeField] private Button _pause;
        [SerializeField] private Canvas _main;
        [SerializeField] private Canvas _pauseCanvas;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private MainMenuScript _mainScript;

        public bool buttonIsPress { get; set; } = false;
        public bool IsOpened { get; private set; } = false;

        private void Awake()
        {
            _pause.onClick.AddListener(() => PauseGame());
        }

        public void PauseGame()
        {
            _pauseCanvas.GetComponent<Canvas>().enabled = !IsOpened;
            _main.GetComponent<Canvas>().enabled = IsOpened;
            _timerController.StopTimer(0);
            buttonIsPress = true;
            _mainScript.GetComponent<MainMenuScript>().ForPause();
        }
    }
}
