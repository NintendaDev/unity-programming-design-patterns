using Example03.GameRules;
using Example03.Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03.Installers
{
    public class GameProjectInstaller : MonoInstaller
    {
        [SerializeField, Required, AssetsOnly] private GameScenesDescriptions _gameScenesDescriptions;
        [SerializeField, Required, AssetsOnly] private GameRulesNames _gameRulesNames;

        public override void InstallBindings()
        {
            BindZenjectSceneLoaderWrapper();
            BindSceneLoader();
            BindLevelLoaderMediator();
        }

        private void BindZenjectSceneLoaderWrapper()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        }

        private void BindSceneLoader()
        {
            Container.Bind<GameScenesDescriptions>().FromInstance(_gameScenesDescriptions);
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        }

        private void BindLevelLoaderMediator()
        {
            Container.Bind<GameRulesNames>().FromInstance(_gameRulesNames).AsSingle();
            Container.BindInterfacesAndSelfTo<LevelLoaderMediator>().AsSingle();
        }
    }
}
