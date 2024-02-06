using UnityEngine;

namespace Example08.Configurations
{
    [CreateAssetMenu(fileName = "new SpecializationsConfiguration", menuName = "Example08 / Configurations / SpecializationsConfiguration")]
    public class SpecializationsConfiguration : ScriptableObject
    {
        [field: SerializeField] public StatsParameters MagicianParameters { get; private set; }

        [field: SerializeField] public StatsParameters ThiefParameters { get; private set; }

        [field: SerializeField] public StatsParameters BarbarianParameters { get; private set; }
    }
}
