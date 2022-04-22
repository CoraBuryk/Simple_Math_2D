using System;
using UnityEngine;

namespace SimpleMath_2D.Scripts.Gameplay
{
    public class ScoreCounter : MonoBehaviour
    {
        public int Counter { get; set; }

        public int HighScore { get; set; }

        public event Action ScoreChange;

        public void ChangeScore(int newScore)
        {
            Counter = newScore;
            ScoreChange?.Invoke();
        }
    }
}