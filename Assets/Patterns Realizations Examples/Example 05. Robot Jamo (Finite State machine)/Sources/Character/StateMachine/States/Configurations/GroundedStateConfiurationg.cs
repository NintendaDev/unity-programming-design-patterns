using System;
using UnityEngine;

namespace Example05.Characters.StateMachine.States.Configurations
{
    [Serializable]
    public class GroundedStateConfiurationg
    {
        [SerializeField, Range(0, 10)] private float _moveSpeed;
        [SerializeField, Range(0, 10)] private float _runingSpeed;
        [SerializeField, Range(0, 10)] private float _walkingSpeed;

        public float MoveSpeed => _moveSpeed;

        public float RuningSpeed => _runingSpeed;

        public float WalkingSpeed => _walkingSpeed;
    }
}