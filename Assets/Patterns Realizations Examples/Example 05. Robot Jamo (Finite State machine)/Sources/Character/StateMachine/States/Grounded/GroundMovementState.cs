namespace Example05.Characters.StateMachine.States.Grounded
{
    public abstract class GroundMovementState : GroundedState
    {
        public GroundMovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
        }

        public sealed override void Enter()
        {
            base.Enter();

            View.StartRunning();

            Data.Speed = GetSpeed();
        }

        public sealed override void Exit()
        {
            base.Exit();

            View.StopRunning();
        }

        public override void Update()
        {
            base.Update();

            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
        }

        protected abstract float GetSpeed();
    }
}
