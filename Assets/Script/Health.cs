using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private Difficulty difficulty;

    private void Awake()
    {
        difficulty = GetComponent<Difficulty>();
    }

    private void FixedUpdate()
    {
        if (health > HealthController.NumOfHeart)
        {
            health = HealthController.NumOfHeart;
        }
        if (health == 0)
        {
            difficulty.RestartDifficulty();
            HealthController.RunOutOfHearts();
            health = HealthController.NumOfHeart;
        }
        for (int i = 0; i < hearts.Length; i++)
        { 
            if (i < Mathf.RoundToInt(health))
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
