using Example07.GameResources;
using UnityEngine;

namespace Example07.UI.Factories
{
    [CreateAssetMenu(fileName = "new PentagonGemViewFactory", menuName = "Example07 / Factories / PentagonGemViewFactory")]
    public class PentagonGemViewFactory : ResourceViewFactory
    {
        protected override Resource GetResource(ResourceColor color)
        {
            return Storage.PentagonGems.GetResourceByColor(color);
        }

        protected override ResourceType GetResourceType()
        {
            return ResourceType.Gem;
        }
    }
}
