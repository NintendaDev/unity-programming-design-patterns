using Example08.Configurations;
using Example08.Skills;
using Example08.Specializations;
using Example08.Stats;
using UnityEngine;

namespace Example08.Constructors
{
    public class CharacterCreator
    {
        private RacialMaxStatsConfiguration _racialMaxStatsConfiguration;
        private SpecializationsConfiguration _specializationsConfiguration;
        private SkillsConfiguration _skillsConfiguration;

        public CharacterCreator(RacialMaxStatsConfiguration racialMaxStatsConfiguration, 
            SpecializationsConfiguration specializationsConfiguration, SkillsConfiguration skillsConfiguration)
        {
            _racialMaxStatsConfiguration = racialMaxStatsConfiguration;
            _specializationsConfiguration = specializationsConfiguration;
            _skillsConfiguration = skillsConfiguration;
        }

        public IStats Create(RaceType race, SpecializationType specialization, SkillType skill)
        {
            RaceStatProvider raceStatsProvider = new RaceStatProvider(_racialMaxStatsConfiguration);
            IStats character = raceStatsProvider.Make(race);

            SpecializationProvider specializationProvider = new SpecializationProvider(_specializationsConfiguration);
            character = specializationProvider.Make(character, specialization);

            SkillProvider skillProvider = new SkillProvider(_skillsConfiguration);
            character = skillProvider.Make(character, skill);

            PrintCharacter(character);

            return character;
        }

        private void PrintCharacter(IStats character)
        {
            Debug.Log($"Created character: MaxForce={character.MaxForce}, MaxDexterity={character.MaxDexterity}, MaxDexterity={character.MaxIntelligence}");
        }
    }
}
