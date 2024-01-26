using Example05.Core;
using UnityEngine.InputSystem;
using Example05.Characters.StateMachine.States.Airborn;

namespace Example05.Characters.StateMachine.States.Grounded
{
    public abstract class GroundedState : MovementState
    {
        private readonly GroundChecker _groundChecker;

        public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _groundChecker = character.GroundChecker;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartGrounded();
        }

        public override void Exit()
        {
            base.Exit();

            View.StopGrounded();
        }

        public override void Update()
        {
            base.Update();

            if (_groundChecker.IsTouches == false)
                StateSwitcher.SwitchState<FallingState>();
        }

        protected override void AddInputActionCallbacks()
        {
            base.AddInputActionCallbacks();

            Input.Movement.Jump.started += OnJumpKeyPressed;
        }

        protected override void RemoveInputActionCallbacks()
        {
            base.RemoveInputActionCallbacks();

            Input.Movement.Jump.started -= OnJumpKeyPressed;
        }

        private void OnJumpKeyPressed(InputAction.CallbackContext context)
        {
            StateSwitcher.SwitchState<JumpingState>();
        }
    }
}
