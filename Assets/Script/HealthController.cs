using System;
using UnityEngine;

namespace Assets.Script
{
    public class HealthController : MonoBehaviour
    {
        public int NumOfHeart { get; set; } = 3;
        public event Action HealthControl;

        private Difficulty _difficulty;

        private void Awake()
        {
            _difficulty = GetComponent<Difficulty>();  
        }

        public void HeartControl()
        {
            //if(NumOfHeart <=3)
            NumOfHeart--;

            if (NumOfHeart == 0)
            {
                NumOfHeart = 3;
                _difficulty.RestartDifficulty();
            }

            HealthControl?.Invoke();
        }
    }
}
