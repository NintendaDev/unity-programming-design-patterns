using Example08.Configurations;
using Example08.Stats;

namespace Example08.Specializations.Decorators
{
    public class BarbarianSpecialization : ModifiedStats
    {
        public BarbarianSpecialization(IStats stats, SpecializationsConfiguration configuration) : base(stats, configuration.BarbarianSpecilization)
        {
        }
    }
}
