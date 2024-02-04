using Example08.Configurations;

namespace Example08.Stats.Racial
{
    public class HumanStats : BaseStats
    {
        public HumanStats(RacialMaxStatsConfiguration maxStatsConfiguration) : base(maxStatsConfiguration.HumanStatMaxParameters)
        {
        }
    }
}
