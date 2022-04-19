using Assets.MyAssets.Scripts.UI.Audio;
using Assets.MyAssets.Scripts.UI.Menu;
using Assets.MyAssets.Scripts.UI.Menu.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyAssets.Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private Button[] _buttonsAnswer;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private AudioEffects _audioEffects;
        [SerializeField] private MainMenuAnimations _mainMenuAnimations;

        private void Start()
        {
            StartCoroutine(_timerController.StartTimer());
            _timerController.ResetTotalTime();
        }

        private void OnEnable()
        {
            _mainMenuAnimations.ForMain();
            _timerController.TimerChange += TimeZero;

            _buttonsAnswer[0].onClick.AddListener(() => AnswerButton(1));
            _buttonsAnswer[1].onClick.AddListener(() => AnswerButton(2));
            _buttonsAnswer[2].onClick.AddListener(() => AnswerButton(3));
        }

        private void OnDisable()
        {
            _timerController.TimerChange -= TimeZero;

            _buttonsAnswer[0].onClick.RemoveListener(() => AnswerButton(1));
            _buttonsAnswer[1].onClick.RemoveListener(() => AnswerButton(2));
            _buttonsAnswer[2].onClick.RemoveListener(() => AnswerButton(3));
        }

        private void AnswerButton(int answer)
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
            _levelController.FirstLevel();
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
                _healthController.HealthDecreased();
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
            _scoreCounter.SaveHighScore();
            _timerController.TimerSwitch(0);
        }
    }
}
