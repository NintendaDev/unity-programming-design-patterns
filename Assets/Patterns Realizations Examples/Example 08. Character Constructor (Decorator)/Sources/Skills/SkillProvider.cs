using Example08.Configurations;
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

        public BaseStats Make(SkillType skillType)
        {
            BaseStats skill;

            switch(skillType)
            {
                case SkillType.Bodybuilding:
                    skill = new BaseStats(_skillsConfiguration.BodybuildingParameters);
                    break;

                case SkillType.Chess:
                    skill = new BaseStats(_skillsConfiguration.ChessParameters);
                    break;

                case SkillType.MorningExercises:
                    skill = new BaseStats(_skillsConfiguration.MorningExercisesParameters);
                    break;

                default:
                    throw new System.Exception("Detected unknown skill type");
            }

            return skill;
        }
    }
}
