using Example03.Control;
using Example03.GameRules;
using Example03.Strategies;
using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03.UI
{
    public class UIStartScreen : UIScreen
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Button _startGameButton;
        [SerializeField, Required, ChildGameObjectsOnly] private Dropdown _gameRulesDropdown;

        private LevelRestarter _levelRestarter;
        private WinLoseStrategyChanger _winLoseStrategyChanger;
        private GameRulesNames _gameRulesNames;
        private IPlayerInput _playerInput;

        public void Initialize(LevelRestarter levelRestarter, WinLoseStrategyChanger winLoseStrategyChanger, 
            GameRulesNames gameRulesNames, IPlayerInput playerInput)
        {
            _levelRestarter = levelRestarter;
            _winLoseStrategyChanger = winLoseStrategyChanger;
            _gameRulesNames = gameRulesNames;
            _playerInput = playerInput;

            SetGameRule(_gameRulesDropdown.CurrentSelection);

            CompleteInitialization();
        }

        private void OnEnable()
        {
            _gameRulesDropdown.OnValueChanged.AddListener(OnGameRuleChange);
            _startGameButton.OnClicked.AddListener(OnStartButtonClick);
        }

        private void OnDisable()
        {
            _gameRulesDropdown.OnValueChanged.RemoveListener(OnGameRuleChange);
            _startGameButton.OnClicked.RemoveListener(OnStartButtonClick);
        }

        private void SetGameRule(string gameRuleName)
        {
            if (_gameRulesNames.TryGetRuleType(gameRuleName, out GameRuleType gameRuleType))
                _winLoseStrategyChanger.ActivateGameRule(gameRuleType);
            else
            {
                throw new System.ArgumentException($"Не найдено правило игры по имени '{gameRuleName}'");
            }
        }

        private void OnGameRuleChange(string gameRuleName)
        {
            SetGameRule(gameRuleName);
        }

        private void OnStartButtonClick()
        {
            _levelRestarter.Restart();
            _playerInput.Enable();
            Disable();
        }
    }
}
