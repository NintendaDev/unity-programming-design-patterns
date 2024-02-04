using Example08.Configurations;

namespace Example08.Stats.Racial
{
    public class ElfStats : BaseStats
    {
        public ElfStats(RacialMaxStatsConfiguration maxStatsConfiguration) : base(maxStatsConfiguration.ElfStatMaxParameters)
        {
        }
    }
}
