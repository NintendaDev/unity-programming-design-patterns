using Example07.GameResources;
using UnityEngine;

namespace Example07.UI.Factories
{
    [CreateAssetMenu(fileName = "new TriangleGemViewFactory", menuName = "Example07 / Factories / TriangleGemViewFactory")]
    public class TriangleGemViewFactory : ResourceViewFactory
    {
        protected override Resource GetResource(ResourceColor color)
        {
            return Storage.TriangleGems.GetResourceByColor(color);
        }

        protected override ResourceType GetResourceType()
        {
            return ResourceType.Gem;
        }
    }
}