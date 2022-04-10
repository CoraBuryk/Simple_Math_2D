using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class LevelController : MonoBehaviour
    {
        private Numbers _numbers = new Numbers();

        public string ExampleText { get => _numbers.MathExample; private set => ExampleText = value; }
        public int Total { get => _numbers.Result; private set => Total = value; }
        public int Level { get; private set; }

        public event Action LevelChange;

        private const int numbersOfExamplesForLvl1 = 5;
        private const int numbersOfExamplesForLvl2 = 10;
        private const int numbersOfExamplesForLvl3 = 15;
        private const int numbersOfExamplesForLvl4 = 25;
        private const int numbersOfExamplesForLvl5 = 35;
        private const int numbersOfExamplesForLvl6 = 55;
        private const int numbersOfExamplesForLvl7 = 75;

        private void Awake()
        {
            LevelUp(0);
        }

        public void LevelUp(int lev)
        {
            Level = lev;
            if (Level <= numbersOfExamplesForLvl1)
            {
                _numbers.DoLevelOne();
            }
            else if(Level <= numbersOfExamplesForLvl2)
            {
                _numbers.DoLevelTwo();
            }
            else if(Level <= numbersOfExamplesForLvl3)
            {
                _numbers.DoLevelThree();
            }
            else if(Level <= numbersOfExamplesForLvl4)
            {
                _numbers.DoLevelFour();
            }
            else if (Level <= numbersOfExamplesForLvl5)
            {
                _numbers.DoLevelFive();
            }
            else if(Level <= numbersOfExamplesForLvl6)
            {
                _numbers.DoLevelSix();
            }
            else if (Level <= numbersOfExamplesForLvl7)
            {
               _numbers.DoLevelSeven();
            }
            else
            {
                _numbers.DoLevelEight();
            }
            Level++;
            LevelChange?.Invoke();
        }
    }
}