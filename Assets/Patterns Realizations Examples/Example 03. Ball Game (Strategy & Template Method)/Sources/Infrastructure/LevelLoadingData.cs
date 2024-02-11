using Example03.GameRules;

namespace Example03.Infrastructure
{
    public class LevelLoadingData
    {
        public LevelLoadingData(SceneDescription sceneDescription, GameRuleType gameRuleType)
        {
            SceneDescription = sceneDescription;
            RuleType = gameRuleType;
        }

        public SceneDescription SceneDescription { get; private set; }

        public GameRuleType RuleType { get; private set; }
    }
}
