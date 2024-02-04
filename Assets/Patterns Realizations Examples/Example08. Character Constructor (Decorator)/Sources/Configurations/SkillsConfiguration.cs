using UnityEngine;

namespace Example08.Configurations
{
    [CreateAssetMenu(fileName = "new SkillsConfiguration", menuName = "Example08 / Configurations / SkillsConfiguration")]
    public class SkillsConfiguration : ScriptableObject
    {
        [field: SerializeField] public StatsModificatorsParameters MorningExercises { get; private set; }

        [field: SerializeField] public StatsModificatorsParameters Chess { get; private set; }

        [field: SerializeField] public StatsModificatorsParameters Bodybuilding { get; private set; }
    }
}
