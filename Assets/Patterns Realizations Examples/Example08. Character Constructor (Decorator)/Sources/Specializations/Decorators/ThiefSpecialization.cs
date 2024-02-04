using Example08.Configurations;
using Example08.Stats;

namespace Example08.Specializations.Decorators
{
    public class ThiefSpecialization : ModifiedStats
    {
        public ThiefSpecialization(IStats stats, SpecializationsConfiguration configuration) : base(stats, configuration.ThiefSpecilization)
        {
        }
    }
}
