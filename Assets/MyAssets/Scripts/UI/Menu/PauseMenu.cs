using Assets.MyAssets.Scripts.Gameplay;
using Assets.MyAssets.Scripts.UI.Menu.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.MyAssets.Scripts.UI.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _settings;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private MainMenuAnimations _mainAnimations;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(ContinueGame);
            _exitButton.onClick.AddListener(ExitGame);
            _restartButton.onClick.AddListener(RestartGame);
            _settings.onClick.AddListener(GameSettings);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(ContinueGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            _restartButton.onClick.RemoveListener(RestartGame);
            _settings.onClick.RemoveListener(GameSettings);
        }

        public void PauseGame()
        {
            _pausePanel.SetActive(!_isOpened);
            _mainPanel.SetActive(_isOpened);
            _gameplayController.Pause();
            _mainAnimations.ForPause();
        }

        private void ContinueGame()
        {
            _pausePanel.SetActive(_isOpened);
            _mainPanel.SetActive(!_isOpened);
            _gameplayController.Continue();
            _mainAnimations.ForMain();
        }

        private void RestartGame()
        {
            _pausePanel.SetActive(_isOpened);
            _mainPanel.SetActive(!_isOpened);
            _gameplayController.Restart();
            _mainAnimations.ForRestart();
        }

        private void GameSettings()
        {
            _pausePanel.SetActive(_isOpened);
            _settingsPanel.SetActive(!_isOpened);
            _mainAnimations.ForSettings();
        }

        private void ExitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            _mainAnimations.KillAnimations();
        }
    }
}
