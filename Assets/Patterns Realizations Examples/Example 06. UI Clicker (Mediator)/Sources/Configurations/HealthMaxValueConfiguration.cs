using System.Collections.Generic;
using UnityEngine;

namespace Example06.Configurations
{
    [CreateAssetMenu(fileName = "new HealthMaxValueConfiguration", menuName = "Example06 / HealthMaxValueConfiguration")]
    public class HealthMaxValueConfiguration : ValueByLevelConfiguration, IValueByLevel
    {
        [SerializeField] private int[] _healthMaxValueOnLevel;

        protected override IEnumerable<int> GetLevelDataArray()
        {
            return _healthMaxValueOnLevel;
        }
    }
}