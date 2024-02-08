using Example05.UI.HealthVisualization;
using Example06.Attributes;
using Example06.Configurations;
using Example06.Core;
using Example06.UI;
using Example06.UI.DamageVisualization;
using Example06.UI.ExperienceVisualization;
using Example06.UI.GameScreens;
using Example06.UI.Reset;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Zenject;

namespace Example06.Installers
{
    public class GameInstaler : MonoInstaller
    {
        [Title("Settings")]
        [SerializeField, Required, AssetsOnly] private LevelConfiguration _levelConfiguration;
        [SerializeField, Required, AssetsOnly] private HealthMaxValueConfiguration _healthConfiguration;

        [Title("UI Settings")]
        [SerializeField, Required] private LevelScreen _levelScreen;
        [SerializeField, Required] private GameOverScreen _gameOverScreen;

        public override void InstallBindings()
        {
            BindGameplayObjects();
            BindResetObjects();
            BindUI();
        }

        private void BindGameplayObjects()
        {
            Container.BindInterfacesAndSelfTo<Experience>().AsSingle();

            Container.BindInterfacesAndSelfTo<Level>()
                .FromMethod(MakeLevel)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<Health>()
                .FromMethod(MakeHealth)
                .AsSingle();
        }

        private void BindResetObjects()
        {
            Container.Bind<IReset>().FromComponentsInHierarchy().AsSingle();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<HealthMediator>().AsSingle().WithArguments(_levelScreen.HealthIndicator);

            Container.Bind<IDisposable>()
                .To<NotifiedValueMediator>()
                .FromMethod(MakeLevelViewMediator)
                .AsTransient()
                .NonLazy();

            Container.Bind<IDisposable>()
                .To<NotifiedValueMediator>()
                .FromMethod(MakeExperienceViewMediator)
                .AsTransient()
                .NonLazy();

            Container.BindInterfacesAndSelfTo<GameOverMediator>().AsSingle().WithArguments(_levelScreen, _gameOverScreen).NonLazy();
            Container.BindInterfacesAndSelfTo<DamageMediator>().AsSingle().NonLazy();
            Container.Bind<ExperienceMediator>().AsSingle();

            Container.Bind<ResetMediator>().AsSingle();
        }

        private Level MakeLevel(InjectContext context)
        {
            return new Level(Container.Resolve<Experience>(), _levelConfiguration);
        }

        private Health MakeHealth(InjectContext context)
        {
            return new Health(Container.Resolve<Level>(), _healthConfiguration);
        }

        private NotifiedValueMediator MakeLevelViewMediator(InjectContext context)
        {
            return new NotifiedValueMediator(Container.Resolve<Level>(), _levelScreen.LevelLabel);
        }

        private NotifiedValueMediator MakeExperienceViewMediator(InjectContext context)
        {
            return new NotifiedValueMediator(Container.Resolve<Experience>(), _levelScreen.ExperienceLabel);
        }
    }
}
