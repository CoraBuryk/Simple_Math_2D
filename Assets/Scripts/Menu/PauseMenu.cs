using Assets.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _mainObj;
        [SerializeField] private GameObject _pauseObj;
        [SerializeField] private GameplayController _controller;
        [SerializeField] private MenuAnimator _mainScript;
        [SerializeField] private GeneralTimeController _generalTimeController;

        public bool IsOpened { get; private set; } = false;
        public bool buttonContinueIsPress { get; set; } = false;
        public bool buttonExitIsPress { get; set; } = false;
        public bool buttonRestartIsPress { get; set; } = false;

        private void Awake()
        {
            _continueButton.onClick.AddListener(() => ContinueGame());
            _exitButton.onClick.AddListener(() => ExitGame());
            _restartButton.onClick.AddListener(() => RestartGame());
        }

        public void ContinueGame()
        {
            _pauseObj.SetActive(IsOpened);
            _mainObj.SetActive(!IsOpened);
            _controller.Continue();
            buttonContinueIsPress = true;
            _mainScript.ForContinue();
        }
        public void RestartGame()
        {
            _pauseObj.SetActive(IsOpened);
            _mainObj.SetActive(!IsOpened);
            _controller.Restart();
            buttonRestartIsPress = true;
            _mainScript.ForRestart();
            _generalTimeController.SwitchToZero();
        }

        public void ExitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
