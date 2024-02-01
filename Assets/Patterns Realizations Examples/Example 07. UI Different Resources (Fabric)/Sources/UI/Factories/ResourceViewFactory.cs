using Example07.Accounters;
using Example07.GameResources;
using Example07.GameResources.Gem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example07.UI.Factories
{
    public abstract class ResourceViewFactory : ScriptableObject
    {
        [SerializeField, Required] private ResourcesStorage _storage;
        [SerializeField, Required] private ResourceView _viewPrefab;

        private ResourceAccounter _resourceAccounter;
        private bool _isInitialized;

        protected ResourcesStorage Storage => _storage;

        public void Initialize(ResourceAccounter resourceAccounter)
        {
            _resourceAccounter = resourceAccounter;
            _isInitialized = true;
        }

        public ResourceView Get(ResourceColor color)
        {
            if (_isInitialized == false)
                throw new System.Exception($"{GetType()} is not initialized");

            Resource resource = GetResource(color);
            ResourceView view = Instantiate(_viewPrefab);

            ResourceType resourceType = GetResourceType();
            ResourceMediator mediator = new(resourceType, _resourceAccounter, view);

            view.Initialize(resource);

            return view;
        }

        protected abstract Resource GetResource(ResourceColor color);

        protected abstract ResourceType GetResourceType();
    }
}
