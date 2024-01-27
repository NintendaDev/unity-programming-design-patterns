using System;
using UnityEngine;

namespace Example05.Characters.StateMachine.States.Configurations
{
    [Serializable]
    public class JumpingStateConfiguration
    {
        [SerializeField, Range(0, 10)] private float _maxHeight;
        [SerializeField, Range(0, 10)] private float _timeToReachMaxHeight;

        private float _gravityMultiplier = 2f;

        public float StartYVelocity => _gravityMultiplier * _maxHeight / _timeToReachMaxHeight;

        public float MaxHeight => _maxHeight;

        public float TimeToReachMaxHeight => _timeToReachMaxHeight;
    }
}