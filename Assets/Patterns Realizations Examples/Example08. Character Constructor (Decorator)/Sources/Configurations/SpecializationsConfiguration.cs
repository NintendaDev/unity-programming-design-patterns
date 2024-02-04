using UnityEngine;

namespace Example08.Configurations
{
    [CreateAssetMenu(fileName = "new SpecializationsConfiguration", menuName = "Example08 / Configurations / SpecializationsConfiguration")]
    public class SpecializationsConfiguration : ScriptableObject
    {
        [field: SerializeField] public StatsModificatorsParameters MagicianSpecilization { get; private set; }

        [field: SerializeField] public StatsModificatorsParameters ThiefSpecilization { get; private set; }

        [field: SerializeField] public StatsModificatorsParameters BarbarianSpecilization { get; private set; }
    }
}
