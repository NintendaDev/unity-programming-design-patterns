using Example05.UI.HealthVisualization;
using Example06.Core;
using Specifications;
using System;
using UnityEngine;

namespace Example06.Attributes
{
    public class Health : IHealth, IDamageable, IDisposable
    {
        private int _currentValue;
        private int _maxValue;
        private IReadOnlyNotifiedValue _level;
        private IValueByLevel _healthConfiguration;

        public Health(IReadOnlyNotifiedValue level, IValueByLevel healthConfiguration, int currentValue) : this(level, healthConfiguration)
        {
            if (currentValue > MaxValue)
                throw new Exception("An attempt to set the current health above the maximum");

            int previousLevel = Mathf.Max(level.Value - 1, 0);
            int previousHealthMaxValue = healthConfiguration.GetMaxValueBy(previousLevel);

            if (currentValue < previousHealthMaxValue)
                throw new Exception("The current health does not match the player's current level");

            CurrentValue = currentValue;
        }

        public Health(IReadOnlyNotifiedValue level, IValueByLevel healthConfiguration)
        {
            _level = level;
            _healthConfiguration = healthConfiguration;

            _level.Changed += OnLevelChanged;
            UpdateMaxValueFromConfiguration();
            CurrentValue = MaxValue;
        }

        public event Action<int, int> Changed;

        public event Action Died;

        public int MaxValue
        {
            get => _maxValue;

            private set
            {
                _maxValue = value;

                if (_maxValue < 0)
                    _maxValue = 0;
            }
        }

        public int CurrentValue
        {
            get => _currentValue;

            private set
            {
                _currentValue = value;

                if (_currentValue < 0)
                    _currentValue = 0;
            }
        }

        public float Percent => CurrentValue / (float)MaxValue;

        public void TakeDamage(int damage)
        {
            IntValidator.GreatOrEqualZero(damage);

            int previousValue = CurrentValue;
            CurrentValue -= damage;

            Changed?.Invoke(previousValue, CurrentValue);

            if (CurrentValue == 0)
                Died?.Invoke();
        }

        public void Dispose()
        {
            _level.Changed -= OnLevelChanged;
        }

        private void OnLevelChanged(int previousLevelValue, int currentLevelValue)
        {
            if (previousLevelValue == currentLevelValue)
                return;

            UpdateMaxValueFromConfiguration();

            int previousHealthValue = CurrentValue;
            CurrentValue = MaxValue;

            Changed?.Invoke(previousHealthValue, CurrentValue);
        }

        private void UpdateMaxValueFromConfiguration()
        {
            MaxValue = _healthConfiguration.GetMaxValueBy(_level.Value);
        }
    }
}
