using Example05.Characters.StateMachine.States.Configurations;
using UnityEngine.InputSystem;

namespace Example05.Characters.StateMachine.States.Grounded
{
    public class WalkingState : GroundMovementState
    {
        private readonly GroundedStateConfiurationg _configuration;

        public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _configuration = character.Configuration.GroundedStateConfiguration;
        }

        protected override float GetSpeed()
        {
            return _configuration.WalkingSpeed;
        }

        protected override void AddInputActionCallbacks()
        {
            base.AddInputActionCallbacks();

            Input.Movement.Walk.canceled += OnWalkCanceled;
        }

        protected override void RemoveInputActionCallbacks()
        {
            base.RemoveInputActionCallbacks();

            Input.Movement.Walk.canceled -= OnWalkCanceled;
        }

        private void OnWalkCanceled(InputAction.CallbackContext context)
        {
            StateSwitcher.SwitchState<RunningState>();
        }
    }
}