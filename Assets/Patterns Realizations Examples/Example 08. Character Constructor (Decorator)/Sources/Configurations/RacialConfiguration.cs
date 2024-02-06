using UnityEngine;

namespace Example08.Configurations
{
    [CreateAssetMenu(fileName = "new RacialConfiguration", menuName = "Example08 / Configurations / RacialConfiguration")]
    public class RacialConfiguration : ScriptableObject
    {
        [field: SerializeField] public StatsParameters HumanParameters { get; private set; }

        [field: SerializeField] public StatsParameters ElfParameters { get; private set; }

        [field: SerializeField] public StatsParameters OrkParameters { get; private set; }
    }
}
