using Example06.Attributes;
using Example06.Configurations;
using Example06.Core;
using MonoUtils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Example06
{
    public class Player : InitializedMonoBehaviour, IReset
    {
        [SerializeField, Required, AssetsOnly] private LevelConfiguration _levelConfiguration;
        [SerializeField, Required, AssetsOnly] private HealthMaxValueConfiguration _healthConfiguration;

        private Level _level;
        private Health _health;
        private Experience _experience;

        public Experience Experience => _experience;

        public Level Level => _level;

        public Health Health => _health;

        public void Initialize()
        {
            _experience = new Experience();
            _level = new Level(_experience, _levelConfiguration);
            _health = new Health(_level, _healthConfiguration);

            CompleteInitialization();
        }

        public void Reset()
        {
            _experience.Reset();
        }
    }
}