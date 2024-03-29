﻿using System;
using System.Collections;
using UnityEngine;

namespace SimpleMath_2D.Scripts.Gameplay
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private int _timer; 

        public int TimeLeft { get; private set; }
        public float GameTime;
        public float ActiveTime;
        public bool IsPaused { get; set; } = false;

        private int _delta = 0;
        public float _activeTimeForPause;
        public float _pausedTime;

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

        public void ActiveGameTime()
        {
            GameTime = Time.timeSinceLevelLoad - ActiveTime - _pausedTime;
        }

        public void ActivePause() 
        {
            _activeTimeForPause = Time.timeSinceLevelLoad;
        }

        public void OpenedPauseTime()
        {
            if (IsPaused == true)
            {
                float margin = Time.timeSinceLevelLoad - _activeTimeForPause;
                _pausedTime += margin;
            }
        }

        public void ResetTotalTime()
        {
            GameTime = 0;
            ActiveTime = Time.timeSinceLevelLoad;
            _activeTimeForPause = 0;
            _pausedTime = 0;
        }
    }
}