using Specifications;

namespace Example02.Core
{
    public class IntCounterBehaviour
    {
        private const int MinStartValue = 0;
        private int _value;
        private ISpecification<int>[] _valueSpecifications;

        public IntCounterBehaviour()
        {
            _value = MinStartValue;
        }

        public IntCounterBehaviour(int startValue)
        {
            Value = startValue;
        }

        public IntCounterBehaviour(int startValue, ISpecification<int> valueSpecification) : this(startValue, 
            new ISpecification<int>[1] { valueSpecification })
        {
        }

        public IntCounterBehaviour(int startValue, ISpecification<int>[] valueSpecifications) : this(startValue)
        {
            _valueSpecifications = valueSpecifications;
        }

        public int Value { 

            get => _value; 

            set
            {
                ValidateCounterValue(value);
                _value = value;
            }
        }

        public void Increase(int value)
        {
            ValidateCounterValue(value);

            Value += value;
        }

        private void ValidateCounterValue(int value)
        {
            if (IsSatisfiedBySpecifications(value) == false)
                throw new System.ArgumentOutOfRangeException(nameof(value));
        }

        private bool IsSatisfiedBySpecifications(int value)
        {
            if (_valueSpecifications == null)
                return true;

            foreach (ISpecification<int> valueSpecification in _valueSpecifications)
            {
                if (valueSpecification.IsSatisfiedBy(value) == false)
                    return false;
            }

            return true;
        }
    }
}
