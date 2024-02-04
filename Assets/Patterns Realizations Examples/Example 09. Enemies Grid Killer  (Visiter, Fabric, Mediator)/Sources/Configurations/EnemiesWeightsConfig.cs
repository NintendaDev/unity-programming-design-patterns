using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.Configurations
{
    [CreateAssetMenu(fileName = "new EnemiesWeightsConfig", menuName = "Example09 / Configurations / EnemiesWeightsConfig")]
    public class EnemiesWeightsConfig : ScriptableObject
    {
        [field: SerializeField, MinValue(0)] public int HumanWeight { get; private set; } = 5;
        [field: SerializeField, MinValue(0)] public int OrkWeight { get; private set; } = 5;
        [field: SerializeField, MinValue(0)] public int ElfWeight { get; private set; } = 5;
        [field: SerializeField, MinValue(0)] public int RobotWeight { get; private set; } = 5;
    }
}
