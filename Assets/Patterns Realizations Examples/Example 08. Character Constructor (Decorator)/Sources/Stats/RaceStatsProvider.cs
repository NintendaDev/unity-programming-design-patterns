using Example08.Configurations;

namespace Example08.Stats
{
    public class RaceStatsProvider
    {
        private RacialConfiguration _racialMaxStatsConfiguration;

        public RaceStatsProvider(RacialConfiguration racialMaxStatsConfiguration)
        {
            _racialMaxStatsConfiguration = racialMaxStatsConfiguration;
        }

        public BaseStats Make(RaceType raceType)
        {
            BaseStats raceStats;

            switch(raceType)
            {
                case RaceType.Elf:
                    raceStats = new BaseStats(_racialMaxStatsConfiguration.ElfParameters);
                    break;

                case RaceType.Human:
                    raceStats = new BaseStats(_racialMaxStatsConfiguration.HumanParameters);
                    break;

                case RaceType.Ork:
                    raceStats = new BaseStats(_racialMaxStatsConfiguration.OrkParameters);
                    break;

                default:
                    throw new System.Exception("Detected unknown race type");

            }

            return raceStats;
        }
    }
}
