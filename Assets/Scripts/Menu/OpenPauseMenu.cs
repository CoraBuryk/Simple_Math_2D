using Assets.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class OpenPauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _mainObj;
        [SerializeField] private GameObject _pauseObj;
        [SerializeField] private MenuAnimator _menuAnimator;
        [SerializeField] private GameplayController _gameplayController;

        public bool buttonIsPress { get; set; } = false;
        public bool IsOpened { get; private set; } = false;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(() => PauseGame());
        }

        public void PauseGame()
        {
            _pauseObj.SetActive(!IsOpened);
            _mainObj.SetActive(IsOpened);
            _gameplayController.Pause();
            buttonIsPress = true;
            _menuAnimator.ForPause();
        }
    }
}
