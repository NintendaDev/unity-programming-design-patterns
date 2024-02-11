using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Example03.Infrastructure
{
    public class ZenjectSceneLoaderWrapper
    {
        private ZenjectSceneLoader _zenjectSceneLoader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public void LoadScene(Action<DiContainer> action, SceneDescription sceneDescription)
        {
            _zenjectSceneLoader.LoadScene(sceneDescription.Name, LoadSceneMode.Single, container => action?.Invoke(container));
        }
    }
}