using SimpleMath_2D.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleMath_2D.Scripts.UI.Menu
{
    public class SceenBehavior : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private HealthController _healthController;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(_pauseMenu.PauseGame);
            _healthController.HealthChange += ZeroHealth;
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(_pauseMenu.PauseGame);
            _healthController.HealthChange -= ZeroHealth;
        }

        public void ZeroHealth()
        {
            if(_healthController.NumOfHeart <= 0)
            _gameOverMenu.End();
        }
    }
}
