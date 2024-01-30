using Example03.GameRules;
using MonoUtils;
using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example03
{
    public class UIRulesSelector : InitializedMonobehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Dropdown _gameRulesDropdown;

        public void Initialize(GameRulesNames gameRulesNames)
        {
            _gameRulesDropdown.ResetOptions();

            foreach (GameRuleDescription gameRuleDescription in gameRulesNames.GameRulesDescriptions)
            {
                _gameRulesDropdown.AddOption(gameRuleDescription.Name);
            }

            CompleteInitialization();
        }
    }
}
