using SimpleMath_2D.Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleMath_2DScripts.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image[] _hearts;
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private Sprite _emptyHeart;
        [SerializeField] private HealthController _health;

        private void OnEnable()
        {
            _health.HealthChange += HeartsView;
        }

        private void OnDisable()
        {
            _health.HealthChange -= HeartsView;
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