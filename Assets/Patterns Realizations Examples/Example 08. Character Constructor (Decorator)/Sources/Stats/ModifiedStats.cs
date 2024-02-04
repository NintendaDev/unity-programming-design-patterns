using Example08.Configurations;
using UnityEngine;

namespace Example08.Stats
{
    public abstract class ModifiedStats : IStats
    {
        private IStats _stats;
        private StatsModificatorsParameters _modificators;

        public ModifiedStats(IStats stats, StatsModificatorsParameters modificators)
        {
            _stats = stats;
            _modificators = modificators;
        }

        public int MaxForce => ModifyByAdder(ModifyByMultiplier(_stats.MaxForce, _modificators.MaxForceMultiplier), _modificators.MaxForceAdder);

        public int Force => ModifyByAdder(ModifyByMultiplier(_stats.Force, _modificators.ForceMultiplier, MaxForce), _modificators.ForceAdder, MaxForce);

        public int MaxIntelligence => ModifyByAdder(ModifyByMultiplier(_stats.MaxIntelligence, _modificators.MaxIntelligenceMultiplier), _modificators.MaxIntelligenceAdder);

        public int Intelligence => ModifyByAdder(ModifyByMultiplier(_stats.Intelligence, _modificators.IntelligenceMultiplier, MaxIntelligence), _modificators.IntelligenceAdder, MaxIntelligence);

        public int MaxDexterity => ModifyByAdder(ModifyByMultiplier(_stats.MaxDexterity, _modificators.MaxDexterityMultiplier), _modificators.MaxDexterityAdder);

        public int Dexterity => ModifyByAdder(ModifyByMultiplier(_stats.Dexterity, _modificators.DexterityMultiplier, MaxDexterity), _modificators.DexterityeAdder, MaxDexterity);

        public void DecreaseDexterity(int value) => _stats.DecreaseDexterity(value);

        public void DecreaseForce(int value) => _stats.DecreaseForce(value);

        public void DecreaseIntelligence(int value) => _stats.DecreaseIntelligence(value);

        public void IncreaseDexterity(int value) => _stats.IncreaseDexterity(value);

        public void IncreaseForce(int value) => _stats.IncreaseForce(value);

        public void IncreaseIntelligence(int value) => _stats.IncreaseIntelligence(value);

        private int ModifyByAdder(int value, int adder, int maxValue)
        {
            return Mathf.Min(ModifyByAdder(value, adder), maxValue);
        }

        private int ModifyByAdder(int value, int adder)
        {
            return value + adder;
        }

        private int ModifyByMultiplier(int value, float multiplier, int maxValue)
        {
            return Mathf.Min(ModifyByMultiplier(value, multiplier), maxValue);
        }

        private int ModifyByMultiplier(int value, float multiplier)
        {
            return (int)(value * multiplier);
        }
    }
}
