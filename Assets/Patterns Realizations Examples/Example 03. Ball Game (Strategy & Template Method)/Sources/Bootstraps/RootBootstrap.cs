using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private PlayerBootstrap _playerBootstrap;
        [SerializeField, Required, SceneObjectsOnly] private LevelBootstrap _levelBootstrap;
        [SerializeField, Required, SceneObjectsOnly] private UIBootstrap _uiBootstrap;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _playerBootstrap.Initialize();
            _levelBootstrap.Initialize();
            _uiBootstrap.Initialize();
        }
    }
}
