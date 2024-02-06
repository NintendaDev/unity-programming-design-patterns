using Example08.Attributes;
using Example08.Configurations;

namespace Example08.Stats
{
    public class BaseStats
    {
        private AttributeValue _force;
        private AttributeValue _intelligence;
        private AttributeValue _dexterity;

        public BaseStats()
        {
            _force = new AttributeValue();
            _intelligence = new AttributeValue();
            _dexterity = new AttributeValue();
        }

        public BaseStats(StatsParameters parameters)
        {
            _force = new AttributeValue(parameters.MaxForce, parameters.Force);
            _intelligence = new AttributeValue(parameters.MaxIntelligence, parameters.Intelligence);
            _dexterity = new AttributeValue(parameters.MaxDexterity, parameters.Dexterity);
        }

        public int MaxForce => _force.MaxValue;

        public int Force => _force.Value;

        public int MaxIntelligence => _intelligence.MaxValue;

        public int Intelligence => _intelligence.Value;

        public int MaxDexterity => _dexterity.MaxValue;

        public int Dexterity => _dexterity.Value;

        public static BaseStats operator + (BaseStats firstStats, BaseStats secondStats)
        {
            StatsParameters statsParameters = new StatsParametersBuilder()
                .SetForce(firstStats.Force + secondStats.Force)
                .SetMaxForce(firstStats.MaxForce + secondStats.MaxForce)
                .SetIntelligence(firstStats.Intelligence + secondStats.Intelligence)
                .SetMaxIntelligence(firstStats.MaxIntelligence + secondStats.MaxIntelligence)
                .SetDexterity(firstStats.Dexterity + secondStats.Dexterity)
                .SetMaxDexterity(firstStats.MaxDexterity + secondStats.MaxDexterity)
                .Build();

            return new BaseStats(statsParameters);
        }

        public void IncreaseForce(int value) => _force.Increase(value);

        public void DecreaseForce(int value) => _force.Decrease(value);

        public void IncreaseIntelligence(int value) => _intelligence.Increase(value);

        public void DecreaseIntelligence(int value) => _intelligence.Decrease(value);

        public void IncreaseDexterity(int value) => _dexterity.Increase(value);

        public void DecreaseDexterity(int value) => _dexterity.Decrease(value);
    }
}
