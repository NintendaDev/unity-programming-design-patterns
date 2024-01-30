using Example06.UI.Reset;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI.GameScreens
{
    public class GameOverScreen : Screen
    {
        [SerializeField, Required] private UIResetButton _resetButton;

        private Player _player;
        private bool _isSubscribed;

        public void Initialize(ResetMediator resetMediator, Player player)
        {
            _player = player;
            _resetButton.Initialize(resetMediator);

            Subscribe();

            CompleteInitialization();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            if (_isSubscribed)
                return;

            _player.Health.Died += OnPlayerDie;
            _isSubscribed = true;
        }

        private void OnPlayerDie()
        {
            Enable();
        }

        private void Unsubscribe()
        {
            if (_isSubscribed == false)
                return;

            _player.Health.Died -= OnPlayerDie;
            _isSubscribed = false;
        }
    }
}
