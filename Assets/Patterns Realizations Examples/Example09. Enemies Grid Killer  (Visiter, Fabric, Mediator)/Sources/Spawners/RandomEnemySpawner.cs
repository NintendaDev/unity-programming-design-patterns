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
        [SerializeField, MinValue(0)] private float _spawnCooldown;
        [SerializeField, MinValue(0)] private int _forceWeightThreshold = 50;
        [SerializeField, Required] private EnemyFactory _enemyFactory;

        private Coroutine _spawn;
        private Dictionary<Vector3, Enemy> _spawnedEnemies = new();
        private Transform _transform;
        private EnemiesForceWeight _enemiesForceWeight;

        public event Action<Enemy> Spawned;

        public event Action<int, int> ForceWeightChanged;

        public event Action<Enemy> EnemiDied;

        public IEnumerable<Enemy> Enemies => _spawnedEnemies.Where(x => x.Value != null).Select(x => x.Value);

        public int ForceWeightThreshold => _forceWeightThreshold;

        public int CurrentForceEnemyWeight => _enemiesForceWeight.Value;

        public void Initialize(GridMaker gridMaker, EnemiesForceWeight spawnForceWeight)
        {
            _transform = transform;

            _enemiesForceWeight = spawnForceWeight;

            _spawnedEnemies.Clear();
            gridMaker.GetGridPoints(transform.position).ForEach(spawnPosition => _spawnedEnemies.Add(spawnPosition, null));

            CompleteInitialization();
        }

        [Button, DisableInEditorMode]
        public bool TrySpawn()
        {
            Stop();

            List<Vector3> freeSpawnPoints = _spawnedEnemies.Where(x => x.Value == null).Select(x => x.Key).ToList();

            if (freeSpawnPoints.Count() == 0)
                return false;

            _spawn = StartCoroutine(Spawn(freeSpawnPoints));

            return true;
        }

        public void Stop()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        private IEnumerator Spawn(IEnumerable<Vector3> spawnPoints)
        {
            foreach(Vector3 spawnPoint in spawnPoints)
            {
                if (_enemiesForceWeight.Value >= _forceWeightThreshold)
                    break;

                if (_spawnedEnemies[spawnPoint] != null)
                    throw new Exception("The creation point is already occupied by another object");

                EnemyType randomEnemyType = (EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
                Enemy enemy = _enemyFactory.Get(randomEnemyType);

                enemy.Died += OnEnemyDie;
                enemy.MoveTo(spawnPoint);
                enemy.SetParrent(_transform);

                _spawnedEnemies[spawnPoint] = enemy;
                Spawned?.Invoke(enemy);

                UpdateForceWeight();

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void UpdateForceWeight()
        {
            _enemiesForceWeight.Update(Enemies);
            ForceWeightChanged?.Invoke(CurrentForceEnemyWeight, ForceWeightThreshold);
        }

        private void OnEnemyDie(Enemy enemy)
        {
            enemy.Died -= OnEnemyDie;

            Vector3 enemySpawnedPosition = _spawnedEnemies
                .Where(x => x.Value == enemy)
                .Select(x => x.Key)
                .First();

            _spawnedEnemies[enemySpawnedPosition] = null;
            UpdateForceWeight();

            EnemiDied?.Invoke(enemy);
        }
    }
}
