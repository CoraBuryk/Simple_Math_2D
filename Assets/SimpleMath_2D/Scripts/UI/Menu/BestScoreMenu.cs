using SimpleMath_2D.Scripts.Gameplay;
using SimpleMath_2D.Scripts.UI.Menu.Animations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleMath_2D.Scripts.UI.Menu
{
    public class BestScoreMenu : MonoBehaviour
    {
        [SerializeField] private PlayerPref _playerPref;
        [SerializeField] private Button _backButton;
        [SerializeField] private GameObject _startScenePanel;
        [SerializeField] private GameObject _bestScorePanel;
        [SerializeField] private StartMenuAnimations _startMenuAnimations;
        [SerializeField] public TextMeshProUGUI _bestScore;

        private bool _isOpened = false;

        private void Awake()
        {
            _playerPref.LoadScore();
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(Back);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(Back);
        }

        private void Back()
        {
            _startScenePanel.SetActive(!_isOpened);
            _bestScorePanel.SetActive(_isOpened);
            _startMenuAnimations.ForBack();
        }
    }
}
