using Specifications;
using System;

namespace Example08.Attributes
{
    public class AttributeValue
    {
        private int _value;
        private int _previousValue;

        public AttributeValue()
        {
            Value = MaxValue = 0;
        }

        public AttributeValue(int maxValue, int value) : this(maxValue)
        {
            IntValidator.GreatOrEqualZero(value);

            if (value > maxValue)
                throw new Exception("Ìalue is greater than maximum value");

            Value = value;
        }

        public AttributeValue(int maxValue)
        {
            IntValidator.GreatOrEqualZero(maxValue);
            MaxValue = maxValue;
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
            Changed?.Invoke(_previousValue, Value);
        }

        public void Decrease(int value)
        {
            IntValidator.GreatOrEqualZero(value);

            Value -= value;
            Changed?.Invoke(_previousValue, Value);
        }
    }
}
