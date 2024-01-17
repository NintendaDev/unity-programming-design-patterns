using Example02.Attributes;
using Example02.Control;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example02.Bootstraps
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField, Required, SceneObjectsOnly] private Player _player;
        [SerializeField, Required, SceneObjectsOnly] private UIAge _uiAge;

        private PlayerInputReceiver _inputReceiver;
        private Age _age;

        public void Initialize()
        {
            _inputReceiver = _player.GetComponent<PlayerInputReceiver>();
            _inputReceiver.Initialize();

            _age = _player.GetComponent<Age>();
            _age.Initialize();
            _uiAge.Initialize(_age);
        }
    }
}