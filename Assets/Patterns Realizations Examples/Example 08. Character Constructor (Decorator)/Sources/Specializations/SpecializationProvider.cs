using Example08.Configurations;
using Example08.Stats;

namespace Example08.Specializations
{
    public class SpecializationProvider
    {
        private SpecializationsConfiguration _specializationsConfiguration;

        public SpecializationProvider(SpecializationsConfiguration specializationsConfiguration)
        {
            _specializationsConfiguration = specializationsConfiguration;
        }

        public BaseStats Make(SpecializationType specializationType)
        {
            BaseStats specialization;

            switch(specializationType)
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

            return specialization;
        }
    }
}
