using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GeneralTimeController : MonoBehaviour
    {
        public int TotalTime;

        public event Action TimerChange;

        private int _delta = 1;


        private void Start()
        {
            StartCoroutine(TimeCounter());
        }

        public IEnumerator TimeCounter()
        {
            while (TotalTime >= 0)
            {
                TotalTime += _delta;
                TimerChange?.Invoke();
                yield return new WaitForSeconds(1);
            }
        }

        public void DeltaController(int delta)
        {
            _delta = delta;
        }

        public void SwitchToZero()
        {
            TotalTime = 0;
        }
    }
}
