using SimpleMath_2D.Scripts.UI.Audio;
using SimpleMath_2D.Scripts.UI.Menu;
using SimpleMath_2D.Scripts.UI.Menu.Animations;
using UnityEngine;

namespace SimpleMath_2D.Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private AudioEffects _audioEffects;
        [SerializeField] private MainMenuAnimations _mainMenuAnimations;
        [SerializeField] private PlayerPref _playerPref;

        private void Start()
        {
            StartCoroutine(_timerController.StartTimer());
            _timerController.ResetTotalTime();
        }

        private void OnEnable()
        {
            _mainMenuAnimations.ForMain();
            _timerController.TimerChange += TimeZero;
        }

        private void OnDisable()
        {
            _timerController.TimerChange -= TimeZero;
        }

        public void AnswerButton(int answer)
        {
            if (answer == _levelController.Total)
            {               
                AnswerRight();
            }
            else
            {
                AnswerWrong();
            }
        }

        private void AnswerRight()
        {
            _audioEffects.PlayOnRight();
            ScoreUpdate();
            _levelController.LevelUp();
            _levelController.SetExample();
            _timerController.TimerSwitch(1);
            
        }

        private void AnswerWrong()
        {            
            _audioEffects.PlayOnWrong();
            _timerController.TimerSwitch(1);
            _healthController.HealthDecreased();
            _levelController.LevelUp();
            _levelController.SetExample();
        }

        private void ScoreUpdate()
        {
            if (_timerController.TimeLeft > 10)
            {
                _scoreCounter.ChangeScore(_scoreCounter.Counter += 2);
            }
            else if (_timerController.TimeLeft <= 10)
            {
                _scoreCounter.ChangeScore(_scoreCounter.Counter += 1);
            }
        }

        public void TimeZero()
        {
            if (_timerController.TimeLeft <= 0)
            {
                _timerController.TimerSwitch(1);
                _levelController.FirstLevel();
                _levelController.SetExample();
            }
        }

        public void Restart()
        {
            _levelController.FirstLevel();
            _levelController.SetExample();
            _healthController.ResetHealth();
            _timerController.TimerSwitch(1);
            _scoreCounter.ChangeScore(0);
            _timerController.ResetTotalTime();
        }

        public void Continue()
        {
            _levelController.SetExample();
            _timerController.TimerSwitch(1);
            _timerController.OpenedPauseTime();
            _timerController.IsPaused = false;
        }

        public void Pause()
        {
            _timerController.TimerSwitch(0);
            _timerController.ActivePause();
            _timerController.IsPaused = true;
        }

        public void Over()
        {
            _timerController.ActiveGameTime();
            _playerPref.SaveHighScore();
            _timerController.TimerSwitch(0);
        }
    }
}
