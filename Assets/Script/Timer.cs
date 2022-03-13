using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] internal float time;
    [SerializeField] private Text timerText;

    private Generator _generator;
    private Health _health;

    private float _timeLeft;
    internal float _timeBonus;

    public IEnumerator StartTimer()
    {
        while(_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            _timeBonus = _timeLeft;
            UpdateTimeText();
            yield return null;
        }
    }
    public void TimerSwitch()
    {
        _timeLeft = 30f;
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
            _timeLeft = 30;
            _generator = GetComponent<Generator>();
            _generator.GetQuestionForSubtraction();
            Debug.Log("Time's up. New question");
            _health = GetComponent<Health>();
            _health.numOfHearts -= 1;
        } 

        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{00:00}", seconds); 
    }
}
