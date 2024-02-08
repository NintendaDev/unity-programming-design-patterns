using Example03.Accounters;
using Example03.Handler;
using Example03.Strategies;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField, Required, SceneObjectsOnly] private BallAccounterInitializer _ballsAccounterInitializer;
        [SerializeField, Required, SceneObjectsOnly] private WinLoseStrategyChanger _winLoseStrategyChanger;

        public override void InstallBindings()
        {
            BindLevel();
        }

        private void BindLevel()
        {
            Container.Bind<Level>().FromInstance(new Level()).AsSingle();
            Container.Bind<BallAccounterInitializer>().FromInstance(_ballsAccounterInitializer).AsSingle();
            Container.Bind<BallsAccounter>().FromResolveGetter<BallAccounterInitializer>(x => x.BallsAccounter).AsSingle();
            Container.Bind<BurstBallsAccounter>().AsSingle();
            Container.Bind<WinLoseStrategyChanger>().FromInstance(_winLoseStrategyChanger).AsSingle();
        }
    }
}
