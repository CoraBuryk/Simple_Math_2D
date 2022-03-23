using System;
using UnityEngine;

namespace Assets.Script
{
    public class GameplayControl : MonoBehaviour
    {
        private GeneratorBehavior _generatorBehavior;
        private Difficulty _difficulty;
        private Bonus _bonus;
        private ScoreCounter _score;
        private HealthController _health;
        private TimerController _timer;

        private void Awake()
        {
            _difficulty = GetComponent<Difficulty>();
            _bonus = GetComponent<Bonus>();
            _health = GetComponent<HealthController>();
            _generatorBehavior = GetComponent<GeneratorBehavior>();
            _timer = GetComponent<TimerController>();
            _score = GetComponent<ScoreCounter>();
        }

        public void AnswerButton(int index)
        {
            if (_generatorBehavior.ButtonText[index].text.ToString() == _generatorBehavior.Total.ToString())
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
            _bonus.ScoreUpdate();
            _difficulty.Variation();
            _timer.TimerSwitch();
        }

        public void AnswerWrong()
        {
            _score.ChangeScore(0);
            _timer.TimerSwitch();
            _health.HeartControl();
            _generatorBehavior.GetQuestionForLevelOne();
            _difficulty.RestartDifficulty();
        }
    }
}
