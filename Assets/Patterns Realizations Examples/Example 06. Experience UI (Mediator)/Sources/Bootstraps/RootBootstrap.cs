using Example06.Core;
using Example06.UI.Reset;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06.Bootstraps
{
    public class RootBootstrap : MonoBehaviour, IReset
    {
        [SerializeField, Required] private PlayerBootstrap _playerBootstrap;
        [SerializeField, Required] private UIBootstrap _uiBootstrap;

        private void Awake()
        {
            Initialize();
        }

        public void Reset()
        {
            _playerBootstrap.Reset();
            _uiBootstrap.Reset();
        }

        private void Initialize()
        {
            _playerBootstrap.Initialize();

            ResetMediator resetMediator = new(this);
            _uiBootstrap.Initialize(resetMediator);

            Reset();
        }
    }
}
