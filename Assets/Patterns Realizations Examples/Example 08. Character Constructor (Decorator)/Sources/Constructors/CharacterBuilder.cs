using Example08.Configurations;
using Example08.Skills;
using Example08.Specializations;
using Example08.Stats;
using UnityEngine;

namespace Example08.Constructors
{
    public class CharacterBuilder
    {
        private IStatsProvider _characterStatProvider;
        private BaseStats _character;

        public CharacterBuilder(RaceType raceType, RacialConfiguration racialMaxStatsConfiguration)
        {
            _characterStatProvider = new RaceStatsProvider(raceType, racialMaxStatsConfiguration);
        }

        public CharacterBuilder SetSpecialization(SpecializationsConfiguration specializationsConfiguration, 
            SpecializationType specialization)
        {
            _characterStatProvider = new SpecializationProvider(_characterStatProvider, specialization, specializationsConfiguration);

            return this;
        }

        public CharacterBuilder SetSkill(SkillsConfiguration skillsConfigurationn, SkillType skill)
        {
            _characterStatProvider = new SkillProvider(_characterStatProvider, skill, skillsConfigurationn);

            return this;
        }

        public BaseStats Build()
        {
            _character = _characterStatProvider.Make();
            PrintCharacter();

            return _character;
        }

        private void PrintCharacter()
        {
            Debug.Log($"Created character: MaxForce={_character.MaxForce}, MaxDexterity={_character.MaxDexterity}, MaxDexterity={_character.MaxIntelligence}");
        }
    }
}
