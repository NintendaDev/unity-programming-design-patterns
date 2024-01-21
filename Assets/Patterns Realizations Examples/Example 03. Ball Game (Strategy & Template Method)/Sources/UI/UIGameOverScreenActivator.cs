using Example03.Control;
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
        private IPlayerInput _playerInput;

        public void Initialize(UIGameOverScreen winScreen, UIGameOverScreen loseScreen, Level level, IPlayerInput playerInput)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _level = level;
            _playerInput = playerInput;
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
            _playerInput.Disable();
        }

        private void OnWin()
        {
            _winScreen.Enable();
            _playerInput.Disable();
        }
    }
}
