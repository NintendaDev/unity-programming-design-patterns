using Example03.Control;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField, Required, SceneObjectsOnly] private PlayerInputReceiver _playerInputReceiver;

        public override void InstallBindings()
        {
            BindInput();
        }

        private void BindInput()
        {
            Container.Bind<IPlayerInput>().FromInstance(_playerInputReceiver).AsSingle();
        }
    }
}
