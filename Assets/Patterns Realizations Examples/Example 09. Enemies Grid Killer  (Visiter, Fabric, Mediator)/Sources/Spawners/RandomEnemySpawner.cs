using Example09.Enemies;
using MonoUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Example09.Core;
using Sirenix.OdinInspector;
using Example09.Accounters;
using Random = UnityEngine.Random;

namespace Example09.Spawners
{
    public class RandomEnemySpawner: InitializedMonoBehaviour, ISpawner, ILevelEnemies, IEnemySpawnNotifier, IEnemyDeathNotifier
    {
        [SerializeField, MinValue(0)] private int _forceWeightThreshold = 50;
        [SerializeField, MinValue(0)] private float _spawnCooldown;
        [SerializeField, Required] private EnemyFactory _enemyFactory;

        private Coroutine _spawnCoroutine;
        private List<EnemySpawnPoint> _spawnPoints = new();
        private Transform _transform;
        private EnemiesForceWeight _enemiesForceWeight;
        private bool _isPaused;

        public event Action<Enemy> Spawned;

        public event Action<Enemy> EnemiDied;

        public IEnumerable<Enemy> Enemies => _spawnPoints.Where(x => x.IsEmpty == false).Select(x => x.PointObject);

        public int ForceWeightThreshold => _forceWeightThreshold;

        public void Initialize(GridMaker gridMaker, EnemiesForceWeight spawnForceWeight)
        {
            _transform = transform;

            _enemiesForceWeight = spawnForceWeight;

            _spawnPoints.Clear();
            gridMaker.GetGridPoints(transform.position).ForEach(spawnPosition => _spawnPoints.Add(new EnemySpawnPoint(spawnPosition)));

            CompleteInitialization();
        }

        private void OnEnable()
        {
            _enemiesForceWeight.LimitExceeded += OnLimitExceed;
            _enemiesForceWeight.ValueConsistented += OnLimitNormalize;
        }

        private void OnDisable()
        {
            _enemiesForceWeight.LimitExceeded -= OnLimitExceed;
            _enemiesForceWeight.ValueConsistented -= OnLimitNormalize;
        }

        [Button, DisableInEditorMode]
        public bool StartSpawn()
        {
            StopSpawn();
            _spawnCoroutine = StartCoroutine(SpawnCoroutine());

            return true;
        }

        public void StopSpawn()
        {
            if (_spawnCoroutine != null)
                StopCoroutine(_spawnCoroutine);
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
            bool isEnd = false;
            var cooldownWaiter = new WaitForSeconds(_spawnCooldown);
            EnemySpawnPoint spawnPoint;

            while (isEnd == false)
            {
                spawnPoint = GetEmptyRandomPoint();

                if (spawnPoint == null || _isPaused)
                {
                    yield return cooldownWaiter;

                    continue;
                }

                SpawnRandomEnemy(spawnPoint);

                yield return cooldownWaiter;
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
            enemy.SetParrent(_transform);

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
