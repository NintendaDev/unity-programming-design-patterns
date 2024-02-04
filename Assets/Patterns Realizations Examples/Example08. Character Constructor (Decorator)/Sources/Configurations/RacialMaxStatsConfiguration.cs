using UnityEngine;

namespace Example08.Configurations
{
    [CreateAssetMenu(fileName = "new RacialMaxStatsConfiguration", menuName = "Example08 / Configurations / RacialMaxStatsConfiguration")]
    public class RacialMaxStatsConfiguration : ScriptableObject
    {
        [field: SerializeField] public StatsMaxParameters HumanStatMaxParameters { get; private set; }

        [field: SerializeField] public StatsMaxParameters ElfStatMaxParameters { get; private set; }

        [field: SerializeField] public StatsMaxParameters OrkStatMaxParameters { get; private set; }
    }
}
