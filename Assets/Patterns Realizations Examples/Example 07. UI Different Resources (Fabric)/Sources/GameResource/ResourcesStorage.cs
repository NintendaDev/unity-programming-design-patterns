using Sirenix.OdinInspector;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Example07.GameResources.Gem
{
    [CreateAssetMenu(fileName = "new ResourcesStorage", menuName = "Example07 / ResourcesStorage")]
    public class ResourcesStorage : ScriptableObject
    {
        [ValidateInput(nameof(IsUniqueAllPentagonGemsColors))]
        [SerializeField, Required, RequiredListLength(1, null)] private PentagonGem[] _pentagonGems;

        [ValidateInput(nameof(IsUniqueAllTriangleGemsColors))]
        [SerializeField, Required, RequiredListLength(1, null)] private TriangleGem[] _triangleGems;

        public IEnumerable<PentagonGem> PentagonGems => _pentagonGems;

        public IEnumerable<TriangleGem> TriangleGems => _triangleGems;

        private bool IsUniqueAllPentagonGemsColors(PentagonGem[] pentagonGems, ref string errorMessage)
        {
            return IsUniqueAllResourcesColors(pentagonGems, ref errorMessage);
        }

        private bool IsUniqueAllTriangleGemsColors(TriangleGem[] triangleGems, ref string errorMessage)
        {
            return IsUniqueAllResourcesColors(triangleGems, ref errorMessage);
        }

        private bool IsUniqueAllResourcesColors(IEnumerable<Resource> resources, ref string errorMessage)
        {
            errorMessage = "You cannot add resources with the same color";
            var resourcesDuplicates = resources.GroupBy(x => x.ItemColor).Where(array => array.Count() > 1);

            return resourcesDuplicates.Count() == 0;
        }
    }
}
