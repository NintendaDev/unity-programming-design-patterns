using Example05.UI.HealthVisualization;
using Example06.Core;
using Example06.UI;
using Example06.UI.DamageVisualization;
using Example06.UI.ExperienceVisualization;
using Example06.UI.GameScreens;
using Example06.UI.Reset;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example06.Bootstraps
{
    public class UIBootstrap : MonoBehaviour, IReset, IDisposable
    {
        [SerializeField, Required] private Player _player;
        [SerializeField, Required] private LevelScreen _levelScreen;
        [SerializeField, Required] private GameOverScreen _gameOverScreen;

        private HealthMediator _healthMediator;
        private NotifiedValueMediator _levelLabelMediator;
        private NotifiedValueMediator _experienceLabelMediator;
        private GameOverMediator _gameOverMediator;

        private bool _isInitialized;

        private void OnDestroy()
        {
            Dispose();
        }

        public void Dispose()
        {
            _healthMediator?.Dispose();
            _gameOverMediator?.Dispose();
            _levelLabelMediator?.Dispose();
            _experienceLabelMediator?.Dispose();
        }

        public void Initialize(ResetMediator resetMediator)
        {
            if (_isInitialized)
                Dispose();

            _healthMediator = new HealthMediator(_player.Health, _levelScreen.HealthIndicator);
            _levelLabelMediator = new NotifiedValueMediator(_player.Level, _levelScreen.LevelLabel);
            _experienceLabelMediator = new NotifiedValueMediator(_player.Experience, _levelScreen.ExperienceLabel);
            _gameOverMediator = new GameOverMediator(_levelScreen, _gameOverScreen, _player);

            ExperienceMediator experienceButtonMediator = new ExperienceMediator(_player.Experience);
            _levelScreen.ExperienceButton.Initialize(experienceButtonMediator);

            DamageMediator damageMediator = new DamageMediator(_player.Health);
            _levelScreen.DamageButton.Initialize(damageMediator);
            _gameOverScreen.ResetButton.Initialize(resetMediator);

            _isInitialized = true;
        }

        public void Reset()
        {
            _levelScreen.Enable();
            _gameOverScreen.Disable();
        }
    }
}
