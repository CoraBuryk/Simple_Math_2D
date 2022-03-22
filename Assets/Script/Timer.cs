using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;

    private float _timeLeft;
    private GeneratorBehavior _generator;

    private void Awake()
    {
        _generator = GetComponent<GeneratorBehavior>();
    }

    public IEnumerator StartTimer()
    {
        while(_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            Bonus.TimeBonus = _timeLeft;
            UpdateTimeText();
            yield return null;
        }
    }

    public void TimerSwitch()
    {
        _timeLeft = 15f;
    }

    public void Start()
    {
        _timeLeft = time;
       StartCoroutine(StartTimer());
    }

    private void UpdateTimeText()
    {
        if(_timeLeft < 0)
        {
            _timeLeft = 15;          
            _generator.GetQuestionForSubtraction();
            HealthController.HealthDecreased(3);
        } 
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{00:00}", seconds); 
    }
}
