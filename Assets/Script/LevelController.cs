using UnityEngine;

namespace Assets.Script
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GeneratorBehavior _generator;

        private const int numbersOfExamplesForLvl1 = 5;
        private const int numbersOfExamplesForLvl2 = 10;
        private const int numbersOfExamplesForLvl3 = 15;
        private const int numbersOfExamplesForLvl4 = 25;
        private const int numbersOfExamplesForLvl5 = 35;
        private const int numbersOfExamplesForLvl6 = 55;
        private const int numbersOfExamplesForLvl7 = 75;

        public int Level { get; private set; }

        public void RestartLevel()
        {
             Level = 0;
        }

        public void LevelUp()
        {
            if (Level <= numbersOfExamplesForLvl1)
            {
                _generator.GetQuestionForLevelOne();
            }
            else if(Level <= numbersOfExamplesForLvl2)
            {
                _generator.GetQuestionForLevelTwo();
            }
            else if(Level <= numbersOfExamplesForLvl3)
            {
                _generator.GetQuestionForLevelThree();
            }
            else if(Level <= numbersOfExamplesForLvl4)
            {
                _generator.GetQuestionForLevelFour();
            }
            else if (Level <= numbersOfExamplesForLvl5)
            {
                _generator.GetQuestionForLevelFive();
            }
            else if(Level <= numbersOfExamplesForLvl6)
            {
                _generator.GetQuestionForLevelSix();
            }
            else if (Level <= numbersOfExamplesForLvl7)
            {
                _generator.GetQuestionForLevelSeven();
            }
            else
            {
                _generator.GetQuestionForLevelEight();
            }
            Level++;
        }
    }
}