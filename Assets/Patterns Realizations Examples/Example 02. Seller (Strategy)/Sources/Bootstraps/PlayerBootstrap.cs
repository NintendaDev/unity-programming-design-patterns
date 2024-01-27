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

        public void Initialize()
        {
            PlayerInputReceiver inputReceiver = _player.GetComponent<PlayerInputReceiver>();
            inputReceiver.Initialize();

            Age age = _player.GetComponent<Age>();
            age.Initialize();

            Mover mover = _player.GetComponent<Mover>();
            mover.Initalize();

            _uiAge.Initialize(age);
        }
    }
}