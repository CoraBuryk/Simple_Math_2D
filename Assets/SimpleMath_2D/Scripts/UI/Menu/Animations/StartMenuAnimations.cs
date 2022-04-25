using DG.Tweening;
using UnityEngine;

namespace SimpleMath_2D.Scripts.UI.Menu.Animations
{
    public class StartMenuAnimations : MonoBehaviour
    {
        [SerializeField] private RectTransform _startRectTransform;
        [SerializeField] private RectTransform _imageRectTransform;
        [SerializeField] private RectTransform _settingsRectTransform;
        [SerializeField] private RectTransform _scoreRectTransform;

        public void ForStart()
        {
            _startRectTransform.DOAnchorPosY(0, 0.95f, true);
            _imageRectTransform.DOShakeAnchorPos(50f,10f,2);
        }

        public void ForSettings()
        {
            _startRectTransform.DOAnchorPosY(2000, 0, true);
            _settingsRectTransform.DOAnchorPosY(0, 0.95f, true);
        }

        public void ForScore()
        {
            _startRectTransform.DOAnchorPosY(2000, 0, true);
            _scoreRectTransform.DOAnchorPosY(0, 1, true);
        }

        public void ForBack()
        {
            _settingsRectTransform.DOAnchorPosY(2000, 0, true);
            _scoreRectTransform.DOAnchorPosY(2000, 0, true);
            _startRectTransform.DOAnchorPosY(0, 0.95f, true);
        }

        public void KillAnimations()
        {
            _imageRectTransform.DOKill();
            _scoreRectTransform.DOKill();
            _settingsRectTransform.DOKill();
            _startRectTransform.DOKill();
        }
    }
}
