namespace Example08.Attributes.Decorators.Racial
{
    public class ElfDexterity : IDexterity
    {
        private const float DecreaseMultiplier = 1.2f;

        private IDexterity _dexterity;

        public ElfDexterity(IDexterity dexterity)
        {
            _dexterity = dexterity;
        }

        public int MaxValue => _dexterity.MaxValue;

        public int Value => _dexterity.Value;

        public void Decrease(int value) => _dexterity.Decrease((int)(value * DecreaseMultiplier));

        public void Increase(int value) => _dexterity.Increase(value);
    }
}
