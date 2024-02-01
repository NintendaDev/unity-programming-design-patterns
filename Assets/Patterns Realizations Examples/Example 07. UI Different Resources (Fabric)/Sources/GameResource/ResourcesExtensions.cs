using System.Collections.Generic;
using System.Linq;

namespace Example07.GameResources
{
    public static class ResourcesExtensions
    {
        public static Resource GetResourceByColor(this IEnumerable<Resource> resources, ResourceColor color)
        {
            return resources.Where(x => x.ItemColor == color).FirstOrDefault();
        }
    }
}
