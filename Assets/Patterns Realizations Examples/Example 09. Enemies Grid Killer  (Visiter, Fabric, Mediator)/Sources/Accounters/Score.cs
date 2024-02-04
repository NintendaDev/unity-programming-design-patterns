using Example09.Configurations;
using Example09.Enemies;
using Example09.Enemies.Types;
using System;

namespace Example09.Accounters
{
    public class Score: IDisposable
    {
        private IEnemyDeathNotifier _enemyDeathNotifier;
        private EnemyVisitor _enemyVisitor;

        public Score(IEnemyDeathNotifier enemyDeathNotifier, KillEnemyScoreConfig killEnemyScoreConfig)
        {
            _enemyDeathNotifier = enemyDeathNotifier;
            _enemyDeathNotifier.EnemiDied += OnEnemyKilled;

            _enemyVisitor = new EnemyVisitor(killEnemyScoreConfig);
        }

        public event Action<int, int> Changed;

        public int Value => _enemyVisitor.Score;

        public void Dispose()
        {
            _enemyDeathNotifier.EnemiDied -= OnEnemyKilled;
        }

        private void OnEnemyKilled(Enemy enemy)
        {
            int previousScore = _enemyVisitor.Score;
            _enemyVisitor.Visit(enemy);

            Changed?.Invoke(previousScore, _enemyVisitor.Score);
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            private KillEnemyScoreConfig _killEnemyScoreConfig;

            public EnemyVisitor(KillEnemyScoreConfig killEnemyScoreConfig)
            {
                _killEnemyScoreConfig = killEnemyScoreConfig;
            }

            public int Score { get; private set; }

            public void Visit(Ork ork) => Score += _killEnemyScoreConfig.OrkKillScore;

            public void Visit(Human human) => Score += _killEnemyScoreConfig.HumanKillScore;

            public void Visit(Elf elf) => Score += _killEnemyScoreConfig.ElfKillScore;

            public void Visit(Robot robot) => Score += _killEnemyScoreConfig.RobotKillScore;

            public void Visit(Enemy enemy) => Visit((dynamic) enemy);
        }
    }
}
