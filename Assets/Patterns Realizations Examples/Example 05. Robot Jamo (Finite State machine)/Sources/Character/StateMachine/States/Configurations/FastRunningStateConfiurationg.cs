using System;
using UnityEngine;

namespace Example05.Characters.StateMachine.States.Configurations
{
    [Serializable]
    public class FastRunningStateConfiurationg
    {
        [SerializeField, Range(0, 10)] private float _speed;

        public float Speed => _speed;
    }
}