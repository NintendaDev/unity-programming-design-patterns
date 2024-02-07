using Example09.Accounters;
using Example09.Spawners;
using System;

namespace Example09.UI
{
    public class EnemySpawnMediator : ISpawner, IDisposable
    {
        private IReadOnlyForceWeight _forceWeight;
        private RandomEnemySpawner _spawner;
        private EnemiesForceWeightView _forceWeightView;

        public EnemySpawnMediator(RandomEnemySpawner spawner, EnemiesForceWeightView forceWeightView)
        {
            _forceWeight = spawner.ForceWeight;
            _spawner = spawner;
            _forceWeightView = forceWeightView;

            UpdateForceView(_forceWeight.Value, _forceWeight.MaxValue);
            _forceWeight.Changed += UpdateForceView;
        }

        public void Dispose()
        {
            _forceWeight.Changed -= UpdateForceView;
        }

        public void StartSpawn()
        {
            _spawner.StartSpawn();
        }

        private void UpdateForceView(int currentValue, int maxValue)
        {
            _forceWeightView.UpdateView(currentValue);
        }
    }
}
