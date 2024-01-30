using Example04.Characters;
using Example04.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example04.Bootstraps
{
    public class RootBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Robot _robot;
        [SerializeField, Required, SceneObjectsOnly] private PatrolPointsInitializer _pointsInitializer;

        private void Awake()
        {
            _robot.Initialize(_pointsInitializer);
        }
    }
}
