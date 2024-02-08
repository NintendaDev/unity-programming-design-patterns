using Example09.Spawners;
using Zenject;

namespace Example09.UI
{
    public class SpawnButton : UIButton
    {
        private ISpawner _spawner;

        [Inject]
        private void Construct(ISpawner spawner)
        {
            _spawner = spawner;
        }

        protected override void OnButtonClick()
        {
            _spawner.StartSpawn();
        }
    }
}
