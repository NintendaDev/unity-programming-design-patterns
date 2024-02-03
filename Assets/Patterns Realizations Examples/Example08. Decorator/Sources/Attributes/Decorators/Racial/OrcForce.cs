namespace Example08.Attributes.Decorators.Racial
{
    public class OrcForce : IForce
    {
        private const float MaxValueMultiplier = 1.4f;

        private IForce _force;

        public OrcForce(IForce force)
        {
            _force = force;
        }

        public int MaxValue => (int)(_force.MaxValue * MaxValueMultiplier);

        public int Value => _force.Value;

        public void Decrease(int value) => _force.Decrease(value);

        public void Increase(int value) => _force.Increase(value);
    }
}
