using Example04.Characters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example04.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Robot _robot;

        private void Awake()
        {
            _robot.Initialize();
        }
    }
}
