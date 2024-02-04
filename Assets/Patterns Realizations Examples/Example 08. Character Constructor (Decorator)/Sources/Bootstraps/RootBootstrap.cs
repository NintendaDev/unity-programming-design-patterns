using Sirenix.OdinInspector;
using UnityEngine;

namespace Example08.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private CharactersBootstrap _charactersBootstrap;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _charactersBootstrap.Initialize();
        }
    }
}
