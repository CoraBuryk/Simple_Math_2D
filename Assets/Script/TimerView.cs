using TMPro;
using UnityEngine;

namespace Assets.Script
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TimerController _timer;

        private void OnEnable()
        {
            _timer.TimerChange += UpdateTimeText;
        }

        private void OnDisable()
        {
            _timer.TimerChange -= UpdateTimeText;
        }

        private void Start()
        {
            StartCoroutine(_timer.StartTimer());
        }

        private void UpdateTimeText()
        {
            float seconds = Mathf.FloorToInt(_timer.TimeLeft % 60);
            _timerText.text = string.Format("{00:00}", seconds);
        }
    }
}