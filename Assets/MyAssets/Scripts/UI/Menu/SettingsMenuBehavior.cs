using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyAssets.Scripts.UI.Menu
{
    public abstract class SettingsMenuBehavior : MonoBehaviour
    {
        [SerializeField] private Button _back;
        [SerializeField] private GameObject _previousPanel;
        [SerializeField] private GameObject _settingsPanel;

        private bool _isOpened = false;

        protected virtual void OnEnable()
        {
            _back.onClick.AddListener(Back);
        }

        protected virtual void OnDisable()
        {
            _back.onClick.RemoveListener(Back);
        }

        public virtual void Back()
        {
            _previousPanel.SetActive(!_isOpened);
            _settingsPanel.SetActive(_isOpened);
        }
    }
}
