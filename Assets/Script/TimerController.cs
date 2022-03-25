using System;
using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private GameplayController _gameplayControl;

        public float TimeLeft { get; set; }

        public float TimeBonus { get; set; } = 0;

        public event Action TimerChange;

        public IEnumerator StartTimer()
        {
            TimerSwitch();
            while (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                TimeBonus = TimeLeft;
                _gameplayControl.TimeZero();
                TimerChange?.Invoke();
                yield return null;
            }
        }

        public void TimerSwitch()
        {
            TimeLeft = 15f;
        }
    }
}