using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private UIBootstrap _uiBootstrap;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _uiBootstrap.Initialize();
        }
    }
}
