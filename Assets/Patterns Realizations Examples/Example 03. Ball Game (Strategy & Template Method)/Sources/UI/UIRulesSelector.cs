using Example03.GameRules;
using MonoUtils;
using NovaSamples.UIControls;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example03
{
    public class UIRulesSelector : InitializedMonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Dropdown _gameRulesDropdown;

        [Inject]
        private void Construct(GameRulesNames gameRulesNames)
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
