using Example03.GameRules;
using Example03.Handler;
using Example03.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03.Bootstraps
{
    public class UIBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private GameRulesNames _gameRulesNames;
        [SerializeField, Required] private UIRulesSelector _rulesSelector;
        [SerializeField, Required] private UIGameOverScreenActivator _uiGameOverScreenActivator;
        [SerializeField, Required] private UIStartScreen _startScreen;
        [SerializeField, Required] private UIGameOverScreen _winScreen;
        [SerializeField, Required] private UIGameOverScreen _loseScreen;
        [SerializeField, Required] private LevelRestarter _levelRestarter;
        [SerializeField, Required] private WinLoseStrategyChanger _winLosStrategyChanger;
        [SerializeField, Required] private Level _level;

        public void Initialize()
        {
            _uiGameOverScreenActivator.Initialize(_winScreen, _loseScreen, _level);
            _rulesSelector.Initialize(_gameRulesNames);
            _startScreen.Initialize(_levelRestarter, _winLosStrategyChanger, _gameRulesNames);
            _winScreen.Initialize(_startScreen);
            _loseScreen.Initialize(_startScreen);

            _startScreen.Enable();
            _winScreen.Disable();
            _loseScreen.Disable();
        }
    }
}
