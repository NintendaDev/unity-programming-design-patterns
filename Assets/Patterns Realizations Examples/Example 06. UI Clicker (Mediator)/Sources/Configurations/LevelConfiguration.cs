using Specifications;
using UnityEngine;

namespace Example06.Configurations
{
    [CreateAssetMenu(fileName = "new LevelConfiguration", menuName = "Example06 / LevelConfiguration")]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private int[] _levelByExperience;

        public int GetLevelBy(int currentExperience)
        {
            IntValidator.GreatOrEqualZero(currentExperience);

            if (_levelByExperience.Length == 0)
                return 0;

            for (int levelNumber = 0; levelNumber < _levelByExperience.Length; levelNumber++)
            {
                if (_levelByExperience[levelNumber] > currentExperience)
                    return levelNumber;
            }

            int maxLevel = _levelByExperience.Length - 1;

            return maxLevel;
        }
    }
}
