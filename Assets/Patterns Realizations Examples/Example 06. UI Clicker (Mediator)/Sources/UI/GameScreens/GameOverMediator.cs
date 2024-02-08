using Example06.Attributes;
using System;

namespace Example06.UI.GameScreens
{
    public class GameOverMediator : IDisposable
    {
        private LevelScreen _levelScreen;
        private GameOverScreen _gameOverScreen;
        private Health _health;

        public GameOverMediator(LevelScreen levelScreen, GameOverScreen gameOverScreen, Health health)
        {
            _levelScreen = levelScreen;
            _gameOverScreen = gameOverScreen;
            _health = health;

            _health.Died += OnPlayerDie;
        }

        public void Dispose()
        {
            _health.Died -= OnPlayerDie;
        }

        private void OnPlayerDie()
        {
            _levelScreen.Disable();
            _gameOverScreen.Enable();
        }
    }
}
