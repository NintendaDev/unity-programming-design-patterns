using Sirenix.OdinInspector;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Example07.GameResources.Energy;

namespace Example07.GameResources.Gem
{
    [CreateAssetMenu(fileName = "new ResourcesStorage", menuName = "Example07 / ResourcesStorage")]
    public class ResourcesStorage : ScriptableObject
    {
        [ValidateInput(nameof(IsUniquePentagonGemsColors))]
        [SerializeField, Required, RequiredListLength(1, null)] private PentagonGem[] _pentagonGems;

        [ValidateInput(nameof(IsUniqueTriangleGemsColors))]
        [SerializeField, Required, RequiredListLength(1, null)] private TriangleGem[] _triangleGems;

        [ValidateInput(nameof(IsUniqueBadgeEnergiesColors))]
        [SerializeField, Required, RequiredListLength(1, null)] private BadgeEnergy[] _badgeEnergies;

        [ValidateInput(nameof(IsUniqueBatteryEnergiesColors))]
        [SerializeField, Required, RequiredListLength(1, null)] private BatteryEnergy[] _batteryEnergies;

        public IEnumerable<PentagonGem> PentagonGems => _pentagonGems;

        public IEnumerable<TriangleGem> TriangleGems => _triangleGems;

        public IEnumerable<BadgeEnergy> BadgeEnergies => _badgeEnergies;

        public IEnumerable<BatteryEnergy> BatteryEnergies => _batteryEnergies;

        private bool IsUniquePentagonGemsColors(PentagonGem[] pentagonGems, ref string errorMessage)
        {
            return IsUniqueAllResourcesColors(pentagonGems, ref errorMessage);
        }

        private bool IsUniqueTriangleGemsColors(TriangleGem[] triangleGems, ref string errorMessage)
        {
            return IsUniqueAllResourcesColors(triangleGems, ref errorMessage);
        }

        private bool IsUniqueBadgeEnergiesColors(BadgeEnergy[] badgeEnergies, ref string errorMessage)
        {
            return IsUniqueAllResourcesColors(badgeEnergies, ref errorMessage);
        }

        private bool IsUniqueBatteryEnergiesColors(BatteryEnergy[] batteryEnergies, ref string errorMessage)
        {
            return IsUniqueAllResourcesColors(batteryEnergies, ref errorMessage);
        }

        private bool IsUniqueAllResourcesColors(IEnumerable<Resource> resources, ref string errorMessage)
        {
            errorMessage = "You cannot add resources with the same color";
            var resourcesDuplicates = resources.GroupBy(x => x.ItemColor).Where(array => array.Count() > 1);

            return resourcesDuplicates.Count() == 0;
        }
    }
}
