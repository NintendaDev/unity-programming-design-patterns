using Example08.Configurations;
using Example08.Stats;

namespace Example08.Skills.Decorators
{
    public class MorningExercisesSkill : ModifiedStats
    {
        public MorningExercisesSkill(IStats stats, SkillsConfiguration configuration) : base(stats, configuration.MorningExercises)
        {
        }
    }
}
