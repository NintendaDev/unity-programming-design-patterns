namespace Example03.Infrastructure
{
    public class SceneLoader : ISimpleSceneLoader, ILevelLoader
    {
        private ZenjectSceneLoaderWrapper _zenjectSceneLoaderWrapper;
        private GameScenesDescriptions _gameScenesDescriptions;

        public SceneLoader(ZenjectSceneLoaderWrapper zenjectSceneLoaderWrapper, GameScenesDescriptions gameScenesDescriptions)
        {
            _zenjectSceneLoaderWrapper = zenjectSceneLoaderWrapper;
            _gameScenesDescriptions = gameScenesDescriptions;
        }

        public void LoadScene(SceneIdentificator sceneIdentificator)
        {
            SceneDescription sceneDescription = _gameScenesDescriptions.GetSceneDescription(sceneIdentificator);
            _zenjectSceneLoaderWrapper.LoadScene(null, sceneDescription);
        }

        public void LoadScene(LevelLoadingData levelLoadingData)
        {
            _zenjectSceneLoaderWrapper.LoadScene(container => 
            {
                container.BindInstance(levelLoadingData);
            }, levelLoadingData.SceneDescription);
        } 
    }
}
