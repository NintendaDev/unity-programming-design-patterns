using Example08.Configurations;
using Example08.Stats;

namespace Example08.Skills.Decorators
{
    public class BodybuildingSkill : ModifiedStats
    {
        public BodybuildingSkill(IStats stats, SkillsConfiguration configuration) : base(stats, configuration.Bodybuilding)
        {
        }
    }
}
