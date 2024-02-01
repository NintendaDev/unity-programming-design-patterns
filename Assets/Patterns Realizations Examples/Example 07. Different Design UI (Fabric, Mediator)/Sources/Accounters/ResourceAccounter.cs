using Example07.GameResources;
using Specifications;
using System;
using System.Collections.Generic;

namespace Example07.Accounters
{
    public class ResourceAccounter
    {
        private Dictionary<ResourceType, int> _resourcesCount = new();

        public event Action<ResourceType, int, int> Changed;

        public void Add(ResourceType type, int count)
        {
            StaticSpecification.ValidateIntGreatOrEqualZero(count);

            if (_resourcesCount.ContainsKey(type) == false)
                _resourcesCount[type] = 0;

            int previousValue = _resourcesCount[type];
            _resourcesCount[type] += count;

            Changed?.Invoke(type, previousValue, _resourcesCount[type]);
        }

        public bool TryRemove(ResourceType type, int count)
        {
            StaticSpecification.ValidateIntGreatOrEqualZero(count);

            if (_resourcesCount.ContainsKey(type) == false)
                return false;

            if (count > _resourcesCount[type])
                return false;

            int previousValue = _resourcesCount[type];
            _resourcesCount[type] -= count;

            Changed?.Invoke(type, previousValue, _resourcesCount[type]);

            return true;
        }

        public int GetCount(ResourceType type)
        {
            if (_resourcesCount.ContainsKey(type) == false)
                return 0;

            return _resourcesCount[type];
        }
    }
}