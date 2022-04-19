using Assets.MyAssets.Scripts.Gameplay;
using Assets.MyAssets.Scripts.UI.Menu.Animations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyAssets.Scripts.UI.Menu
{
    public class BestScoreMenu : MonoBehaviour
    {
        public static ScoreCounter _scoreCounter;

        [SerializeField] private Button _backButton;
        [SerializeField] private GameObject _startScenePanel;
        [SerializeField] private GameObject _bestScorePanel;
        [SerializeField] private TextMeshProUGUI _bestScore;
        [SerializeField] private StartMenuAnimations _startMenuAnimations;

        private bool _isOpened = false;

        private void Awake()
        {
            Load();
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

        private void Load()
        {            
            if (PlayerPrefs.HasKey("HighScore"))
                _bestScore.text = "Score:" + PlayerPrefs.GetInt("HighScore");
        }
    }
}
