using Example09.Enemies;

namespace Example09.UI
{
    public class RandomKillButton : UIButton
    {
        private RandomEnemyKiller _enemyKiller;

        public void Initialize(RandomEnemyKiller enemyKiller)
        {
            _enemyKiller = enemyKiller;
            CompleteInitialization();
        }

        protected override void OnButtonClick()
        {
            _enemyKiller.TryKill();
        }
    }
}
