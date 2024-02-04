using Example08.Configurations;

namespace Example08.Stats.Racial
{ 
    public class OrcStats : BaseStats
    {
        public OrcStats(RacialMaxStatsConfiguration maxStatsConfiguration) : base(maxStatsConfiguration.OrkStatMaxParameters)
        {
        }
    }
}
