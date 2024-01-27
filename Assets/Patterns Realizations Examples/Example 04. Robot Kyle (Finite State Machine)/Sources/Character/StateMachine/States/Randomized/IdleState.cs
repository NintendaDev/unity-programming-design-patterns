namespace Example04.Characters.StateMachine.States.Randomized
{
    public class IdleState : RandomizeState
    {
        public IdleState(IStateSwitcher stateSwitcher, Robot robot) : base(stateSwitcher, robot)
        { 
        }

        public override void Enter()
        {
            base.Enter();
            View.StartIdle();
        }

        public override void Exit()
        {
            base.Exit();
            View.StopIdle();
        }

        protected override bool IsPlayingStateAnimation()
        {
            return View.IsPlayingIdleAnimation();
        }
    }
}