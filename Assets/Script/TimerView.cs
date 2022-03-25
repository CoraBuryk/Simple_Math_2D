using TMPro;
using UnityEngine;

namespace Assets.Script
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        private TimerController _timer;

        private void Awake()
        {
            _timer = GetComponent<TimerController>();
            _timer.TimerChange += UpdateTimeText;
        }

        public void Start()
        {
            StartCoroutine(_timer.StartTimer());
        }

        private void UpdateTimeText()
        {
            float seconds = Mathf.FloorToInt(_timer.TimeLeft % 60);
            timerText.text = string.Format("{00:00}", seconds);
        }
    }
}