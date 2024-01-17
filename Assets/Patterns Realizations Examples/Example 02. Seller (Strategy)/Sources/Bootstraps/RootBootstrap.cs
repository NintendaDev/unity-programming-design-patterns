using Sirenix.OdinInspector;
using UnityEngine;

namespace Example02.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private PlayerBootstrap _playerBootstrap;
        [SerializeField, Required, ChildGameObjectsOnly] private SellerBootstrap _sellerBootstrap;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _playerBootstrap.Initialize();
            _sellerBootstrap.Initialize();
        }
    }
}
