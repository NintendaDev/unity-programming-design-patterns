using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.Configurations
{
    [CreateAssetMenu(fileName = "new EnemySpawnerConfig", menuName = "Example09 / Configurations / EnemySpawnerConfig")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [field: SerializeField, MinValue(0)] public int ForceWeightThreshold { get; private set; }
        [field: SerializeField, MinValue(0), Unit(Units.Second)] public float SpawnCooldown { get; private set; }
    }
}
