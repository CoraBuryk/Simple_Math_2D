using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Assets.Script;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text score;

    private void Start()
    {
        HandleScoreDelegate();
    }

    public void HandleScoreDelegate()
    {
        score.text = $"Score: {ScoreCounter.Counter}";
    }
}
