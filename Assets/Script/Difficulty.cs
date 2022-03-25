using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class Difficulty : MonoBehaviour
    {
        [SerializeField] private float _difficultyUp;
        private GeneratorBehavior _generator;

        private void Awake()
        {
            _generator = GetComponent<GeneratorBehavior>();
        }
        public IEnumerator Difficlty()
        {
            while (_difficultyUp > 0)
            {
                _difficultyUp -= Time.deltaTime;
                yield return null;
            }
        }

        public void Variation()
        {
            StartCoroutine(Difficlty());
            if (_difficultyUp > 30_000f)
            {
                _generator.GetQuestionForLevelOne();
            }
            else if (_difficultyUp < 30_000f && _difficultyUp > 25_000f)
            {
                _generator.GetQuestionForLevelTwo();
            }
            else if (_difficultyUp < 25_000f && _difficultyUp > 15_000f)
            {
                _generator.GetQuestionForLevelThree();
            }
            else
            {
                _generator.GetQuestionForLevelFour();
            }
        }

        public void RestartDifficulty()
        {
             _generator.GetQuestionForLevelOne();
             if (_difficultyUp < 35_000f)
             _difficultyUp = 35_000f;
             StartCoroutine(Difficlty());
        }
    }
}
