using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class GeneratorBehavior : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI example;
        [SerializeField] internal TextMeshProUGUI[] ButtonText;
        [SerializeField] private Button[] button;

        public Numbers numbers;

        public int Total { get => numbers.Result; private set => Total = value; }

        private void Awake()
        {
            ButtonText[0].text = "1";
            ButtonText[1].text = "2";
            ButtonText[2].text = "3";

            GetQuestionForLevelOne();
        }

        public void GetQuestionForLevelOne()
        {
            numbers.DoLevelOne();
            example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelTwo()
        {
            numbers.DoLevelTwo();
            example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelThree()
        {
            numbers.DoLevelThree();
            example.text = numbers.MathExample;
        }

        public void GetQuestionForLevelFour()
        {
            numbers.DoLevelFour();
            example.text = numbers.MathExample;
        }
    }
}