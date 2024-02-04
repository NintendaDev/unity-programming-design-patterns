using Example09.Enemies;
using System;

namespace Example09.Spawners
{
    public interface IEnemySpawnNotifier
    {
        public event Action<Enemy> Spawned;
    }
}
