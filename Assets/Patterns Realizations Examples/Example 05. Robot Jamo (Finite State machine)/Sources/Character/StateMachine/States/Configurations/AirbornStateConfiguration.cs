using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Example05.Characters.StateMachine.States.Configurations
{
    [Serializable]
    public class AirbornStateConfiguration
    {
        [SerializeField, Required] private JumpingStateConfiguration _jumpingStateConfiguration;
        [SerializeField, Range(0, 15f)] private float _speed;

        private float _gravityMultiplier = 2f;

        public float Speed => _speed;

        public JumpingStateConfiguration JumpingStateConfiguration => _jumpingStateConfiguration;

        public float BaseGravity
        {
            get
            {
                return _gravityMultiplier * _jumpingStateConfiguration.MaxHeight /
                (_jumpingStateConfiguration.TimeToReachMaxHeight * _jumpingStateConfiguration.TimeToReachMaxHeight);
            }
        }
    }
}
