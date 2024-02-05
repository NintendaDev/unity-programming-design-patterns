using Example09.Configurations;
using Example09.Enemies;
using Example09.Enemies.Types;
using Example09.Spawners;
using System;

namespace Example09.Accounters
{
    public class EnemiesForceWeight : IReadOnlyForceWeight, IDisposable
    {
        private readonly int _maxValue;
        private IEnemyDeathNotifier _deathNotifier;
        private IEnemySpawnNotifier _spawnNotifier;
        private EnemyVisiter _spawnedEnemyVisiter;
        private EnemyVisiter _deadEnemyVisiter;
        private int _value;

        public EnemiesForceWeight(int maxValue, EnemiesWeightsConfig config, IEnemySpawnNotifier spawnNotifier, IEnemyDeathNotifier deathNotifier)
        {
            _maxValue = maxValue;
            _deathNotifier = deathNotifier;
            _spawnNotifier = spawnNotifier;

            _spawnedEnemyVisiter = new EnemyVisiter(config, enemyWeight => { Value += enemyWeight; });
            _deadEnemyVisiter = new EnemyVisiter(config, enemyWeight => { Value -= enemyWeight; });

            _spawnNotifier.Spawned += OnEnemySpawn;
            _deathNotifier.EnemiDied += OnEnemyDead;
        }

        public event Action<int, int> Changed;

        public Action LimitExceeded;

        public Action ValueConsistented;

        public int Value {

            get => _value;

            private set
            {
                _value = value;

                if (_value < 0)
                    _value = 0;
            }
        }

        public int MaxValue => _maxValue;

        public void Dispose()
        {
            _spawnNotifier.Spawned -= OnEnemySpawn;
            _deathNotifier.EnemiDied -= OnEnemyDead;
        }

        private void OnEnemySpawn(Enemy enemy)
        {
            VisitEnemy(_spawnedEnemyVisiter, enemy);
        }

        private void OnEnemyDead(Enemy enemy)
        {
            VisitEnemy(_deadEnemyVisiter, enemy);
        }

        private void VisitEnemy(EnemyVisiter visiter, Enemy enemy)
        {
            visiter.Visit(enemy);

            if (Value > MaxValue)
                LimitExceeded?.Invoke();
            else
                ValueConsistented?.Invoke();

            Changed?.Invoke(Value, MaxValue);
        }

        private class EnemyVisiter : IEnemyVisitor
        {
            private EnemiesWeightsConfig _config;
            private Action<int> _enemyWeightAction;

            public EnemyVisiter(EnemiesWeightsConfig config, Action<int> enemyWeightAction)
            {
                _config = config;
                _enemyWeightAction = enemyWeightAction;
            }

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);

            public void Visit(Ork ork) => _enemyWeightAction(_config.OrkWeight);

            public void Visit(Human human) => _enemyWeightAction(_config.HumanWeight);

            public void Visit(Elf elf) => _enemyWeightAction(_config.ElfWeight);

            public void Visit(Robot robot) => _enemyWeightAction(_config.RobotWeight);
        }
    }
}
