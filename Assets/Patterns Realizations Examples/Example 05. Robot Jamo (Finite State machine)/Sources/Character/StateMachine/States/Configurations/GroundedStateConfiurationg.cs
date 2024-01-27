using System;
using UnityEngine;

namespace Example05.Characters.StateMachine.States.Configurations
{
    [Serializable]
    public class GroundedStateConfiurationg
    {
        [SerializeField, Range(0, 10)] private float _walkingSpeed;
        [SerializeField, Range(0, 10)] private float _runingSpeed;
        [SerializeField, Range(0, 10)] private float _fastRuningSpeed;

        public float RunningSpeed => _runingSpeed;

        public float FastRuningSpeed => _fastRuningSpeed;

        public float WalkingSpeed => _walkingSpeed;
    }
}