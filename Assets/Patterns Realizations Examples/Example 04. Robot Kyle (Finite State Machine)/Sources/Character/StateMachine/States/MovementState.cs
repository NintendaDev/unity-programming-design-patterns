namespace Example04.Characters.StateMachine.States
{
    public abstract class MovementState : BaseState
    {
        public MovementState(IStateSwitcher stateSwitcher, Robot robot) : base(stateSwitcher, robot)
        {
        }

        public override void Enter()
        {
            base.Enter();

            View.StartMoving();
        }

        public override void Exit() 
        {
            base.Exit();

            View.StopMoving();
        }
    }
}
