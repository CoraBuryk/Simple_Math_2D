using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MenuAnimator : MonoBehaviour
    {
        [SerializeField] private OpenPauseMenu _openPauseMenuScript;
        [SerializeField] private PauseMenu _pauseMenuScript;
        [SerializeField] private GameOverMenu _gameOverScript;
        [SerializeField] private Animator Main;

        private const string @continue = "continue";
        private const string over = "over";
        private const string restart = "restart";
        private const string pause = "pause";

        public void ForPause()
        {
            if (_openPauseMenuScript.buttonIsPress == true)
            {
                Main.SetBool(over, false);
                Main.SetBool(restart, false);
                Main.SetBool(@continue, false);
                Main.SetBool(pause, true);
            }
        }

        public void ForContinue()
        {
            if (_pauseMenuScript.buttonContinueIsPress == true)
            {
                Main.SetBool(@continue, true);
                Main.SetBool(over, false);
                Main.SetBool(restart, false);
                Main.SetBool(pause, false);
            }
        }

        public void ForRestart()
        {
            if (_gameOverScript.buttonRestartIsPress == true)
            {
                Main.SetBool(restart, true);
                Main.SetBool(over, false);
                Main.SetBool(@continue, false);
                Main.SetBool(pause, false);
            }
        }

        public void ForOver()
        {
            Main.SetBool(over, true);
            Main.SetBool(restart, false);
            Main.SetBool(@continue, false);
            Main.SetBool(pause, false);
        }
    }
}
