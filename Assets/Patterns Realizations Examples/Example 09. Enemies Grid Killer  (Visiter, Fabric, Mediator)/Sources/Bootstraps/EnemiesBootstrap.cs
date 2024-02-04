using Example09.Accounters;
using Example09.Configurations;
using Example09.Core;
using Example09.Spawners;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example09.Bootstraps
{
    public class EnemiesBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private RectangleGridConfig _rectangleGridConfig;
        [SerializeField, Required] private EnemiesWeightsConfig _enemiesWeightsConfig;
        [SerializeField, Required] private KillEnemyScoreConfig _killEnemyScoreConfig;
        [SerializeField, Required] private RandomEnemySpawner _spawner;

        public RandomEnemySpawner Spawner => _spawner;

        public Score Score { get; private set; }

        public void Initialize()
        {
            var gridMaker = new RectangleGridMaker(_rectangleGridConfig);
            var enemmiesForceWeight = new EnemiesForceWeight(_enemiesWeightsConfig);
            _spawner.Initialize(gridMaker, enemmiesForceWeight);

            Score = new Score(_spawner, _killEnemyScoreConfig);
        }
    }
}
