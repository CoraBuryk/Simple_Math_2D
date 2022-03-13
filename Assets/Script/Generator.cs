using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Generator : MonoBehaviour
{
    public Numbers numbers;
    [SerializeField] private Text example;
    [SerializeField] private Text[] buttonText;
    [SerializeField] private Button[] button;
    [SerializeField] internal float _difficultyUp;

    private ButtonCounter _counter;
    private Health _health;
    private Timer _timer;  

    public void Start()
    {
        GetQuestionForSubtraction();
    }

    public void GetQuestionForSubtraction()
    {
        numbers.num1 = Random.Range(0, 100);
        numbers.num2 = Random.Range(0, numbers.num1);
        var content = Random.Range(numbers.result - 2, numbers.result + 2);

        numbers.result = numbers.num1 - numbers.num2;
        
        example.text = $"{numbers.num1} - {numbers.num2} = ?";

        if (numbers.result > content)
        {
            buttonText[0].text = $"{numbers.result - 2}";
            buttonText[1].text = $"{numbers.result - 1}";
            buttonText[2].text = $"{numbers.result}";
        }
        else if (numbers.result == content)
        {
            buttonText[0].text = $"{numbers.result - 1}";
            buttonText[1].text = $"{numbers.result}";
            buttonText[2].text = $"{numbers.result + 1}";
        }
        else if (numbers.result < content)
        {
            buttonText[0].text = $"{numbers.result}";
            buttonText[1].text = $"{numbers.result + 1}";
            buttonText[2].text = $"{numbers.result + 2}";
        }
    }

    public void GetQuestionForDivision()
    {
        numbers.num1 = Random.Range(0, 100);
        numbers.num2 = Random.Range(1, numbers.num1);
        var content = Random.Range(numbers.result - 2, numbers.result + 2);

        numbers.result = numbers.num1 / numbers.num2;

        example.text = $"{numbers.num1} / {numbers.num2} = ?";

        if (numbers.result > content)
        {
            buttonText[0].text = $"{numbers.result - 2}";
            buttonText[1].text = $"{numbers.result - 1}";
            buttonText[2].text = $"{numbers.result}";
        }
        else if (numbers.result == content)
        {
            buttonText[0].text = $"{numbers.result - 1}";
            buttonText[1].text = $"{numbers.result}";
            buttonText[2].text = $"{numbers.result + 1}";
        }
        else if (numbers.result < content)
        {
            buttonText[0].text = $"{numbers.result}";
            buttonText[1].text = $"{numbers.result + 1}";
            buttonText[2].text = $"{numbers.result + 2}";
        }
    }

    public void GetQuestionForMultiply()
    {
        numbers.num1 = Random.Range(0, 50);
        numbers.num2 = Random.Range(0, numbers.num1);
        var content = Random.Range(numbers.result - 2, numbers.result + 2);

        numbers.result = numbers.num1 * numbers.num2;

        example.text = $"{numbers.num1} * {numbers.num2} = ?";

        if (numbers.result > content)
        {
            buttonText[0].text = $"{numbers.result - 2}";
            buttonText[1].text = $"{numbers.result - 1}";
            buttonText[2].text = $"{numbers.result}";
        }
        else if (numbers.result == content)
        {
            buttonText[0].text = $"{numbers.result - 1}";
            buttonText[1].text = $"{numbers.result}";
            buttonText[2].text = $"{numbers.result + 1}";
        }
        else if (numbers.result < content)
        {
            buttonText[0].text = $"{numbers.result}";
            buttonText[1].text = $"{numbers.result + 1}";
            buttonText[2].text = $"{numbers.result + 2}";
        }
    }
    public void AnswerButton(int index)
    {
        _counter = GetComponent<ButtonCounter>();
        _health = GetComponent<Health>();
        _timer = GetComponent<Timer>();

        if (buttonText[index].text.ToString() == numbers.result.ToString())
        {         
            if(_timer._timeBonus > 15)
            {
                _counter.DoublePlus();
            }else if(_timer._timeBonus <= 15)
            {
            _counter.Plus(); 
            }          
        }
        else
        {
            _counter.ToZero();          
            _health.numOfHearts -= 1;
        }

        if (_difficultyUp <= 2500f) //about 10 min
        {
            GetQuestionForSubtraction();
            StartCoroutine(Difficlty());
            Debug.Log("Difficulty: Substraction");
            
        }
        else if(_difficultyUp < 1250f) //about 5 min
        {
            GetQuestionForDivision();
            StartCoroutine(Difficlty());
            Debug.Log("Difficulty: Division");

        }
        else if(_difficultyUp < 625f) //about 2.5 min
        {
            GetQuestionForMultiply();
            StartCoroutine(Difficlty());
            Debug.Log("Difficulty: Multiply");
        }
    }
    public IEnumerator Difficlty()
    {
        while (_difficultyUp > 0)
        {
            _difficultyUp -= Time.deltaTime;
            yield return null;
        }
    }
}
[System.Serializable]
public class Numbers
{
    public int num1; 
    public int num2;
    public int result;
}