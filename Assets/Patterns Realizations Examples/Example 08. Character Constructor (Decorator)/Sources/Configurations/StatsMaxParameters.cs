using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example08.Configurations
{
    [Serializable]
    public class StatsMaxParameters
    {
        [field: SerializeField, MinValue(0)] public int MaxForce { get; private set; }

        [field: SerializeField, MinValue(0)] public int MaxIntelligence { get; private set; }

        [field: SerializeField, MinValue(0)] public int MaxDexterity { get; private set; }
    }
}
