using Example03.Control;
using Example03.Core;
using Example03.GameRules;
using Example03.Strategies;
using Example03.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField, Required] private GameRulesNames _gameRulesNames;
        [SerializeField, Required] private UIRulesSelector _rulesSelector;
        [SerializeField, Required] private UIGameOverScreenActivator _uiGameOverScreenActivator;
        [SerializeField, Required] private UIStartScreen _startScreen;
        [SerializeField, Required] private UIGameOverScreen _winScreen;
        [SerializeField, Required] private UIGameOverScreen _loseScreen;

        public override void InstallBindings()
        {
            BindUI();
        }

        private void BindUI()
        {
            Container.Bind<IRestart>().FromComponentInHierarchy().AsSingle();
            Container.Bind<LevelRestarter>().AsSingle();

            Container.Bind<GameRulesNames>().FromInstance(_gameRulesNames).AsSingle();
            Container.Bind<UIStartScreen>().FromInstance(_startScreen).AsSingle();

            Container.Bind<UIGameOverScreen>().FromInstance(_winScreen);
            Container.Bind<UIGameOverScreen>().FromInstance(_loseScreen);

            Container.Bind<UIGameOverScreenActivator>()
                .FromInstance(_uiGameOverScreenActivator)
                .AsSingle();

            Container.Bind<UIRulesSelector>().FromInstance(_rulesSelector).AsSingle();
        }
    }
}
