namespace Example08.Attributes.Decorators.Racial
{
    public class ElfForce : IForce
    {
        private const float IncreaseMultiplier = 1.25f;

        private IForce _force;

        public ElfForce(IForce force)
        {
            _force = force;
        }

        public int MaxValue => _force.MaxValue;

        public int Value => _force.Value;

        public void Decrease(int value) => _force.Decrease(value);

        public void Increase(int value) => _force.Increase((int)(value * IncreaseMultiplier));
    }
}
