using DG.Tweening;
using UnityEngine;

namespace Assets.MyAssets.Scripts.UI.Menu.Animations
{
    public class MainMenuAnimations : MonoBehaviour
    {
        [SerializeField] private RectTransform _pauseRectTransform;
        [SerializeField] private RectTransform _gameOverRectTransform;
        [SerializeField] private RectTransform _settingsRectTransform;
        [SerializeField] private RectTransform _mainRectTransform;

        public void ForPause()
        {
            _mainRectTransform.DOAnchorPosY(2000, 0, true);
            _pauseRectTransform.DOAnchorPosY(0, 1, true);
            _settingsRectTransform.DOAnchorPosY(2000, 0, true);
        }

        public void ForMain()
        {
            _mainRectTransform.DOAnchorPosY(0, 0.95f, true);
            _pauseRectTransform.DOAnchorPosY(2000, 1, true);
        }

        public void ForRestart()
        {
            _mainRectTransform.DOAnchorPosY(0, 0.95f, true);
            _pauseRectTransform.DOAnchorPosY(2000, 0, true);
            _gameOverRectTransform.DOAnchorPosY(2000, 0, true);
        }

        public void ForSettings()
        {
            _pauseRectTransform.DOAnchorPosY(2000, 0, true);
            _settingsRectTransform.DOAnchorPosY(0, 1, true);
        }

        public void ForOver()
        {
            _mainRectTransform.DOAnchorPosY(2000, 0, true);
            _gameOverRectTransform.DOAnchorPosY(0, 1, true);
        }

        public void KillAnimations()
        {
            _pauseRectTransform.DOKill();
            _gameOverRectTransform.DOKill();
            _settingsRectTransform.DOKill();
            _mainRectTransform.DOKill();
        }
    }
}
