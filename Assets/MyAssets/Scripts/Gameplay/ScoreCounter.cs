using System;
using UnityEngine;

namespace Assets.MyAssets.Scripts.Gameplay
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

        public void SaveHighScore()
        {
            if (Counter > HighScore)
            {
                HighScore = Counter;
            }
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
    }
}