using Example07.Accounters;
using Example07.GameResources;
using System;

namespace Example07.UI
{
    public class ResourceViewMediator : IDisposable
    {
        private ResourceType _mediatorResourceType;
        private ResourceAccounter _resourcesAccounter;
        private ResourceView _resourceView;

        public ResourceViewMediator(ResourceType mediatorResourceType, ResourceAccounter resourcesAccounter, ResourceView resourceView)
        {
            _mediatorResourceType = mediatorResourceType;
            _resourcesAccounter = resourcesAccounter;
            _resourceView = resourceView;

            SetResourceCounter(_resourcesAccounter.GetCount(mediatorResourceType));

            _resourcesAccounter.Changed += OnResourceChanged;
        }

        public void Dispose()
        {
            _resourcesAccounter.Changed -= OnResourceChanged;
        }

        private void OnResourceChanged(ResourceType resourceType, int previousValue, int currentValue)
        {
            if (resourceType != _mediatorResourceType)
                return;

            SetResourceCounter(currentValue);
        }

        private void SetResourceCounter(int currentValue)
        {
            _resourceView.SetResourceCounter(currentValue);
        }
    }
}
