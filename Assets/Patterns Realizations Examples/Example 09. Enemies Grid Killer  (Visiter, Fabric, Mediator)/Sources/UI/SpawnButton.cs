using Example09.Spawners;

namespace Example09.UI
{
    public class SpawnButton : UIButton
    {
        private ISpawner _spawner;

        public void Initialize(ISpawner spawner)
        {
            _spawner = spawner;
            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _spawner.StartSpawn();
        }
    }
}
