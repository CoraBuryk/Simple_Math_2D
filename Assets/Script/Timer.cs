using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;

    private float _timeLeft = 20f;

    public IEnumerator StartTimer()
    {
        while(_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }
    public void TimerSwitch()
    {
        _timeLeft = 20f;
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
            _timeLeft = 20;
            Generator generator = GetComponent<Generator>();
            generator.GetQuestionForSubtraction();
            Debug.Log("Time's up. New question");
            Health health = GetComponent<Health>();
            health.numOfHearts -= 1;
        }           
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{00:00}", seconds);          
    }
}
