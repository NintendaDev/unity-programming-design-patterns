using Example08.Configurations;
using Example08.Stats;

namespace Example08.Specializations
{
    public class SpecializationProvider : IStatsProvider
    {
        private IStatsProvider _statsProvider;
        private SpecializationType _specializationType;
        private SpecializationsConfiguration _specializationsConfiguration;

        public SpecializationProvider(IStatsProvider statsProvider, SpecializationType specializationType,
            SpecializationsConfiguration specializationsConfiguration)
        {
            _statsProvider = statsProvider;
            _specializationType = specializationType;
            _specializationsConfiguration = specializationsConfiguration;
        }

        public BaseStats Make()
        {
            BaseStats specialization;

            switch(_specializationType)
            {
                case SpecializationType.Barbarian:
                    specialization = new BaseStats(_specializationsConfiguration.BarbarianParameters);
                    break;

                case SpecializationType.Magician:
                    specialization = new BaseStats(_specializationsConfiguration.MagicianParameters);
                    break;

                case SpecializationType.Thief:
                    specialization = new BaseStats(_specializationsConfiguration.ThiefParameters);
                    break;

                default:
                    throw new System.Exception("Detected unknown specialization type");
            }

            return _statsProvider.Make() + specialization;
        }
    }
}
