using Example03.Bootstraps;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03
{
    public class LevelRestarter : MonoBehaviour
    {
        [SerializeField] private RootBootstrap _rootBootstrap;

        [Button, DisableInEditorMode]
        public void Restart()
        {
            _rootBootstrap.Initialize();
        }
    }
}
