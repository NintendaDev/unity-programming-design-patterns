using Example08.Configurations;
using Example08.Stats;

namespace Example08.Skills
{
    public class SkillProvider : IStatsProvider
    {
        private IStatsProvider _statsProvider;
        private SkillType _skillType;
        private SkillsConfiguration _skillsConfiguration;

        public SkillProvider(IStatsProvider statsProvider, SkillType skillType, SkillsConfiguration skillsConfiguration)
        {
            _statsProvider = statsProvider;
            _skillType = skillType;
            _skillsConfiguration = skillsConfiguration;
        }

        public BaseStats Make()
        {
            BaseStats skill;

            switch(_skillType)
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

            return _statsProvider.Make() + skill;
        }
    }
}
