using Example08.Configurations;
using Example08.Constructors;
using Example08.Skills;
using Example08.Specializations;
using Example08.Stats;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example08.Bootstraps
{
    public class CharactersBootstrap : MonoBehaviour
    {
        [SerializeField, Required] private RacialMaxStatsConfiguration _racialMaxStatsConfiguration;
        [SerializeField, Required] private SpecializationsConfiguration _specializationsConfiguration;
        [SerializeField, Required] private SkillsConfiguration _skillsConfiguration;

        public void Initialize()
        {
            CharacterCreator characterCreator = new CharacterCreator(_racialMaxStatsConfiguration, _specializationsConfiguration, _skillsConfiguration);
            characterCreator.Create(RaceType.Human, SpecializationType.Thief, SkillType.MorningExercises);
            characterCreator.Create(RaceType.Elf, SpecializationType.Magician, SkillType.Chess);
            characterCreator.Create(RaceType.Ork, SpecializationType.Barbarian, SkillType.Bodybuilding);
        }
    }
}
