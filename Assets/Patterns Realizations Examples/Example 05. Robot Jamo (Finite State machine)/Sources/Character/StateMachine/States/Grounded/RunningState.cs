using Example05.Characters.StateMachine.States.Configurations;

namespace Example05.Characters.StateMachine.States.Grounded
{
    public class RunningState : GroundMovementState
    {
        private readonly GroundedStateConfiurationg _configuration;

        public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _configuration = character.Configuration.GroundedStateConfiguration;
        }

        public override void Update()
        {
            base.Update();

            if (Input.Movement.FastRun.IsPressed())
                StateSwitcher.SwitchState<FastRunningState>();

            else if (Input.Movement.Walk.IsPressed())
                StateSwitcher.SwitchState<WalkingState>();
        }

        protected override float GetSpeed()
        {
            return _configuration.RunningSpeed;
        }
    }
}
