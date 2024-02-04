using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example08.Configurations
{
    [Serializable]
    public class StatsModificatorsParameters
    {
        [field: SerializeField, MinValue(1)] public float MaxForceMultiplier { get; private set; } = 1;

        [field: SerializeField, MinValue(0)] public int MaxForceAdder { get; private set; }

        [field: SerializeField, MinValue(1)] public float ForceMultiplier { get; private set; } = 1;

        [field: SerializeField, MinValue(0)] public int ForceAdder { get; private set; }

        [field: SerializeField, MinValue(1)] public float MaxIntelligenceMultiplier { get; private set; } = 1;

        [field: SerializeField, MinValue(0)] public int MaxIntelligenceAdder { get; private set; }

        [field: SerializeField, MinValue(1)] public float IntelligenceMultiplier { get; private set; } = 1;

        [field: SerializeField, MinValue(0)] public int IntelligenceAdder { get; private set; }

        [field: SerializeField, MinValue(1)] public float MaxDexterityMultiplier { get; private set; } = 1;

        [field: SerializeField, MinValue(0)] public int MaxDexterityAdder { get; private set; }

        [field: SerializeField, MinValue(1)] public float DexterityMultiplier { get; private set; } = 1;

        [field: SerializeField, MinValue(0)] public int DexterityeAdder { get; private set; }
    }
}
