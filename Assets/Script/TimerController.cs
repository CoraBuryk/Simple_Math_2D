using System;
using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private GameplayController _gameplayControl;

        public float TimeLeft { get; private set; }
        public float TimeBonus { get; set; } = 0;

        public event Action TimerChange;

        private int _delta = 0;

        public IEnumerator StartTimer()
        {
            TimerSwitch();
            while (TimeLeft > 0)
            {
                TimeLeft -= _delta;
                TimeBonus = TimeLeft;
                TimerChange?.Invoke();
                _gameplayControl.TimeZero();
                yield return new WaitForSeconds(1);
            }
        }

        public void StopTimer(int delta)
        {
            _delta = delta;
        }

        public void TimerSwitch()
        {
            TimeLeft = 15;
        }
    }
}