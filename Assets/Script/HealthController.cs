using System;
using UnityEngine;

namespace Assets.Script
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        public int NumOfHeart { get; set; }

        public event Action HealthChange;

        private void Awake()
        {
            NumOfHeart = _maxHealth;
        }

        public void HealthDecreased()
        {
            _maxHealth -= 1;
            NumOfHeart = _maxHealth;

            HealthChange?.Invoke();
        }

        public void ResetHealth()
        {
            NumOfHeart = 3;
            _maxHealth = NumOfHeart;

            HealthChange?.Invoke();
        }
    }
}