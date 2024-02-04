using Example09.Configurations;
using Example09.Enemies;
using Example09.Enemies.Types;
using System.Collections.Generic;

namespace Example09.Accounters
{
    public class EnemiesForceWeight
    {
        private EnemyVisiter _weightVisiter;

        public EnemiesForceWeight(EnemiesWeightsConfig config)
        {
            _weightVisiter = new EnemyVisiter(config);
        }

        public int Value => _weightVisiter.Weight;

        public void Update(IEnumerable<Enemy> enemies)
        {
            _weightVisiter.Reset();

            foreach (Enemy enemy in enemies)
                _weightVisiter.Visit(enemy);
        }

        private class EnemyVisiter : IEnemyVisitor
        {
            private EnemiesWeightsConfig _config;

            public EnemyVisiter(EnemiesWeightsConfig config)
            {
                _config = config;
            }

            public int Weight { get; private set; }

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);

            public void Visit(Ork ork) => Weight += _config.OrkWeight;

            public void Visit(Human human) => Weight += _config.HumanWeight;

            public void Visit(Elf elf) => Weight += _config.ElfWeight;

            public void Visit(Robot robot) => Weight += _config.RobotWeight;

            public void Reset() => Weight = 0;
        }
    }
}
