using Specifications;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Example06
{
    public abstract class ValueByLevelConfiguration : ScriptableObject, IValueByLevel
    {
        public int GetMaxValueBy(int level)
        {
            IntValidator.GreatOrEqualZero(level);

            IEnumerable<int> levelDataArray = GetLevelDataArray();
            int levelDataArraySize = levelDataArray.Count();

            int value;

            if (levelDataArraySize == 0)
                value = 0;
            else if (level >= levelDataArraySize)
                value = levelDataArray.Last();
            else
                value = levelDataArray.ElementAtOrDefault(level);

            return value;
        }

        protected abstract IEnumerable<int> GetLevelDataArray();
    }
}
