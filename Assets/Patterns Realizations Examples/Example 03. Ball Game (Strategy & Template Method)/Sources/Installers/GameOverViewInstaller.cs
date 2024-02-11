using Example03.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03.Installers
{
    public class GameOverViewInstaller : MonoInstaller
    {
        [SerializeField, Required, SceneObjectsOnly] private UIScreen _winScreen;
        [SerializeField, Required, SceneObjectsOnly] private UIScreen _loseScreen;

        public override void InstallBindings()
        {
            BindGameOverView();
        }

        private void BindGameOverView()
        {
            Container.BindInterfacesAndSelfTo<GameOverMediator>().AsSingle().WithArguments(_winScreen, _loseScreen);
        }
    }
}
