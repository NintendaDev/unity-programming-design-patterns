using Example06.Core;
using Specifications;
using System;

namespace Example06.Attributes
{
    public class Experience : IReadOnlyExperience, IReset
    {
        public Experience()
        {
            Value = 0;
        }

        public Experience(int currentValue)
        {
            StaticSpecification.ValidateIntGreatOrEqualZero(currentValue);
            Value = currentValue;
        }

        public event Action<int> Changed;

        public int Value { get; private set; }

        public void Reset()
        {
            Value = 0;
            Changed?.Invoke(Value);
        }

        public void AddExperience(int delta)
        {
            StaticSpecification.ValidateIntGreatOrEqualZero(delta);
            Value += delta;

            Changed?.Invoke(Value);
        }
    }
}
