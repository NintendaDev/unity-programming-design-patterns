using Example08.Configurations;

namespace Example08.Stats
{
    public class RaceStatsProvider : IStatsProvider
    {
        private RaceType _raceType;
        private RacialConfiguration _racialConfiguration;

        public RaceStatsProvider(RaceType raceType, RacialConfiguration racialConfiguration)
        {
            _raceType = raceType;
            _racialConfiguration = racialConfiguration;
        }

        public BaseStats Make()
        {
            BaseStats raceStats;

            switch(_raceType)
            {
                case RaceType.Elf:
                    raceStats = new BaseStats(_racialConfiguration.ElfParameters);
                    break;

                case RaceType.Human:
                    raceStats = new BaseStats(_racialConfiguration.HumanParameters);
                    break;

                case RaceType.Ork:
                    raceStats = new BaseStats(_racialConfiguration.OrkParameters);
                    break;

                default:
                    throw new System.Exception("Detected unknown race type");

            }

            return raceStats;
        }
    }
}
