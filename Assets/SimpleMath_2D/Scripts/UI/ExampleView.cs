using SimpleMath_2D.Scripts.Gameplay;
using TMPro;
using UnityEngine;

namespace SimpleMath_2D.Scripts.UI
{
    public class ExampleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _example;
        [SerializeField] private LevelController _levelController;

        private void OnEnable()
        {
           _levelController.LevelChange += ExampleText;
        }

        private void OnDisable()
        {
            _levelController.LevelChange -= ExampleText;
        }

        private void Start()
        {
            ExampleText();
        }

        public void ExampleText()
        {
            _example.text = _levelController.ExampleText;
        }
    }
}