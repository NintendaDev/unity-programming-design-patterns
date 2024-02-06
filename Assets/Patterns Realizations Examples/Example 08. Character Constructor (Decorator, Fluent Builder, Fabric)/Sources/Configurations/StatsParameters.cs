using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example08.Configurations
{
    [Serializable]
    public class StatsParameters
    {
        [ValidateInput(nameof(ValidateMaxForce))]
        [SerializeField, MinValue(0)] private int _maxForce = 0;

        [ValidateInput(nameof(ValidateForce))]
        [field: SerializeField, MinValue(0)] private int _force = 0;

        [ValidateInput(nameof(ValidateMaxIntelligence))]
        [field: SerializeField, MinValue(0)] private int _maxIntelligence = 0;

        [ValidateInput(nameof(ValidateIntelligence))]
        [field: SerializeField, MinValue(0)] private int _intelligence = 0;

        [ValidateInput(nameof(ValidateMaxDexterity))]
        [field: SerializeField, MinValue(0)] private int _maxDexterity = 0;

        [ValidateInput(nameof(ValidateDexterity))]
        [field: SerializeField, MinValue(0)] private int _dexterity = 0;

        public StatsParameters()
        {
        }

        public StatsParameters(int force, int maxForce, int intelligence, int maxIntelligence,
            int dexterity, int maxDexterity)
        {
            _force = force;
            _maxForce = maxForce;
            _intelligence = intelligence;
            _maxIntelligence = maxIntelligence;
            _dexterity = dexterity;
            _maxDexterity = maxDexterity;
        }

        public int MaxForce =>_maxForce;

        public int Force => _force;

        public int MaxIntelligence => _maxIntelligence;

        public int Intelligence => _intelligence;

        public int MaxDexterity => _maxDexterity;

        public int Dexterity => _dexterity;

        private bool ValidateMaxForce(int maxValue, ref string errorMessage)
        {
            return IsCorrectMaxValue(Force, maxValue, ref errorMessage);
        }

        private bool IsCorrectMaxValue(int value, int maxValue, ref string errorMessage)
        {
            errorMessage = "The maximum value cannot be less than the value";

            return maxValue >= value;
        }

        private bool ValidateForce(int value, ref string errorMessage)
        {
            return IsLessOrEqualMaxValue(value, MaxForce, ref errorMessage);
        }

        private bool IsLessOrEqualMaxValue(int value, int maxValue, ref string errorMessage)
        {
            errorMessage = "Value is greater than MaxValue";

            return value <= maxValue;
        }

        private bool ValidateMaxIntelligence(int maxValue, ref string errorMessage)
        {
            return IsCorrectMaxValue(Intelligence, maxValue, ref errorMessage);
        }

        private bool ValidateIntelligence(int value, ref string errorMessage)
        {
            return IsLessOrEqualMaxValue(value, MaxIntelligence, ref errorMessage);
        }

        private bool ValidateMaxDexterity(int maxValue, ref string errorMessage)
        {
            return IsCorrectMaxValue(Dexterity, maxValue, ref errorMessage);
        }

        private bool ValidateDexterity(int value, ref string errorMessage)
        {
            return IsLessOrEqualMaxValue(value, MaxDexterity, ref errorMessage);
        }
    }
}
