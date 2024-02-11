using Example03.GameRules;

namespace Example03.Infrastructure
{
    public class LevelLoaderMediator : ILevelRule
    {
        private GameRulesNames _gameRulesNames;
        private GameScenesDescriptions _gameScenesDescriptions;
        private ILevelLoader _levelLoader;
        private ISimpleSceneLoader _simpleSceneLoader;
        private GameRuleType _levelRuleType;

        public LevelLoaderMediator(GameRulesNames gameRulesNames, GameScenesDescriptions gameScenesDescriptions,
            ILevelLoader levelLoader, ISimpleSceneLoader simpleSceneLoader)
        {
            _gameRulesNames = gameRulesNames;
            _gameScenesDescriptions = gameScenesDescriptions;
            _levelLoader = levelLoader;
            _simpleSceneLoader = simpleSceneLoader;
        }

        public void SetLevelRule(string ruleName)
        {
            if (_gameRulesNames.TryGetRuleType(ruleName, out GameRuleType gameRuleType))
                _levelRuleType = gameRuleType;
            else
                throw new System.ArgumentException($"Не найдено правило игры по имени '{ruleName}'");
        }

        public void LoadMainMenu()
        {
            _simpleSceneLoader.LoadScene(SceneIdentificator.Menu);
        }

        public void LoadLevel(SceneIdentificator sceneIdentificator)
        {
            if (sceneIdentificator == SceneIdentificator.Menu)
                throw new System.Exception("You cannot load menu using this method");

            SceneDescription levelSceneDescription = _gameScenesDescriptions.GetSceneDescription(sceneIdentificator);
            var levelLoadingData = new LevelLoadingData(levelSceneDescription, _levelRuleType);

            _levelLoader.LoadScene(levelLoadingData);
        }
    }
}
