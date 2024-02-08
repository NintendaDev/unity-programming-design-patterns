using Example09.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example09.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField, Required] private EnemiesForceWeightView _enemiesForceWeightView;
        [SerializeField, Required] private ScoreView _scoreView;

        public override void InstallBindings()
        {
            BindMediators();
        }

        private void BindMediators()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawnMediator>().AsSingle().WithArguments(_enemiesForceWeightView);
            Container.BindInterfacesAndSelfTo<ScoreViewMediator>().AsSingle().WithArguments(_scoreView);
        }
    }
}
