using Example09.Accounters;
using Example09.Enemies;
using Example09.Spawners;
using Example09.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.Bootstraps
{
    public class UIBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private SpawnButton _spawnButton;
        [SerializeField, Required] private RandomKillButton _randomKillButton;
        [SerializeField, Required] private EnemiesForceWeightView _enemiesForceWeightView;
        [SerializeField, Required] private ScoreView _scoreView;

        private EnemySpawnMediator _enemyMediator;
        private ScoreViewMediator _scoreMediator;

        public void Initialize(RandomEnemySpawner spawner, Score score)
        {
            _enemyMediator = new EnemySpawnMediator(spawner, _enemiesForceWeightView);
            _spawnButton.Initialize(_enemyMediator);

            var randomEnemyKiller = new RandomEnemyKiller(spawner);
            _randomKillButton.Initialize(randomEnemyKiller);

            _scoreMediator = new ScoreViewMediator(score, _scoreView);
        }

        private void OnDestroy()
        {
            _enemyMediator.Dispose();
            _scoreMediator.Dispose();
        }
    }
}
