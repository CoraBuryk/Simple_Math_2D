using SimpleMath_2D.Scripts.UI.Menu.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SimpleMath_2D.Scripts.UI.Menu
{
    public class StartSceneMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _scoreButton;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private GameObject _scorePanel;
        [SerializeField] private StartMenuAnimations _startMenuAnimations;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);
            _settingsButton.onClick.AddListener(Settings);
            _scoreButton.onClick.AddListener(ScoreList);
            _startMenuAnimations.ForStart();
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            _settingsButton.onClick.RemoveListener(Settings);
            _scoreButton.onClick.RemoveListener(ScoreList);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            _startMenuAnimations.KillAnimations();
        }

        private void Settings()
        {
            _startMenuAnimations.ForSettings();
            _settingsPanel.SetActive(!_isOpened);
            _startPanel.SetActive(_isOpened);
        }

        private void ScoreList()
        {
            _scorePanel.SetActive(!_isOpened);
            _startPanel.SetActive(_isOpened);
            _startMenuAnimations.ForScore();
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
