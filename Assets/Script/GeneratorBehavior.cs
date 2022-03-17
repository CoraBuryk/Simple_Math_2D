using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Assets.Script;

public class GeneratorBehavior : MonoBehaviour
{
    [SerializeField] private Text example;
    [SerializeField] private Text[] buttonText;
    [SerializeField] private Button[] button;

    public Numbers numbers;
    private Difficulty _difficulty;
 
    private void Awake()
    {
        _difficulty = GetComponent<Difficulty>();

        buttonText[0].text = "1";
        buttonText[1].text = "2";
        buttonText[2].text = "3";

        GetQuestionForSubtraction();
    }

    public void GetQuestionForSubtraction()
    {
        numbers.DoSubtraction();
        example.text = numbers.MathExample;
    }

    public void GetQuestionForDivision()
    {
        numbers.DoDivision();
        example.text = numbers.MathExample;
    }

    public void GetQuestionForSubtractionUp()
    {
        numbers.DoSubtractionUp();
        example.text = numbers.MathExample;
    }

    public void GetQuestionForDivisionUp()
    {
        numbers.DoDivisionUp();
        example.text = numbers.MathExample;
    }

    public void AnswerButton(int index)
    {
        if (buttonText[index].text.ToString() == numbers.Result.ToString())
        {
            Bonus.ScoreUpdate();
            _difficulty.Variation();
        }
        else
        {
            ScoreCounter.ScoreToZero += ScoreCounter.ToZero;
            HealthController.HealthDecreased(3);
            GetQuestionForSubtraction();
        }
    }
}