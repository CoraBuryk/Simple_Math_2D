using Assets.Scripts.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private LevelController _level;
        [SerializeField] private ScoreCounter _score;
        [SerializeField] private HealthController _health;
        [SerializeField] private Button[] _buttons;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private GameOverMenu _gameOverScript;   

        private void Awake()
        {
            _buttons[0].onClick.AddListener(() => AnswerButton(1));
            _buttons[1].onClick.AddListener(() => AnswerButton(2));
            _buttons[2].onClick.AddListener(() => AnswerButton(3));
        }

        private void Start()
        {
            StartCoroutine(_timerController.StartTimer());
        }

        private void OnEnable()
        {
            _timerController.TimerChange += TimeZero;
        }

        private void OnDisable()
        {
            _timerController.TimerChange -= TimeZero;
        }

        public void AnswerButton(int answer)
        {
            if (answer == _level.Total)
            {
                AnswerRight();
            }
            else
            {
                AnswerWrong();
            }
        }

        public void AnswerRight()
        {
            ScoreUpdate();
            _level.LevelUp(_level.Level);
            _timerController.TimerSwitch(1);
        }

        public void AnswerWrong()
        {
            _timerController.TimerSwitch(1);
            _health.HealthDecreased();
            _level.LevelUp(0);
            OutOfHearts();
        }

        public void ScoreUpdate()
        {
            if (_timerController.TimeLeft > 10)
            {
                _score.ChangeScore(_score.Counter += 2);
            }
            else if (_timerController.TimeLeft <= 10)
            {
                _score.ChangeScore(_score.Counter += 1);
            }
        }

        public void TimeZero()
        {
            if (_timerController.TimeLeft <= 0)
            {
                _timerController.TimerSwitch(1);
                _level.LevelUp(0);
                _health.HealthDecreased();
                OutOfHearts();
            }
        }

        public void OutOfHearts()
        { 
            if(_health.NumOfHeart == 0)
            {
                _timerController.TimerSwitch(0);
                _gameOverScript.End();
            }
        }

        public void Restart()
        {
            _level.LevelUp(0);
            _health.ResetHealth();
            _timerController.TimerSwitch(1);
            _score.ChangeScore(0);
        }

        public void Continue()
        {
            _level.LevelUp(_level.Level);
            _health.HealthDecreased();
            _timerController.TimerSwitch(1);
            OutOfHearts();
        }

        public void Pause()
        {
            _timerController.TimerSwitch(0);
        }
    }
}
