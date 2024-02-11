using Example03.Handlers;
using System;

namespace Example03.UI
{
    public class GameOverMediator : IDisposable
    {
        private UIScreen _winScreen;
        private UIScreen _loseScreen;
        private Level _level;

        public GameOverMediator(UIScreen winScreen, UIScreen loseScreen, Level level)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _level = level;

            _winScreen.Disable();
            _loseScreen.Disable();

            _level.Won += OnPlayerWin;
            _level.Lost += OnPlayerLose;
        }

        public void Dispose()
        {
            _level.Won -= OnPlayerWin;
            _level.Lost -= OnPlayerLose;
        }

        private void OnPlayerWin()
        {
            _winScreen.Enable();
            _loseScreen.Disable();
        }

        private void OnPlayerLose()
        {
            _winScreen.Disable();
            _loseScreen.Enable();
        }
    }
}
