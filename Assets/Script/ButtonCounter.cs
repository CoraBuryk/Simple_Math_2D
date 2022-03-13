using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ButtonCounter : MonoBehaviour
{
    [SerializeField] private Text count;
    [SerializeField] private int counter = 0;

    private void Update()
    {
        count.text = "Score: " + counter.ToString();
    }

    public void Plus()
    {
        counter ++;
        Debug.Log("Correct answer. Score increased.");
    }
    public void ToZero()
    {
        counter = 0;
        Debug.Log("Incorrect answer. Score down to zero");
    }
    public void DoublePlus()
    {
        counter += 2;
        Debug.Log("Correct answer. Score increased. Time bonus");
    }
}
