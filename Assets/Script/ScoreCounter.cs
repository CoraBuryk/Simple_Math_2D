using System;
using UnityEngine;

namespace Assets.Script
{
    public class ScoreCounter : MonoBehaviour
    {
        public int Counter { get; set; }

        public event Action ScoreChange; 

        public void ChangeScore(int newScore)
        {
            Counter = newScore;
            ScoreChange?.Invoke();
        }
    }
}
