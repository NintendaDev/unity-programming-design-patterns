using Example07.GameResources;
using UnityEngine;

namespace Example07.UI.Factories
{
    [CreateAssetMenu(fileName = "new BadgeEnergyViewFactory", menuName = "Example07 / Factories / BadgeEnergyViewFactory")]
    public class BadgeEnergyViewFactory : ResourceViewFactory
    {
        protected override Resource GetResource(ResourceColor color)
        {
            return Storage.BadgeEnergies.GetResourceByColor(color);
        }

        protected override ResourceType GetResourceType()
        {
            return ResourceType.Energy;
        }
    }
}
