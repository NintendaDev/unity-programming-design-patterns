using Example09.Enemies;
using UnityEngine;

namespace Example09.Spawners
{
    public class EnemySpawnPoint : SpawnPoint<Enemy>
    {
        public EnemySpawnPoint(Vector3 position, Enemy enemy) : base(position, enemy)
        {
        }

        public EnemySpawnPoint(Vector3 position) : base(position)
        {
        }
    }
}
