using UnityEngine;

namespace Assets.MyAssets.Scripts.UI.Audio
{
    public class AudioEffects : MonoBehaviour
    {
        [SerializeField] private AudioSource _answerWrong;
        [SerializeField] private AudioSource _answerRight;
        [SerializeField] private AudioSource _bestScore;

        public void PlayOnRight()
        {
            _answerRight.Play();
        }

        public void PlayOnWrong()
        {
            _answerWrong.Play();
        }

        public void PlayOnBestScore()
        {
            _bestScore.Play();
        }
    }
}
