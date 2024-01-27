using System;

namespace Example05.Characters.StateMachine
{
    public class StateMachineData
    {
        public float XVelocity;
        public float YVelocity;

        private float _speed;
        private float _xInput;

        public float XInput
        {
            get => _xInput;
            set
            {
                if (value < -1 || value > 1)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _xInput = value;
            }
        }

        public float Speed
        {
            get => _speed;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _speed = value;
            }
        }
    }
}
