using Example06.Configurations;
using Example06.Core;
using System;

namespace Example06.Attributes
{
    public class Level : IReadOnlyNotifiedValue, IDisposable
    {
        private IReadOnlyNotifiedValue _experience;
        private LevelConfiguration _levelConfiguration;

        public Level(IReadOnlyNotifiedValue experience, LevelConfiguration levelConfiguration)
        {
            _experience = experience;
            _levelConfiguration = levelConfiguration;
            _experience.Changed += OnExpericenceChanged;
        }

        public event Action<int, int> Changed;

        public int Value { get; private set; }

        public void Dispose()
        {
            _experience.Changed -= OnExpericenceChanged;
        }

        private void OnExpericenceChanged(int previousValue, int currentValue)
        {
            int levelPreviousValue = Value;
            Value = _levelConfiguration.GetLevelBy(_experience.Value);
            Changed?.Invoke(levelPreviousValue, Value);
        }
    }
}