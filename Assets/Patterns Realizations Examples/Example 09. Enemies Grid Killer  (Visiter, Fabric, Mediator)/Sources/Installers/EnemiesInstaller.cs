using Example09.Accounters;
using Example09.Configurations;
using Example09.Core;
using Example09.Enemies;
using Example09.Spawners;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Example09.Installers
{
    public class EnemiesInstaller : MonoInstaller
    {
        [SerializeField, Required] private RectangleGridConfig _rectangleGridConfig;
        [SerializeField, Required] private EnemiesWeightsConfig _enemiesWeightsConfig;
        [SerializeField, Required] private KillEnemyScoreConfig _killEnemyScoreConfig;
        [SerializeField, Required] private EnemySpawnerConfig _enemySpawnerConfig;
        [SerializeField, Required] private EnemyFactory _enemyFactory;
        [SerializeField, Required] private Transform _spawnPoint;

        public override void InstallBindings()
        {
            BindConfigurations();
            BindEnemySpawner();
            BindScore();
            BindEnemyKiller();
        }

        private void BindConfigurations()
        {
            Container.Bind<RectangleGridConfig>().FromInstance(_rectangleGridConfig).AsSingle();
            Container.Bind<EnemiesWeightsConfig>().FromInstance(_enemiesWeightsConfig).AsSingle();
            Container.Bind<KillEnemyScoreConfig>().FromInstance(_killEnemyScoreConfig).AsSingle();
            Container.Bind<EnemySpawnerConfig>().FromInstance(_enemySpawnerConfig).AsSingle();
        }

        private void BindEnemySpawner()
        {
            Container.Bind<GridMaker>().To<RectangleGridMaker>().AsSingle();
            Container.Bind<EnemyFactory>().FromInstance(_enemyFactory).AsSingle();
            Container.BindInterfacesAndSelfTo<RandomEnemySpawner>().AsSingle().WithArguments(_spawnPoint);
        }

        private void BindScore()
        {
            Container.Bind<Score>().AsSingle();
        }

        private void BindEnemyKiller()
        {
            Container.Bind<RandomEnemyKiller>().AsSingle();
        }
    }
}
