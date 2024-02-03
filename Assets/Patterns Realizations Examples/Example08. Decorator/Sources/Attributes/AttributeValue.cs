using Specifications;
using System;

namespace Example08.Attributes
{
    public abstract class AttributeValue : IAttribute
    {
        private int _value;
        private int _previousValue;

        public AttributeValue(int maxValue)
        {
            IntValidator.GreatOrEqualZero(maxValue);
            MaxValue = Value = maxValue;
        }

        public event Action<int, int> Changed;

        public int MaxValue { get; private set; }

        public int Value
        {
            get => _value;

            private set
            {
                _previousValue = _value;
                _value = value;

                if (_value < 0)
                    _value = 0;
            }
        }

        public void Increase(int value)
        {
            IntValidator.GreatOrEqualZero(value);

            Value += value;
            Changed?.Invoke(Value, _previousValue);
        }

        public void Decrease(int value)
        {
            IntValidator.GreatOrEqualZero(value);

            Value -= value;
            Changed?.Invoke(Value, _previousValue);
        }
    }
}
