using UnityEngine;

namespace Example08.Attributes.Decorators.Racial
{
    public class HumanForce : IForce
    {
        private const float DecreasePercent = 0.8f;

        private IForce _force;

        public HumanForce(IForce force)
        {
            _force = force;
        }

        public int MaxValue => _force.MaxValue;

        public int Value => _force.Value;

        public void Decrease(int value) => _force.Decrease((int)Mathf.Ceil((value * DecreasePercent)));

        public void Increase(int value) => _force.Increase(value);
    }
}
