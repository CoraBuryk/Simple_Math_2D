using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image[] _hearts;
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private Sprite _emptyHeart;
        [SerializeField] private HealthController _health;

        private void Awake()
        {
            _health.HealthChange += HeartsView;
        }

        private void Start()
        {
            HeartsView();
        }

        public void HeartsView()
        {
            for (int i = 0; i < _hearts.Length; i++)
            {
                if (i < _health.NumOfHeart)
                {
                    _hearts[i].sprite = _fullHeart;
                }
                else
                {
                    _hearts[i].sprite = _emptyHeart;
                }
            }
        }
    }
}