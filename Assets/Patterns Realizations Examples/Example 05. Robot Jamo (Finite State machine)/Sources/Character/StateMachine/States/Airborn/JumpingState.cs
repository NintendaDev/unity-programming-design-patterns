using Example05.Characters.StateMachine.States.Configurations;

namespace Example05.Characters.StateMachine.States.Airborn
{
    public class JumpingState : AirbornState
    {
        private readonly JumpingStateConfiguration _config;

        public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        {
            _config = character.Configuration.AirbornStateConfiguration.JumpingStateConfiguration;
        }

        public override void Enter()
        {
            base.Enter();

            View.StartJumping();

            Data.YVelocity = _config.StartYVelocity;
        }

        public override void Exit()
        {
            base.Exit();

            View.StopJumping();
        }

        public override void Update()
        {
            base.Update();

            if (Data.YVelocity <= 0)
                StateSwitcher.SwitchState<FallingState>();
        }
    }
}
