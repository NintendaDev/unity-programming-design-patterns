using Example06.Attributes;

namespace Example06.UI.DamageVisualization
{
    public class DamageMediator
    {
        private IDamageable _damageable;

        public DamageMediator(IDamageable damageable)
        {
            _damageable = damageable;
        }

        public void TakeDamage(int damage)
        {
            _damageable.TakeDamage(damage);
        }
    }
}
