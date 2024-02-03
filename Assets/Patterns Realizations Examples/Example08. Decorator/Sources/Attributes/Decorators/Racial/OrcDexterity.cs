namespace Example08.Attributes.Decorators.Racial
{
    public class OrcDexterity : IDexterity
    {
        private const float IncreaseMultiplier = 1.05f;

        private IDexterity _dexterity;

        public OrcDexterity(IDexterity dexterity)
        {
            _dexterity = dexterity;
        }

        public int MaxValue => _dexterity.MaxValue;

        public int Value => _dexterity.Value;

        public void Decrease(int value) => _dexterity.Decrease(value);

        public void Increase(int value) => _dexterity.Increase((int)(value * IncreaseMultiplier));
    }
}
