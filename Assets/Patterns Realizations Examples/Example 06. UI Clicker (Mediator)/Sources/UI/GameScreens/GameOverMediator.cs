using System;

namespace Example06.UI.GameScreens
{
    public class GameOverMediator : IDisposable
    {
        private LevelScreen _levelScreen;
        private GameOverScreen _gameOverScreen;
        private Player _player;

        public GameOverMediator(LevelScreen levelScreen, GameOverScreen gameOverScreen, Player player)
        {
            _levelScreen = levelScreen;
            _gameOverScreen = gameOverScreen;
            _player = player;

            _player.Health.Died += OnPlayerDie;
        }

        public void Dispose()
        {
            _player.Health.Died -= OnPlayerDie;
        }

        private void OnPlayerDie()
        {
            _levelScreen.Disable();
            _gameOverScreen.Enable();
        }
    }
}
