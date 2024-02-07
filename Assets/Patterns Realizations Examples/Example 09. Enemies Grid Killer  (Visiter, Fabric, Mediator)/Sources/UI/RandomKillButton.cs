using Example09.Enemies;
using Zenject;

namespace Example09.UI
{
    public class RandomKillButton : UIButton
    {
        private RandomEnemyKiller _enemyKiller;

        [Inject]
        private void Construct(RandomEnemyKiller enemyKiller)
        {
            _enemyKiller = enemyKiller;
        }

        protected override void OnButtonClick()
        {
            _enemyKiller.TryKill();
        }
    }
}
