using Example05.Characters.StateMachine.States.Configurations;
using UnityEngine.InputSystem;

namespace Example05.Characters.StateMachine.States.Grounded
{
    public class FastRunningState : GroundMovementState
    {
        private readonly GroundedStateConfiurationg _configuration;

        public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _configuration = character.Configuration.GroundedStateConfiguration;
        }

        protected override float GetSpeed()
        {
            return _configuration.FastRuningSpeed;
        }

        protected override void AddInputActionCallbacks()
        {
            base.AddInputActionCallbacks();

            Input.Movement.FastRun.canceled += OnFastRunCanceled;
        }

        protected override void RemoveInputActionCallbacks()
        {
            base.RemoveInputActionCallbacks();

            Input.Movement.FastRun.canceled -= OnFastRunCanceled;
        }

        private void OnFastRunCanceled(InputAction.CallbackContext context)
        {
            StateSwitcher.SwitchState<RunningState>();
        }
    }
}
