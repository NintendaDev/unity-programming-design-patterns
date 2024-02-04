using Example06.Core;
using Specifications;
using System;

namespace Example06.Attributes
{
    public class Experience : IReadOnlyNotifiedValue, IReset
    {
        public Experience()
        {
            Value = 0;
        }

        public Experience(int currentValue)
        {
            IntValidator.GreatOrEqualZero(currentValue);
            Value = currentValue;
        }

        public event Action<int, int> Changed;

        public int Value { get; private set; }

        public void Reset()
        {
            Value = 0;
            Changed?.Invoke(Value, Value);
        }

        public void AddExperience(int delta)
        {
            IntValidator.GreatOrEqualZero(delta);

            int previousExperienceValue = Value;
            Value += delta;
            Changed?.Invoke(previousExperienceValue, Value);
        }
    }
}
