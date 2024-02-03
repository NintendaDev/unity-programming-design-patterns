using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private EnemiesBootstrap _enemiesBootstrap;
        [SerializeField, Required] private UIBootstrap _uiBootstrap;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _enemiesBootstrap.Initialize();
            _uiBootstrap.Initialize(_enemiesBootstrap.Spawner, _enemiesBootstrap.Score);
        }
    }
}
