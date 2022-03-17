using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField]private float _difficultyUp;
    GeneratorBehavior _generator;

    private void Awake()
    {
        _generator = GetComponent<GeneratorBehavior>();   
    }
    public IEnumerator Difficlty()
    {
        while (_difficultyUp > 0)
        {
            _difficultyUp -= Time.deltaTime;
            yield return null;
        }
    }

    public void Variation()
    {
        StartCoroutine(Difficlty());
        if (_difficultyUp > 1250f)
        {
            _generator.GetQuestionForSubtraction();
        }
        else if (_difficultyUp < 1250f && _difficultyUp > 625f)
        {
            _generator.GetQuestionForDivision();
        }
        else if (_difficultyUp < 1250f && _difficultyUp > 625f)
        {
            _generator.GetQuestionForSubtractionUp();
        }else
        {
            _generator.GetQuestionForDivisionUp();
        }
    }

    public void RestartDifficulty()
    {
        if(HealthController.NumOfHeart <=0)
        {
            _generator.GetQuestionForSubtraction();
            if (_difficultyUp < 2500f)
                _difficultyUp = 2500f;
            StartCoroutine(Difficlty());
        }
    }
}
