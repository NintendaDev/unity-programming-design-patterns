using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Example09.Enemies
{
    public class RandomEnemyKiller
    {
        private ILevelEnemies _enemiesAggregator;

        public RandomEnemyKiller(ILevelEnemies enemiesAggregator)
        {
            _enemiesAggregator = enemiesAggregator;
        }

        public bool TryKill()
        {
            IEnumerable<Enemy> enemies = _enemiesAggregator.Enemies;
            int enemiesCount = enemies.Count();

            if (enemiesCount == 0)
                return false;

            Enemy randomEnemy = enemies.ElementAt(Random.Range(0, enemiesCount));
            randomEnemy.Kill();

            return true;
        }
    }
}
