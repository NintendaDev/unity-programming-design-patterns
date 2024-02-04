using Example08.Attributes;
using Example08.Configurations;

namespace Example08.Stats
{
    public abstract class BaseStats : IStats
    {
        private AttributeValue _force;
        private AttributeValue _intelligence;
        private AttributeValue _dexterity;

        public BaseStats(StatsMaxParameters maxParameters) : this(maxParameters.MaxForce, maxParameters.MaxIntelligence, maxParameters.MaxDexterity)
        {
        }

        public BaseStats(int maxForce, int maxIntelligence, int maxDexterity)
        {
            _force = new AttributeValue(maxForce);
            _intelligence = new AttributeValue(maxIntelligence);
            _dexterity = new AttributeValue(maxDexterity);
        }

        public int MaxForce => _force.MaxValue;

        public int Force => _force.Value;

        public int MaxIntelligence => _intelligence.MaxValue;

        public int Intelligence => _intelligence.Value;

        public int MaxDexterity => _dexterity.MaxValue;

        public int Dexterity => _dexterity.Value;

        public void IncreaseForce(int value) => _force.Increase(value);

        public void DecreaseForce(int value) => _force.Decrease(value);

        public void IncreaseIntelligence(int value) => _intelligence.Increase(value);

        public void DecreaseIntelligence(int value) => _intelligence.Decrease(value);

        public void IncreaseDexterity(int value) => _dexterity.Increase(value);

        public void DecreaseDexterity(int value) => _dexterity.Decrease(value);
    }
}
