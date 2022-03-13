using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Generator _generator;

    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        if (health == 0)
        {
            _generator = GetComponent<Generator>();
            StopCoroutine(_generator.Difficlty());
            _generator._difficultyUp = 2500;
            _generator.GetQuestionForSubtraction();           

            numOfHearts = 3;
            health = numOfHearts;

            Debug.Log("Restart");
        }
        for (int i = 0; i < hearts.Length; i++)
        { 
            if (i< Mathf.RoundToInt(health))
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
