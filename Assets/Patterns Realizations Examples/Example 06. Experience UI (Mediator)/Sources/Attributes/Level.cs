using Example06.Configurations;
using System;

namespace Example06.Attributes
{
    public class Level : IReadOnlyLevel, IDisposable
    {
        private IReadOnlyExperience _experience;
        private LevelConfiguration _levelConfiguration;

        public Level(IReadOnlyExperience experience, LevelConfiguration levelConfiguration)
        {
            _experience = experience;
            _levelConfiguration = levelConfiguration;
            _experience.Changed += OnExpericenceChanged;
        }

        public event Action<int> Changed;

        public int Value { get; private set; }

        public void Dispose()
        {
            _experience.Changed -= OnExpericenceChanged;
        }

        private void OnExpericenceChanged(int value)
        {
            Value = _levelConfiguration.GetLevelBy(_experience.Value);
            Changed?.Invoke(Value);
        }
    }
}