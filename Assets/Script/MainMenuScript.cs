using UnityEngine;

namespace Assets.Script
{
    public class MainMenuScript : MonoBehaviour
    {
        [SerializeField] private StartMenuScript _startMenuScript;
        [SerializeField] private OpenPauseMenuScript _openPauseMenuScript;
        [SerializeField] private PauseMenuScript _pauseMenuScript;
        [SerializeField] private GameOverScript _gameOverScript;
        [SerializeField] private Animator Main;

        public void ForStart()
        {
            if (_startMenuScript.buttonIsPress == true)
            {
                Main.SetBool("start", true);
                Main.SetBool("continue", false);
                Main.SetBool("over", false);
                Main.SetBool("exit", false);
                Main.SetBool("exit", false);
                Main.SetBool("restart", false);
                Main.SetBool("pause", false);
            }
        }

        public void ForPause()
        {
            if (_openPauseMenuScript.buttonIsPress == true)
            {
                Main.SetBool("over", false);
                Main.SetBool("exit", false);
                Main.SetBool("exit", false);
                Main.SetBool("restart", false);
                Main.SetBool("continue", false);
                Main.SetBool("pause", true);
                Main.SetBool("start", false);
            }
        }

        public void ForContinue()
        {
            if (_pauseMenuScript.buttonContinueIsPress == true)
            {
                Main.SetBool("continue", true);
                Main.SetBool("over", false);
                Main.SetBool("exit", false);
                Main.SetBool("exit", false);
                Main.SetBool("restart", false);
                Main.SetBool("pause", false);
                Main.SetBool("start", false);
            }
        }

        public void ForRestart()
        {
            if (_gameOverScript.buttonRestartIsPress == true)
            {
                Main.SetBool("restart", true);
                Main.SetBool("over", false);
                Main.SetBool("exit", false);
                Main.SetBool("exit", false);
                Main.SetBool("continue", false);
                Main.SetBool("pause", false);
                Main.SetBool("start", false);
            }
        }

        public void ForExit()
        {
            if (_pauseMenuScript.buttonExitIsPress == true || _gameOverScript.buttonExitIsPress == true)
            {
                Main.SetBool("over", false);
                Main.SetBool("exit", true);
                Main.SetBool("exit", true);                
                Main.SetBool("restart", false);
                Main.SetBool("continue", false);
                Main.SetBool("pause", false);
                Main.SetBool("start", false);
            }
        }

        public void ForOver()
        {
            Main.SetBool("over", true);
            Main.SetBool("exit", false);
            Main.SetBool("exit", false);
            Main.SetBool("restart", false);
            Main.SetBool("continue", false);
            Main.SetBool("pause", false);
            Main.SetBool("start", false);
        }
    }
}
