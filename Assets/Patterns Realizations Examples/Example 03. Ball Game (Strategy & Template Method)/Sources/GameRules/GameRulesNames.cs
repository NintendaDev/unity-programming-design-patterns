using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Example03.GameRules
{
    [CreateAssetMenu(fileName = "new GameRulesNames", menuName = "Example03 / GameRulesNames")]
    public class GameRulesNames : ScriptableObject
    {
        [ValidateInput(nameof(IsUniqueRuleTypes))]
        [SerializeField, Required] List<GameRuleDescription> _gameRulesDescriptions;

        public List<GameRuleDescription> GameRulesDescriptions => _gameRulesDescriptions;

        public bool TryGetRuleType(string ruleName, out GameRuleType gameRuleType)
        {
            var filteredDescriptions =  _gameRulesDescriptions.Where(x => x.Name == ruleName);
            gameRuleType = filteredDescriptions.Select(x => x.Type).FirstOrDefault();

            return filteredDescriptions.Count() > 0;
        }

        private bool IsUniqueRuleTypes(ref string errorMessage)
        {
            errorMessage = "Game Rule Types is not unique...";

            return _gameRulesDescriptions.Count == _gameRulesDescriptions.GroupBy(x => x.Type).Count();
        }
    }

    [System.Serializable]
    public class GameRuleDescription
    {
        [SerializeField] private GameRuleType _type;
        [SerializeField] private string _name;

        public GameRuleType Type => _type;

        public string Name => _name;

    }

    public enum GameRuleType
    {
        AllBallBurst, OneColorBallsBurst
    }
}
