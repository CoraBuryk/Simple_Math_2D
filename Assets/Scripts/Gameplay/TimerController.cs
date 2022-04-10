using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private GameplayController _gameplayControl;
        [SerializeField] private int _timer;
        [SerializeField] private int _delta = 0;

        public int TimeLeft { get; private set; }

        public event Action TimerChange;

        private void Awake()
        {
            TimerSwitch(1);
        }

        public IEnumerator StartTimer()
        {
            while (TimeLeft > 0)
            {
                TimeLeft -= _delta;
                TimerChange?.Invoke();
                yield return new WaitForSeconds(1);
            }
        }

        public void TimerSwitch(int delta)
        {
            TimeLeft = _timer;
            _delta = delta;
        }
    }
}