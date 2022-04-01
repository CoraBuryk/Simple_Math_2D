using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private GeneratorBehavior _generatorBehavior;
        [SerializeField] private LevelController _level;
        [SerializeField] private ScoreCounter _score;
        [SerializeField] private HealthController _health;
        [SerializeField] private TimerController _timer;
        [SerializeField] private Button[] _buttons;
        [SerializeField] private Canvas _gameOverCanvas;
        [SerializeField] private Canvas _main;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private GameOverScript _gameOverScript;

        private void Awake()
        {
            _buttons[0].onClick.AddListener(() => AnswerButton(0));
            _buttons[1].onClick.AddListener(() => AnswerButton(1));
            _buttons[2].onClick.AddListener(() => AnswerButton(2));           
        }

        private void OnEnable()
        {
            _timerController.TimerChange += TimeZero;
        }

        private void OnDisable()
        {
            _timerController.TimerChange -= TimeZero;
        }

        public void AnswerButton(int index)
        {
            if (_generatorBehavior._buttonText[index].text.ToString() == _generatorBehavior.Total.ToString())
            {
                AnswerRight();
            }
            else
            {
                AnswerWrong();
            }
            OutOfHearts();
        }

        public void AnswerRight()
        {
            ScoreUpdate();
            _level.LevelUp();
            _timer.TimerSwitch();
        }

        public void AnswerWrong()
        {
            _timer.TimerSwitch();
            _health.HealthDecreased();
            _generatorBehavior.GetQuestionForLevelOne();
            _level.RestartLevel();
        }

        public void ScoreUpdate()
        {
            if (_timer.TimeBonus > 10)
            {
                _score.ChangeScore(_score.Counter += 2);
            }
            else if (_timer.TimeBonus <= 10)
            {
                _score.ChangeScore(_score.Counter += 1);
            }
        }

        public void TimeZero()
        {
            if (_timer.TimeLeft <= 0)
            {
                _timer.TimerSwitch();
                _generatorBehavior.GetQuestionForLevelOne();
                _health.HealthDecreased();
            }
        }

        public void OutOfHearts()
        { 
            if(_health.NumOfHeart == 0)
            {
                _timerController.StopTimer(0);
                _gameOverScript.End();
            }
        }

        public void Restart()
        {
            _level.RestartLevel();
            _health.ResetHealth();
            _timer.TimerSwitch();
            _score.ChangeScore(0);
            _timerController.StopTimer(1);
        }

        public void ForExit()
        {
            _level.RestartLevel();
            _health.ResetHealth();
            _timer.TimerSwitch();
            _score.ChangeScore(0);
            _timerController.StopTimer(0);
        }
    }
}
