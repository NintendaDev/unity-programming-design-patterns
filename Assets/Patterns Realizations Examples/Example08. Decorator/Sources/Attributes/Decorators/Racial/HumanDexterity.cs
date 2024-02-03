namespace Example08.Attributes.Decorators.Racial
{
    public class HumanDexterity : IDexterity
    {
        private const float ValueMultiplier = 1.3f;

        private IDexterity _dexterity;

        public HumanDexterity(IDexterity dexterity)
        {
            _dexterity = dexterity;
        }

        public int MaxValue => _dexterity.MaxValue;

        public int Value
        {
            get
            {
                int value = (int)(_dexterity.Value * ValueMultiplier);

                if (value > MaxValue)
                    value = MaxValue;

                return value;
            }
        }

        public void Decrease(int value) => _dexterity.Decrease(value);

        public void Increase(int value) => _dexterity.Increase(value);
    }
}
