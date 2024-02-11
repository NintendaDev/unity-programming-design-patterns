using Example03.Accounters;
using Example03.Core;
using Example03.Handlers;
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
        [SerializeField, Required, AssetsOnly] private LevelRestarter _levelRestarter;

        public override void InstallBindings()
        {
            BindLevel();
            BindRestarter();
        }

        private void BindLevel()
        {
            Container.Bind<Level>().FromInstance(new Level()).AsSingle();
            Container.Bind<BallAccounterInitializer>().FromInstance(_ballsAccounterInitializer).AsSingle();

            Container.Bind<BallsAccounter>().FromResolveGetter<BallAccounterInitializer>(x => x.BallsAccounter).AsSingle();
            Container.Bind<IRestart>().FromResolveGetter<BallAccounterInitializer>(x => x.BallsAccounter);

            Container.BindInterfacesAndSelfTo<BurstBallsAccounter>().AsSingle();
            Container.Bind<WinLoseStrategyChanger>().FromInstance(_winLoseStrategyChanger).AsSingle();
        }

        private void BindRestarter()
        {
            Container.Bind<IRestart>().FromComponentsInHierarchy().AsSingle();
            LevelRestarter levelRestarter = Container.InstantiatePrefabForComponent<LevelRestarter>(_levelRestarter);
            Container.Bind<LevelRestarter>().FromInstance(levelRestarter).AsSingle();
        }
    }
}
