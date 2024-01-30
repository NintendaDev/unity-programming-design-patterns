using Example05.UI.HealthVisualization;
using Example06.UI.DamageVisualization;
using Example06.UI.ExperienceVisualization;
using Example06.UI.LevelVisualization;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.UI.GameScreens
{
    public class LevelScreen : Screen
    {
        [SerializeField, Required] private TextHealthIndicator _healthTextIndicator;
        [SerializeField, Required] private UIDamageButton _damageButton;
        [SerializeField, Required] private UIExperienceLabel _experienceLabel;
        [SerializeField, Required] private UIExperienceButton _experienceButton;
        [SerializeField, Required] private UILevelLabel _levelLabel;

        public TextHealthIndicator HealthIndicator => _healthTextIndicator;

        public UIDamageButton DamageButton => _damageButton;

        public UIExperienceLabel ExperienceLabel => _experienceLabel;

        public UIExperienceButton ExperienceButton => _experienceButton;

        public UILevelLabel LevelLabel => _levelLabel;
    }
}
