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
        [SerializeField, Required] private RacialConfiguration _racialMaxStatsConfiguration;
        [SerializeField, Required] private SpecializationsConfiguration _specializationsConfiguration;
        [SerializeField, Required] private SkillsConfiguration _skillsConfiguration;

        public void Initialize()
        {
            BaseStats humanCharacter = new CharacterBuilder().CreateRace(_racialMaxStatsConfiguration, RaceType.Human)
                .SetSpecialization(_specializationsConfiguration, SpecializationType.Thief)
                .SetSkill(_skillsConfiguration, SkillType.MorningExercises)
                .Build();

            BaseStats elfCharacter = new CharacterBuilder().CreateRace(_racialMaxStatsConfiguration, RaceType.Elf)
                .SetSpecialization(_specializationsConfiguration, SpecializationType.Magician)
                .SetSkill(_skillsConfiguration, SkillType.Chess)
                .Build();

            BaseStats orkCharacter = new CharacterBuilder().CreateRace(_racialMaxStatsConfiguration, RaceType.Ork)
                .SetSpecialization(_specializationsConfiguration, SpecializationType.Barbarian)
                .SetSkill(_skillsConfiguration, SkillType.Bodybuilding)
                .Build();
        }
    }
}