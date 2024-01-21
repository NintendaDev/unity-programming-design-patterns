using Example03.Control;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private PlayerInputReceiver _playerInputReceiver;

        public void Initialize()
        {
            _playerInputReceiver.Initialize();
        }
    }
}
