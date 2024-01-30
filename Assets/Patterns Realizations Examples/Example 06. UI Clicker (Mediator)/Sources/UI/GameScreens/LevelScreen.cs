using Example05.UI.HealthVisualization;
using Example05.UI.HealthVisualization.Integer;
using Example06.UI.DamageVisualization;
using Example06.UI.ExperienceVisualization;
using Example06.UI.LevelVisualization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI.GameScreens
{
    public class LevelScreen : Screen
    {
        [SerializeField, Required] private IntTextHealthIndicator _healthTextIndicator;
        [SerializeField, Required] private UIDamageButton _damageButton;
        [SerializeField, Required] private UIExperienceButton _uiExperienceButton;
        [SerializeField, Required] private UILevelLabel _uiLevelLabel;
        [SerializeField, Required] private UIExperienceLabel _uiExperienceLabel;

        public void Initialize(Player player)
        {
            IntHealthMediator healthMediator = new(player.Health);
            _healthTextIndicator.Initialize(healthMediator);

            DamageMediator damageMediator = new(player.Health);
            _damageButton.Initialize(damageMediator);

            LevelMediator levelMediator = new(player.Level);
            _uiLevelLabel.Initialize(levelMediator);

            ExperienceMediator experienceMediator = new(player.Experience);
            _uiExperienceLabel.Initialize(experienceMediator);
            _uiExperienceButton.Initialize(experienceMediator);

            CompleteInitialization();
        }
    }
}
