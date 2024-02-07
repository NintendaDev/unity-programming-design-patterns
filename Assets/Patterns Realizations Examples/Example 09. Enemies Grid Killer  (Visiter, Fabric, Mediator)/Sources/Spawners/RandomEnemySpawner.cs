using Example09.Enemies;
using Example09.Configurations;
using System;
using UnityEngine;
using System.Linq;
using Example09.Core;
using Example09.Accounters;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Collections;

namespace Example09.Spawners
{
    public class RandomEnemySpawner: IDisposable, ILevelEnemies, IEnemySpawnNotifier, IEnemyDeathNotifier
    {
        private EnemySpawnerConfig _spawnConfig;
        private EnemyFactory _enemyFactory;
        private Transform _spawnPoint;
        private List<EnemySpawnPoint> _spawnPoints = new();
        private EnemiesForceWeight _enemiesForceWeight;
        private MonoBehaviour _context;
        private bool _isPaused;
        private Coroutine _spawnCoroutine;

        public RandomEnemySpawner(Transform spawnPoint, EnemySpawnerConfig spawnConfig, EnemyFactory enemyFactory,
            GridMaker gridMaker, EnemiesWeightsConfig weightsConfigt)
        {
            _spawnConfig = spawnConfig;
            _enemyFactory = enemyFactory;
            _spawnPoint = spawnPoint;
            _enemiesForceWeight = new EnemiesForceWeight(ForceWeightThreshold, weightsConfigt, this, this);

            _context = ContextMaker.Make();

            gridMaker.GetGridPoints(_spawnPoint.position).ForEach(spawnPosition => _spawnPoints.Add(new EnemySpawnPoint(spawnPosition)));

            _enemiesForceWeight.LimitExceeded += OnLimitExceed;
            _enemiesForceWeight.ValueConsistented += OnLimitNormalize; 
        }

        public event Action<Enemy> Spawned;

        public event Action<Enemy> EnemiDied;

        public IEnumerable<Enemy> Enemies => _spawnPoints.Where(x => x.IsEmpty == false).Select(x => x.PointObject);

        public int ForceWeightThreshold => _spawnConfig.ForceWeightThreshold;

        public IReadOnlyForceWeight ForceWeight => _enemiesForceWeight;

        public void Dispose()
        {
            StopSpawn();

            _enemiesForceWeight.LimitExceeded -= OnLimitExceed;
            _enemiesForceWeight.ValueConsistented -= OnLimitNormalize;

            _enemiesForceWeight.Dispose();
        }

        public void StartSpawn()
        {
            StopSpawn();

            _spawnCoroutine = _context.StartCoroutine(SpawnCoroutine());
        }

        public void StopSpawn()
        {
            if (_spawnCoroutine != null && _context != null)
                _context.StopCoroutine(_spawnCoroutine);
        }

        private void OnLimitExceed()
        {
            _isPaused = true;
        }

        private void OnLimitNormalize()
        {
            _isPaused = false;
        }

        private IEnumerator SpawnCoroutine()
        {
            EnemySpawnPoint spawnPoint;

            var spawnDelay = new WaitForSeconds(_spawnConfig.SpawnCooldown);
            bool isEnd = false;

            while (isEnd == false)
            {
                spawnPoint = GetEmptyRandomPoint();

                if (spawnPoint != null && _isPaused == false)
                    SpawnRandomEnemy(spawnPoint);

                yield return spawnDelay;
            }
        }

        private EnemySpawnPoint GetEmptyRandomPoint()
        {
            IEnumerable<EnemySpawnPoint> emptySpawnPoints = GetEmptySpawnPoints();

            if (emptySpawnPoints.Count() == 0)
                return null;

            int randomPointIndex = Random.Range(0, emptySpawnPoints.Count());

            return emptySpawnPoints.ElementAt(randomPointIndex);
        }

        private IEnumerable<EnemySpawnPoint> GetEmptySpawnPoints()
        {
            return _spawnPoints.Where(x => x.IsEmpty);
        }

        private void SpawnRandomEnemy(EnemySpawnPoint spawnPoint)
        {
            EnemyType randomEnemyType = (EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
            Enemy enemy = _enemyFactory.Get(randomEnemyType);

            enemy.Died += OnEnemyDie;
            enemy.MoveTo(spawnPoint.Position);
            enemy.SetParrent(_spawnPoint);

            spawnPoint.Set(enemy);

            Spawned?.Invoke(enemy);
        }

        private void OnEnemyDie(Enemy enemy)
        {
            enemy.Died -= OnEnemyDie;

            EnemySpawnPoint spawnPoint = _spawnPoints.Where(x => x.PointObject == enemy).FirstOrDefault();
            spawnPoint?.Unset();

            EnemiDied?.Invoke(enemy);
        }
    }
}
