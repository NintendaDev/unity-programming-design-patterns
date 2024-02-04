using Example08.Configurations;
using Example08.Stats;

namespace Example08.Specializations.Decorators
{
    public class MagicianSpecialization : ModifiedStats
    {
        public MagicianSpecialization(IStats stats, SpecializationsConfiguration configuration) : base(stats, configuration.MagicianSpecilization)
        {
        }
    }
}
