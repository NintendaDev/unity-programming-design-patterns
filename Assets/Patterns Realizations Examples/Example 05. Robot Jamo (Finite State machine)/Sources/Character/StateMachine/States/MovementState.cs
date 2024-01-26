using UnityEngine;

namespace Example05.Characters.StateMachine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly StateMachineData Data;

        private readonly Character _character;

        public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
        {
            StateSwitcher = stateSwitcher;
            _character = character;
            Data = data;
        }

        protected PlayerInput Input => _character.Input;

        protected CharacterController CharacterController => _character.Controller;

        protected CharacterView View => _character.View;

        private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);

        private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

        public virtual void Enter()
        {
            View.StartMovement();
            AddInputActionCallbacks();
        }

        public virtual void Exit()
        {
            View.StopMovement();
            RemoveInputActionCallbacks();
        }

        public virtual void HandleInput()
        {
            Data.XInput = ReadHorizontalInput();
            Data.XVelocity = Data.XInput * Data.Speed;
        }

        public virtual void Update()
        {
            Vector3 velocity = GetConvertedVelocity();

            CharacterController.Move(velocity * Time.deltaTime);
            _character.transform.rotation = GetRotationFrom(velocity);
        }

        protected virtual void AddInputActionCallbacks() { }
        protected virtual void RemoveInputActionCallbacks() { }

        protected bool IsHorizontalInputZero()
        {
            return Data.XInput == 0;
        }

        private Quaternion GetRotationFrom(Vector3 velocity)
        {
            if (velocity.x > 0)
                return TurnRight;

            if (velocity.x < 0)
                return TurnLeft;

            return _character.transform.rotation;
        }

        private Vector3 GetConvertedVelocity()
        {
            return new Vector3(Data.XVelocity, Data.YVelocity, 0);
        }

        private float ReadHorizontalInput()
        {
            return Input.Movement.Move.ReadValue<float>();
        }
    }
}
