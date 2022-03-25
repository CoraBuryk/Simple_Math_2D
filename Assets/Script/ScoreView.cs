using TMPro;
using UnityEngine;

namespace Assets.Script
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;

        private ScoreCounter _scoreCounter;

        private void Awake()
        {
            _scoreCounter = GetComponent<ScoreCounter>();
            _scoreCounter.ScoreChange += HandleScoreDelegate; 
        }

        private void Start()
        {
           HandleScoreDelegate();
        }

        public void HandleScoreDelegate()
        {           
            score.text = $"Score:{_scoreCounter.Counter}";
        }
    }
}
