using System;

namespace Example05.UI.HealthVisualization
{
    public class HealthMediator : IDisposable
    {
        private IHealth _health;
        private HealthIndicator _healthIndicator;

        public HealthMediator(IHealth health, HealthIndicator healthIndicator)
        {
            _health = health;
            _healthIndicator = healthIndicator;
            _health.Changed += OnHealthChanged;

            OnHealthChanged(_health.CurrentValue, _health.CurrentValue);
        }

        public void Dispose()
        {
            _health.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged(int previousValue, int currentValue)
        {
            _healthIndicator.UpdateHealthVisualization(previousValue, currentValue, _health.MaxValue);
        }
    }
}
