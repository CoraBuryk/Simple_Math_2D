using System;
using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class TimerController : MonoBehaviour
    {
        public float TimeLeft { get; set; }
        public event Action TimerChange;

        private GeneratorBehavior _generator;
        private HealthController _health;
        private Bonus _bonus;

        private void Awake()
        {
            _health = GetComponent<HealthController>();
            _generator = GetComponent<GeneratorBehavior>();
            _bonus = GetComponent<Bonus>();
        }

        public IEnumerator StartTimer()
        {
            TimerSwitch();
            while (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                _bonus.TimeBonus = TimeLeft;
                TimeZero();
                TimerChange?.Invoke();
                yield return null;
            }
        }

        public void TimeZero()
        {
            if (TimeLeft < 0)
            {
                TimerSwitch();
                _generator.GetQuestionForLevelOne();
                _health.HeartControl();
            }
        }

        public void TimerSwitch()
        {
            TimeLeft = 15f;
        }
    }
}
