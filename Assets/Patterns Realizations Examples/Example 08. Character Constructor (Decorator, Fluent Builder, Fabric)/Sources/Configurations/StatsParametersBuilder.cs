namespace Example08.Configurations
{
    public class StatsParametersBuilder
    {
        private int _maxForce;
        private int _force;
        private int _maxIntelligence;
        private int _intelligence;
        private int _maxDexterity;
        private int _dexterity;

        public StatsParametersBuilder SetForce(int force)
        {
            _force = force;

            return this;
        }

        public StatsParametersBuilder SetMaxForce(int maxForce)
        {
            _maxForce = maxForce;

            return this;
        }

        public StatsParametersBuilder SetIntelligence(int intelligence)
        {
            _intelligence = intelligence;

            return this;
        }

        public StatsParametersBuilder SetMaxIntelligence(int maxIntelligence)
        {
            _maxIntelligence = maxIntelligence;

            return this;
        }

        public StatsParametersBuilder SetDexterity(int dexterity)
        {
            _dexterity = dexterity;

            return this;
        }

        public StatsParametersBuilder SetMaxDexterity(int maxDexterity)
        {
            _maxDexterity = maxDexterity;

            return this;
        }

        public StatsParameters Build()
        {
            return new StatsParameters(_force, _maxForce, _intelligence, 
                _maxIntelligence, _dexterity, _maxDexterity);
        }
    }
}
