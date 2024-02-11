using Example03.GameRules;
using Example03.Infrastructure;
using MonoUtils;
using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Example03
{
    public class UIRulesSelector : InitializedMonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Dropdown _gameRulesDropdown;

        private ILevelRule _levelRuler;

        [Inject]
        private void Construct(GameRulesNames gameRulesNames, ILevelRule levelRuler)
        {
            _gameRulesDropdown.ResetOptions();

            foreach (GameRuleDescription gameRuleDescription in gameRulesNames.GameRulesDescriptions)
                _gameRulesDropdown.AddOption(gameRuleDescription.Name);

            _levelRuler = levelRuler;

            if (gameRulesNames.GameRulesDescriptions.Count > 0)
                levelRuler.SetLevelRule(gameRulesNames.GameRulesDescriptions.First().Name);

            CompleteInitialization();
        }

        private void OnEnable()
        {
            _gameRulesDropdown.OnValueChanged.AddListener(OnRuleChange);
        }

        private void OnDisable()
        {
            _gameRulesDropdown.OnValueChanged.RemoveListener(OnRuleChange);
        }

        private void OnRuleChange(string ruleName)
        {
            _levelRuler.SetLevelRule(ruleName);
        }
    }
}
