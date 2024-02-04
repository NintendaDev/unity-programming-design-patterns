using Example08.Configurations;
using Example08.Stats.Racial;

namespace Example08.Stats
{
    public class RaceStatProvider
    {
        private RacialMaxStatsConfiguration _racialMaxStatsConfiguration;

        public RaceStatProvider(RacialMaxStatsConfiguration racialMaxStatsConfiguration)
        {
            _racialMaxStatsConfiguration = racialMaxStatsConfiguration;
        }

        public IStats Make(RaceType raceType)
        {
            IStats raceStats;

            switch(raceType)
            {
                case RaceType.Elf:
                    raceStats = new ElfStats(_racialMaxStatsConfiguration);
                    break;

                case RaceType.Human:
                    raceStats = new HumanStats(_racialMaxStatsConfiguration);
                    break;

                case RaceType.Ork:
                    raceStats = new OrcStats(_racialMaxStatsConfiguration);
                    break;

                default:
                    throw new System.Exception("Detected unknown race type");

            }

            return raceStats;
        }
    }
}
