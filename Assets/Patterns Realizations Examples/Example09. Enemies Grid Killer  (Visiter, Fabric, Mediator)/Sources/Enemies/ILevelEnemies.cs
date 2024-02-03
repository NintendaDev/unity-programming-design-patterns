using System.Collections.Generic;

namespace Example09.Enemies
{
    public interface ILevelEnemies
    {
        public IEnumerable<Enemy> Enemies { get; }
    }
}
