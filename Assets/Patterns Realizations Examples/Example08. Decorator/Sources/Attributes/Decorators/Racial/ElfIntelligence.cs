namespace Example08.Attributes.Decorators.Racial
{
    public class ElfIntelligence : IIntelligence
    {
        private const int AdditionalValue = 150;

        private IIntelligence _intelligence;

        public ElfIntelligence(IIntelligence intelligence)
        {
            _intelligence = intelligence;
        }

        public int MaxValue => _intelligence.MaxValue;

        public int Value
        {
            get
            {
                int value = _intelligence.Value + AdditionalValue;

                if (value > MaxValue)
                    value = MaxValue;

                return value;
            }
        }

        public void Decrease(int value) => _intelligence.Decrease(value);

        public void Increase(int value) => _intelligence.Increase(value);
    }
}
