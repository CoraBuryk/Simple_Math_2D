using TMPro;
using UnityEngine;

namespace Assets.Script
{
    public class GeneratorBehavior : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _example;
        [SerializeField] internal TextMeshProUGUI[] _buttonText;

        public Numbers numbers;

        public int Total { get => numbers.Result; private set => Total = value; }

        private void Awake()
        {
            _buttonText[0].text = "1";
            _buttonText[1].text = "2";
            _buttonText[2].text = "3";

            GetQuestionForLevelOne();
        }

        public void GetQuestionForLevelOne()
        {
            numbers.DoLevelOne();
            _example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelTwo()
        {
            numbers.DoLevelTwo();
            _example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelThree()
        {
            numbers.DoLevelThree();
            _example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelFour()
        {
            numbers.DoLevelFour();
            _example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelFive()
        {
            numbers.DoLevelFive();
            _example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelSix()
        {
            numbers.DoLevelSix();
            _example.text = numbers.MathExample;
        }
        public void GetQuestionForLevelSeven()
        {
            numbers.DoLevelSeven();
            _example.text = numbers.MathExample;
        }
        public void GetQuestionForLevelEight()
        {
            numbers.DoLevelEight();
            _example.text = numbers.MathExample;
        }
    }
}