using Example08.Configurations;
using Example08.Skills.Decorators;
using Example08.Stats;

namespace Example08.Skills
{
    public class SkillProvider
    {
        private SkillsConfiguration _skillsConfiguration;

        public SkillProvider(SkillsConfiguration skillsConfiguration)
        {
            _skillsConfiguration = skillsConfiguration;
        }

        public IStats Make(IStats stats, SkillType skillType)
        {
            IStats skill;

            switch(skillType)
            {
                case SkillType.Bodybuilding:
                    skill = new BodybuildingSkill(stats, _skillsConfiguration);
                    break;

                case SkillType.Chess:
                    skill = new ChessSkill(stats, _skillsConfiguration);
                    break;

                case SkillType.MorningExercises:
                    skill = new MorningExercisesSkill(stats, _skillsConfiguration);
                    break;

                default:
                    throw new System.Exception("Detected unknown skill type");
            }

            return skill;
        }
    }
}
