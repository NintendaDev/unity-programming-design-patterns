using Example08.Configurations;
using Example08.Stats;

namespace Example08.Skills.Decorators
{
    public class ChessSkill : ModifiedStats
    {
        public ChessSkill(IStats stats, SkillsConfiguration configuration) : base(stats, configuration.Chess)
        {
        }
    }
}
