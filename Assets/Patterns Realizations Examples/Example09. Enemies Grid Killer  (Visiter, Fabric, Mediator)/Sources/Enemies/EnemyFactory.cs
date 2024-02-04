using Example09.Enemies.Types;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example09.Enemies
{
    [CreateAssetMenu(fileName = "new EnemyFactory", menuName = "Example09 / EnemyFactory")]
    public class EnemyFactory: ScriptableObject
    {
        [SerializeField, Required] private Human _humanPrefab;
        [SerializeField, Required] private Ork _orkPrefab;
        [SerializeField, Required] private Elf _elfPrefab;
        [SerializeField, Required] private Robot _robotPrefab;

        public Enemy Get(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Elf:
                    return Instantiate(_elfPrefab);

                case EnemyType.Human:
                    return Instantiate(_humanPrefab);

                case EnemyType.Ork:
                    return Instantiate(_orkPrefab);

                case EnemyType.Robot:
                    return Instantiate(_elfPrefab);

                default:
                    throw new ArgumentException(nameof(type));
            }
        }
    }
}
