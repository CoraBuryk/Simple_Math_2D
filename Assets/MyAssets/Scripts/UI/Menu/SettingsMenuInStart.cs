using Assets.MyAssets.Scripts.UI.Menu.Animations;
using UnityEngine;

namespace Assets.MyAssets.Scripts.UI.Menu
{
    public class SettingsMenuInStart : SettingsMenuBehavior
    {
        [SerializeField] private StartMenuAnimations _startMenuAnimator;

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        public override void Back()
        {
            base.Back();
            _startMenuAnimator.ForBack();
        }
    }
}
