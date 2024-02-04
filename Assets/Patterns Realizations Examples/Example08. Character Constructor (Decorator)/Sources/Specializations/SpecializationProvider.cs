using Example08.Configurations;
using Example08.Specializations.Decorators;
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

        public IStats Make(IStats stats, SpecializationType specializationType)
        {
            IStats specialization;

            switch(specializationType)
            {
                case SpecializationType.Barbarian:
                    specialization = new BarbarianSpecialization(stats, _specializationsConfiguration);
                    break;

                case SpecializationType.Magician:
                    specialization = new MagicianSpecialization(stats, _specializationsConfiguration);
                    break;

                case SpecializationType.Thief:
                    specialization = new ThiefSpecialization(stats, _specializationsConfiguration);
                    break;

                default:
                    throw new System.Exception("Detected unknown specialization type");
            }

            return specialization;
        }
    }
}
