using Example05.UI.HealthVisualization;
using Example06.Core;
using Example06.UI;
using Example06.UI.DamageVisualization;
using Example06.UI.ExperienceVisualization;
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
            HealthMediator healthMediator = new(_player.Health, _levelScreen.HealthIndicator);
            NotifiedValueMediator levelLabelMediator = new(_player.Level, _levelScreen.LevelLabel);
            NotifiedValueMediator experienceLabelMediator = new(_player.Experience, _levelScreen.ExperienceLabel);
            GameOverMediator gameOverMediator = new GameOverMediator(_levelScreen, _gameOverScreen, _player);

            ExperienceMediator experienceButtonMediator = new ExperienceMediator(_player.Experience);
            _levelScreen.ExperienceButton.Initialize(experienceButtonMediator);

            DamageMediator damageMediator = new(_player.Health);
            _levelScreen.DamageButton.Initialize(damageMediator);
            _gameOverScreen.ResetButton.Initialize(resetMediator);
        }

        public void Reset()
        {
            _levelScreen.Enable();
            _gameOverScreen.Disable();
        }
    }
}
