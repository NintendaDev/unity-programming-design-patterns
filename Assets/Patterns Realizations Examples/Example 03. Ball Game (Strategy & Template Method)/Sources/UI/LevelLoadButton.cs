using Example03.Infrastructure;
using UnityEngine;
using Zenject;

namespace Example03.UI
{
    public class LevelLoadButton : ButtonBehaviour
    {
        [SerializeField] private SceneIdentificator _sceneIdentificator;

        private LevelLoaderMediator _levelLoaderMediator;

        [Inject]
        private void Construct(LevelLoaderMediator levelLoaderMediator)
        {
            _levelLoaderMediator = levelLoaderMediator;
        }

        protected override void OnClick()
        {
            _levelLoaderMediator.LoadLevel(_sceneIdentificator);
        }
    }
}
