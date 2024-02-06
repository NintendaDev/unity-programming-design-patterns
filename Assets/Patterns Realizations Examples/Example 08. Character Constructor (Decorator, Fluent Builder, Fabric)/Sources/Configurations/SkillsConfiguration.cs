using UnityEngine;

namespace Example08.Configurations
{
    [CreateAssetMenu(fileName = "new SkillsConfiguration", menuName = "Example08 / Configurations / SkillsConfiguration")]
    public class SkillsConfiguration : ScriptableObject
    {
        [field: SerializeField] public StatsParameters BodybuildingParameters { get; private set; }

        [field: SerializeField] public StatsParameters ChessParameters { get; private set; }

        [field: SerializeField] public StatsParameters MorningExercisesParameters { get; private set; }
    }
}
