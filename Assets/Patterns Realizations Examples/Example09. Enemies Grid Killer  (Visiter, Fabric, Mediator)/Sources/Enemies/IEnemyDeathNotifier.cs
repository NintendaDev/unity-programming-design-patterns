using System;

namespace Example09.Enemies
{
    public interface IEnemyDeathNotifier
    {
        event Action<Enemy> EnemiDied;
    }
}
