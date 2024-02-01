using Example07.Accounters;
using Example07.GameResources;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example07.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private UIBootstrap _uiBootstrap;

        public ResourceAccounter ResourceAccounter { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            ResourceAccounter resourceAccounter = new ResourceAccounter();
            resourceAccounter.Add(ResourceType.Gem, 450);
            _uiBootstrap.Initialize(resourceAccounter);
        }
    }
}
