using Example06.Core;
using Example06.UI.GameScreens;
using Example06.UI.Reset;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.Bootstraps
{
    public class UIBootstrap : MonoBehaviour, IReset
    {
        [SerializeField, Required] private Player _player;
        [SerializeField, Required] private LevelScreen _levelScreen;
        [SerializeField, Required] private GameOverScreen _gameOverScreen;

        public void Initialize(ResetMediator resetMediator)
        {
            _levelScreen.Initialize(_player);
            _gameOverScreen.Initialize(resetMediator, _player);
        }

        public void Reset()
        {
            _levelScreen.Enable();
            _gameOverScreen.Disable();
        }
    }
}
