using Example07.GameResources;
using UnityEngine;

namespace Example07.UI.Factories
{
    [CreateAssetMenu(fileName = "new BatteryEnergyViewFactory", menuName = "Example07 / Factories / BatteryEnergyViewFactory")]
    public class BatteryEnergyViewFactory : ResourceViewFactory
    {
        protected override Resource GetResource(ResourceColor color)
        {
            return Storage.BatteryEnergies.GetResourceByColor(color);
        }

        protected override ResourceType GetResourceType()
        {
            return ResourceType.Energy;
        }
    }
}
