using Example03.Infrastructure;
using Zenject;

namespace Example03.UI
{
    public class MenuLoadButton : ButtonBehaviour
    {
        private LevelLoaderMediator _levelLoaderMediator;

        [Inject]
        private void Construct(LevelLoaderMediator levelLoaderMediator)
        {
            _levelLoaderMediator = levelLoaderMediator;
        }

        protected override void OnClick()
        {
            _levelLoaderMediator.LoadMainMenu();
        }
    }
}
