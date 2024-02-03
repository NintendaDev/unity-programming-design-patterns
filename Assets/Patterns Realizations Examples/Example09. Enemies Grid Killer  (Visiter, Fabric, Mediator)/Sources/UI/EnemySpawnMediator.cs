using Example09.Spawners;
using System;

namespace Example09.UI
{
    public class EnemySpawnMediator : ISpawner, IDisposable
    {
        private RandomEnemySpawner _spawner;
        private EnemiesForceWeightView _forceWeightView;

        public EnemySpawnMediator(RandomEnemySpawner spawner, EnemiesForceWeightView forceWeightView)
        {
            _spawner = spawner;
            _forceWeightView = forceWeightView;

            UpdateForceView(_spawner.CurrentForceEnemyWeight, _spawner.ForceWeightThreshold);
            _spawner.ForceWeightChanged += UpdateForceView;
        }

        public void Dispose()
        {
            _spawner.ForceWeightChanged -= UpdateForceView;
        }

        public bool TrySpawn()
        {
            return _spawner.TrySpawn();
        }

        private void UpdateForceView(int currentValue, int maxValue)
        {
            _forceWeightView.UpdateView(currentValue);
        }
    }
}
