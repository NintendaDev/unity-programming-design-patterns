using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.Configurations
{
    [CreateAssetMenu(fileName = "new KillEnemyScoreConfig", menuName = "Example09 / Configurations / KillEnemyScoreConfig")]
    public class KillEnemyScoreConfig : ScriptableObject
    {
        [field: SerializeField, Required, MinValue(0)] public int ElfKillScore { get; private set; } = 10;
        [field: SerializeField, Required, MinValue(0)] public int HumanKillScore { get; private set; } = 5;
        [field: SerializeField, Required, MinValue(0)] public int OrkKillScore { get; private set; } = 15;
        [field: SerializeField, Required, MinValue(0)] public int RobotKillScore { get; private set; } = 20;
    }
}
