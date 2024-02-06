using Example08.Configurations;
using Example08.Skills;
using Example08.Specializations;
using Example08.Stats;
using UnityEngine;

namespace Example08.Constructors
{
    public class CharacterBuilder
    {
        private BaseStats _character = new BaseStats();

        public CharacterBuilder CreateRace(RacialConfiguration racialMaxStatsConfiguration, RaceType race)
        {
            RaceStatsProvider raceStatsProvider = new RaceStatsProvider(racialMaxStatsConfiguration);
            _character += raceStatsProvider.Make(race);

            return this;
        }

        public CharacterBuilder SetSpecialization(SpecializationsConfiguration specializationsConfiguration, 
            SpecializationType specialization)
        {
            SpecializationProvider specializationProvider = new SpecializationProvider(specializationsConfiguration);
            _character += specializationProvider.Make(specialization);

            return this;
        }

        public CharacterBuilder SetSkill(SkillsConfiguration skillsConfigurationn, SkillType skill)
        {
            SkillProvider skillProvider = new SkillProvider(skillsConfigurationn); ;
            _character += skillProvider.Make(skill);

            return this;
        }

        public BaseStats Build()
        {
            PrintCharacter();

            return _character;
        }

        private void PrintCharacter()
        {
            Debug.Log($"Created character: MaxForce={_character.MaxForce}, MaxDexterity={_character.MaxDexterity}, MaxDexterity={_character.MaxIntelligence}");
        }
    }
}
