using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image[] hearts;
        [SerializeField] private Sprite fullHeart;
        [SerializeField] private Sprite emptyHeart;

        private HealthController _health;

        private void Awake()
        {
            _health = GetComponent<HealthController>();
            _health.HealthControl += HeartsView;
        }

        private void Start()
        {
            HeartsView();
        }

        public void HeartsView()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < _health.NumOfHeart)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }
    }
}
