using UnityEngine;

namespace Assets.Script
{
    public class Bonus : MonoBehaviour
    {
        public float TimeBonus { get; set; } = 0;

        private ScoreCounter _score;
        private void Awake()
        {
            _score = GetComponent<ScoreCounter>();
        }
        public void ScoreUpdate()
        {
            if (TimeBonus > 10)
            {
                _score.ChangeScore(_score.Counter += 2);
            }
            else if (TimeBonus <= 10)
            {
                _score.ChangeScore(_score.Counter += 1);
            }
        }
    }
}
