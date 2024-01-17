using Example03.Handler;
using Example03.UI;
using UnityEngine;

namespace Example03
{
    public class UIGameOverScreenActivator : MonoBehaviour
    {
        private UIGameOverScreen _winScreen;
        private UIGameOverScreen _loseScreen;
        private Level _level;

        public void Initialize(UIGameOverScreen winScreen, UIGameOverScreen loseScreen, Level level)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _level = level;
        }

        private void OnEnable()
        {
            _level.Won += OnWin;
            _level.Lost += OnLose;
        }

        private void OnDisable()
        {
            _level.Won -= OnWin;
            _level.Lost -= OnLose;
        }

        private void OnLose()
        {
            _loseScreen.Enable();
        }

        private void OnWin()
        {
            _winScreen.Enable();
        }
    }
}
