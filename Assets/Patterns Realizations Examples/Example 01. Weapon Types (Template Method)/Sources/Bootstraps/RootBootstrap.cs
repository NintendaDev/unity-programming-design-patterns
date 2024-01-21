using Sirenix.OdinInspector;
using UnityEngine;

namespace Example01.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private UIBootstrap _uiBootstrap;
        [SerializeField, Required, SceneObjectsOnly] private ShootingBootstrap _shootingBootstrap;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _uiBootstrap.Initialize();
            _shootingBootstrap.Initialize();
        }
    }
}
